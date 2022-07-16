using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Enemies : MonoBehaviour
{
    // Start is called before the first frame update
    public float targetTime = 5f;
    public string CurrentEnemy = "orc";
    public string Enemy = "orc";
    public static MC_Enemies instance;
    public bool attackAll = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        CurrentEnemy = activeEnemieTag();
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
            targetTime = 5f;
        }
    }

    public void timerEnded()
    {
        CurrentEnemy = activeEnemieTag();
        
    }

    public bool CanAttackAll()
    {
        return attackAll;
    }


    public string activeEnemieTag()
    {
        do
        {
            int Number = Random.Range(0, 21); //elegimos numero al azar 
            if (Number <= 3)
            {
                Enemy = "orc";
                attackAll = false;
            }
            if (Number > 3 && Number <= 7)
            {
                Enemy = "skeleton";
                attackAll = false;
            }
            if (Number > 7 && Number <= 11)
            {
                Enemy = "beast";
                attackAll = false;
            }
            if (Number > 11 && Number <= 15)
            {
                Enemy = "witch";
                attackAll = false;
            }
            if (Number > 15 && Number <= 19)
            {
                Enemy = "ogre";
                attackAll = false;
            }
            if (Number == 20)
            {
                Enemy = "all";
                attackAll = true;
            }
        }
        while (Enemy.CompareTo(CurrentEnemy) == 0);

        return Enemy;
    }
}
