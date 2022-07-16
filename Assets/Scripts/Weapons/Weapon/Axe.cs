using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon
{
    public Transform attackPoint;
    public float attackRange = 0.5f;

    public override void Attack()
    {
        if (!Cooldown())
        {
            return;
        }

        Collider2D[] hitEnemies = (isEnemy) ? Physics2D.OverlapCircleAll(attackPoint.position, attackRange, LayerMask.GetMask("Player")) : Physics2D.OverlapCircleAll(attackPoint.position, attackRange, LayerMask.GetMask("Enemy"));

        foreach (Collider2D enemy in hitEnemies)
        {
            if (isEnemy)
            {
                if (enemy.CompareTag("Player"))
                {
                    enemy.GetComponent<CharacterController>().TakeDamage(damage);
                }
            }
            else
            // TODO: Check active tag on dice
            if (enemy.CompareTag("orc"))
            {
                enemy.GetComponent<CharacterController>().TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
