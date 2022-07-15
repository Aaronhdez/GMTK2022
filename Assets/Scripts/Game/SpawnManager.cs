using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private int _enemiesAliveLimit;
    [SerializeField] private int _amountOfEnemiesSpawnedAtOnce;
    [SerializeField] private int _minimumSpawnRate;
    [SerializeField] private int _maximumSpawnRate;

    [Header("Entities")]
    [SerializeField] private List<GameObject> _enemiesAvailable;
    [SerializeField] private List<GameObject> _spawnPoints;

    private List<GameObject> _enemiesLoaded;
    private float lastTimeEnemiesWereSpawned = 0;
    private bool _spawningEnabled;

    public void StartSpawnRoutine(){
        _spawningEnabled = true;
        InstantiateEntities();
        SpawnEnemies();
        ReloadSpawnRate();
    }

    public void Update() {
        if (_spawningEnabled) { 
            CheckSpawnEnemies();
        }
    }

    private void InstantiateEntities() {
        for (int i = 0; i < _enemiesAvailable.Count; i++) {
            for (int j = 0; j < _enemiesAvailable.Count; j++) {
                var newInstance = Instantiate(_enemiesAvailable[i], this.transform);
                _enemiesLoaded.Add(newInstance);
                newInstance.SetActive(false);
            }
        }
    }

    private void SpawnEnemies() {
        var enemiesToSpawn = UnityEngine.Random.Range(
            1, _amountOfEnemiesSpawnedAtOnce);
        for (int i = 0; i < enemiesToSpawn; i++) {
            //REVISAR IN-GAME
            var nonActiveEnemyEntities = _enemiesLoaded.Where(e => !e.activeInHierarchy).ToList();
            var index = UnityEngine.Random.Range(0, nonActiveEnemyEntities.Count);
            Activate(nonActiveEnemyEntities[index]);
        }

    }

    private void ReloadSpawnRate() {
        _maximumSpawnRate = UnityEngine.Random.Range(
            _minimumSpawnRate, _maximumSpawnRate);
    }

    private void CheckSpawnEnemies() {
        var currentTime = Time.time;
        if (currentTime - lastTimeEnemiesWereSpawned >= _maximumSpawnRate) {
            SpawnEnemies();
            lastTimeEnemiesWereSpawned = currentTime;
            ReloadSpawnRate();
        }
    }

    private void Activate(GameObject gameObject) {
        var index = UnityEngine.Random.Range(0, _spawnPoints.Count);
        gameObject.transform.position = _spawnPoints[index].transform.position;
        //Rotar respecto a centro (opcional)
        gameObject.SetActive(true);
    }

}
