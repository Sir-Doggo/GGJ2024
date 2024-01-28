using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] Transform player;
    [SerializeField] GameObject deathUI;
    [SerializeField] TextMeshProUGUI deathText;
    [SerializeField] Dialogue narrator;

    [SerializeField] GameObject victoryUI;

    Transform checkPoint;
    bool playerDead = false;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    public static void NextCheckPoint(Transform checkPoint)
    {
        instance.checkPoint = checkPoint;
        instance.narrator.UpdateText("New Check Point Added!");
    }

    public static void LoadCheckPoint()
    {
        Debug.Log("Loading Checkpoint");
        instance.deathUI.SetActive(false);
        instance.player.position = instance.checkPoint.position;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        instance.playerDead = false;
    }

    public static void PlayerDeath(string deathMessage)
    {
        if (instance.playerDead) return;

        instance.playerDead = true;

        Debug.Log("Die");
        instance.deathUI.SetActive(true);
        instance.deathText.text = deathMessage;
        Time.timeScale = 0;
        // unlock mouse
        Cursor.lockState = CursorLockMode.None;
    }

    public static void PlayerWin()
    {
        instance.victoryUI.SetActive(true);
    }
}
