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
        if (!tGTS.isOn) PersistantSaver.playerData.stationStats[0].active = false;
        if (!tINK.isOn) PersistantSaver.playerData.stationStats[1].active = false;
        if (!tINT.isOn) PersistantSaver.playerData.stationStats[2].active = false;
        if (!tLMG.isOn) PersistantSaver.playerData.stationStats[3].active = false;
        if (!tKIK.isOn) PersistantSaver.playerData.stationStats[4].active = false;

        PersistantSaver.saveToHardDrive();
    }
    
}
