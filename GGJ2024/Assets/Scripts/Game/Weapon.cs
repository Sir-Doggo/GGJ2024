using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Dialogue narrator;

    [SerializeField] GameObject gunDialogueObject;
    [SerializeField] Dialogue gunDialoguetext;

    [SerializeField] GameObject gunModel;

    public bool hasGun = false;
    bool firstTime = true;
    public void ActivateGun()
    {
        hasGun = true;

        gunModel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasGun)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                // whiff
                if (!whiffed)
                {
                    StartCoroutine(Whiff());
                }
                
                if(firstTime)
                {
                    firstTime = false;
                    narrator.UpdateText("Huh, that should have worked....");
                }
            }
            //else
            //{
            //    gunDialogueObject.SetActive(false);
            //}
        }
        //else
        //{
        //    gunDialogueObject.SetActive(false);
        //}
    }

    bool whiffed = false;
    IEnumerator Whiff()
    {
        if(whiffed) yield return null;

        whiffed = true;

        gunDialogueObject.SetActive(true);
        gunDialoguetext.UpdateText("Whiff");

        yield return new WaitForSeconds(0.25f);

        gunDialogueObject.SetActive(false);

        whiffed= false;
    }
}
