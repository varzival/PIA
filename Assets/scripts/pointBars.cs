using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class pointBars : MonoBehaviour {

    public float height;

    public int maxPoints;

    public RectTransform[] barEmpts;
    public RectTransform[] barFulls;
    public Text[] texts;

    public Text pointsMaxText;
    public Text pointsAchievedText;

	// Use this for initialization
	void Start () {

        int maxPointSum = 0;
        for (int i = 0; i<barEmpts.Length; i++)
        {
            int maxPoints = StationData.stations[i].quizQuestions.Length;
            maxPointSum += maxPoints;
            float newheight = ((float)maxPoints / (float)maxPoints) * height;
            barEmpts[i].sizeDelta = new Vector2(barEmpts[i].sizeDelta.x, newheight);
            barEmpts[i].anchoredPosition = new Vector2(barEmpts[i].anchoredPosition.x, newheight/2);
        }


        int[] points = PersistantSaver.playerData.points;
        int pointSum = 0;
        for (int i = 0; i < barFulls.Length; i++)
        {
            pointSum += points[i];
            float newheight = ((float)points[i] / (float)maxPoints) * height;
            barFulls[i].sizeDelta = new Vector2(barEmpts[i].sizeDelta.x, newheight);
            barFulls[i].anchoredPosition = new Vector2(barFulls[i].anchoredPosition.x, newheight / 2);
        }

        pointsAchievedText.text = pointSum + "";
        pointsMaxText.text = maxPointSum + "";

        for (int i = 0; i < texts.Length; i++)
        {
            if (!PersistantSaver.playerData.stationStats[i].discovered)
            {
                texts[i].text = "???";
            }
        }

 }
	
	// Update is called once per frame
	void Update () {
		
	}
}
