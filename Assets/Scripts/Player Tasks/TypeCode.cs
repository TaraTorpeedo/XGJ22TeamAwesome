using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TypeCode : BaseTask
{
    [SerializeField] TextMeshProUGUI UI;
    [TextArea(15,20)]
    [SerializeField] string _codeBlock;
    [SerializeField] float _typingSpeed;

    WaitForSeconds _typingDelay;

    
    private void Start()
    {
        _typingDelay = new WaitForSeconds(_typingSpeed);
        UI.text = _codeBlock;
        UI.maxVisibleCharacters = 0;
        
    }

    public void StartTyping()
    {
        StartCoroutine(TypeText());

    }

    IEnumerator TypeText()
    {
        var indexes = _codeBlock.AllIndexesOf("<color");
        yield return new WaitForEndOfFrame();
        Started.Invoke();

        UI.maxVisibleCharacters = 0;
        while (UI.maxVisibleCharacters < _codeBlock.Length-(indexes.Count()*11*2))
        {
            UI.maxVisibleCharacters = UI.maxVisibleCharacters + 1;
            yield return _typingDelay;
        }
        Completed.Invoke();
    }
}
