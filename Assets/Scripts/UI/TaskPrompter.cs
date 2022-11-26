using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPrompter : MonoBehaviour
{
    [SerializeField] string _prompt;
    [SerializeField] StringData _promptData;

    private void OnEnable()
    {
        _promptData.Set(_prompt);
    }

    private void OnDisable()
    {
        _promptData.Set("");
    }

}
