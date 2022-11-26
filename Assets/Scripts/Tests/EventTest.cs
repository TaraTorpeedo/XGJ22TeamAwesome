using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventTest : MonoBehaviour
{
    int _count;

    [SerializeField] TextMeshPro UI;

    private void Start()
    {
        UI = GetComponent<TextMeshPro>();
        if (UI != null)
        {
            UI.maxVisibleWords = 0;
        }
    }

    public void NextWord()
    {
        Debug.Log("hsdgfls");
        UI.maxVisibleWords++;
    }


    public void Increment()
    {
        _count++;
        Debug.Log(_count);
    }

    public void VectorEvent(Vector2 input)
    {
        Debug.Log(input);
    }


}
