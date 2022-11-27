using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RageEvents : MonoBehaviour
{
    public bool EventIsOn = false;
    public GameObject GameOverScreen;

    //ClickEventVariables
    int clicks;
    public int clicksNeeded;
    public KeyCode[] KeysToSmash;
    KeyCode TheKey;
    public GameObject RagePanel;
    public Slider RageSlider;
    public Image SliderFill;
    public TextMeshProUGUI KeyIndicator;
    public float rageIntencity;

    public TextMeshProUGUI SwearText;
    public string[] SwearWords;

    public GameObject PcScreen;
    public GameObject MonitorCanvas;

    public GameObject Player;
    [SerializeField] TaskManager TaskManager;
    private void Update()
    {
        if (EventIsOn)
        {
            CallRageEvent(0);
        }
    }

    public void HitMonitor()
    {
        if (EventIsOn)
        {
            //AudioManager.instance.Play("Rage");
            RageSlider.value += Time.deltaTime * rageIntencity;
            SliderFill.color = new Color(1, 1 - RageSlider.value / 10, 1 - RageSlider.value / 10);
            Player.GetComponent<Animator>().SetBool("IsRaging", true);
            RagePanel.SetActive(true);

            if (Input.GetKeyDown(TheKey))
            {
                clicks++;
                RageSlider.value -= 0.2f;
                if (DefeatedRage())
                {
                    Player.GetComponent<Animator>().SetBool("Chill", true);
                    Player.GetComponent<Animator>().SetBool("IsRaging", false);
                    ResetValues();
                    EventIsOn = false;
                    RagePanel.SetActive(false);
                    TaskManager.ActivateRandomTask();
                }
            }

            if (RageSlider.value >= RageSlider.maxValue)
            {
                Lose();
            }
        }
    }

    private bool DefeatedRage()
    {
        return clicks >= clicksNeeded;
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
        StartCoroutine(ResetAnimation());   
        KeyIndicator.gameObject.SetActive(false);
        SwearText.gameObject.SetActive(false);
    }
    public void InitValues()
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

    void Lose()
    {
        EventIsOn = false;

        RagePanel.SetActive(false);

        Player.GetComponent<Animator>().SetBool("Chill", false);
        Player.GetComponent<Animator>().SetBool("IsRaging", false);
        Player.GetComponent<Animator>().SetBool("HitMonitor", true);

        StartCoroutine(MonitorFly());


    }

    IEnumerator ResetAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        Player.GetComponent<Animator>().SetBool("Chill", false);
    }

    IEnumerator MonitorFly()
    {
        yield return new WaitForSeconds(0.3f);
        MonitorCanvas.SetActive(false);
        PcScreen.GetComponent<Rigidbody>().isKinematic = false;
        PcScreen.GetComponent<Rigidbody>().velocity = Vector3.up * 5f;
        PcScreen.GetComponent<Rigidbody>().velocity = Vector3.forward * -7f;

        yield return new WaitForSeconds(0.5f);
        GameOverScreen.SetActive(true);

    }

}


