using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseTask : MonoBehaviour
{
    [SerializeField] protected UnityEvent Started;
    [SerializeField] protected UnityEvent Completed;
}
