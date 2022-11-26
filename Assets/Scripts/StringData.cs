using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New String Data", menuName = "Custom/Data/String")]
public class StringData : ScriptableObject
{
    public string Value { get; private set; }

    public void Set(string value)
    {
        Value = value;
    }

    public int Length()
    {
        return Value.Length;
    }


}
