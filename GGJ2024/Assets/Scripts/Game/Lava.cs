using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] string deathDialogue;
    [SerializeField] float timeToKill = 0.1f;
    bool playerPresent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPresent = true;
            Invoke(nameof(Kill), timeToKill);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPresent = false;
        }
    }

    void Kill()
    {
        if (playerPresent)
        {
            GameManager.PlayerDeath(deathDialogue);
        }
    }
}
