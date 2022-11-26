using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingNPC : MonoBehaviour
{
    Animator anim;

    public enum SittingPose
    {
        woman,
        man,
        rubbing
    }

    public SittingPose sittingPose;

    // Start is called before the first frame update
    void Start()
    {
        int index;
        anim = GetComponent<Animator>();

        if (sittingPose == SittingPose.woman)
            index = 0;
        else if (sittingPose == SittingPose.man)
            index = 1;
        else
            index = 2;

        anim.SetInteger("sittingIndex", index);

    }

}
