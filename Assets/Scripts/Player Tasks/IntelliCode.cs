using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntelliCode : BaseTask
{

    TextMeshPro Screen;
    Script _script;

    SuggestionCode _suggestionCode;

    int _visibleCharacters;
    // Start is called before the first frame update
    void Start()
    {
        _visibleCharacters = 0;
        Screen = GetComponent<TextMeshPro>();
        _script = new Script()
        {
            MethodType = "void",
            Name = "PressTab",
            ArgumentType = "int",
            Argument = "state",
            Member = "_input",
            MemberFunction = "TabAction",
            CodeBlock = "Jotain"
        };
        _suggestionCode = transform.parent.GetComponentInChildren<SuggestionCode>();
        _suggestionCode.SetSuggestionText(_script.PlaceholderText());
    }

    public void AutoComplete()
    {
        if(Screen != null)
            Screen.text = _script.GenerateCode();
    }

    public void TabText()
    {

    }

    IEnumerator TypeNextLine()
    {
        yield return null;
    }

    /*
     On start: type code up to method
    enable input event listener and show auto complete

     
     */
}
