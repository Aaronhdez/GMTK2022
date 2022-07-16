using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointController : MonoBehaviour
{

    [Header("Parameters")]
    [SerializeField] private int _detectionRange;
    [SerializeField] private bool isActive = true;

    public bool IsActive { get => isActive; set => isActive = value; }

    void Update() {
        var playerLayermask = 1 << 6;
        var playersAround = 
            new List<Collider>(Physics.OverlapSphere(
                transform.position, _detectionRange, playerLayermask));
        if (playersAround.Count > 0) {
            IsActive = false;
        } else {
            IsActive = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _detectionRange);
    }
}
