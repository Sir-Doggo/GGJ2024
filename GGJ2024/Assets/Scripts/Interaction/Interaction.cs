using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] GameObject interactionDialogueObject;
    [SerializeField] TextMeshProUGUI interactionText;

    [SerializeField] float interactionDistance = 10f;
    [SerializeField] LayerMask interactableLayers;
    private void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.forward,out RaycastHit hit, interactionDistance, interactableLayers))
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
        Gizmos.DrawLine(transform.position, transform.forward * interactionDistance);
    }
}
