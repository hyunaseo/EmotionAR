using System.Collections.Generic;
using UnityEngine;

public class EmotionCanavasControl : MonoBehaviour
{
    // Inspector에서 할당할 변수들
    public GameObject Neutral;   // Neutral GameObject
    public GameObject[] Emotions = new GameObject[6];  // 1~6번 GameObject들
    public GameObject FaceOn;    // FaceOn GameObject
    public GameObject FaceOff;   // FaceOff GameObject
    public GameObject BodyOn;    // BodyOn GameObject
    public GameObject BodyOff;   // BodyOff GameObject
    public GameObject Finish;

    public bool isTutorialEnd = false; 

    private int gameObjectIndex = -1;
    private int currentStep = 0;   // 현재 단계 (파란버튼 누를 때마다 변경)
    private List<int> remainingEmotions = new List<int>();  
    private int previousStep = -1;  // 빨간 버튼을 눌렀을 때 이전 단계로 돌아가기 위한 변수

    private void Start()
    {
        for (int i = 0; i < Emotions.Length; i++)
        {
            remainingEmotions.Add(i);
        }

        DeactivateAllObjects();
    }

    private void DeactivateAllObjects()
    {
        Neutral.SetActive(false);
        FaceOn.SetActive(false);
        FaceOff.SetActive(false);
        BodyOn.SetActive(false);
        BodyOff.SetActive(false);
        foreach (GameObject obj in Emotions)
        {
            obj.SetActive(false);
        }
    }

    public void OnBlueButtonPressed()
    {
        if (!isTutorialEnd) return;

        switch (currentStep)
        {
            case 0:
                Neutral.SetActive(true);
                FaceOff.SetActive(false);
                BodyOff.SetActive(false);
                break;

            case 1:
                // FaceOn 활성화
                FaceOn.SetActive(true);
                break;

            case 2:
                FaceOn.SetActive(false);
                BodyOn.SetActive(true);
                break;

            case 3: // 여기가 랜덤하게 활성화 하는 파트
                BodyOn.SetActive(false);
                ActivateRandomGameObject();
                break;

            case 4:
                // FaceOn 활성화
                FaceOn.SetActive(true);
                break;

            case 5:
                // FaceOn 비활성화, BodyOn 비활성화
                FaceOn.SetActive(false);
                BodyOn.SetActive(true);
                break;

            case 6:
                BodyOn.SetActive(false);
                DeactivateLastActivatedGameObject();
                ActivateRandomGameObject();
                break;
        }

        // 파란 버튼을 눌렀을 때마다 currentStep을 증가시키고, 마지막 단계에 도달하면 remainingEmotions가 모두 비어있을 때까지 반복
        currentStep++;
        if (currentStep > 6)
        {
            currentStep = 4;
        }
    }

    public void OnRedButtonPressed()
    {
        if (!isTutorialEnd) return;
        
        // 현재 단계가 0보다 크다면 이전 단계로 돌아가기
        if (currentStep > 0)
        {
            currentStep--;

            switch (currentStep)
            {
                case 0:
                    Neutral.SetActive(true);
                    FaceOff.SetActive(true);
                    BodyOff.SetActive(true);
                    break;

                case 1:
                    FaceOn.SetActive(false);
                    Neutral.SetActive(true);
                    break;

                case 2:
                    BodyOn.SetActive(false);
                    FaceOn.SetActive(true);
                    break;

                case 3:
                    DeactivateLastActivatedGameObject();
                    BodyOn.SetActive(true);
                    break;

                case 4:
                    FaceOn.SetActive(false);
                    ActivateLastDeactivatedGameObject();
                    break;

                case 5:
                    BodyOn.SetActive(false);
                    FaceOn.SetActive(true);
                    break;

                case 6:
                    Finish.SetActive(false);
                    ActivateLastDeactivatedGameObject();
                    BodyOn.SetActive(true);
                    break;
            }
        }
    }

    // 마지막으로 비활성화된 GameObject를 다시 활성화하는 함수
    private void ActivateLastDeactivatedGameObject()
    {
        if (remainingEmotions.Count < Emotions.Length)
        {
            int lastIndex = Emotions.Length - remainingEmotions.Count - 1;
            if (lastIndex >= 0 && lastIndex < Emotions.Length)
            {
                Emotions[lastIndex].SetActive(true);
                remainingEmotions.Insert(0, lastIndex);
            }
        }
    }


    // 마지막으로 활성화된 GameObject를 비활성화하는 함수
    private void DeactivateLastActivatedGameObject()
    {
        if (currentStep == 6)
        {
            if (remainingEmotions.Count > 0)
            {
                Emotions[gameObjectIndex].SetActive(false);
            }
            else{
                Emotions[gameObjectIndex].SetActive(false);
                Finish.SetActive(true);
            }
        }
    }

    // 1~6번 중 아직 활성화되지 않은 GameObject를 랜덤하게 활성화하는 함수
    private void ActivateRandomGameObject()
    {
        Neutral.SetActive(false);

        if (remainingEmotions.Count > 0)
        {
            int randomIndex = Random.Range(0, remainingEmotions.Count);
            gameObjectIndex = remainingEmotions[randomIndex];
            Emotions[gameObjectIndex].SetActive(true);
            remainingEmotions.RemoveAt(randomIndex);
        }
    }
}
