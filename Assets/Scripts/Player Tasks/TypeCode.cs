using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TypeCode : BaseTask
{
     TextMeshPro Screen;
    [TextArea(15, 20)]
    [SerializeField] string _codeBlock;
    [SerializeField] float _typingSpeed;

    
    Script _script;
    string raw;

    [SerializeField] IntData typeState;
    protected override void Start()
    {
        base.Start();
        SetState(-1);
        _script = Script.CreateRandomOfTypeT();
        Screen = GetComponent<TextMeshPro>();
        Screen.text = _script.GenerateMethodOfTypeT();
        ResetMe();
    }

    private void SetState(int state)
    {
        typeState.Value = state;
    }

    public void StartTyping()
    {
        if (typeState.Value == 1)
            TypeText();

    }

    public void TypeCodeStuff(Vector2 v)
    {
        Debug.Log("typing");
        StartTyping();
    }

    private void OnDisable()
    {
        Debug.Log("Disabled");
        ResetMe();
    }

    void TypeText()
    {
        if (Screen.maxVisibleCharacters < raw.Length)
        {
            Screen.maxVisibleCharacters = Screen.maxVisibleCharacters + 1;
        }
        else
        {

            Completed.Invoke();
            Complete();
        }
    }

    protected override void ResetMe()
    {
        Screen.enabled = true;
        _script = Script.CreateRandomOfTypeT();
        raw = _script.GetRawText();
        Screen.maxVisibleCharacters = 0;
    }

    public override void Raise()
    {
        base.Raise();
        SetState(1);
        ResetMe();
    }

    public override void Hide()
    {
        base.Hide();
        Screen.enabled = false;
        SetState(-1);
    }

    public override void Complete()
    {
        SetState(-1);
        base.Complete();
    }
}
