using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public float damage = 1f;

    public float speed = 3f;

    private void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }

    public abstract void Attack();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO: Check active tag on dice
        if (collision.transform.CompareTag("orc"))
        {
            // TODO: damage enemy
            Attack();
        }
    }
}
