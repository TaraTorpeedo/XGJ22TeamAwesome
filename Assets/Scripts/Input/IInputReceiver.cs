using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputReceiver
{
    void OnRightClick(int state);
    void OnLeftClick(int state);

    void OnPressSpace(int state);
    void OnPressEnter(int state);
    void OnPressTab(int state);

    void OnWASD(Vector2 wasd);

    void OnPressBackSpace(int state);

    void OnPressEsc(int state);
}
