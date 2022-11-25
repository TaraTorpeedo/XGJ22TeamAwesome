using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Input Event", menuName = "Custom/InputEvent")]
public class InputEvent : ScriptableObject
{
    List<InputEventListener> listeners = new List<InputEventListener>();

    public void Raise()
    {
        foreach (var listener in listeners)
        {
            listener.Invoke();
        }
    }

    public void AddListener(InputEventListener listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(InputEventListener listener)
    {
        listeners.Remove(listener);
    }
}
