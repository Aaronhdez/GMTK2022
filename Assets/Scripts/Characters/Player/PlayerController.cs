using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, ICharacterController {

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    float movementSpeed = 5f; //Placeholder
    float deltaTimeVar = 60f; //placeHolder
    
    public void Attack() {
        throw new System.NotImplementedException();
    }

    public void Die() {
        throw new System.NotImplementedException();
    }

    public void Move() {


        // convert mouse position into world coordinates
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // set vector of transform directly
        transform.up = mouseScreenPosition;


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

        //Rotacion 
 
    }
}
