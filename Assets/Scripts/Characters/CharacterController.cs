using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController: MonoBehaviour {

    public int CharacterLife;
    public float CharacterMovementSpeed;

    public abstract void Move();
    public abstract void Attack();
    public abstract void Die();
    public abstract void TakeDamage(int damage);

}
