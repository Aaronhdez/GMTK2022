using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : Weapon
{
    public Transform spawnPoint;
    public GameObject fireballGO;

    public override void Attack()
    {
        if (!Cooldown())
        {
            return;
        }

        GameObject projectile = Instantiate(fireballGO, spawnPoint.position, spawnPoint.rotation);
        projectile.GetComponent<Projectile>().isEnemy = isEnemy;
    }
}
