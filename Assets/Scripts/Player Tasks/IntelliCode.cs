using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntelliCode : MonoBehaviour
{

    TextMeshPro Screen;
    Script _script;
    // Start is called before the first frame update
    void Start()
    {
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
    }

    public void AutoComplete()
    {
        if(Screen != null)
            Screen.text = _script.GenerateCode();
    }
}
