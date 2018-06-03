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
        public tip tips;
        public int maxPoints;
    }

    public struct tip
    {
        public string t1;
        public string t2;
        public string t3;
    }

    public static stationInfo[] stations;

	// Use this for initialization
	public static void populateStations () {

        tip tipGTS = new tip { t1 = "GTS T1", t2 = "GTS t2", t3 = "GTS t3" };
        tip tipINK = new tip { t1 = "INK T1", t2 = "INK t2", t3 = "INK t3" };
        tip tipINT = new tip { t1 = "INT T1", t2 = "INT t2", t3 = "INT t3" };
        tip tipLMG = new tip { t1 = "LMG T1", t2 = "LMG t2", t3 = "LMG t3" };
        tip tipKIK = new tip { t1 = "KIK T1", t2 = "KIK t2", t3 = "KIK t3" };

        stationInfo ganztagsschulen = new stationInfo { str = "Ganztagsschulen", scene = "GTSInfo", qrcodestring = "gts", active=true, tips=tipGTS, maxPoints=3 };
        stationInfo inklusion = new stationInfo { str = "Inklusion", scene = "INKInfo", qrcodestring = "inkl", active = true, tips = tipINK, maxPoints = 5 };
        stationInfo integration = new stationInfo { str = "Integration", scene = "INTInfo", qrcodestring = "integr", active = true, tips = tipINT, maxPoints = 5 };
        stationInfo lmgesetze = new stationInfo { str = "Lebensmittelgesetze", scene = "LMGInfo", qrcodestring = "lmgstze", active = true, tips = tipLMG, maxPoints = 5 };
        stationInfo krimklzimmer = new stationInfo { str = "Kreuz im Klassenzimmer", scene = "KIKInfo", qrcodestring = "krimk", active = true, tips = tipKIK, maxPoints = 5 };

        stations = new stationInfo[] { ganztagsschulen, inklusion, integration, lmgesetze, krimklzimmer };

    }
}
