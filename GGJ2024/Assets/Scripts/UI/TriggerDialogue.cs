using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    [SerializeField] GameObject dialogue;
    [SerializeField] string text;
    Dialogue d;
    // Start is called before the first frame update
    void Start()
    {
        //dialogue.SetActive(true);
        d = dialogue.GetComponent<Dialogue>();

        //SetText();
    }

    public void SetText()
    {
        dialogue.SetActive(true);
        d.UpdateText(text);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetText();
        }
    }
}