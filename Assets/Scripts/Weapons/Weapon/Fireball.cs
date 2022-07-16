using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Projectile
{
    public override void Attack(GameObject enemy)
    {
        enemy.GetComponent<CharacterController>().TakeDamage(damage);

        Destroy(gameObject);
    }
}
