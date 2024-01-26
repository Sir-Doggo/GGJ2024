using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonController : MonoBehaviour
{
    [SerializeField] GameObject startMenu;
    GameObject currentActiveMenu;

    private void Awake()
    {
        currentActiveMenu = startMenu;
    }

    public void ActivateMenu(GameObject menuObjectToActivate)
    {
        if(currentActiveMenu != null)
        {
            currentActiveMenu.SetActive(false);
        }
        currentActiveMenu = menuObjectToActivate;
        currentActiveMenu.SetActive(true);
    }
}
