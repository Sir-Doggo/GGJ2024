using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleDialogue : MonoBehaviour
{
    [SerializeField] GameObject dialogue;
    [SerializeField] string text;
    Dialogue d;
    // Start is called before the first frame update
    void Start()
    {
        dialogue.SetActive(true);
        d = dialogue.GetComponent<Dialogue>();

        SetText();
    }

    public void SetText()
    {
        dialogue.SetActive(true);
        d.UpdateText(text);
    }
}