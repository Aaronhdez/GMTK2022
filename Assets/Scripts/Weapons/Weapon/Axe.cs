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
            {
                switch (MC_Enemies.instance.CurrentEnemy)
                {
                    case 0:
                        if (enemy.CompareTag("orc"))
                        {
                            enemy.GetComponent<CharacterController>().TakeDamage(damage);
                        }
                        break;
                    case 1:
                        if (enemy.CompareTag("skeleton"))
                        {
                            enemy.GetComponent<CharacterController>().TakeDamage(damage);
                        }
                        break;
                    case 2:
                        if (enemy.CompareTag("beast"))
                        {
                            enemy.GetComponent<CharacterController>().TakeDamage(damage);
                        }
                        break;
                    case 3:
                        if (enemy.CompareTag("witch"))
                        {
                            enemy.GetComponent<CharacterController>().TakeDamage(damage);
                        }
                        break;
                    case 4:
                        if (enemy.CompareTag("ogger"))
                        {
                            enemy.GetComponent<CharacterController>().TakeDamage(damage);
                        }
                        break;
                    case 5:
                        if (enemy)
                        {
                            enemy.GetComponent<CharacterController>().TakeDamage(damage);
                        }
                        break;
                    default:
                        break;

                }
            }
            // TODO: Check active tag on dice
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}


