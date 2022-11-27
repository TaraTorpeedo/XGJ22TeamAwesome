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
    [SerializeField] ScriptFactory ScriptFactory;
    TextMeshPro Screen;
    Script Script = new Script();

    int _taskState = 0;
    [SerializeField] float typingSpeed = 0.1f;
    int _length;
    string _raw;
    WaitForSeconds TypingDelay;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        InitializeScreen();
        SetState(-1);
    }

    private void GetRandomScript()
    {
        ScriptFactory.CreateRandom(Script);
        _raw = Script.GetRawText();
        Screen.text = Script.GenerateCode();
        Debug.Log($"Reset intellicode: {Script.MethodType} {Script.Name}");
        Debug.Log(_raw);
    }

    private void InitializeScreen()
    {
        TypingDelay = new WaitForSeconds(typingSpeed);

        Screen = GetComponent<TextMeshPro>();
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
        Screen.text = Script.PlaceholderText();
    }

    public override void Complete()
    {
        Debug.Log("Complete");
        SetState(-1);
        Screen.text = Script.GenerateCode();
        Completed.Invoke();
        base.Complete();
    }

    IEnumerator TypeNextLine()
    {
        SetState(-1);
        yield return new WaitForEndOfFrame();
        Completed.Invoke();
        Screen.maxVisibleCharacters = 0;
        _raw = Script.GetRawText();
        _length = _raw.Length;
        while (_length > Screen.maxVisibleCharacters)
        {
            Screen.maxVisibleCharacters++;
            if (_raw[Screen.maxVisibleCharacters - 1] == '.')
            {
                yield return new WaitForSeconds(2f);
                Screen.maxVisibleCharacters += Script.Member.Length + Script.MemberFunction.Length + 4;
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
        GetRandomScript();
        Screen.maxVisibleCharacters = 0;
        SetState(0);
    }

    public override void Hide()
    {
        base.Hide();
        Debug.Log($"Hide {gameObject.name}");
        Screen.enabled = false;
    }

    public override void Raise()
    {
        base.Raise();
        Screen.enabled = true;
        ResetMe();
        SetState(0);
        Started.Invoke();
    }

    /*
     On start: type code up to method
    enable input event listener and show auto complete
    on complete next line: show next suggestion
     
     */
}
