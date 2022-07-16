using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Projectile
   
{
    [SerializeField] public AudioSource hitWithFireBall;
    public override void Attack(GameObject enemy)
    {
        enemy.GetComponent<CharacterController>().TakeDamage(damage);
        if (enemy.CompareTag("Player")){
            hitWithFireBall.Play();}

        Destroy(gameObject);
    }
}
