using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    [Tooltip("This is the special dialogue that will be displayed to the player when close enough to an object")]
    public string interactionDialogue;
    [Tooltip("This decides if the object should only display text, not be interacted with")]
    public bool observeOnly;

    public abstract void Interaction();
}
