using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon
{

    [SerializeField] public AudioSource fireWithBow;
    public Transform spawnPoint;
    public GameObject arrowGO;

    public override void Attack()
    {
        if (!Cooldown())
        {
            return;
        }
        GameObject projectile = Instantiate(arrowGO, spawnPoint.position, spawnPoint.rotation);
        projectile.GetComponent<Projectile>().isEnemy = isEnemy;
        if(isEnemy){
            fireWithBow.Play();
        }
    }
}
