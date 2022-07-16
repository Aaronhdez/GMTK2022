using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("MainMenuScreen")]
    [SerializeField] private List<GameObject> _mainMenuScreenElements;

    [Header("CreditsScreen")]
    [SerializeField] private List<GameObject> _creditsScreenElements;

    [Header("GameScreen")]
    [SerializeField] private List<GameObject> _gameScreenElements;

    [Header("PauseScreen")]
    [SerializeField] private List<GameObject> _pauseScreenElements;

    [Header("GameOverScreen")]
    [SerializeField] private List<GameObject> _gameOverScreenElements;

    [Header("Parameters")]
    [SerializeField] private string _currentScreen;
    private Dictionary<string, List<GameObject>> _screensAvailable;

    public void Start() {
        LoadScreensMap();
        Activate(_currentScreen);
    }
    private void LoadScreensMap() {
        _screensAvailable = new Dictionary<string, List<GameObject>>();
        _screensAvailable.Add("MainMenuScreen", _mainMenuScreenElements);
        _screensAvailable.Add("CreditsScreen", _creditsScreenElements);
        _screensAvailable.Add("GameScreen", _gameScreenElements);
        _screensAvailable.Add("PauseScreen", _pauseScreenElements);
        _screensAvailable.Add("GameOverScreen", _gameOverScreenElements);
    }
    public void Activate(string currentScreen) {
        _currentScreen = currentScreen;
        foreach(KeyValuePair<string, List<GameObject>> entry in _screensAvailable){
            if (!entry.Key.Equals(currentScreen)) {
                DisableScreen(entry.Value);
            }
        }
        EnableScreen(_screensAvailable[_currentScreen]);
    }

    private void EnableScreen(List<GameObject> elements) {
        foreach (GameObject element in elements) {
            element.SetActive(true);
        }
    }

    private void DisableScreen(List<GameObject> elements) {
        foreach (GameObject element in elements) {
            element.SetActive(false);
        }
    }
}
