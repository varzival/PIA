using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationData : MonoBehaviour {

    [System.Serializable]
    public struct stationString
    {
        public string str;
        public stationUnlocker unlocker;
    }

    public stationString[] stringToStations;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
