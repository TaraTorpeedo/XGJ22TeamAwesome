using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Programmer : MonoBehaviour, IInputReceiver
{

    [SerializeField] InputEvent RightClick;
    [SerializeField] InputEvent LeftClick;
    [SerializeField] InputEvent Space;
    [SerializeField] InputEvent Enter;
    [SerializeField] InputEvent Backspace;
    [SerializeField] InputEvent Tab;
    [SerializeField] VectorInputEvent Wasd;
    [SerializeField] InputEvent Esc;

    void Awake()
    {
#if UNITY_EDITOR
        Debug.unityLogger.logEnabled = true;
#else
	    Debug.unityLogger.logEnabled = false;
#endif
    }


    public void OnRightClick(int state)
    {
        if (state == 1)
            RightClick.Raise();
    }

    public void OnLeftClick(int state)
    {
        if (state == 1)
            LeftClick.Raise();
    }

    public void OnPressSpace(int state)
    {
        if (state == 1)
            Space.Raise();
    }

    public void OnPressBackSpace(int state)
    {
        if (state == 1)
            Backspace.Raise();
    }

    public void OnPressEnter(int state)
    {
        if (state == 1)
            Enter.Raise();
    }

    public void OnPressEsc(int state)
    {
        if (state == 1)
            Esc.Raise();
    }

    public void OnPressTab(int state)
    {
        if (state == 1)
            Tab.Raise();
    }
    public void OnWASD(Vector2 wasd)
    {
        Wasd.Raise(wasd);
    }
}
