using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationDataChangeScene : MonoBehaviour {

    [System.Serializable]
    public struct stationString
    {
        public string str;
        public string scene;
    }

    public stationString[] stringToStations;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
