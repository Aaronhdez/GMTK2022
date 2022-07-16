using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsDiceController : MonoBehaviour {

    [Header("Entities")]
    [SerializeField] private List<Weapon> _weaponsAvailable;
    [SerializeField] private PlayerController _playerController;

    [Header("Parameters")]
    [SerializeField] private int _weaponIndex = 0;
    [SerializeField] private float _rollTime = 10.0f;
    
    void Start() {
        DisableAllWeapons();
        RollTheDice();
        _playerController.SetWeapon(_weaponsAvailable[_weaponIndex]);
    }

    void Update() {
        _rollTime -= Time.deltaTime;
        if (_rollTime <= 0.0f) {
            RollTheDice();
            _rollTime = 10.0f;
        }
    }

    public void RollTheDice() {
        DisableAllWeapons();
        _weaponIndex = GetRandomWeaponIndex();
        _weaponsAvailable[_weaponIndex].gameObject.SetActive(true);
    }

    public int GetRandomWeaponIndex() {
        var newIndex = UnityEngine.Random.Range(0, 11) % 5;
        while (_weaponIndex == newIndex) {
            newIndex = UnityEngine.Random.Range(0, 11) % 5;
        }
        return newIndex;
    }

    //AUXILIARY METHODS
    private void DisableAllWeapons() {
        foreach (Weapon weapon in _weaponsAvailable) {
            weapon.gameObject.SetActive(false);
        }
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
