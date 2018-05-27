using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationData {


    [System.Serializable]
    public struct stationInfo
    {
        public string str;
        public string scene;
        public string qrcodestring;
        public bool active;
    }

    public static stationInfo[] stations;

	// Use this for initialization
	public static void populateStations () {

        stationInfo ganztagsschulen = new stationInfo { str = "Ganztagsschulen", scene = "GTSInfo", qrcodestring = "gts", active=true };
        stationInfo inklusion = new stationInfo { str = "Inklusion", scene = "INKInfo", qrcodestring = "inkl", active = true };
        stationInfo integration = new stationInfo { str = "Integration", scene = "INTInfo", qrcodestring = "integr", active = true };
        stationInfo lmgesetze = new stationInfo { str = "Lebensmittelgesetze", scene = "LMGInfo", qrcodestring = "lmgstze", active = true };
        stationInfo krimklzimmer = new stationInfo { str = "Kreuz im Klassenzimmer", scene = "KIKInfo", qrcodestring = "krimk", active = true };

        stations = new stationInfo[] { ganztagsschulen, inklusion, integration, lmgesetze, krimklzimmer };

    }
}
