using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveCurrentScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("saving scene: " + SceneManager.GetActiveScene().name);
        PersistantSaver.setCurrentScene(SceneManager.GetActiveScene().name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
