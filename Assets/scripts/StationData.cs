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
        public tip tips;
        public int maxPoints;
        public string opinionQuestion;
    }

    [System.Serializable]
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

        string qGTS = "Findet Ihr, dass Bayern vermehrt in den Ausbau von Ganztagsschulen investieren sollte?";
        string qINK = "Findest Ihr, dass beeinträchtigte Schüler, anstatt in speziell ausgelegten Förderschulen, besser in herkömmlichen Schulen unterrichtet werden sollen?";
        string qINT = "Hältst du Zuwandererklassen für die bessere Unterrichtsform von ausländischen Schülern als Integrationsklassen?";
        string qKIK = "Sollte in bayrischen Klassenzimmern ein Kreuz hängen?";
        string qLMG = "Findest Du, es sollte eine Vorschrift geben, die den Schülern vorschreibt, was sie essen sollen, anstatt jeden Schüler für sich selbst entscheiden zu lassen?";

        stationInfo ganztagsschulen = new stationInfo { str = "Ganztagsschulen", scene = "GTSInfo", qrcodestring = "gts", tips=tipGTS, maxPoints=3, opinionQuestion=qGTS };
        stationInfo inklusion = new stationInfo { str = "Inklusion", scene = "INKInfo", qrcodestring = "inkl", tips = tipINK, maxPoints = 5, opinionQuestion=qINK };
        stationInfo integration = new stationInfo { str = "Integration", scene = "INTInfo", qrcodestring = "integr", tips = tipINT, maxPoints = 5, opinionQuestion=qINT };
        stationInfo lmgesetze = new stationInfo { str = "Lebensmittelgesetze", scene = "LMGInfo", qrcodestring = "lmgstze", tips = tipLMG, maxPoints = 5, opinionQuestion=qLMG };
        stationInfo krimklzimmer = new stationInfo { str = "Kreuz im Klassenzimmer", scene = "KIKInfo", qrcodestring = "krimk", tips = tipKIK, maxPoints = 5, opinionQuestion=qKIK };

        stations = new stationInfo[] { ganztagsschulen, inklusion, integration, lmgesetze, krimklzimmer };
    }
}
