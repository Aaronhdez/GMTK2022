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
        PlayAnimation();
        _diceImage.sprite = _diceFaces[newIndex];
    }

    private IEnumerable PlayAnimation() {
        yield return new WaitForSeconds(3f);
    }
}
