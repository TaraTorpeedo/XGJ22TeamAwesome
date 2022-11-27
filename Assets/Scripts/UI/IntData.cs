using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New IntData", menuName = "Custom/Data/Int")]
public class IntData : ScriptableObject
{
    public int Value { get; set; }
    [SerializeField] int _max;

    public int Max() { return _max; }

    public void Increment()
    {
        Value++;
    }

}
