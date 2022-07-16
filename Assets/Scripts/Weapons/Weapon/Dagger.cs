using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : Weapon
{
    public Transform[] attackPoints;
    public float attackRange = 0.5f;

    public override void Attack()
    {
        if (!Cooldown())
        {
            return;
        }

        foreach (Transform attackPoint in attackPoints)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);

            foreach (Collider2D enemy in hitEnemies)
            {
                // TODO: Check active tag on dice
                if (enemy.CompareTag("orc"))
                {
                    enemy.GetComponent<CharacterController>().TakeDamage(damage);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoints[0].position, attackRange);
        Gizmos.DrawWireSphere(attackPoints[1].position, attackRange);
    }
}
