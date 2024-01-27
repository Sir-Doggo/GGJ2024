using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : InteractableObject
{
    [Tooltip("The objects which will do something when the button does something, it can be just one object")]
    [SerializeField] InteractableObject[] linkedObjects;
    public override void Interaction()
    {
        foreach(var obj in linkedObjects)
        {
            obj.Interaction();
        }

        StartCoroutine(AnimateButton());
    }

    IEnumerator AnimateButton()
    {
        moveDown = true;

        yield return new WaitForSeconds(0.25f);

        moveDown = false;
        moveUp = true;

        yield return new WaitForSeconds(0.25f);
        moveUp = false;
    }

    bool moveDown = false;
    bool moveUp = false;

    private void Update()
    {
        if(moveDown)
        {
            transform.position -= new Vector3(0.0f, 0.1f, 0.0f) * Time.deltaTime;
        }
        if(moveUp)
        {
            transform.position -= new Vector3(0.0f, 0.1f, 0.0f) * Time.deltaTime;
        }
    }
}
