using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;

public class IntObserver : MonoBehaviour
{
    IntReactiveProperty Reactive;
    [SerializeField] IntData data;
    TextMeshProUGUI UI;
    [SerializeField] string _prepend = "";
    [SerializeField] string _append = "";
    // Start is called before the first frame update
    void Start()
    {
        if (data == null) return;
        UI = GetComponent<TextMeshProUGUI>();
        Reactive = new IntReactiveProperty(data.Value);
        Reactive
            .ObserveEveryValueChanged(v => data.Value)
            .TakeUntilDisable(this)
            .Subscribe(d => UI.text = _prepend + data.Value.ToString() + _append);

    }

}
