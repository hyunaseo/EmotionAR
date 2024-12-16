using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimator : MonoBehaviour
{
    public string avatarID;
    public Avatar correctAnimation;

    private bool isUpdated = false;

    void Update()
    {
        if (!isUpdated)
        {
            GameObject avatarObject = GameObject.Find(avatarID);

            if (avatarObject != null)
            {
                Animator animator = avatarObject.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.avatar = correctAnimation;
                    isUpdated = true; // Mark as updated to prevent further execution
                }
                else
                {
                    Debug.LogWarning($"Animator component not found on GameObject '{avatarID}'.");
                }
            }
        }
    }
}
