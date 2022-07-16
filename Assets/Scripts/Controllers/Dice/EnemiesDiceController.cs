using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDiceController : DiceController {
    
    [Header("Entities")]
    [SerializeField] private List<string> _enemiesAvailable;
    [SerializeField] public DiceUIController _diceUIController;

    [Header("Parameters")]
    [SerializeField] public string _currentEnemy;
    [SerializeField] private bool attackAll = false;

    public static EnemiesDiceController instance;
    public bool AttackAll { get => attackAll; set => attackAll = value; }

    void Awake() {
        if (instance == null)
            instance = this;
    }

    void Start() {
        LoadEnemiesList();
        _currentEnemy = _enemiesAvailable[0];
        _diceUIController.SetUp(0);
        RollTheDice();
    }

    void Update() {
        if (IsActive) {
            _rollTime -= Time.deltaTime;
            if (_rollTime <= 0.0f) {
                RollTheDice();
                //Reproducir Sonido
                _rollTime = 5f;
            }
            AttackAll = _currentEnemy.Equals("all");
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

    public override void RollTheDice() {
        int newIndex = UnityEngine.Random.Range(0, 12) % 6;
        while (_enemiesAvailable[newIndex].Equals(_currentEnemy)) {
            newIndex = UnityEngine.Random.Range(0, 12) % 6;
        }
        _diceUIController.RollingAnimation(newIndex);
        _currentEnemy = _enemiesAvailable[newIndex];
    }

    public override void EnableDice() {
        IsActive = true;
    }

    public override void DisableDice() {
        IsActive = false;
    }
}
