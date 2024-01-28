using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : InteractableObject
{
    [Tooltip("The objects which will do something when the button does something, it can be just one object")]
    [SerializeField] InteractableObject[] linkedObjects;

    [SerializeField] float buttonMoveSpeed = 0.5f;
    public AudioSource source;
    public AudioClip clip;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        source.clip = clip;
    }
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

        yield return new WaitForSeconds(2f * buttonMoveSpeed);

        moveDown = false;
        moveUp = true;

        yield return new WaitForSeconds(2f * buttonMoveSpeed);
        moveUp = false;
    }

    bool moveDown = false;
    bool moveUp = false;

    private void Update()
    {
        if(moveDown)
        {
            transform.position -= transform.up * buttonMoveSpeed * Time.deltaTime;
        }
        if(moveUp)
        {
            transform.position += transform.up * buttonMoveSpeed * Time.deltaTime;
        }
    }
}
