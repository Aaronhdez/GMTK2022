using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int damage = 1;

    public float attackRate = 1f;
    protected float nextAttactTime = 0f;

    public bool isEnemy = false;

    public abstract void Attack();

    protected bool Cooldown()
    {
        if (Time.time >= nextAttactTime)
        {
            nextAttactTime = Time.time + 1f / attackRate;
            return true;
        }
        return false;
    }

    public bool CanAttack()
    {
        if (Time.time >= nextAttactTime)
        {
            return true;
        }
        return false;
    }
}
