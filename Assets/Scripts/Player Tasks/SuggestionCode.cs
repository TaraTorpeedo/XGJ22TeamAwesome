using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SuggestionCode : MonoBehaviour
{

    TextMeshPro Screen;

    int maxCharacters;
    
    public void Initialize()
    {
        Screen = GetComponent<TextMeshPro>();
    }

    public int CountOfVisibleCharacters()
    {
        return Screen.maxVisibleCharacters;
    }

    public void SetSuggestionText(string text)
    {
        Screen.text = text;
        Screen.maxVisibleLines = 1;
        maxCharacters = Screen.text.Length;
        Debug.Log($"Max visible characters {maxCharacters} / {Screen.maxVisibleLines} lines");
    }

    public void ShowNextLine()
    {
        Debug.Log($"Max visible characters {maxCharacters} / {Screen.maxVisibleLines} lines");
        if (maxCharacters > Screen.maxVisibleCharacters)
        {
            Screen.maxVisibleLines++;
        }
    }

}
