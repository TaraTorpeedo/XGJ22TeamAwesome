using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Unity.Burst.Intrinsics.X86.Avx;

public class CommitEvent : MonoBehaviour
{
    public GameObject pushButton;
    public GameObject commitButton;
    public GameObject fetchButtonUI;
    public GameObject pushButtonUI;
    public TMP_InputField commitInput;
    public void GitButtonsEvent()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.name == commitButton.name)
            {
                pushButtonUI.SetActive(true);
                pushButton.SetActive(true);
                fetchButtonUI.SetActive(false);
                commitInput.text = string.Empty;
                AudioManager.instance.Play("Typing");
            }
            if (hit.transform.name == pushButton.name)
            {
                AudioManager.instance.Play("Click");
                //taski complite
            }
        }
    }
}
