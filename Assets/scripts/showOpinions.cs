using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class showOpinions : MonoBehaviour {

    public Text[] texts;
    public Text[] opinionTexts;
    public Color proColor;
    public Color contraColor;


	// Use this for initialization
	void Start () {

        for (int i = 0; i<texts.Length; i++)
        {
            if (StationData.stations[i].opinion == StationData.Opinion.PRO)
            {                
                texts[i].text = StationData.stations[i].opinionQuestion;
                opinionTexts[i].text = "JA";
                opinionTexts[i].color = proColor;
            }
            else if (StationData.stations[i].opinion == StationData.Opinion.CONTRA)
            {
                opinionTexts[i].text = "NEIN";
                opinionTexts[i].color = contraColor;
            }
            else
            {
                texts[i].text = StationData.stations[i].opinionQuestion;
                texts[i].text = "???";
                opinionTexts[i].text = "";
            }
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
