using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon
{

    public Transform spawnPoint;
    public GameObject arrowGO;

    public override void Attack()
    {
        if (!Cooldown())
        {
            return;
        }

        GameObject projectile = Instantiate(arrowGO, spawnPoint.position, spawnPoint.rotation);

        if (isEnemy)
        {
            int LayerEnemyBullets = LayerMask.NameToLayer("EnemyBullets");
            projectile.layer = LayerEnemyBullets;
            projectile.GetComponent<Projectile>().isEnemy = isEnemy;
        }
    }
}
