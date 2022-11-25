using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Vector Input Event", menuName = "Custom/Vector Input Event")]

public class VectorInputEvent : ScriptableObject
{
    List<VectorInputEventListener> listeners = new List<VectorInputEventListener>();

    public void Raise(Vector2 input)
    {
        foreach (var listener in listeners)
        {
            listener.Invoke(input);
        }
    }

    public void AddListener(VectorInputEventListener listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(VectorInputEventListener listener)
    {
        listeners.Remove(listener);
    }
}
