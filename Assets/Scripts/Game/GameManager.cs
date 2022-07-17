using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [Header("Entities")]
    [SerializeField] PlayerController _player;
    [SerializeField] SpawnManager _spawnManager;
    [SerializeField] TimerController _timerController;
    [SerializeField] UIController _uiController;
    [SerializeField] SoundManager _soundController;
    [SerializeField] public DiceController _weaponsDiceController;
    [SerializeField] public DiceController _enemiesDiceController;

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
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        _spawnManager = GetComponent<SpawnManager>();
        _timerController = GetComponent<TimerController>();
        _uiController = GetComponent<UIController>();
        _soundController = GetComponent<SoundManager>();
        _enemiesDiceController.DisableDice();
        _weaponsDiceController.DisableDice();
    }

    private void SetUpGame() {
        score = 0;
        _spawnManager.LoadSpawnManager();
        _soundController.PlayMainMenuMusic();
    }

    public void StartGame() {
        _gameStarted = true;
        playerMovementLocked = false;
        _timerController.StartTimer();
        _soundController.PlayGameMusic();
        _spawnManager.StartSpawnManager();
        _enemiesDiceController.EnableDice();
        _weaponsDiceController.EnableDice();
    }

    void Update() {
        if (!_gameOver && _player.characterLife == 0) {
            GameOver();
        }

        if (!_gameOver) { 
            if (_gameStarted) { 
                if (Input.GetKeyDown(KeyCode.Escape)) {
                    if (_gamePaused)
                        ResumeGame();
                    else
                        PauseGame();
                }
            }
        }
    }

    private void ResumeGame() {
        _gamePaused = false;
        playerMovementLocked = false;
        Time.timeScale = 1f;
        _timerController.Resume();
        _uiController.Activate("GameScreen");
        _enemiesDiceController.EnableDice();
        _weaponsDiceController.EnableDice();
    }

    private void PauseGame() {
        _gamePaused = true;
        playerMovementLocked = true;
        Time.timeScale = 0f;
        _timerController.Pause();
        _enemiesDiceController.DisableDice();
        _weaponsDiceController.DisableDice();
        _uiController.Activate("PauseScreen");
    }

    private void GameOver() {
        _gameOver = true;
        playerMovementLocked = true;
        Time.timeScale = 0f;
        _timerController.Pause();
        _enemiesDiceController.DisableDice();
        _weaponsDiceController.DisableDice();
        _soundController.PlayGameOverMusic();
        _gameOverInfo.text = "You have survived " + _timerController.GetCurrentTime() + "\nScore: " + score + " points";
        _uiController.Activate("GameOverScreen");
    }

    public void RestartGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("FinalScene");
    }

    public void AddScore(int score) {
        this.score += score;
        _player.AddKill();
        EnemyDiedEvent?.Invoke(this.score);
    }
}
