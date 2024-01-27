using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : InteractableObject
{
    [SerializeField] GameObject pivot;
    [Tooltip("The angle for the door. 15 is optimum, anymore will make it spin")]
    [SerializeField] int doorAngle = 15;
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
            //transform.RotateAround(pivot.transform.position, Vector3.up, 90);
        while (angle <= doorAngle)
        {
            transform.RotateAround(pivot.transform.position, Vector3.up, angle);
            yield return new WaitForSeconds(0.1f);
            angle++;
            Debug.Log(angle);
        }
        yield return null;
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
