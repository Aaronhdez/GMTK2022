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

        transform.Translate((player.transform.position - transform.position).normalized * CharacterMovementSpeed * Time.deltaTime);
    }
}
