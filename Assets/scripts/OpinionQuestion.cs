using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class OpinionQuestion : MonoBehaviour {

    public int stationNum;
    public string nextScene;

    public void opinionPro()
    {
        PersistantSaver.playerData.stationStats[stationNum].opinion = PersistantSaver.Opinion.PRO;
        //PersistantSaver.saveToHardDrive();
        SceneManager.LoadScene(nextScene);
    }

    public void opinionContra()
    {
        PersistantSaver.playerData.stationStats[stationNum].opinion = PersistantSaver.Opinion.CONTRA;
        //PersistantSaver.saveToHardDrive();
        SceneManager.LoadScene(nextScene);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
