using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreViewController : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;

    [SerializeField]
    private TextMeshProUGUI text;

    void Start()
    {
        _gameManager.EnemyDiedEvent += OnEnemyDied;
    }

    void OnEnemyDied(int score)
    {
        text.text = score.ToString();
    }
}
