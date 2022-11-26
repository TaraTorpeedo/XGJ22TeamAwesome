using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Task Manager", menuName = "Custom/Task Manager")]
public class TaskManager : ScriptableObject
{
    List<IGameTask> tasks = new List<IGameTask>();

    public void ActivateRandomTask(IGameTask previousTask)
    {
        previousTask.Hide();
        int rand = Random.Range(0, tasks.Count);
        tasks[rand].Raise();
        Debug.Log($"Start task {rand}");
    }

    public void ActivateFirstTask()
    {
        tasks[0].Raise();
    }

    public void Add(IGameTask obj)
    {
        tasks.Add(obj);
    }


    public void Remove(IGameTask obj)
    {
        tasks.Remove(obj);
    }

}
