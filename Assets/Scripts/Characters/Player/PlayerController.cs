using UnityEngine;

public class PlayerController : CharacterController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    float movementSpeed = 5f; 

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    public override void Move() {

        //Rotacion 

        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = Mathf.Atan2(positionOnScreen.y - mouseOnScreen.y, positionOnScreen.x - mouseOnScreen.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90.0f));


        //Direcciones

        if (Input.GetKey(KeyCode.D)) //Si el jugador tiene el boton "D" pulsado 
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime, Space.World); //Se mueve a la derecha
        }

        if (Input.GetKey(KeyCode.A)) //Si el jugador tiene el boton "A" pulsado 
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime, Space.World); //Se mueve hacia la izquierda
        }

        if (Input.GetKey(KeyCode.W)) //Si el jugador tiene el boton "W" pulsado 
        {
            transform.Translate(Vector2.up * movementSpeed * Time.deltaTime, Space.World); //Se mueve hacia arriba
        }

        if (Input.GetKey(KeyCode.S)) //Si el jugador tiene el boton "S" pulsado 
        {
            transform.Translate(Vector2.down * movementSpeed * Time.deltaTime, Space.World); //Se mueve hacia abajo
        } 
    }

    public override void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}
