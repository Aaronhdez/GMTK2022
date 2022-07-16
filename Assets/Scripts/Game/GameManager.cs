using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    CharacterController _player;
    SpawnManager _spawnManager;
    TimerController _timerController;
    UIController _uiController;
    SoundManager _soundController;

    [SerializeField] private bool _gameStarted = false;
    [SerializeField] private bool _gamePaused = false;
    [SerializeField] private bool _gameOver = false;

    public bool playerMovementLocked = true;
    private int score;

    public event Action<int> EnemyDiedEvent;

    [SerializeField]
    private TextMeshProUGUI _gameOverInfo;


    void Start() {
        LoadEntities();
        SetUpGame();
    }

    public bool GameHasStarted() {
        return _gameStarted;
    }

    public bool GameIsPaused() {
        return _gamePaused;
    }

    private void LoadEntities() {
        _player = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
        _spawnManager = GetComponent<SpawnManager>();
        _timerController = GetComponent<TimerController>();
        _uiController = GetComponent<UIController>();
        _soundController = GetComponent<SoundManager>();
    }

    private void SetUpGame() {
        score = 0;
        _spawnManager.LoadSpawnManager();
        _soundController.PlayMainMenuMusic();
    }


    void Update() {
        if (!_gameOver && _player.CharacterLife == 0) {
            GameOver();
        }

        if (!_gameStarted && Input.GetKeyDown(KeyCode.Space)) {
            _gameStarted = true;
            playerMovementLocked = false;
            _timerController.StartTimer();
            _soundController.PlayGameMusic();
            _spawnManager.StartSpawnManager();
        }

        if (_gameStarted) { 
            if (Input.GetKeyDown(KeyCode.Escape)) {
                if (_gamePaused)
                    ResumeGame();
                else
                    PauseGame();
            }
        }
    }

    private void ResumeGame() {
        _gamePaused = false;
        playerMovementLocked = false;
        Time.timeScale = 1f;
        _timerController.Resume();
        _uiController.Activate("GameScreen");
    }

    private void PauseGame() {
        _gamePaused = true;
        playerMovementLocked = true;
        Time.timeScale = 0f;
        _timerController.Pause();
        _uiController.Activate("PauseScreen");
    }

    private void GameOver() {
        _gameOver = true;
        playerMovementLocked = true;
        Time.timeScale = 0f;
        _timerController.Pause();
        _soundController.PlayGameOverMusic();
        _gameOverInfo.text = "You have survived " + _timerController.GetCurrentTime() + " and scored " + score + " points.";
        _uiController.Activate("GameOverScreen");
    }

    public void RestartGame()
    {
        _gameOver = false;
        _gamePaused = false;
        _gameStarted = false;
        playerMovementLocked = true;
        _timerController.Restart();
        _player.Revive();
        SceneManager.LoadScene("MainScene");
    }

    public void AddScore(int score) {
        this.score += score;
        EnemyDiedEvent?.Invoke(this.score);
    }
}
