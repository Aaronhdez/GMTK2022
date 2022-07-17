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

    private GameManager _gameManager;
    [SerializeField] private int _force = 5;
    [SerializeField] private int _enemiesDefeated = 0;

    [SerializeField]
    private Weapon weapon;


    // Start is called before the first frame update
    void Start()
    {
        characterLife = 6;
        dead = false;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _rb = GetComponent<Rigidbody2D>();
        _speed = new Vector2(0, 0);
    }

    // Update is called once per frame
    void LateUpdate()
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
        if (collision.gameObject.layer.Equals("Enemy"))
        {
            Debug.Log("Taking damage");
            TakeDamage(1);
        }

        if (collision.gameObject.CompareTag("Arena"))
        {
            Debug.Log("te saliste puto");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }



    public override void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(weapon is Dagger)
            {
                _ = StartCoroutine("InivicibleDagger");
            }
            weapon.Attack();
            
        }
    }

    public void AddKill()
    {
        _enemiesDefeated++;

        if (_enemiesDefeated >= 10 && characterLife < 6){
            characterLife++;
            playerDamagedEvent?.Invoke(characterLife);
            _enemiesDefeated = 0;
        }
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
        if (!_gameManager.playerMovementLocked)
        {
            //Rotation
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
            Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
            float angle = Mathf.Atan2(positionOnScreen.y - mouseOnScreen.y, positionOnScreen.x - mouseOnScreen.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90.0f));

            //Direcciones
            _speed.x = Input.GetAxisRaw("Horizontal");
            _speed.y = Input.GetAxisRaw("Vertical");
            _speed.Normalize();
            _speed *= characterMovementSpeed * Time.deltaTime;
           
            __rb.velocity = _speed;

            if (weapon is Dagger)
            {
                _speed = _speed * 1.5f;
            }

            _rb.MovePosition(rb.position + _speed);
        }
    }

    public override void TakeDamage(int damage)
    {
        if (!invincible)
        {
            characterLife = Mathf.Clamp(characterLife - damage, 0, 6);

            //play audio


            playerDamagedEvent?.Invoke(characterLife);

            if (characterLife == 0)
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

    private IEnumerator InivicibleDagger()
    {
        invincible = true;
        yield return new WaitForSeconds(0.35f);
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
