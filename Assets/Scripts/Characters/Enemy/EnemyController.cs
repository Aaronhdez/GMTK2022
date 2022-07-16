using System;
using UnityEngine;

public class EnemyController : CharacterController {
    [SerializeField] private int _defaultCharacterLife;

    [SerializeField] private int enemyScore;


    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _defaultCharacterLife = CharacterLife;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        _gameManager.AddScore(enemyScore);
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
}
