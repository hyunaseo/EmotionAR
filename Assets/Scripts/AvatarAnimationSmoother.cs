using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Movement.AnimationRigging; // RetargetingLayer의 namespace 추가

public class AvatarAnimationSmoother : MonoBehaviour
{
    public Animator animator;
    public float blendDuration = 1f;
    public RetargetingLayer retargetingLayer;

    private bool isblending = false;
    private float blendWeight = 0;
    private float blendStartTime; 

    // Update is called once per frame
    void Update()
    {
        if (isblending){
            float elapsed = Time.time - blendStartTime;
            blendWeight = Mathf.Clamp01(elapsed/blendDuration);
            animator.SetLayerWeight(1, blendWeight);

            if(blendWeight >= 1f){
                isblending = false;
            }
        }
    }


    public void StartAnimationA(){
        if (isblending) return;
        blendStartTime = Time.time;
        isblending = true;

        animator.Play("AngryAnimationClip", 1, 0);

        retargetingLayer.enabled = false;
    }
}
