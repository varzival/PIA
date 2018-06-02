using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PopOver : MonoBehaviour {

    public GameObject[] popOvers;
    public GameObject[] buttons;
    public GameObject backButton;
    public GameObject overlay;

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
