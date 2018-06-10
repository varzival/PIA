using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PopOver : MonoBehaviour {

    public GameObject[] popOvers;
    public GameObject[] buttons;
    public GameObject backButton;
    public GameObject overlay;
    public Text[] texts;

	// Use this for initialization
	void Start () {

        foreach (GameObject but in buttons)
        {
            but.SetActive(true);
        }

        foreach (GameObject po in popOvers)
        {
            po.SetActive(false);
        }

        int station = PersistantSaver.getCurrentStation();
        if (station == -1) return;
        for (int i = 0; i<texts.Length; i++)
        {
            if (i == 0) texts[i].text = StationData.stations[station].tips.t1;
            else if (i == 1) texts[i].text = StationData.stations[station].tips.t2;
            if (i == 2) texts[i].text = StationData.stations[station].tips.t3;
        }

        backButton.SetActive(false);
        overlay.SetActive(false);
	}

    public void popup(int num)
    {
        foreach (GameObject but in buttons)
        {
            but.SetActive(false);
        }
        popOvers[num].SetActive(true);
        backButton.SetActive(true);
        overlay.SetActive(true);
    }

    public void back()
    {
        Start();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
