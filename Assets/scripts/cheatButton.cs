using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class cheatButton : MonoBehaviour {

    public void changeToCurrentStation()
    {
        int station = PersistantSaver.getCurrentStation();
        PersistantSaver.playerData.stationStats[station].discovered = true;
        Debug.Log("Dreckiger Cheater! changing to "+station);
        SceneManager.LoadScene(StationData.stations[station].scene);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
