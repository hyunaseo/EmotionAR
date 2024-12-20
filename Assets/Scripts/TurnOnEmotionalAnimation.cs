using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnEmotionalAnimation : MonoBehaviour
{
    public GameObject OriginalAvatar;
    public GameObject OriginalAvatarFace;
    public GameObject OriginalAvatarBody;
    public GameObject AngryAvatar;

    public GameObject OriginalHip;
    public GameObject AngryHip;

    private bool isAnimationOn = false;

    public enum EmotionType{
        Neutral, 
        Happy, 
        Angry, 
        Disgust, 
        Sad, 
        Fearful, 
        Surprised
    }

    public void Update(){

    }

    public void OnEmotionalAnimation(){
        if(!isAnimationOn){
            AngryHip.transform.position = OriginalHip.transform.position;

            OriginalAvatarFace.SetActive(false);
            OriginalAvatarBody.SetActive(false);

            AngryAvatar.SetActive(true);

            isAnimationOn = true;
        }
        else{
            OriginalAvatarFace.SetActive(true);
            OriginalAvatarBody.SetActive(true);

            AngryAvatar.SetActive(false);

            isAnimationOn = false;
        }
    }

}
