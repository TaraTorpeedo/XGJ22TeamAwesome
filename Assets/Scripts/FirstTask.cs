using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTask : MonoBehaviour
{
    [SerializeField] TaskManager taskManager;
    [SerializeField] IntData TasksDone;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        TasksDone.Value = 0;
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForEndOfFrame();
        taskManager.ActivateFirstTask();
    }
}
