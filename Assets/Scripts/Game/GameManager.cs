using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    SpawnManager _spawnManager;
    public TimerController _timerController;
    [SerializeField] private bool _gameStarted = false;
    [SerializeField] private bool _gamePaused = false;

    public bool playerMovementLocked = true;

    private int score;

    public event Action<int> EnemyDiedEvent;


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
        _spawnManager = GetComponent<SpawnManager>();
        _timerController = GetComponent<TimerController>();
    }

    private void SetUpGame() {
        score = 0;
        _spawnManager.LoadSpawnManager();
    }


    void Update() {
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
    }

    private void PauseGame() {
        _gamePaused = true;
        playerMovementLocked = true;
        Time.timeScale = 0f;
        _timerController.Pause();
    }

    public void AddScore(int score)
    {
        this.score += score;
        EnemyDiedEvent?.Invoke(this.score);
    }
}
