using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class PopOver : MonoBehaviour {

    public GameObject[] popOvers;
    public GameObject[] buttons;
    public GameObject lock1;
    public GameObject lock2;
    public Text counter1;
    public Text counter2;
    public int waittimeseconds1;
    public int waittimeseconds2;
    public GameObject backButton;
    public GameObject overlay;
    public Text[] texts;
    private DateTime startTime;

	// Use this for initialization
	void Start () {

        startTime = DateTime.Now;
        lock1.SetActive(true);
        lock2.SetActive(true);

        buttons[0].SetActive(true);
        for (int i = 1; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
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
        buttons[0].SetActive(true);
        buttons[1].SetActive(!lock1.activeSelf);
        buttons[2].SetActive(!lock2.activeSelf);

        foreach (GameObject po in popOvers)
        {
            po.SetActive(false);
        }

        backButton.SetActive(false);
        overlay.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        DateTime now = DateTime.Now;
        TimeSpan diff = now - startTime;
        TimeSpan waittime1 = new TimeSpan(0, 0, waittimeseconds1);
        TimeSpan waittime2 = new TimeSpan(0, 0, waittimeseconds2);
        TimeSpan timeLeft1 = waittime1 - diff;
        TimeSpan timeLeft2 = waittime2 - diff;
        if (lock1.activeSelf)
        {
            if (timeLeft1.CompareTo(TimeSpan.Zero) < 0)
            {
                counter1.text = "";
                lock1.SetActive(false);
                buttons[1].SetActive(true);
            }
            else
            {
                counter1.text = timeLeft1.Minutes + ":" + timeLeft1.Seconds;
            } 
        }
        if (lock2.activeSelf)
        {
            if (timeLeft2.CompareTo(TimeSpan.Zero) < 0)
            {
                counter2.text = "";
                lock2.SetActive(false);
                buttons[2].SetActive(true);
            }
            else
            {
                counter2.text = timeLeft2.Minutes + ":" + timeLeft2.Seconds;
            }
        }
        

    }
}
