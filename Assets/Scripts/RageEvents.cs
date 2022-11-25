using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageEvents : MonoBehaviour
{
    bool doTheHit = false;

    void Start()
    {
        HitMonitor();
    }

    private void Update()
    {
        
    }


    public void HitMonitor()
    {
        doTheHit = true;
        int clicks = 0;
        StartCoroutine(SmashCounter(5, 20, clicks));
    }

    IEnumerator SmashCounter(int time, int clicskNeeded, int clicks)
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            clicks++;
            Debug.Log(clicks);
            if (clicks >= clicskNeeded)
            {
                doTheHit = false;
                Debug.Log("You did it");
                yield return null;
            }
        }

        yield return new WaitForSeconds(time);

        if (doTheHit)
        {
            Debug.Log("Lose");
        }
    }

}
