public class EnemyController : CharacterController {

    // Start is called before the first frame update
    void Start()
    {
        
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

}
