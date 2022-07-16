using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDiceController : MonoBehaviour {
    
    [Header("Entities")]
    [SerializeField] private List<string> _enemiesAvailable;

    [Header("Parameters")]
    [SerializeField] public float rollTime = 5f;
    [SerializeField] public string currentEnemy = "orc";
    [SerializeField] public string enemy = "";
    [SerializeField] private bool attackAll = false;

    public static EnemiesDiceController instance;
    public bool AttackAll { get => attackAll; set => attackAll = value; }

    void Awake() {
        if (instance == null)
            instance = this;
    }

    void Start() {
        LoadEnemiesList();
        RollTheDice();
    }

    void Update() {
        rollTime -= Time.deltaTime;
        if (rollTime <= 0.0f) {
            RollTheDice();
            rollTime = 5f;
        }
        if (currentEnemy.Equals("all")) {
            AttackAll = true;
        } else {
            AttackAll = false;
        }
    }
    private void LoadEnemiesList() {
        _enemiesAvailable = new List<string> {
            "orc",
            "skeleton",
            "beast",
            "witch",
            "ogre",
            "all"
        };
    }

    public void RollTheDice() {
        while (enemy.Equals(currentEnemy)) {
            enemy = _enemiesAvailable[UnityEngine.Random.Range(0, 12) % 6];
        }
        currentEnemy = enemy;
    }

}
