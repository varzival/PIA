﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class initSaver : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StationData.populateStations();
        PersistantSaver.init();
        StartCoroutine(loadCurrentScene());
	}

    IEnumerator loadCurrentScene()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(PersistantSaver.playerData.currentScene);
        yield return null;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
