using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : Weapon
{

    [SerializeField] public AudioSource hitWithDagger;
    public Transform[] attackPoints;
    public float attackRange = 0.5f;

    private bool isplaying = false;

    [SerializeField] private Sprite[] daggerAttack;

    public override void Attack()
    {
        if (!Cooldown())
        {
            return;
        }

        if (!isEnemy)
        {
            StartCoroutine(PlayAnimationAttack());
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

    public IEnumerator PlayAnimationAttack()
    {
        isplaying = true;
        var spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        for (int i = 1; i < daggerAttack.Length; i++)
        {
            spriteRenderer.sprite = daggerAttack[i];
            yield return new WaitForSeconds(0.25f);
        }
        spriteRenderer.sprite = daggerAttack[0];
        isplaying = false;
    }
}
