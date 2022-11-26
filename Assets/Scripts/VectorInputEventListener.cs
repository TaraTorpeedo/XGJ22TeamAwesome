using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VectorInputEventListener : MonoBehaviour
{
    [SerializeField] VectorInputEvent _inputEvent;
    [SerializeField] UnityEvent<Vector2> Response;


    public void Invoke(Vector2 input)
    {
        Response.Invoke(input);
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
