using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionDialogue : MonoBehaviour
{
    [SerializeField] GameObject interactionDialogue;
    [SerializeField] TextMeshProUGUI text;

    public enum InteractionType { E}

    public void InteractionText(InteractionType type)
    {
        switch (type)
        {
            case InteractionType.E:
                text.text = "Press E To Interact";
                break;
        }

        interactionDialogue.SetActive(true);
    }


}
