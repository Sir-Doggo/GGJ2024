using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeLava : MonoBehaviour
{
    [SerializeField] Dialogue narrator;
    [SerializeField] string dialogue;
    [SerializeField] MovingPlatforms triggeredPlatform;

    bool triggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            narrator.UpdateText(dialogue);
            triggeredPlatform.TriggerPlatform();
        }
    }
}
