using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{

    public event Action<int> playerDamagedEvent;

    [SerializeField]
    private bool invincible;
    [SerializeField]
    private float invincibleTime;

    // Start is called before the first frame update
    void Start()
    {
        CharacterLife = 6;
        CharacterMovementSpeed = 20f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    public override void TakeDamage(int damage)
    {
        if (!invincible)
        {
            CharacterLife = Mathf.Clamp(CharacterLife - damage, 0, 6);

            //play audio


            playerDamagedEvent?.Invoke(CharacterLife);
            StartCoroutine("InvincibleTimer");
        }
    }

    private IEnumerator InvincibleTimer()
    {
        invincible = true;
        yield return new WaitForSeconds(invincibleTime);
        invincible = false;
    }
}
