using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;

    [SerializeField] float waitBeforeMove;
    [SerializeField] float speed;

    [SerializeField] bool triggered = true;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        if(!triggered) yield break;

        float lerp = 0;
        Vector3 start = pointA.position;
        Vector3 end = pointB.position;
        transform.position = start;

        while (true)
        {
            yield return new WaitForSeconds(waitBeforeMove);
            while (lerp <= 1f)
            {
                // lerp to pointB;
                transform.position = Vector3.Lerp(start, end, lerp);
                lerp += Time.deltaTime * speed;
                yield return new WaitForSeconds(Time.deltaTime * speed);
            }
            yield return new WaitForSeconds(waitBeforeMove);
            while (lerp >= 0f)
            {
                // lerp to pointB;
                transform.position = Vector3.Lerp(start, end, lerp);
                lerp -= Time.deltaTime * speed;
                yield return new WaitForSeconds(Time.deltaTime * speed);
            }
        }
    }

    public void TriggerPlatform()
    {
        triggered = true;
        StartCoroutine(Start());
    }
}
