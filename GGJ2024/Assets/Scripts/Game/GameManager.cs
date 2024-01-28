using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] Transform player;
    [SerializeField] GameObject deathUI;
    [SerializeField] TextMeshProUGUI deathText;
    [SerializeField] Dialogue checkpointNarrator;

    [SerializeField] GameObject victoryUI;

    Vector3 checkPoint;
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

    public static void NextCheckPoint(Vector3 checkPoint)
    {
        instance.checkPoint = checkPoint;
        instance.checkpointNarrator.UpdateText("New Check Point Added!");
    }

    public static void LoadCheckPoint()
    {
        Debug.Log("Loading Checkpoint");
        instance.deathUI.SetActive(false);
        instance.player.position = instance.checkPoint;
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
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void ToTitleScreen()
    {
        SceneManager.LoadScene(0);
    }
}
