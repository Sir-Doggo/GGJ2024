using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : InteractableObject
{
    [Tooltip("The objects which will do something when the button does something, it can be just one object")]
    [SerializeField] InteractableObject[] linkedObjects;

    public AudioSource source;
    public AudioClip clip;
    public override void Interaction()
    {
        source.PlayOneShot(clip);
        if (linkedObjects != null && linkedObjects.Length > 0)
        {
            foreach (var obj in linkedObjects)
            {
                if(obj == null)continue;
                obj.Interaction();
            }
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
            transform.position -= transform.up * 0.1f * Time.deltaTime;
        }
        if(moveUp)
        {
            transform.position += transform.up * 0.1f * Time.deltaTime;
        }
    }
}
