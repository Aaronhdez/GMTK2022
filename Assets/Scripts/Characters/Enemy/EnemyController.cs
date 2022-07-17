using System;
using System.Collections;
using UnityEngine;

public class EnemyController : CharacterController {
    [SerializeField] protected int _defaultCharacterLife;

    [SerializeField] private int enemyScore;

    [SerializeField] private Animator enemyAnimator;

    [SerializeField] protected Sprite[] deadAttack;

    protected GameManager _gameManager;

    public Weapon weapon;
    public float attackRange;
    private bool isDead = false;
    private bool isDying = false;

    // Start is called before the first frame update
    void Start()
    {
        _defaultCharacterLife = characterLife;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        _rb = GetComponent<Rigidbody2D>();
        _speed = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override float GetAttackDistance()
    {
        return attackRange;
    }

    private void dashAttack()
    {
        weapon.Attack();
        _rb.AddRelativeForce(Vector2.up * 100);
        weapon.Attack();

    }
    public override void Attack()
    {
        if(weapon is Dagger)
        {
            dashAttack();
        }

        weapon.Attack();

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        float angle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));
    }

    public override void Die() {
        _gameManager.AddScore(enemyScore);
        gameObject.SetActive(false);
    }

    public override void Move()
    {
        if (!weapon.CanAttack()) {
            return;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _speed.x = Input.GetAxisRaw("Horizontal");
        _speed.y = Input.GetAxisRaw("Vertical");
        _speed.Normalize();
        _speed *= characterMovementSpeed * Time.fixedDeltaTime;

        _rb.velocity = _speed;

        _rb.MovePosition(_rb.position + _speed);

        float angle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

        transform.Translate((player.transform.position - transform.position).normalized * characterMovementSpeed * Time.deltaTime, Space.World);
    }

    public override void TakeDamage(int damage)
    { 
        characterLife -= damage;
    }

    public void ResetToDefaults() {
        characterLife = _defaultCharacterLife;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(weapon.transform.position, attackRange);
    }


}
