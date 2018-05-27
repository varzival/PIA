using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class StationChoice : MonoBehaviour {

    // stations = new stationInfo[] { ganztagsschulen, inklusion, integration, lmgesetze, krimklzimmer };
    public Toggle tGTS;
    public Toggle tINK;
    public Toggle tINT;
    public Toggle tLMG;
    public Toggle tKIK;

    public void setStations()
    {
        StationData.populateStations();
        if (!tGTS.isOn) StationData.stations[0].active = false;
        if (!tINK.isOn) StationData.stations[1].active = false;
        if (!tINT.isOn) StationData.stations[2].active = false;
        if (!tLMG.isOn) StationData.stations[3].active = false;
        if (!tKIK.isOn) StationData.stations[4].active = false;
    }

    public static void debugStations()
    {
        foreach (StationData.stationInfo si in StationData.stations)
        {
            Debug.Log(si.str + ": active=" + si.active);
        }
    }
}
