using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    SpawnManager _spawnManager;
    TimerController _timerController;
    UIController _uIController;

    CharacterController _player;

    [SerializeField] private bool _gameStarted = false;
    [SerializeField] private bool _gamePaused = false;

    public bool playerMovementLocked = true;

    private int score;

    public event Action<int> EnemyDiedEvent;

    [SerializeField]
    private TextMeshProUGUI _gameOverInfo;


    void Start() {
        LoadEntities();
        SetUpGame();
    }

    public bool GameHasStarted()
    {
        return _gameStarted;
    }

    public bool GameIsPaused()
    {
        return _gamePaused;
    }

    private void LoadEntities() {
        _player = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
        _spawnManager = GetComponent<SpawnManager>();
        _timerController = GetComponent<TimerController>();
        _uIController = GetComponent<UIController>();
    }

    private void SetUpGame() {
        score = 0;
        _spawnManager.LoadSpawnManager();
    }


    void Update() {
        if (_player.CharacterLife == 0)
        {
            GameOver();
        }

        if (!_gameStarted && Input.GetKeyDown(KeyCode.Return)) {
            _gameStarted = true;
            playerMovementLocked = false;
            _timerController.StartTimer();
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
        _uIController.Activate("GameScreen");
    }

    private void PauseGame() {
        _gamePaused = true;
        playerMovementLocked = true;
        Time.timeScale = 0f;
        _timerController.Pause();
        _uIController.Activate("PauseScreen");
    }

    private void GameOver()
    {
        _gamePaused = true;
        playerMovementLocked = true;
        Time.timeScale = 0f;
        _timerController.Pause();
        _gameOverInfo.text = "You have survived " + _timerController.GetCurrentTime() + " and scored " + score + " points.";
        _uIController.Activate("GameOverScreen");
    }

    public void AddScore(int score)
    {
        this.score += score;
        EnemyDiedEvent?.Invoke(this.score);
    }
}
