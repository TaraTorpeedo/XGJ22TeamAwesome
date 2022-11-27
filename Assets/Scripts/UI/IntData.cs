using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New IntData", menuName = "Custom/Data/Int")]
public class IntData : ScriptableObject
{
    public int Value { get; set; }
    public void Increment()
    {
        Value++;
    }

}
