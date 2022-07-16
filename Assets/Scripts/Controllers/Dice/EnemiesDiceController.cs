using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDiceController : DiceController {
    
    [Header("Entities")]
    [SerializeField] private List<string> _enemiesAvailable;

    [Header("Parameters")]
    [SerializeField] public string currentEnemy;
    [SerializeField] private bool attackAll = false;

    public static EnemiesDiceController instance;
    public bool AttackAll { get => attackAll; set => attackAll = value; }

    void Awake() {
        if (instance == null)
            instance = this;
    }

    void Start() {
        LoadEnemiesList();
        currentEnemy = _enemiesAvailable[0];
        RollTheDice();
    }

    void Update() {
        _rollTime -= Time.deltaTime;
        if (_rollTime <= 0.0f) {
            RollTheDice();
            //Reproducir Sonido
            _rollTime = 5f;
        }
        AttackAll = currentEnemy.Equals("all");
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
        var newEnemy = _enemiesAvailable[newIndex];
        while (newEnemy.Equals(currentEnemy)) {
            currentEnemy = _enemiesAvailable[UnityEngine.Random.Range(0, 12) % 6];
        }
        currentEnemy = newEnemy;

        //Actualizar el Dado en la UI;
    }

}
