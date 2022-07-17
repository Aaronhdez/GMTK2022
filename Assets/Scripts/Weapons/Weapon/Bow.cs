using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon
{

    [SerializeField] public AudioSource fireWithBow;
    public Transform spawnPoint;
    public GameObject arrowGO;
    private bool isplaying = false;

    [SerializeField] private Sprite[] bowAttack;



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
        GameObject projectile = Instantiate(arrowGO, spawnPoint.position, spawnPoint.rotation);

        if (isEnemy)
        {
            int LayerEnemyBullets = LayerMask.NameToLayer("EnemyBullets");
            projectile.layer = LayerEnemyBullets;
            projectile.GetComponent<Projectile>().isEnemy = isEnemy;
            fireWithBow.Play();
        }
    }

    public IEnumerator PlayAnimationAttack()
    {
        isplaying = true;
        var spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        for (int i = 1; i < bowAttack.Length; i++)
        {
            spriteRenderer.sprite = bowAttack[i];
            yield return new WaitForSeconds(0.25f);
        }
        spriteRenderer.sprite = bowAttack[0];
        isplaying = false;
    }
}
