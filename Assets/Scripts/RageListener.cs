using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RageListener : MonoBehaviour, IRage
{
    public RageRandomizer rageRandomizer;
    public UnityEvent rageEvent;

    public void InvokeRage()
    {
        rageEvent.Invoke();
    }

    public void Add()
    {
        rageRandomizer.AddListener(this);
    }

    public void Remove()
    {
        rageRandomizer.RemoveListener(this);
    }

    private void OnEnable()
    {
        Add();
    }
    private void OnDisable()
    {
        Remove();
    }
}
