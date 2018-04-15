using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeAnimationOnEnable : MonoBehaviour {
    public Animator anim;
    private void OnEnable()
    {
        anim.speed = 1;
    }
}
