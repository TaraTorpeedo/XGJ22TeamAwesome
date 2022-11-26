using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class IntelliCode : BaseTask
{
    [SerializeField] IntData data;
    [SerializeField] UnityEvent PhaseOneCompleted;
    TextMeshPro Screen;
    Script _script;

    int _taskState = 0;
    [SerializeField] float typingSpeed = 0.1f;
    int length;
    string raw;
    WaitForSeconds TypingDelay;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _script = new Script()
        {
            MethodType = "void",
            Name = "PressTab",
            ArgumentType = "int",
            Argument = "state",
            Member = "_input",
            MemberFunction = "TabAction",
        };
        InitializeScreen();
        SetState(-1);
    }

    private void InitializeScreen()
    {
        TypingDelay = new WaitForSeconds(typingSpeed);

        Screen = GetComponent<TextMeshPro>();
        Screen.text = _script.GenerateCode();
        ResetMe();
    }


    public void StartCoding()
    {
        if (Screen != null)
        {
            if(_taskState == 0)
                StartCoroutine(TypeNextLine());
            if (_taskState == 1)
                Complete();
        }
    }

    public void SuggestCode()
    {
        Screen.text = _script.PlaceholderText();
    }

    public override void Complete()
    {
        Debug.Log("Complete");
        SetState(-1);
        Screen.text = _script.GenerateCode();
        Completed.Invoke();
        base.Complete();
    }

    IEnumerator TypeNextLine()
    {
        SetState(-1);
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
                SetState(1);
                break;
            }
            yield return TypingDelay;
        }
        PhaseOneCompleted.Invoke();
    }

    private void SetState(int state)
    {
        _taskState = state;
        data.Value = _taskState;
    }

    private void OnDisable()
    {
        ResetMe();
    }

    protected override void ResetMe()
    {
        Screen.maxVisibleCharacters = 0;
        SetState(0);
    }

    public override void Hide()
    {
        Debug.Log($"Hide {gameObject.name}");
        Screen.enabled = false;
    }

    public override void Raise()
    {
        Screen.enabled = true;
        ResetMe();
        SetState(0);
    }

    /*
     On start: type code up to method
    enable input event listener and show auto complete
    on complete next line: show next suggestion
     
     */
}
