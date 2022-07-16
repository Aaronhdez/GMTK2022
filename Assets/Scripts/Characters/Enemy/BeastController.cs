using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastController : EnemyController
{
    public override void Attack()
    {

    }

    public override void Move()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        transform.Translate((player.transform.position - transform.position).normalized * CharacterMovementSpeed * Time.deltaTime);
    }
}
