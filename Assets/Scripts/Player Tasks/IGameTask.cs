using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameTask
{
    void Raise();
    void Hide();
    void Complete();

}
