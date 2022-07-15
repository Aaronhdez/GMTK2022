using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float damage = 1f;

    public float attackRate = 1f;
    protected float nextAttactTime = 0f;

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
}
