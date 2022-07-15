using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{

    public Transform attackPoint;
    public float attackRange = 0.5f;

    public override void Attack()
    {
        if (!Cooldown())
        {
            return;
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);

        foreach (Collider2D enemy in hitEnemies)
        {
            // TODO: Check active tag on dice
            if (enemy.CompareTag("orc"))
            {
                // TODO: damage enemy
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
