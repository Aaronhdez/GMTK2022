using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon
{

    [SerializeField] public AudioSource hitWithAxe;
    public Transform attackPoint;
    public float attackRange = 0.5f;

    [SerializeField] private Animator beastAnimator;


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
                    beastAnimator.SetBool("Attack", true);
                    hitWithAxe.Play();
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


