using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveCurrentScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("saving scene: " + SceneManager.GetActiveScene().name);
        PersistantSaver.playerData.currentScene = SceneManager.GetActiveScene().name;
        PersistantSaver.saveToHardDrive();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
