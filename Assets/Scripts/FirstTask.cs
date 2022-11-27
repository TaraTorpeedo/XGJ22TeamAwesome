using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTask : MonoBehaviour
{
    [SerializeField] TaskManager taskManager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForEndOfFrame();
        taskManager.ActivateFirstTask();
    }
}
