using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public int damage = 1;

    public float speed = 3f;

    private void Start()
    {
        Destroy(gameObject, 20);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public abstract void Attack(GameObject enemy);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO: Check active tag on dice
        if (collision.transform.CompareTag("orc"))
        {
            Attack(collision.gameObject);
        }
    }
}
