using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Projectile
{
    public override void Attack()
    {
        // TODO: damage enemy

        Destroy(gameObject);
    }
}
