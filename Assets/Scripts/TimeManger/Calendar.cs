using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    Animator anim;

    public TimeManager timeManager;

    bool isNewDay = true;

    public GameObject FridayCard, SaturdayCard;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeManager != null)
        {
            if (timeManager.GetHour() > 23 && timeManager.GetMinutes() > 59)
            {
                if (isNewDay)
                {
                    isNewDay = false;

                    if (!anim.GetBool("isSaturday"))
                    {
                        anim.SetBool("isSaturday", true);
                        StartCoroutine(destroyCard(FridayCard));
                    }

                    else if (!anim.GetBool("isSunday"))
                    {
                        anim.SetBool("isSunday", true);
                        StartCoroutine(destroyCard(SaturdayCard));
                    }
                    else
                    {
                        Debug.Log("Win");
                        Time.timeScale = 0;
                    }
                }

            }
            if (timeManager.GetHour() < 2)
            {
                isNewDay = true;
            }
        }
    }

    IEnumerator destroyCard(GameObject card)
    {
        yield return new WaitForSeconds(3);
        card.SetActive(false);
    }
}
