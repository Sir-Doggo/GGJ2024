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

    public void QuitPopUp(GameObject menuObjectToActivate)
    {
        //randomly place this popup around the place.
        Vector3 pos = new(Random.Range(0,Screen.width), Random.Range(0, Screen.height),0);
        GameObject obj = Instantiate(menuObjectToActivate, pos,Quaternion.identity, transform);
        obj.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
