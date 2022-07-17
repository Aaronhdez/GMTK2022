using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : Weapon
{

    [SerializeField] public AudioSource fireWithStaff;
    public Transform spawnPoint;
    public GameObject fireballGO;

    private bool isplaying = false;

    [SerializeField] private Sprite[] staffAttack;


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

        GameObject projectile = Instantiate(fireballGO, spawnPoint.position, spawnPoint.rotation);

        if (isEnemy)
        {
            int LayerEnemyBullets = LayerMask.NameToLayer("EnemyBullets");
            projectile.layer = LayerEnemyBullets;
            projectile.GetComponent<Projectile>().isEnemy = isEnemy;
            fireWithStaff.Play();
        }
    }

    public IEnumerator PlayAnimationAttack()
    {
        isplaying = true;
        var spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        for (int i = 1; i < staffAttack.Length; i++)
        {
            spriteRenderer.sprite = staffAttack[i];
            yield return new WaitForSeconds(0.1f);
        }
        spriteRenderer.sprite = staffAttack[0];
        isplaying = false;
    }
}
