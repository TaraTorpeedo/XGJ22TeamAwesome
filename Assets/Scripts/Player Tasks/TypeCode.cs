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

    [SerializeField] ScriptFactory ScriptFactory;


    Script Script = new Script();
    string _raw;
    [SerializeField] IntData typeState;
    protected override void Start()
    {
        base.Start();
        SetState(-1);
        Screen = GetComponent<TextMeshPro>();
        GetRandomScript();
        
        ResetMe();
    }

    private void GetRandomScript()
    {
        ScriptFactory.CreateRandomOfTypeT(Script);
        _raw = Script.GetRawText();
        Screen.text = Script.GenerateMethodOfTypeT();
        Debug.Log($"get new type script {Script.MethodType} {Script.Name}");
        Debug.Log(_raw);
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
        StartTyping();
    }

    private void OnDisable()
    {
        Debug.Log("Disabled");
        ResetMe();
    }

    void TypeText()
    {
        if (Screen.maxVisibleCharacters < _raw.Length)
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
        GetRandomScript();
        _raw = Script.GetRawText();
        Screen.maxVisibleCharacters = 0;
    }

    public override void Raise()
    {
        base.Raise();
        ResetMe();
        SetState(1);
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
