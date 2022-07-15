using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    SpawnManager _spawnManager;
    void Start() {
        LoadEntities();
        SetUpGame();
    }

    private void LoadEntities() {
        _spawnManager = GetComponent<SpawnManager>();
    }

    private void SetUpGame() {
        _spawnManager.StartSpawnManager();
    }


    void Update() {
        
    }
}
