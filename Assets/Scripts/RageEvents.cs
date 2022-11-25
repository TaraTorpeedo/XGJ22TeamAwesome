using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RageEvents : MonoBehaviour
{
    bool EventIsOn = false;

    //ClickEventVariables
    int clicks;
    public int clicksNeeded;
    public KeyCode[] KeysToSmash;
    KeyCode TheKey;
    public Slider RageSlider;
    public TextMeshProUGUI KeyIndicator;

    public TextMeshProUGUI SwearText;
    public string[] SwearWords;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            InitValues();
        }

        CallRageEvent(0);
    }

    public void HitMonitor()
    {
        if (EventIsOn)
        {
            RageSlider.value += 0.01f;

            if (Input.GetKeyDown(TheKey))
            {
                clicks++;
                RageSlider.value -= 0.2f;
                if (clicks >= clicksNeeded)
                {
                    Debug.Log("You did it");
                    ResetValues();
                    EventIsOn = false;
                }
            }

            if (RageSlider.value >= RageSlider.maxValue)
            {
                Debug.Log("Lose");
                EventIsOn = false;
            }
        }
    }

    public void CallRageEvent(int RageEventIndex)
    {
        if (RageEventIndex == 0)
            HitMonitor();
    }

    void ResetValues()
    {
        RageSlider.value = 0;
        clicks = 0;
        KeyIndicator.gameObject.SetActive(false);
        SwearText.gameObject.SetActive(false);
    }
    void InitValues()
    {
        if (!EventIsOn)
        {
            EventIsOn = true;

            int random = Random.Range(0, KeysToSmash.Length);
            TheKey = KeysToSmash[random];
            KeyIndicator.gameObject.SetActive(true);
            KeyIndicator.text = TheKey.ToString();

            random = Random.Range(0, SwearWords.Length);
            SwearText.gameObject.SetActive(true);
            SwearText.text = SwearWords[random];
        }
    }
}


