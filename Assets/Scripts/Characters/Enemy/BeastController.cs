using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeastController : EnemyController {
    [SerializeField] Sprite[] axeAttack;

    [SerializeField] Sprite[] beastDeath;

    [SerializeField] SpriteRenderer beast;

    public bool isplaying = false;

    private void Start(){
        _defaultCharacterLife = characterLife;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _rb = GetComponent<Rigidbody2D>();
        _speed = new Vector2(0, 0);
        beast = GetComponent<SpriteRenderer>();
    }

    public override void Die() {
        base.Die();
    }

    public override void Attack() {
        if (!isplaying) {
            StartCoroutine(PlayAnimationAttack());
        }
        base.Attack();
    }

    public IEnumerator PlayAnimationAttack() {
        isplaying = true;
        for(int i = 2; i < axeAttack.Length; i++) {
            beast.sprite = axeAttack[i];
            yield return new WaitForSeconds(0.25f);
        }
        beast.sprite = axeAttack[0];
        isplaying = false;
    }
}
