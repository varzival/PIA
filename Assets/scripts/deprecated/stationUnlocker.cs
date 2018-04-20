using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stationUnlocker : MonoBehaviour {

    public Image lockImg;
    public Image unlockImg;
    public GameObject StartButton; 

    bool locked = true;

    public void Unlock()
    {
        locked = false;
        lockImg.enabled = false;
        unlockImg.enabled = true;
        StartButton.SetActive(true);
    } 

	// Use this for initialization
	void Start () {
        lockImg.enabled = true;
        unlockImg.enabled = false;
        StartButton.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
