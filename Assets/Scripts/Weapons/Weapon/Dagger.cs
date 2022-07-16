using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : Weapon
{
    [SerializeField] public AudioSource hitWithDagger;
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
            Collider2D[] hitEnemies = (isEnemy) ? Physics2D.OverlapCircleAll(attackPoint.position, attackRange, LayerMask.GetMask("Player")) : Physics2D.OverlapCircleAll(attackPoint.position, attackRange, LayerMask.GetMask("Enemy"));

            foreach (Collider2D enemy in hitEnemies)
            {
                
                if (isEnemy)
                {
                    if (enemy.CompareTag("Player"))
                    {
                        hitWithDagger.Play();
                        enemy.GetComponent<CharacterController>().TakeDamage(damage);
                    }
                }
                else
                {
                    if (enemy.CompareTag(EnemiesDiceController.instance._currentEnemy) || EnemiesDiceController.instance.AttackAll)
                    {
                        enemy.GetComponent<CharacterController>().TakeDamage(damage);
                    }
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
