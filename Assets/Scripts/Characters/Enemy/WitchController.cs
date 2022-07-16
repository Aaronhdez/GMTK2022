using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchController : EnemyController
{
    public override void Move()
    {
        if (!weapon.CanAttack())
        {
            return;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        float angle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

        transform.Translate((player.transform.position - transform.position).normalized * characterMovementSpeed * Time.deltaTime, Space.World);
    }
}
