using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseTask : MonoBehaviour, IGameTask
{
    [SerializeField] protected TaskManager taskManager;
    [SerializeField] protected UnityEvent Started;
    [SerializeField] protected UnityEvent Completed;
    [SerializeField] protected RageRandomizer rageManager;

    protected virtual void Start()
    {
        taskManager.Add(this);
    }

    public virtual void Complete()
    {
        StartCoroutine(TaskIntermission());
    }

    protected IEnumerator TaskIntermission()
    {
        yield return new WaitForSeconds(2f);
        Hide();
        rageManager.RaiseRandomRage();

    }

    public abstract void Hide();

    public abstract void Raise();

    [SerializeField] protected abstract void ResetMe();
}
