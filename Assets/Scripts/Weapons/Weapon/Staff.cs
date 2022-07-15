using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : Weapon
{
    public Transform spawnPoint;
    public GameObject fireballGO;

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

        Instantiate(fireballGO, spawnPoint.position, spawnPoint.rotation);
    }
}
