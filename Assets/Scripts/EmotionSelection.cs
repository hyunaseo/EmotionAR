using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmotionSelection : MonoBehaviour
{
    [Range(2, 10)]
    public int numberOfRadialPart; 
    public GameObject radialPartPrefab;
    public Transform radialCanvas;
    public float angleBetweenPart = 5;
    public Transform handTransform;

    private List<GameObject> spawnedParts = new List<GameObject>();
    private int currentSelectedRaidalPart = -1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SapwnRadialPart();
        GetSelectedRadialPart();
    }

    public void GetSelectedRadialPart(){
        Vector3 centerToHand = handTransform.position - radialCanvas.position;
        Vector3 centerToHandProjected = Vector3.ProjectOnPlane(centerToHand, radialCanvas.forward);

        float angle =Vector3.SignedAngle(radialCanvas.up, centerToHandProjected, -radialCanvas.forward);
        if(angle<0) {
            angle += 360;
        }
        currentSelectedRaidalPart = (int) angle * numberOfRadialPart / 360;

        for (int i=0; i<spawnedParts.Count; i++){
            if (i==currentSelectedRaidalPart){
                spawnedParts[i].GetComponent<Image>().color = Color.yellow;
                spawnedParts[i].transform.localScale = 1.1f * Vector3.one;
            }
            else{
                spawnedParts[i].GetComponent<Image>().color = Color.white;
                spawnedParts[i].transform.localScale = Vector3.one;
            }
        }
    }


    public void SapwnRadialPart(){
        foreach (var item in spawnedParts){
            Destroy(item);
        }

        spawnedParts.Clear();

        for (int i=0; i<numberOfRadialPart; i++){
            float angle = i * 360/numberOfRadialPart - angleBetweenPart/2;
            Vector3 raidalPartEulerAngle = new Vector3(0, 0, angle);

            GameObject spawnedRadialPart = Instantiate(radialPartPrefab, radialCanvas);
            spawnedRadialPart.transform.position = radialCanvas.position;
            spawnedRadialPart.transform.localEulerAngles = raidalPartEulerAngle;

            spawnedRadialPart.GetComponent<Image>().fillAmount = 1/(float)numberOfRadialPart - (angleBetweenPart/360);
            
            spawnedParts.Add(spawnedRadialPart);
        }



    }
}
