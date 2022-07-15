using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon
{

    public Transform spawnPoint;
    public GameObject arrowGO;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    public override void Attack()
    {
        if (!Cooldown())
        {
            return;
        }

        Instantiate(arrowGO, spawnPoint.position, spawnPoint.rotation);
    }
}
