using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DiceController : MonoBehaviour {

    [Header("Parameters")]
    [SerializeField] protected float _rollTime = 10.0f;

    public abstract void RollTheDice();

}
