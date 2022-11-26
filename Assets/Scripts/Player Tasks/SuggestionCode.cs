using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SuggestionCode : MonoBehaviour
{

    TextMeshPro Screen;

    int visibleLines;
    // Start is called before the first frame update
    void Awake()
    {
        Screen = GetComponent<TextMeshPro>();
        visibleLines = 0;
        Screen.maxVisibleLines = visibleLines;
    }

    public void SetSuggestionText(string text)
    {
        Screen.text = text;
    }

    public void ShowNextLine()
    {
        visibleLines++;
        Screen.maxVisibleLines = visibleLines;
    }
}
