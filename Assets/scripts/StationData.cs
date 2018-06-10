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
        public string opinionQuestion;
        public Question[] quizQuestions;
    }

    [System.Serializable]
    public struct tip
    {
        public string t1;
        public string t2;
        public string t3;
    }

    [System.Serializable]
    public class Question
    {
        public string quizText;
        public string correctText;
        public string[] wrongTexts;
    }


    public static stationInfo[] stations;

	// Use this for initialization
	public static void populateStations () {

        tip tipGTS = new tip { t1 = "GTS T1", t2 = "GTS t2", t3 = "GTS t3" };
        tip tipINK = new tip { t1 = "INK T1", t2 = "INK t2", t3 = "INK t3" };
        tip tipINT = new tip { t1 = "INT T1", t2 = "INT t2", t3 = "INT t3" };
        tip tipLMG = new tip { t1 = "LMG T1", t2 = "LMG t2", t3 = "LMG t3" };
        tip tipKIK = new tip { t1 = "KIK T1", t2 = "KIK t2", t3 = "KIK t3" };

        Question q1GTS = new Question { quizText = "Das Staatsministerium für Bildung und Kultus, welches in Bayern für die Initiation und Koordination der Ganztagesschulwn verantwortlich ist, findet man wo?", correctText = "München", wrongTexts = new string[] { "Fürth", "Augsburg", "Nürnberg" } };
        Question q2GTS = new Question { quizText = "Ein Grund gegen Ganztagesschulen ist nicht:", correctText = "Die lange Anwesenheit in der Schule festigt Freundschaften.", wrongTexts = new string[] { "Opfer von Mobbing sind ihren Peinigern noch länger ausgesetzt.", "Für außerschulischen Musik-Unterricht bleibt nur noch wenig Zeit.", "Die Erziehung durch die Eltern nimmt einen kleineren Stellenwert ein." } };
        Question q3GTS = new Question { quizText = "Etwa wie viel Prozent der bayerischen Schüler besuchen zum aktuellen Zeitpunkt eine Ganztagesschule?", correctText = "15-20%", wrongTexts = new string[] { "5-10%", "35-45%", "70-90%" } };
        Question q4GTS = new Question { quizText = "Bis zu welchem Jahr sollte in Bayern jeder Schüler einen Anspruch auf einen Ganztagesschulenplatz haben können?", correctText = "2018", wrongTexts = new string[] { "2010", "2013", "2025" } };

        Question q1INK = new Question { quizText = "Worum geht es bei Inklusion?", correctText = "Gleichstellung von Menschen mit und ohne Behinderung", wrongTexts = new string[] { "Strafen für auffällige SchülerInnen", "Unterricht 'Deutsch als Fremdsprache'", "unsichtbare Tinte" } };
        Question q2INK = new Question { quizText = "Warum sollen sich die Schulen um Inklusion bemühen?", correctText = "Menschen mit Behinderung sollen nicht vom allgemeinen Bildungssystem ausgeschlossen werden, weil das gegen das Prinzip der Gleichberechtigung verstößt.", wrongTexts = new string[] { "Damit eine Quote erfüllt wird, die die Bewertung der Schule verbessert.", "Um das Schulhaus attraktiver für eine Nachnutzung zu machen.", "Weil die Schule sowieso eine Renovierung nötig hat." } };
        Question q3INK = new Question { quizText = "Seit wann ist es in Bayern Aufgabe aller Schulen sich um Inklusion zu bemühen?", correctText = "2011", wrongTexts = new string[] { "2008", "1997", "2016" } };
        Question q4INK = new Question { quizText = "Barrieren, die es im Sinne der Barrierefreiheit zu vermeiden gilt, gibt es nicht nur im Gebäude, an Straßen und auf Transportwegen, sondern auch...", correctText = "bei Informations-, Kommunikations- und anderen Diensten", wrongTexts = new string[] { "bei Minecraft", "bei Nachhilfestunden", "bei der Schülersprecherwahl" } };
        //?
        Question q5INK = new Question { quizText = "Wie sollte Barrierefreiheit umgesetzt werden?", correctText = "Im Sinne des Gleichberechtigungsprinzips soll allen Schulen selbstständige Bewegung und Teilnahme ermöglicht werden.", wrongTexts = new string[] { "Barrierefreiheit braucht es nur, wenn jemand speziell betroffen ist.", "Wenn eine Schule einmal barrierefrei geworden ist, ist das Thema abgehakt.", "Barrierefreiheit kostet sehr viel. Man sollte genau überlegen, ob sich das für ein paar Menschen überhaupt lohnt." } };
        Question q6INK = new Question { quizText = "Warum ist das Wort 'Behinderte' im Zusammenhang mit Inklusion unpassend?", correctText = "Es hat etwas beleidigendes.", wrongTexts = new string[] { "Es meint nur körperliche Beeinträchtigungen.", "Es hat nichts mit Tintenflecken zu tun.", "Laut Duden ist das das Gegenteil." } };
        //?
        Question q7INK = new Question { quizText = "Was sind, laut einer Lehrerumfrage, die größten Schwierigkeiten auf dem Weg zur Inklusion?", correctText = "Mangel an Fachpersonal und fehlende materielle Ausstattung", wrongTexts = new string[] { "Die Gesetzeslage und die politische Stimmung", "Widerstand von Eltern und Schulleitung", "Die geringe Zahl betroffener SchülerInnen" } };

        Question q1INT = new Question { quizText = "Welche Aussage zu den Integrations- bzw. Zuwandererklassen ist korrekt?", correctText = "In Integegrationsklassen können die ausländischen Schüler schneller Kontakt mit einheimischen Schülern finden.", wrongTexts = new string[] { "In Zuwandererklassen können die Schüler auch in den Pausen durch Kontakt mit ihren Mitschülern deutsch lernen.", "Lehrer sehen kein Problem, in Integrationsklasen alle Schüler gleichermaßen zu fördern.", "In Integrationsklassen ist es kein Problem, dass sich Schüler mit schlechten Detuschkenntnissen trauen, aktiv am Unterricht teilzunehmen." } };
        Question q2INT = new Question { quizText = "Was ist das Ziel der Integrationskurse?", correctText = "Es soll die deutsche Sprache, aber auch Geschichte und Kultur vermittelt werden.", wrongTexts = new string[] { "Die Einwanderer sollen lernen, wie man richtig deutsches Essen zubereitet.", "Recht wird in diesen Kursen vollständig ausgelassen, da jeder Einwanderer bereits einen Rechtsanwalt hat.", "Diese Kurse werden nur für unter 18-Jährige angeboten, da sich ältere Menschen nicht mehr integrieren lassen." } };
        Question q3INT = new Question { quizText = "Was zählt als politische Verfolgung und berechtigt demnach zu Asyl?", correctText = "Wenn man wegen seiner sexuellen Orientierung verfolgt wird.", wrongTexts = new string[] { "Wenn einem als Mörder eine lange Haftstrafe droht.", "Wenn man in seinem Heimatland keine Arbeit findet.", "Wenn man wegen einer Spielsucht sein ganzes Vermögen verloren hat." } };
        Question q4INT = new Question { quizText = "Welchen Sinn hat Entwicklungshilfe?", correctText = "Der Staat beugt Fluchtursachen vor.", wrongTexts = new string[] { "Der Staat versucht so, seine eigenen Produkte auf einem größeren Markt verkaufen zu können.", "Der Staat verlagert so sein Einkommen, so dass sein Leistungsüberschuss nicht mehr so heraussticht.", "Der Staat versucht so, autokratische Herrscher zu besänftigen, so dass diese keinen Krieg beginnen." } };

        Question q1KIK = new Question { quizText = "Wo ist die Religionsfreiheit verankert?", correctText = "Grundgesetz", wrongTexts = new string[] { "Bayerische Verfassung", "Bürgerliches Gesetzbuch", "Völkerstrafgesetzbuch" } };
        Question q2KIK = new Question { quizText = "Wie ist die Kreuz-Frage in der bayerischen Verfassung geregelt?", correctText = "in Form einer Konfliktlösung: Erziehungsberechtigte und Lehrer können der Anbringung des Kreuzes widersprechen", wrongTexts = new string[] { "in jedem Klassenzimmer muss ein Kreuz hängen", "in jedem Klassenzimmer müssen ein Kreuz, sowie Symbole anderer in der Klasse vertretener Religionen hängen", "in Klassenzimmern darf kein Kreuz oder ähnliches religiöses Symbol hängen" } };
        Question q3KIK = new Question { quizText = "Was geschah im Zeitalter der Aufklärung?", correctText = "Die Bürger wurden zu freien und mündigen Menschen und begehrten gegen die herrschende Klasse auf.", wrongTexts = new string[] { "Es wurde entschieden, dass alle Schüler der 7. Klasse im Sexualkunde-Unterricht aufgeklärt werden.", "Es wurde festegelegt, dass jeder Arzt den Patienten über mögliche Nebenwirkungen seiner Medikamente aufklären sollte.", "In der Aufklärung bestätigt die katholische Kirche, dass es Jesus gar nicht gab." } };
        Question q4KIK = new Question { quizText = "Was ist Säkularisierung?", correctText = "Verweltlichung", wrongTexts = new string[] { "Religiosierung", "Atheismus", "Staatskirche" } };
        Question q5KIK = new Question { quizText = "Was ist KEIN Beispiel für den immer noch bestehenden Einfluss der Kirche auf den deutschen Staat?", correctText = "Der regelmäßige Besuch im Vatikan durch die Bundeskanzlerin.", wrongTexts = new string[] { "Das Studium von Priestern an staatlichen Universitäten", "Das Eintreiben der Kirchensteuer durch den Staat", "Das Kreuz in bayerischen Klassenzimmern." } };

        Question q1LMG = new Question { quizText = "In welcher Reihenfolge sind die Zutaten auf der Lebensmittelverpackung aufgelistet?", correctText = "Zuerst steht, wovon am meisten drin ist", wrongTexts = new string[] { "An erster Stelle steht das, worauf die meisten Menschen allergisch sind", "Das mit den meisten Kalorien steht an erster Stelle", "Meistens steht an erster Stelle die gesündeste Zutat" } };
        Question q2LMG = new Question { quizText = "Was gibt das Mindesthaltbarkeitsdatum an?", correctText = "Bis zu welchem Zeitpunkt das Lebensmittel seine originale Farbe, Geschmack, Nährwerte und Beschaffenheit behält.", wrongTexts = new string[] { "Ab wann man nach Verzehr des Lebensmittels zu 90% eine Lebensmittelvergiftung bekommt.", "Ab wann man in dem Lebensmittel Bakterien wie z.B. E.coli finden kann", "Ab wann das Lebensmittel als Delikatesse gilt (siehe Blauschimmelkäse)" } };
        Question q3LMG = new Question { quizText = "Was machen Legionellen in den meisten Fällen für Symptome?", correctText = "Fieber und Husten wie bei einer Lungenentzündung", wrongTexts = new string[] { "Schnupfen und Halsweh wie bei einer Erkältung", "Kopfweh und Augenflimmern wie bei einer Migräne", "Erbrechen und Durchfall wie bei einem Magen-Darm-Infekt" } };
        Question q4LMG = new Question { quizText = "Wie viel Liter verbraucht ein Mensch in Deutschland pro Tag durchschnittlich?", correctText = "120l: So viel wie in einer vollen Badewanne", wrongTexts = new string[] { "15l: So viel wie in einem Wischkübel", "50l: So viel wie in 5 Minuten duschen", "1600l: So viel wie in einem Planschbecken (2m Radius, 0,5m Höhe)" } };
        Question q5LMG = new Question { quizText = "Wofür gibt es in Deutschland die Trinkwasserverordnung?", correctText = "Um die Qualität des Trinkwassers zu schützen und verbessern.", wrongTexts = new string[] { "Um den Elektrolytgehalt im Trinkwasser vorzuschreiben.", "Um festzulegen, wie viel Wasser jeder Bürger pro Tag verbrauchen darf.", "Um die From der Wasserhähne in Deutschland zu normen." } };

        string qGTS = "Findet Ihr, dass Bayern vermehrt in den Ausbau von Ganztagsschulen investieren sollte?";
        string qINK = "Findest Ihr, dass beeinträchtigte Schüler, anstatt in speziell ausgelegten Förderschulen, besser in herkömmlichen Schulen unterrichtet werden sollen?";
        string qINT = "Hältst du Zuwandererklassen für die bessere Unterrichtsform von ausländischen Schülern als Integrationsklassen?";
        string qKIK = "Sollte in bayrischen Klassenzimmern ein Kreuz hängen?";
        string qLMG = "Findest Du, es sollte eine Vorschrift geben, die den Schülern vorschreibt, was sie essen sollen, anstatt jeden Schüler für sich selbst entscheiden zu lassen?";

        stationInfo ganztagsschulen = new stationInfo { str = "Ganztagsschulen", scene = "GTSInfo", qrcodestring = "gts", tips=tipGTS, opinionQuestion=qGTS, quizQuestions= new Question[] { q1GTS, q2GTS, q3GTS, q4GTS } };
        stationInfo inklusion = new stationInfo { str = "Inklusion", scene = "INKInfo", qrcodestring = "inkl", tips = tipINK, opinionQuestion=qINK, quizQuestions = new Question[] { q1INK, q2INK, q3INK, q4INK, q5INK, q6INK, q7INK} };
        stationInfo integration = new stationInfo { str = "Integration", scene = "INTInfo", qrcodestring = "integr", tips = tipINT, opinionQuestion=qINT, quizQuestions = new Question[] { q1INT, q2INT, q3INT, q4INT } };
        stationInfo lmgesetze = new stationInfo { str = "Lebensmittelgesetze", scene = "LMGInfo", qrcodestring = "lmgstze", tips = tipLMG, opinionQuestion=qLMG, quizQuestions = new Question[] { q1LMG, q2LMG, q3LMG, q4LMG, q5LMG } };
        stationInfo krimklzimmer = new stationInfo { str = "Kreuz im Klassenzimmer", scene = "KIKInfo", qrcodestring = "krimk", tips = tipKIK, opinionQuestion=qKIK, quizQuestions = new Question[] { q1KIK, q2KIK, q3KIK, q4KIK, q5KIK } };

        stations = new stationInfo[] { ganztagsschulen, inklusion, integration, lmgesetze, krimklzimmer };
    }

    public static int getStationCount()
    {
        return stations.Length;
    }
}
