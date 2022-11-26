using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingNPC : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;

    public Transform[] walkPoints;
    int pointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(NextPosition());
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.velocity.sqrMagnitude > 1f)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);

        }
    }

    IEnumerator NextPosition()
    {
        int random = Random.Range(3, 20);

        agent.SetDestination(walkPoints[pointIndex].position);
        if (pointIndex == walkPoints.Length - 1)
        {
            pointIndex = 0;
        }
        else
        {
            pointIndex++;   
        }

        yield return new WaitForSeconds(random);

        StartCoroutine(NextPosition());
    }
    
}
