using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public abstract class Projectile : MonoBehaviour
{
    public int damage = 1;
    public float speed = 3f;
    public MC_Enemies Dice;
    private void Start()
    {
        Destroy(gameObject, 20);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public abstract void Attack(GameObject enemy);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO: Check active tag on dice
        switch (MC_Enemies.instance.CurrentEnemy)
        {
            case 0:
            if (collision.transform.CompareTag("orc"))
                {
                    Attack(collision.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
                break;
            case 1:
            if (collision.transform.CompareTag("skeleton"))
                {
                    Attack(collision.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
                break;
            case 2:
                if (collision.transform.CompareTag("beast"))
                {
                    Attack(collision.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
                break;
            case 3:
                if (collision.transform.CompareTag("witch"))
                {
                    Attack(collision.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
                break;
            case 4:
                if (collision.transform.CompareTag("ogger"))
                {
                    Attack(collision.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
                break;
            case 5:
                if (collision.transform)
                {
                    Attack(collision.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
                break;
             default:
                break;

        }
        
    }
       

    private void OnCollisionEnter2D(Collision2D collision)
    {

        switch (MC_Enemies.instance.CurrentEnemy)
        {
            case 0:
                if (collision.transform.CompareTag("orc"))
                {
                    Attack(collision.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
                break;
            case 1:
                if (collision.transform.CompareTag("skeleton"))
                {
                    Attack(collision.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
                break;
            case 2:
                if (collision.transform.CompareTag("beast"))
                {
                    Attack(collision.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
                break;
            case 3:
                if (collision.transform.CompareTag("witch"))
                {
                    Attack(collision.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
                break;
            case 4:
                if (collision.transform.CompareTag("ogger"))
                {
                    Attack(collision.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
                break;
            case 5:
                if (collision.transform)
                {
                    Attack(collision.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
                break;
            default:
                break;
                }
            }
        }
