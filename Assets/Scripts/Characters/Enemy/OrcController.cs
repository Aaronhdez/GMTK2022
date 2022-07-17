using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcController : EnemyController{
    [SerializeField] Sprite[] spriteAttack;

    [SerializeField] Sprite[] beastDeath;

    [SerializeField] SpriteRenderer _spriteRenderer;

    public bool isplaying = false;

    private void Start() {
        _defaultCharacterLife = characterLife;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _rb = GetComponent<Rigidbody2D>();
        _speed = new Vector2(0, 0);
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
        for (int i = 1; i < spriteAttack.Length; i++) {
            _spriteRenderer.sprite = spriteAttack[i];
            yield return new WaitForSeconds(0.1f);
        }
        _spriteRenderer.sprite = spriteAttack[0];
        isplaying = false;
    }
}
