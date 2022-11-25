using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTest : MonoBehaviour
{
    int _count;



    public void Increment()
    {
        _count++;
        Debug.Log(_count);
    }

    public void VectorEvent(Vector2 input)
    {
        Debug.Log(input);
    }
}
