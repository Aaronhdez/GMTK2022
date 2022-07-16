using System;
using UnityEngine;

public class EnemyController : CharacterController {
    [SerializeField] private int _defaultCharacterLife;

    [SerializeField] private int enemyScore;


    private GameManager _gameManager;

    public Weapon weapon;
    public float attackRange;

    // Start is called before the first frame update
    void Start()
    {
        _defaultCharacterLife = characterLife;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        rb = GetComponent<Rigidbody2D>();
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

    public override void Attack()
    {
        weapon.Attack();
    }

    public override void Die()
    {
        _gameManager.AddScore(enemyScore);
        gameObject.SetActive(false);
    }

    public override void Move()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _speed.x = Input.GetAxisRaw("Horizontal");
        _speed.y = Input.GetAxisRaw("Vertical");
        _speed.Normalize();
        _speed *= characterMovementSpeed * Time.deltaTime;

        rb.velocity = _speed;

        rb.MovePosition(rb.position + _speed);

        transform.Translate((player.transform.position - transform.position).normalized * characterMovementSpeed * Time.deltaTime);
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
