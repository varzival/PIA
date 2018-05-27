using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NicknameInput : MonoBehaviour {

    InputField inpF;

	// Use this for initialization
	void Start () {
        inpF = GetComponent<InputField>();
	}

    public void setNickAndChangeScene(string scene)
    {
        if (inpF.text == null || inpF.text.Equals(""))
        {
            return;
        }
        else
        {
            Debug.Log("New nickname: " + inpF.text);
            PersistantSaver.setNick(inpF.text);
            SceneManager.LoadScene(scene);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
