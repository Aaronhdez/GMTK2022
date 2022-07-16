using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Dice : MonoBehaviour
{

    public int ArrayInt = 0;
    public int number;
    public int OldNumber;
    public float targetTime = 10.0f;
    public ArrayList Weapons = new ArrayList();
    public GameObject Bow;
    public GameObject Staff;
    public GameObject Dagger;
    public GameObject Axe;
    public GameObject Sword;
    public PlayerController playerController;


/*
 * 0 is Sword
 * 1 is Bow
 * 2 is Dagger
 * 3 is Staff
 * 4 is Axe
 */

    
    public int addWeapon(int newWeapon) //Metodo para anadir arma
    {
        if (Weapons.Count < 6) //Si el tamano es menor que 6
        {
            Weapons.Add(newWeapon); //anadimos el arma
        }

        
        return 0; //Todo Ok
    }

    public int replaceWeapon(int newWeapon, int oldWeapon) //Metodo para remplazar un arma
    {
        if (Weapons[oldWeapon] != null)  //Si la antigua arma esta
        {
            Weapons.RemoveAt(oldWeapon); //La quitamos
            Weapons.Add(newWeapon); //Y anadimos el arma
            return 0; //Todo Ok
        }
        return 1; //Error 
        
    }
    // Start is called before the first frame update
    void Start()
    {

        //Empezamos con la espada
        addWeapon(0);
        addWeapon(1);
        addWeapon(2);
        addWeapon(3);
        addWeapon(4);


        ActiveWeapon(0); //La activamos
    }

 


    // Update is called once per frame
    void Update()
    {
        
        //Temporizador para lanzar el dado
        targetTime -= Time.deltaTime; 

        if (targetTime <= 0.0f)
        {
            timerEnded();
            targetTime = 10.0f;
        }


    }

    public int RandomWeapon()
    {
        
        do
        {
            OldNumber = number; //Guardamos el resultado anterior
            number = Random.Range(0, 6); //elegimos numero al azar 
            
        }
        while (number > Weapons.Count || OldNumber == number);
        OldNumber = number; //Guardamos el resultado anterior
        return number; //devuelve el numero
    }

    public void ActiveWeapon(int Weapon)
    {
        Sword.SetActive(false);
        Axe.SetActive(false);
        Bow.SetActive(false);
        Staff.SetActive(false);
        Dagger.SetActive(false);

        switch (Weapon)
        {
            case 0:
                Sword.SetActive(true);
                playerController.SetWeapon(Sword.GetComponent<Weapon>());
                break;
            case 1:
                Bow.SetActive(true);
                playerController.SetWeapon(Bow.GetComponent<Weapon>());
                break;
            case 2:
                Dagger.SetActive(true);
                playerController.SetWeapon(Dagger.GetComponent<Weapon>());
                break;
            case 3:
                Staff.SetActive(true);
                playerController.SetWeapon(Staff.GetComponent<Weapon>());
                break;
            case 4:
                Axe.SetActive(true);
                playerController.SetWeapon(Axe.GetComponent<Weapon>());
                break;
            default:
                Debug.LogError("Error");
                break;
        }


    }

    public void timerEnded()
    {
        ArrayInt = RandomWeapon();
        if (ArrayInt < Weapons.Count)
        {
            int weapon = (int)Weapons[ArrayInt];
            ActiveWeapon(weapon);
        }
        
    }

}
