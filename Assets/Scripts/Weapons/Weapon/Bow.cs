using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon
{

    [SerializeField] public AudioSource fireWithBow;
    public Transform spawnPoint;
    public GameObject arrowGO;

    [SerializeField] private Animator skeletonAnimator;

    public override void Attack()
    {
        if (!Cooldown())
        {
            return;
        }
        GameObject projectile = Instantiate(arrowGO, spawnPoint.position, spawnPoint.rotation);

        if (isEnemy)
        {
            skeletonAnimator.SetBool("Firing", true);
            //skeletonAnimator.Play("SkeletonAnimation");
            int LayerEnemyBullets = LayerMask.NameToLayer("EnemyBullets");
            projectile.layer = LayerEnemyBullets;
            projectile.GetComponent<Projectile>().isEnemy = isEnemy;
            fireWithBow.Play();
        }
    }
}
