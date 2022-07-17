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

    [SerializeField]
    Sprite[] impacts;

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        player.playerDamagedEvent += OnPlayerDamaged;
    }

    void OnPlayerDamaged(int health)
    {
        StartCoroutine(PlayAnimation());
    }


    public IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(0.15f);
        lifeImage.sprite = impacts[player.characterLife];
        yield return new WaitForSeconds(0.15f);
        lifeImage.sprite = lifes[player.characterLife];
        yield return new WaitForSeconds(0.15f);
        lifeImage.sprite = impacts[player.characterLife];
        yield return new WaitForSeconds(0.15f);
        lifeImage.sprite = lifes[player.characterLife];
        yield return new WaitForSeconds(0.15f);
    }
}
