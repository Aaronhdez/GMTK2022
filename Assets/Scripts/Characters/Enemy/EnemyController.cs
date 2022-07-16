using System;
using UnityEngine;

public class EnemyController : CharacterController {
    [SerializeField] private int _defaultCharacterLife;

    // Start is called before the first frame update
    void Start()
    {
        _defaultCharacterLife = CharacterLife;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void Attack()
    {
        
    }

    public override void Die()
    {
        gameObject.SetActive(false);
    }

    public override void Move()
    {
        
    }

    public override void TakeDamage(int damage)
    {
        CharacterLife -= damage;
    }

    public void ResetToDefaults() {
        CharacterLife = _defaultCharacterLife;
    }
}
