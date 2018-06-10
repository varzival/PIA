using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class OpinionQuestion : MonoBehaviour {

    public int stationNum;
    public string nextScene;

    public void opinionPro()
    {
        StationData.stations[stationNum].opinion = StationData.Opinion.PRO;
        PersistantSaver.saveOpinions();
        PersistantSaver.saveToHardDrive();
        SceneManager.LoadScene(nextScene);
    }

    public void opinionContra()
    {
        StationData.stations[stationNum].opinion = StationData.Opinion.CONTRA;
        PersistantSaver.saveOpinions();
        PersistantSaver.saveToHardDrive();
        SceneManager.LoadScene(nextScene);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
