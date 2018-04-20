using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {

    public bool quit;
    public float waitTime;
    private float t = 0;
    public string sceneName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        if (t > waitTime)
        {
            if (quit) Application.Quit();
            else SceneManager.LoadScene(sceneName);
        }
	}
}
