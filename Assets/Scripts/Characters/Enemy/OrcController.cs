using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcController : EnemyController
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Attack()
    {

    }

    public override void Move()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        float angle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90));

        transform.Translate((player.transform.position - transform.position).normalized * CharacterMovementSpeed * Time.deltaTime);
    }
}
