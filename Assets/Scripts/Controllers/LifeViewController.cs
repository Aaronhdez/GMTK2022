using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeViewController : MonoBehaviour
{
    public PlayerController player;
    public float unitHeartLength = 160f;

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        player.playerDamagedEvent += OnPlayerDamaged;
    }

    void OnPlayerDamaged(int health)
    {
        rectTransform.sizeDelta = new Vector2(unitHeartLength * health, rectTransform.rect.height);
    }
}
