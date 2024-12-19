using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class ChangeAnimator : MonoBehaviour
{
    public Avatar avatarToAssign;
    public string id;

    private bool hasUpdated = false;

    void Update()
    {
        // Check if the script has already performed its task
        if (hasUpdated)
            return;

        // Find the GameObject with the name matching the ID
        GameObject idGameObject = GameObject.Find(id);
        if (idGameObject != null)
        {
            // Find the GameObject named "AvatarMirrored"
            GameObject mirroredGameObject = GameObject.Find("AvatarMirrored");

            if (mirroredGameObject != null)
            {
                // Get the Animator components from the found GameObjects
                Animator idAnimator = idGameObject.GetComponent<Animator>();
                Animator mirroredAnimator = mirroredGameObject.GetComponent<Animator>();

                // Ensure both GameObjects have Animator components
                if (idAnimator != null && mirroredAnimator != null)
                {
                    // Assign the avatar to both animators
                    idAnimator.avatar = avatarToAssign;
                    mirroredAnimator.avatar = avatarToAssign;

                    Debug.Log("Avatar updated for both animators.");

                    // Mark as updated to prevent further execution
                    hasUpdated = true;
                }
                else
                {
                    Debug.LogWarning("One or both of the GameObjects do not have an Animator component.");
                }
            }
            else
            {
                Debug.LogWarning("GameObject with the name 'AvatarMirrored' not found in the scene.");
            }
        }
    }
}