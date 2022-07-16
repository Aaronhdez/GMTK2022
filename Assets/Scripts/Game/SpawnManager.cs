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
    private bool _spawningEnabled = false;

    public void StartSpawnManager(){
        if (_enemiesAvailable.Count != 0) {
            _spawningEnabled = true;
            InstantiateEntities();
            SpawnEnemies();
        }
        ReloadSpawnRate();
    }

    private void InstantiateEntities() {
        _enemiesLoaded = new List<GameObject>();
        for (int i = 0; i < _enemiesAvailable.Count; i++) {
            for (int j = 0; j < _enemiesAvailable.Count; j++) {
                var newInstance = Instantiate(_enemiesAvailable[i], this.transform);
                _enemiesLoaded.Add(newInstance);
                newInstance.SetActive(false);
            }
        }
    }

    private void SpawnEnemies() {
        var nonActiveEnemyEntities = _enemiesLoaded.Where(e => !e.activeInHierarchy).ToList();
        int enemiesToSpawn = GetAmountToSpawn(nonActiveEnemyEntities);
        if (nonActiveEnemyEntities.Count > 0) {
            for (int i = 0; i < enemiesToSpawn; i++) {
                //REVISAR IN-GAME
                var index = UnityEngine.Random.Range(0, nonActiveEnemyEntities.Count);
                Activate(nonActiveEnemyEntities[index]);
            }
        }

    }

    private int GetAmountToSpawn(List<GameObject> nonActiveEnemyEntities) {
        return (nonActiveEnemyEntities.Count > _amountOfEnemiesSpawnedAtOnce) ?
            _amountOfEnemiesSpawnedAtOnce :
            UnityEngine.Random.Range(1, nonActiveEnemyEntities.Count); 
    }

    private void Activate(GameObject gameObject) {
        //REVISAR IN-GAME
        var availableSpawnPoints = _spawnPoints.Where(s => s.GetComponent<SpawnPointController>().IsActive).ToList();
        var index = UnityEngine.Random.Range(0, _spawnPoints.Count);
        gameObject.transform.position = availableSpawnPoints[index].transform.position;
        //Rotar respecto a centro (opcional)
        gameObject.GetComponent<EnemyController>().ResetToDefaults();
        gameObject.SetActive(true);
    }

    private void ReloadSpawnRate() {
        _maximumSpawnRate = UnityEngine.Random.Range(
            _minimumSpawnRate, _maximumSpawnRate);
    }

    public void Update() {
        if (_spawningEnabled) {
            CheckSpawnEnemies();
        }
    }

    private void CheckSpawnEnemies() {
        var currentTime = Time.time;
        if (currentTime - lastTimeEnemiesWereSpawned >= _maximumSpawnRate) {
            SpawnEnemies();
            lastTimeEnemiesWereSpawned = currentTime;
            ReloadSpawnRate();
        }
    }

}
