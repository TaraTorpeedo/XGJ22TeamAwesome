using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;

public class StringObserver : MonoBehaviour
{
    StringReactiveProperty stringReactive;
    [SerializeField] StringData data;
    TextMeshProUGUI UI;
    [SerializeField] string _prepend = "";
    [SerializeField] string _append = "";
    // Start is called before the first frame update
    void Start()
    {
        if (data == null) return;
        UI = GetComponent<TextMeshProUGUI>();
        data.Set("");
        stringReactive = new StringReactiveProperty(data.Value);
        stringReactive
            .ObserveEveryValueChanged(v => data.Value)
            .TakeUntilDisable(this)
            .Subscribe(d => UI.text = _prepend + data.Value + _append);
        
    }

}
