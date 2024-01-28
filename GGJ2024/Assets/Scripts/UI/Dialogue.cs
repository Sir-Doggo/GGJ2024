using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    // Dialogue is something that appears at the top of the screen, the characters will appear a couple at a time
    [SerializeField] TextMeshProUGUI text;
    TMP_TextInfo textInfo;

    [SerializeField] float textSpeed = 2f;
    [SerializeField] float displayTime = 3f; // how long text should be displayed after fully visible

    void Awake()
    {
        textInfo = text.textInfo;
    }

    IEnumerator AnimateText(string fullText)
    {
        int currentCharacter = 0;
        //int maxCharacters = text.text.Length;

        while(text.text != fullText)//currentCharacter < maxCharacters)
        {
            text.text += fullText[currentCharacter];
            //SetCharAplha(currentCharacter, 255);
            yield return new WaitForSecondsRealtime(textSpeed);
            currentCharacter++;
        }

        yield return new WaitForSecondsRealtime(displayTime);

        text.text = "";
        gameObject.SetActive(false);
    }


    public void UpdateText(string newText)
    {
        gameObject.SetActive (true);
        text.text = "";
        StopAllCoroutines();
        StartCoroutine(AnimateText(newText));
    }
}
