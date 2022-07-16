using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour {

    [Header("Parameters")]
    [SerializeField] private TextMeshProUGUI _timerTextField;
    [SerializeField] private string _currentTime;
    [SerializeField] private float _time = 0;
    private bool _enabled = false;

    public bool Enabled { get => _enabled; set => _enabled = value; }

    public void Start() {
        _timerTextField.SetText("00:00");
    }

    public void StartTimer()
    {
        Resume();
    }

    void Update() {
        if (Enabled) { 
            _time += Time.deltaTime;
            TimeSpan timeSpan = TimeSpan.FromSeconds(_time);
            _currentTime = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
            _timerTextField.SetText(_currentTime);
        }
    }

    internal void Resume() {
        Enabled = true;
    }

    internal void Pause() {
        Enabled = false;
    }
}
