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

    [SerializeField] Color32[] vertexColours;

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

    //void SetCharAplha(int charId, int alpha)
    //{
    //    if (charId == 0) return;
    //    Debug.Log(charId);
    //    Debug.Log(textInfo);
    //    int matIndex = textInfo.characterInfo[charId].materialReferenceIndex;
    //    int vertexIndex = textInfo.characterInfo[charId].vertexIndex;
    //    vertexColours = textInfo.meshInfo[matIndex].colors32;
    //    Debug.Log(matIndex);

    //    byte cAlpha = (byte)Mathf.Clamp(alpha, 0, 255);
    //    Color colour = new(255,255,255,cAlpha);

    //    vertexColours[vertexIndex + 0] = colour;
    //    vertexColours[vertexIndex + 1] = colour;
    //    vertexColours[vertexIndex + 2] = colour;
    //    vertexColours[vertexIndex + 3] = colour;

    //    //textInfo.characterInfo[charId].color.a = cAlpha;
    //}

    public void UpdateText(string newText)
    {
        //text.text = newText;
        //int currentCharacter = 0;
        //int maxCharacters = text.text.Length;

        //while (currentCharacter < maxCharacters)
        //{
        //    SetCharAplha(currentCharacter, 0);
        //    currentCharacter++;
        //}
        //text.alpha = 0;

        StartCoroutine(AnimateText(newText));
    }
}
