using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    SpawnManager _spawnManager;
    TimerController _timerController;
    [SerializeField] private bool _gameStarted = false;
    [SerializeField] private bool _gamePaused = false;

    void Start() {
        LoadEntities();
        SetUpGame();
    }

    private void LoadEntities() {
        _spawnManager = GetComponent<SpawnManager>();
        _timerController = GetComponent<TimerController>();
    }

    private void SetUpGame() {
        _spawnManager.LoadSpawnManager();
    }


    void Update() {
        if (!_gameStarted && Input.GetKeyDown(KeyCode.Return)) {
            _gameStarted = true;
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
        Time.timeScale = 1f;
        _timerController.Resume();
    }

    private void PauseGame() {
        _gamePaused = true;
        Time.timeScale = 0f;
        _timerController.Pause();
    }
}
