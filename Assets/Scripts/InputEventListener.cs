using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputEventListener : MonoBehaviour
{
    [SerializeField] InputEvent _inputEvent;
    [SerializeField] UnityEvent _respone;
    

    public void Invoke()
    {
        _respone.Invoke();
    }
    private void OnEnable()
    {
        _inputEvent.AddListener(this);
    }
    private void OnDisable()
    {
        _inputEvent.RemoveListener(this);
    }
}
