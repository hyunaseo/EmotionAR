using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectTracker : MonoBehaviour
{
    private HashSet<GameObject> trackedObjects = new HashSet<GameObject>();
    private GameObject lastAddedObject = null;

    void Start()
    {
        // Start 시점에 이미 존재하는 모든 GameObject를 추적 리스트에 추가합니다.
        foreach (GameObject obj in FindObjectsOfType<GameObject>())
        {
            trackedObjects.Add(obj);
            Debug.Log("New GameObject Added: " + obj.name);
        }
    }

    void Update()
    {
        // 현재 Scene의 모든 GameObject를 가져옵니다.
        foreach (GameObject obj in FindObjectsOfType<GameObject>())
        {
            // 추적되지 않은 새로운 GameObject가 있다면, 이를 추가하고 기록합니다.
            if (!trackedObjects.Contains(obj))
            {
                trackedObjects.Add(obj);
                lastAddedObject = obj;
                Debug.Log($"New GameObject detected: {obj.name}");
            }
        }
    }

    // 마지막으로 추가된 GameObject를 반환합니다.
    public GameObject GetLastAddedGameObject()
    {
        return lastAddedObject;
    }
}
