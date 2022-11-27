using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SleepyEvent : BaseTask
{
    [SerializeField] private Volume volume;
    [SerializeField] private float blinkSpeedMin = 0.5f;
    [SerializeField] private float blinkSpeedMax = 1.5f;
    [SerializeField] private GameObject cup;
    [SerializeField] private Transform cupPosition;
    [SerializeField] private Animator animator;

    private Vignette vignette = null;
    private float eyesCloseValue = 0.0f;
    private float eyesOpenValue = 0.9f;
    private bool isCoffeeDrinked = true;
    private bool isDrinking = false;
    private Vector3 cupPos;

    protected override void Start()
    {
        base.Start();
        cupPos = cup.transform.position;
        volume.sharedProfile.TryGet<Vignette>(out vignette);
        ResetMe();
    }

    public void Update()
    {
        if (vignette != null)
        {
            if (isCoffeeDrinked == false)
            {
                SleepyEyes();
            }
        }

        DrinkAnimation();
    }

    private void DrinkAnimation()
    {
        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "TakeCup")
        {
            if (animator.GetAnimatorTransitionInfo(0).normalizedTime >= 0.9f)
            {
                animator.SetBool("IsDrinking", false);
                isDrinking = true;
            }
        }

        if (isDrinking)
        {
            cup.transform.position = cupPosition.gameObject.transform.position;
        }

        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "SipDone")
        {
            if (animator.GetAnimatorTransitionInfo(0).normalizedTime >= 0.9f)
            {
                isDrinking = false;
                AudioManager.instance.Play("Cup");
            }
        }

        if (!isDrinking)
        {
            cup.transform.position = cupPos;
        }
    }

    public void SleepyEyes()
    {
        if (eyesCloseValue < 0.9f)
        {
            eyesCloseValue += ApplyBlink();
            vignette.intensity.value = eyesCloseValue;
        }
        else if (eyesOpenValue > 0.0f)
        {
            eyesOpenValue -= ApplyBlink();
            vignette.intensity.value = eyesOpenValue;
        }
        else
        {
            ResetEyesValue();
        }
    }

    public void DrinkCoffee()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.name == cup.name)
            {
                isCoffeeDrinked = true;
                vignette.intensity.value = 0.0f;
                ResetEyesValue();
                animator.SetBool("IsDrinking", true);
                Complete();
            }
        }

    }
    
    private void ResetEyesValue()
    {
        eyesOpenValue = 0.9f;
        eyesCloseValue = 0.0f;
    }

    private float ApplyBlink() => Random.Range(0.01f, 2f) * Random.Range(blinkSpeedMin, blinkSpeedMax) * Time.deltaTime;

    protected override void ResetMe()
    {
        cupPos = cup.transform.position;
        ResetEyesValue();
    }

    public override void Raise()
    {
        SleepyEyes();
        ResetMe();
        isCoffeeDrinked = false;
    }

    public override void Hide()
    {
        vignette.intensity.value = 0;
        isCoffeeDrinked = true;
    }

    public override void Complete()
    {
        base.Complete();
        isCoffeeDrinked = true;
    }


    private void OnDisable() => ResetMe();
}
