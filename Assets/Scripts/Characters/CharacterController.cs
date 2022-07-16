using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController: MonoBehaviour {

    public int CharacterLife;
    public float CharacterMovementSpeed;
    public bool dead;

    public abstract void Move();
    public abstract float GetAttackDistance();
    public abstract void Attack();
    public abstract void Die();
    public abstract void TakeDamage(int damage);

    public void Revive()
    {
        CharacterLife = 6;
        dead = true;
    }

}
