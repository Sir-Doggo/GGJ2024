using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoiints : MonoBehaviour
{
    bool triggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            GameManager.NextCheckPoint(transform);
        }
    }
}
