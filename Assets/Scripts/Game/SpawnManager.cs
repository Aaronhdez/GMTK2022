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
    private float lastTimeEnemiesWereSpawned = 0;

    void Start(){
        InstantiateEntities();
        SpawnEnemies();
        ReloadSpawnRate();
    }

    public void Update() {
        CheckSpawnEnemies();
    }

    private void InstantiateEntities() {
        throw new NotImplementedException();
    }

    private void CheckSpawnEnemies() {
        var currentTime = Time.time;
        if (currentTime - lastTimeEnemiesWereSpawned >= _maximumSpawnRate) {
            SpawnEnemies();
            lastTimeEnemiesWereSpawned = currentTime;
            ReloadSpawnRate();
        }
    }

    private void SpawnEnemies() {
        var enemiesToSpawn = UnityEngine.Random.Range(
            1, _amountOfEnemiesSpawnedAtOnce);
        for(int i = 0; i < enemiesToSpawn; i++) {
            //Cargamos las entidades inactivas
            var nonActiveEnemyEntities = _enemiesAvailable.Where(e => !e.activeInHierarchy).ToList();
            //Escogemos una al azar y la recolocamos y activamos
            var index = UnityEngine.Random.Range(0, nonActiveEnemyEntities.Count);
            Activate(nonActiveEnemyEntities[index]);
        }
        
    }

    private void Activate(GameObject gameObject) {
        //Reposicionar en algun SpawnPoint
        //Rotar respecto a centro (opcional)
        //Activar
    }

    private void ReloadSpawnRate() {
        _maximumSpawnRate = UnityEngine.Random.Range(
            _minimumSpawnRate, _maximumSpawnRate);
    }

}
