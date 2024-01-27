using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] Transform interactionPoint;
    [SerializeField] GameObject interactionDialogueObject;
    [SerializeField] TextMeshProUGUI interactionText;

    [SerializeField] float interactionDistance = 10f;
    [SerializeField] LayerMask interactableLayers;

    Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Physics.Raycast(interactionPoint.position, interactionPoint.forward,out RaycastHit hit, interactionDistance, interactableLayers))
        {
            //we have found something we can interact with
            var iObj = hit.collider.GetComponent<InteractableObject>();

            if (iObj != null)
            {
                if (iObj.observeOnly)
                {
                    interactionDialogueObject.SetActive(true);
                    interactionText.text = iObj.interactionDialogue;
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        iObj.Interaction();
                        anim.SetTrigger("isInteracting");
                    }

                    // show dialogue;
                    interactionDialogueObject.SetActive(true);
                    interactionText.text = "Press E To Interact With " + iObj.interactionDialogue;
                }
            }
        }
        else
        {
            interactionDialogueObject.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(interactionPoint.position, interactionPoint.forward * interactionDistance);
    }
}
