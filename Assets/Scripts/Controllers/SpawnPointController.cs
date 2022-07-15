using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointController : MonoBehaviour
{

    [Header("Parameters")]
    [SerializeField] private int _detectionRange;

    void Update() {
        var playerLayermask = 1 << 6;
        var playersAround = 
            new List<Collider>(Physics.OverlapSphere(
                transform.position, _detectionRange, playerLayermask));
        if (playersAround.Count > 0) {
            gameObject.SetActive(false);
        } else {
            gameObject.SetActive(true);
        }
    }
}
