using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ReactivParticle : MonoBehaviour
{
    IntReactiveProperty Reactive;
    [SerializeField] IntData data;
    ParticleSystem effect;
    // Start is called before the first frame update
    void Start()
    {
        if (data == null) return;
        effect = GetComponent<ParticleSystem>();
        Reactive = new IntReactiveProperty(data.Value);
        Reactive
            .ObserveEveryValueChanged(v => data.Value)
            .TakeUntilDisable(this)
            .Subscribe(d => 
            {
                if (data.Value == 1) effect.Play();
                else effect.Stop();
            });

    }

}
