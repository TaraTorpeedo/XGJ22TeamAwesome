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
    protected RectTransform rect;
    [SerializeField]protected StringData errorMessage;
    [SerializeField] protected string message;
    [SerializeField] protected IntData TasksDone;
    protected virtual void Start()
    {
        rect = GetComponent<RectTransform>();
        taskManager.Add(this);
    }

    public virtual void Complete()
    {
        TasksDone.Increment();
        StartCoroutine(TaskIntermission());
    }

    protected IEnumerator TaskIntermission()
    {
        yield return new WaitForSeconds(2f);
        Hide();
        rageManager.RaiseRandomRage();

    }

    public virtual void Hide()
    {
        rect.localScale = Vector2.one;
        errorMessage.Set(message);
    }

    public virtual void Raise()
    {
        rect.localScale = Vector3.one;

    }
    protected abstract void ResetMe();
}
