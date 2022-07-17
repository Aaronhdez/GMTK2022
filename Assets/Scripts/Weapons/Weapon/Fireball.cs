using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Projectile {

    [SerializeField] private AudioSource hitWithFireBall;

    [SerializeField] private Animator fireballAnimator;



    public override void Attack(GameObject enemy)
    {
        enemy.GetComponent<CharacterController>().TakeDamage(damage);
        if (enemy.CompareTag("Player")){
            fireballAnimator.Play("Fireball");
            hitWithFireBall.Play();
        }

        Destroy(gameObject);
    }
}
