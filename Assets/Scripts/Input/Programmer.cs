using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Programmer : MonoBehaviour, IInputReceiver
{
    public void OnLeftClick(int state)
    {
        Debug.Log($"Left click {state}");
    }

    public void OnPressBackSpace(int state)
    {
        throw new System.NotImplementedException();
    }

    public void OnPressEnter(int state)
    {
        throw new System.NotImplementedException();
    }

    public void OnPressEsc(int state)
    {
        throw new System.NotImplementedException();
    }

    public void OnPressSpace(int state)
    {
        throw new System.NotImplementedException();
    }

    public void OnPressTab(int state)
    {
        throw new System.NotImplementedException();
    }

    public void OnRightClick(int state)
    {
        Debug.Log(state);
    }

    public void OnWASD(Vector2 wasd)
    {
        throw new System.NotImplementedException();
    }
}
