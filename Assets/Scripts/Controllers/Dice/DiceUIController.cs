using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceUIController : MonoBehaviour
{
    [Header("Entities")]
    [SerializeField] private Image _diceImage;
    [SerializeField] private List<Sprite> _diceFaces;

    [Header("Parameters")]
    [SerializeField] private float _rollingSeconds;

    public void SetUp(int newIndex) {
        _diceImage.sprite = _diceFaces[newIndex];
    }

    public void RollingAnimation(int newIndex) {
        StartCoroutine(PlayAnimation(newIndex));
    }

    private IEnumerator PlayAnimation(int newIndex) {
        for(int i = 0; i < _diceFaces.Count; i++)
        {
            _diceImage.sprite = _diceFaces[i];
            yield return new WaitForSeconds(0.30f/_diceFaces.Count);
        }
        _diceImage.sprite = _diceFaces[newIndex];
    }
}
