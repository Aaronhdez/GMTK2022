using System;
using UnityEngine;

public class EnemyController : CharacterController {
    [SerializeField] private int _defaultCharacterLife;

    public Weapon weapon;
    public float attackRange;

    // Start is called before the first frame update
    void Start()
    {
        _defaultCharacterLife = CharacterLife;
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
        gameObject.SetActive(false);
    }

    public override void Move()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        transform.Translate((player.transform.position - transform.position).normalized * CharacterMovementSpeed * Time.deltaTime);
    }

    public override void TakeDamage(int damage)
    {
        CharacterLife -= damage;
    }

    public void ResetToDefaults() {
        CharacterLife = _defaultCharacterLife;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(weapon.transform.position, attackRange);
    }
}
