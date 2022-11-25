using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    IInputReceiver _inputReceiver;

    private void Start()
    {
        _inputReceiver = GetComponent<IInputReceiver>();
    }

    public void OnRightClick(InputAction.CallbackContext ctx)
    {
        _inputReceiver.OnRightClick(ctx.performed ? 1 : 0);
    }
    public void OnLeftClick(InputAction.CallbackContext ctx)
    {
        _inputReceiver.OnLeftClick(ctx.performed ? 1 : 0);
    }
    public void OnPressSpace(InputAction.CallbackContext ctx)
    {
        _inputReceiver.OnPressSpace(ctx.performed ? 1 : 0);
    }

    public void OnPressTab(InputAction.CallbackContext ctx)
    {
        _inputReceiver.OnPressTab(ctx.performed ? 1 : 0);
    }

    public void OnPressWASD(InputAction.CallbackContext ctx)
    {
        _inputReceiver.OnWASD(ctx.ReadValue<Vector2>());
    }

    public void OnPressEsc(InputAction.CallbackContext ctx)
    {
        _inputReceiver.OnPressEsc(ctx.performed ? 1 : 0);
    }


    public void OnPressBackSpace(InputAction.CallbackContext ctx)
    {
        _inputReceiver.OnPressBackSpace(ctx.performed ? 1 : 0);
    }

    public void OnPressEnter(InputAction.CallbackContext ctx)
    {
        _inputReceiver.OnPressEnter(ctx.performed ? 1 : 0);
    }

}
