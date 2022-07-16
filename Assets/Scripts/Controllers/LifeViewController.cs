using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeViewController : MonoBehaviour
{
    public PlayerController player;

    [SerializeField]
    Image lifeImage;

    [SerializeField]
    Sprite[] lifes;

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        player.playerDamagedEvent += OnPlayerDamaged;
    }

    void OnPlayerDamaged(int health)
    {
        switch (player.characterLife)
        {
            case 6:
                lifeImage.sprite = lifes[0];
                break;
            case 5:
                lifeImage.sprite = lifes[1];
                break;
            case 4:
                lifeImage.sprite = lifes[2];
                break;
            case 3:
                lifeImage.sprite = lifes[3];
                break;
            case 2:
                lifeImage.sprite = lifes[4];
                break;
            case 1:
                lifeImage.sprite = lifes[5];
                break;
            default:
                lifeImage.sprite = lifes[6];
                break;

        }
    }
}
