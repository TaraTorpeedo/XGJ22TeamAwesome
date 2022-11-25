using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Rage Randomizer", menuName = "Custom/Rage Randomizer")]
public class RageRandomizer : ScriptableObject
{
    List<IRage> listeners = new List<IRage>();

    public void RaiseRandomRage()
    {
        int rand = Random.Range(0, listeners.Count);
        listeners[rand].InvokeRage();
        
    }

    public void AddListener(IRage listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(IRage listener)
    {
        listeners.Remove(listener);
    }
}
