using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public abstract class Projectile : MonoBehaviour
{
    public int damage = 1;
    public float speed = 3f;

    public bool isEnemy = false;

    private void Start()
    {
        Destroy(gameObject, 10);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public abstract void Attack(GameObject enemy);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isEnemy)
        {
            Debug.Log("contact");
            if (collision.transform.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<CharacterController>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.transform.CompareTag(EnemiesDiceController.instance._currentEnemy) || EnemiesDiceController.instance.AttackAll)
            {
                if (collision.gameObject != null) {
                    Attack(collision.gameObject);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Arena"))
        {
            Destroy(gameObject);
        }
    }
       
       
}
