using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingNPC : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        float rnd = Random.Range(0.5f, 1.5f);
        anim.speed = rnd;

    }
}
