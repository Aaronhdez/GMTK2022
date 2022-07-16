using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcController : EnemyController
{
    public override void Move()
    {
        if (!weapon.CanAttack())
        {
            return;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        transform.Translate((player.transform.position - transform.position).normalized * CharacterMovementSpeed * Time.deltaTime);
    }
}
