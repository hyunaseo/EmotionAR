using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCanvasControl : MonoBehaviour
{
    public List<GameObject> tutorialCanvasObjects;
    
    public int currentIndex = 0;
    private bool isTutorialEnd = false;

    private void Start()
    {
        // 모든 GameObject를 비활성화하고 첫 번째(0번)만 활성화
        for (int i = 0; i < tutorialCanvasObjects.Count; i++)
        {
            tutorialCanvasObjects[i].SetActive(i == currentIndex);
        }
    }

    public void OnBlueButtonPressed()
    {
        if (isTutorialEnd) return;

        // 현재 활성화된 GameObject 비활성화
        tutorialCanvasObjects[currentIndex].SetActive(false);

        // 다음 인덱스로 이동 (마지막에서 한 번 더 누르면 모두 비활성화)
        currentIndex++;
        if (currentIndex >= tutorialCanvasObjects.Count)
        {
            currentIndex = -1; // 모든 GameObject 비활성화 상태
            isTutorialEnd = true;
        }

        // 현재 인덱스가 유효하면 해당 GameObject 활성화
        if (currentIndex >= 0)
        {
            tutorialCanvasObjects[currentIndex].SetActive(true);
        }
    }

    // 빨간 버튼이 눌렸을 때 호출되는 함수
    public void OnRedButtonPressed()
    {
        if (isTutorialEnd) return;
        
        // 현재가 0번이면 아무 작업도 하지 않음
        if (currentIndex <= 0) return;

        // 현재 활성화된 GameObject 비활성화
        tutorialCanvasObjects[currentIndex].SetActive(false);

        // 이전 인덱스로 이동
        currentIndex--;

        // 이전 GameObject 활성화
        tutorialCanvasObjects[currentIndex].SetActive(true);
    }
}
