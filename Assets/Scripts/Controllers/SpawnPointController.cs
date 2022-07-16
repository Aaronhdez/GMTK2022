using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointController : MonoBehaviour
{

    [Header("Parameters")]
    [SerializeField] private int _detectionRange;
    [SerializeField] public bool _isActive = true;

    void Update() {
        var playerLayermask = 1 << 6;
        var playersAround = 
            new List<Collider>(Physics.OverlapSphere(
                transform.position, _detectionRange, playerLayermask));
        if (playersAround.Count > 0) {
            _isActive = false;
        } else {
            _isActive = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _detectionRange);
    }
}
