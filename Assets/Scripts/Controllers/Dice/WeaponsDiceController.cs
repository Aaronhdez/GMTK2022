using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsDiceController : DiceController {

    [Header("Entities")]
    [SerializeField] private List<Weapon> _weaponsAvailable;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] public DiceUIController _diceUIController;

    [Header("Parameters")]
    [SerializeField] private int _weaponIndex = 0;

    void Start() {
        IsActive = false;
        DisableAllWeapons();
        RollTheDice();
        _diceUIController.SetUp(_weaponIndex);
        _playerController.SetWeapon(_weaponsAvailable[_weaponIndex]);
    }

    void Update() {
        if (IsActive) { 
            _rollTime -= Time.deltaTime;
            if (_rollTime <= 0.0f) {
                _rollTime = 10.0f;
                RollTheDice();
                //Reproducir Sonido
            }
        }
    }

    public int GetRandomWeaponIndex() {
        var newIndex = UnityEngine.Random.Range(0, 11) % 5;
        while (_weaponIndex == newIndex) {
            newIndex = UnityEngine.Random.Range(0, 11) % 5;
        }
        return newIndex;
    }

    public override void RollTheDice() {
        DisableAllWeapons();
        _weaponIndex = GetRandomWeaponIndex();
        _diceUIController.RollingAnimation(_weaponIndex);
        _playerController.SetWeapon(_weaponsAvailable[_weaponIndex]);
        _weaponsAvailable[_weaponIndex].gameObject.SetActive(true);
    }

    //AUXILIARY METHODS
    private void DisableAllWeapons() {
        foreach (Weapon weapon in _weaponsAvailable) {
            weapon.gameObject.SetActive(false);
        }
    }

    public override void EnableDice() {
        IsActive = true;
    }

    public override void DisableDice() {
        IsActive = false;
    }

    //TO DO
    /*
    public void ReplaceWeapon(int newWeapon, int oldWeapon) {
        if (_weaponsAvailable[oldWeapon] != null) {
            _weaponsAvailable.RemoveAt(oldWeapon);
            _weaponsAvailable.Add(newWeapon);
        }
    }
    */

}
