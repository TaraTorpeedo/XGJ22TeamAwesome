using UnityEngine;
using TMPro;

public class CommitEvent : BaseTask
{
    public GameObject pushButton;
    public GameObject commitButton;
    public GameObject fetchButtonUI;
    public GameObject pushButtonUI;
    public TMP_InputField commitInput;
    public GameObject gitWindow;
    public string commitInputText;


    protected override void Start()
    {
        base.Start();
        commitInputText = commitInput.text;
        ResetMe();
    }
    public void GitButtonsEvent()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.name == commitButton.gameObject.name)
            {
                Debug.Log("AAAAAAAAA");
                pushButtonUI.SetActive(true);
                pushButton.SetActive(true);
                fetchButtonUI.SetActive(false);
                commitInput.text = string.Empty;
                AudioManager.instance.Play("Typing");
            }
            if (hit.transform.name == pushButton.name)
            {
                AudioManager.instance.Play("Click");
                Complete();
            }
        }
    }
    private void OnDisable() => ResetMe();

    protected override void ResetMe()
    {
        commitInput.text = commitInputText;
        pushButtonUI.SetActive(false);
        pushButton.SetActive(false);
        fetchButtonUI.SetActive(true);
    }
    public override void Raise()
    {
        base.Raise();
        Started.Invoke();
        ResetMe();
        Cursor.lockState = CursorLockMode.Confined;
    }
    public override void Hide()
    {
        base.Hide();
        Cursor.lockState = CursorLockMode.None;
    }


    public override void Complete()
    {
        base.Complete();
        Completed.Invoke();
    }
}
