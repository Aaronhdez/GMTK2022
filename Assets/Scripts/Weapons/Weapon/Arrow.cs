using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Projectile
{

    [SerializeField] public AudioSource hitWithArrow;
    public override void Attack(GameObject enemy)
    {
        enemy.GetComponent<CharacterController>().TakeDamage(damage);
        if(enemy.CompareTag("Player")) {
            hitWithArrow.Play();
        }
        Destroy(gameObject);
    }
}
