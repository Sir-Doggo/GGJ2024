using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoorFailed : InteractableObject
{
    [SerializeField] GameObject pivot;
    [SerializeField] bool closeBehindPlayer = false;
    public override void Interaction()
    {
        // open the door
        StartCoroutine(Open());
        GetComponent<Collider>().enabled = false;
    }

    IEnumerator Open()
    {
        int angle = 0;
        while(angle < 90)
        {
            transform.RotateAround(pivot.transform.position, Vector3.up, angle);
            yield return new WaitForSeconds(0.1f);
            angle++;
        }
    }

    IEnumerator Close()
    {
        int angle = 90;
        while (angle > 0)
        {
            transform.RotateAround(pivot.transform.position, Vector3.up, angle);
            yield return new WaitForSeconds(0.1f);
            angle--;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine (Close());
        }
    }
}
