using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController: MonoBehaviour {

    public int characterLife;
    public float characterMovementSpeed;

    public abstract void Move();
    public abstract float GetAttackDistance();
    public abstract void Attack();
    public abstract void Die();
    public abstract void TakeDamage(int damage);

}
