using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : InteractableObject
{
    [SerializeField] GameObject pivot;
    [Tooltip("The angle for the door. 15 is optimum, anymore will make it spin")]
    [SerializeField] int doorAngle = 15;
    [SerializeField] int doorCloseAngle = 15;
    [SerializeField] bool closeBehindPlayer = false;
    [SerializeField] bool timed = false;
    [SerializeField] float timer = 2f;
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
        }
        if (timed)
        {
            yield return new WaitForSeconds(timer);
            StartCoroutine(Close());
        }
        //yield return null;
    }

    IEnumerator Close()
    {
        float progress = 0;
        Quaternion startRot = transform.rotation;
        Quaternion endRot = Quaternion.Euler(0, 0, 0);
        Vector3 startPos = transform.localPosition;
        Vector3 endPos = Vector3.zero;
        while (progress < 1)
        {
            //transform.RotateAround(pivot.transform.position, Vector3.up, angle);
            progress += 0.1f;
            transform.localRotation = Quaternion.Lerp(startRot, endRot, progress);
            transform.localPosition = Vector3.Lerp(startPos, endPos, progress);
            yield return new WaitForSeconds(0.1f);
            
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
