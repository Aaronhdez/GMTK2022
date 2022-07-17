using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{    
    [SerializeField] private AudioSource hitWithSword;

    public Transform attackPoint;
    public float attackRange = 0.5f;

    private bool isplaying = false;
    [SerializeField] private Sprite[] swordAttack;

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

        Collider2D[] hitEnemies = (isEnemy) ? Physics2D.OverlapCircleAll(attackPoint.position, attackRange, LayerMask.GetMask("Player")) : Physics2D.OverlapCircleAll(attackPoint.position, attackRange, LayerMask.GetMask("Enemy"));

        foreach (Collider2D enemy in hitEnemies)
        {
            if (isEnemy)
            {
                if (enemy.CompareTag("Player"))
                {
                    hitWithSword.Play();
                    enemy.GetComponent<CharacterController>().TakeDamage(damage);
                }
            } else
            if (enemy.CompareTag(EnemiesDiceController.instance._currentEnemy) || EnemiesDiceController.instance.AttackAll)
            {
                enemy.GetComponent<CharacterController>().TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    public IEnumerator PlayAnimationAttack()
    {
        isplaying = true;
        var spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        for (int i = 1; i < swordAttack.Length; i++)
        {
            spriteRenderer.sprite = swordAttack[i];
            yield return new WaitForSeconds(0.25f);
        }
        spriteRenderer.sprite = swordAttack[0];
        isplaying = false;
    }
}
