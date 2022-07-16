using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DiceController : MonoBehaviour {

    [Header("Parameters")]
    [SerializeField] protected float _rollTime = 10.0f;
    [SerializeField] private bool isActive;

    protected bool IsActive { get => isActive; set => isActive = value; }

    public abstract void RollTheDice();
    public abstract void EnableDice();
    public abstract void DisableDice();

}
