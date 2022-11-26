using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntelliCode : BaseTask
{

    TextMeshPro Screen;
    Script _script;


    [SerializeField] float typingSpeed = 0.1f;
    int length;
    string raw;
    WaitForSeconds TypingDelay;
    // Start is called before the first frame update
    void Start()
    {
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
        InitializeScreen();
    }

    private void InitializeScreen()
    {
        TypingDelay = new WaitForSeconds(typingSpeed);

        Screen = GetComponent<TextMeshPro>();
        Screen.text = _script.GenerateCode();
        Screen.maxVisibleCharacters = 0;
    }


    public void AutoComplete()
    {
        if (Screen != null)
            StartCoroutine(TypeNextLine());
    }

    public void SuggestCode()
    {
        Screen.text = _script.PlaceholderText();
    }

    public void TabText()
    {
        Debug.Log("Complete");
        Screen.text = _script.GenerateCode();
    }

    IEnumerator TypeNextLine()
    {
        yield return new WaitForEndOfFrame();
        Started.Invoke();
        Screen.maxVisibleCharacters = 0;
        raw = _script.GetRawText();
        length = raw.Length;
        while (length > Screen.maxVisibleCharacters)
        {
            Screen.maxVisibleCharacters++;
            if (raw[Screen.maxVisibleCharacters - 1] == '.')
            {
                yield return new WaitForSeconds(2f);
                Screen.maxVisibleCharacters += _script.Member.Length + _script.MemberFunction.Length + 4;
                break;
            }
            yield return TypingDelay;
        }
        Completed.Invoke();
    }

    /*
     On start: type code up to method
    enable input event listener and show auto complete
    on complete next line: show next suggestion
     
     */
}
