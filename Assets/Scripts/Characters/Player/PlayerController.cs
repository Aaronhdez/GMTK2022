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

    private GameManager _gameManager;

    [SerializeField]
    private Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        CharacterLife = 6;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead && !_gameManager.playerMovementLocked)
        {
            Move();
            Attack();
        }
    }
    
    //Recibir daño temporal
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Taking damage");
        TakeDamage(1);
    }

    public override void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            weapon.Attack();
        }
    }

    public override void Die()
    {
        Debug.Log("Player dead");
        dead = true;
        _gameManager._timerController.Pause();
        //Diying animation and sound

        //GameOver screen

    }

    public override void Move()
    {
        if (!_gameManager.playerMovementLocked)
        {
            //Rotacion 

            //Get the Screen positions of the object
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

            //Get the Screen position of the mouse
            Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

            //Get the angle between the points
            float angle = Mathf.Atan2(positionOnScreen.y - mouseOnScreen.y, positionOnScreen.x - mouseOnScreen.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90.0f));


            //Direcciones

            Vector2 dir = Vector2.zero;

            if (Input.GetKey(KeyCode.D)) //Si el jugador tiene el boton "D" pulsado 
            {
                dir += Vector2.right; //Se mueve a la derecha
            }

            if (Input.GetKey(KeyCode.A)) //Si el jugador tiene el boton "A" pulsado 
            {
                dir += Vector2.left; //Se mueve hacia la izquierda
            }

            if (Input.GetKey(KeyCode.W)) //Si el jugador tiene el boton "W" pulsado 
            {
                dir += Vector2.up; //Se mueve hacia arriba
            }

            if (Input.GetKey(KeyCode.S)) //Si el jugador tiene el boton "S" pulsado 
            {
                dir += Vector2.down; //Se mueve hacia abajo
            }

            transform.Translate(dir.normalized * CharacterMovementSpeed * Time.deltaTime, Space.World);
        }
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

    public override float GetAttackDistance()
    {
        return 1;
    }

    public void SetWeapon(Weapon newWeapon) 
    {
        weapon = newWeapon;
    }
}
