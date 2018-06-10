using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class OpinionQuestion : MonoBehaviour {

    private int stationNum;
    public Text txt;
    public string nextScene;

    public void opinionPro()
    {
        PersistantSaver.playerData.stationStats[stationNum].opinion = PersistantSaver.Opinion.PRO;
        //PersistantSaver.saveToHardDrive();
        PersistantSaver.playerData.stationStats[stationNum].active = false;
        SceneManager.LoadScene(nextScene);
    }

    public void opinionContra()
    {
        PersistantSaver.playerData.stationStats[stationNum].opinion = PersistantSaver.Opinion.CONTRA;
        //PersistantSaver.saveToHardDrive();
        PersistantSaver.playerData.stationStats[stationNum].active = false;
        SceneManager.LoadScene(nextScene);
    }

    // Use this for initialization
    void Start () {
        stationNum = PersistantSaver.getCurrentStation();
        txt.text = StationData.stations[stationNum].opinionQuestion;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
