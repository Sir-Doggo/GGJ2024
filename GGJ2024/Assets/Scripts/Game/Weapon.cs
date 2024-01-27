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
    [SerializeField] GameObject effectModel;

    [SerializeField] LayerMask enemyLayer;

    public bool hasGun = false;
    bool firstTime = true;
    bool secondTime = false;

    public AudioSource source;
    public AudioClip clip;

    Animator anim;

    private void Awake()
    {
        anim = gunModel.GetComponentInChildren<Animator>();
    }
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
                    if(clip != null)
                    source.PlayOneShot(clip);
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

        anim.SetTrigger("Shooting");
        whiffed = true;

        effectModel.SetActive(true);

        bool hitEnemy = false;
        if(Physics.Raycast(gunModel.transform.position, gunModel.transform.forward, 100f, enemyLayer))
        {
            Debug.Log("Hit");
            // hit enemy
            hitEnemy = true;
            gunDialogueObject.SetActive(true);
            gunDialoguetext.UpdateText("Whiff");

            if (firstTime)
            {
                firstTime = false;
                secondTime = true;
                
            }
            else if(secondTime)
            {
                secondTime = false;
                narrator.UpdateText("Huh, that should have worked....");
            }
        }


        yield return new WaitForSeconds(0.25f);

        effectModel.SetActive(false);
        if (hitEnemy)
        {
            gunDialogueObject.SetActive(false);
        }

        whiffed= false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(gunModel.transform.position, gunModel.transform.forward * 100f);
    }
}
