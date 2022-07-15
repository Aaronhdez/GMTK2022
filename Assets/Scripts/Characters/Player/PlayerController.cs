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

    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        CharacterLife = 6;
        CharacterMovementSpeed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            Move();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Taking damage");
        TakeDamage(1);
    }

    float movementSpeed = 5f; //Placeholder
    float deltaTimeVar = 60f; //placeHolder


    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Die()
    {
        Debug.Log("Player dead");
        dead = true;

        //Diying animation and sound

        //GameOver screen

    }

    public override void Move()
    {


        // convert mouse position into world coordinates
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // set vector of transform directly
        transform.up = mouseScreenPosition;


        //Direcciones

        if (Input.GetKey(KeyCode.D)) //Si el jugador tiene el boton "D" pulsado 
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime, Space.World); //Se mueve a la derecha
        }

        if (Input.GetKey(KeyCode.A)) //Si el jugador tiene el boton "A" pulsado 
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime, Space.World); //Se mueve hacia la izquierda
        }

        if (Input.GetKey(KeyCode.W)) //Si el jugador tiene el boton "W" pulsado 
        {
            transform.Translate(Vector2.up * movementSpeed * Time.deltaTime, Space.World); //Se mueve hacia arriba
        }

        if (Input.GetKey(KeyCode.S)) //Si el jugador tiene el boton "S" pulsado 
        {
            transform.Translate(Vector2.down * movementSpeed * Time.deltaTime, Space.World); //Se mueve hacia abajo
        }

        //Rotacion 

    }

    public override void TakeDamage(int damage)
    {
        if (!invincible)
        {
            CharacterLife = Mathf.Clamp(CharacterLife - damage, 0, 6);

            //play audio


            playerDamagedEvent?.Invoke(CharacterLife);

            if (CharacterLife == 0)
            {
                Die();
            }
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
