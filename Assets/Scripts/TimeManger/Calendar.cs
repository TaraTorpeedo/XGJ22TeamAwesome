using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Calendar : MonoBehaviour
{
    Animator anim;

    public TimeManager timeManager;
    public GameObject WinnerScreen;

    bool isNewDay = true;
    bool saturdayDone = false;

    public GameObject FridayCard, SaturdayCard;
    [SerializeField] UnityEvent Failed;
    public int StartHour;
    [SerializeField] IntData TasksDone;
    [SerializeField] IntData WinCondition;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeManager != null)
        {
            if (timeManager.GetHour() > 23 - StartHour && timeManager.GetMinutes() > 59)
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
                        saturdayDone = true;
                    }
                }

            }
            if (timeManager.GetHour() < 2)
            {
                isNewDay = true;
            }

            if (saturdayDone)
            {
                if (timeManager.GetHour() - StartHour * -1 >= StartHour)
                {
                    if (timeManager.GetHour() - StartHour * -1 < 20)
                    {
                        if (TasksDone.Value >= WinCondition.Max())
                        {

                            WinnerScreen.SetActive(true);
                            Time.timeScale = 0;
                        }
                        else
                        {
                            Failed.Invoke();
                        }
                    }
                }
            }
        }
    }

    IEnumerator destroyCard(GameObject card)
    {
        yield return new WaitForSeconds(3);
        card.SetActive(false);
    }
}
