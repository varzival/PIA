using System.Collections;
using System.Collections.Generic;

using System.Security.Cryptography;
using System.Text;
using System;
using UnityEngine;


public class PersistantSaver {

    public struct PlayerData
    {
        public string nickname;
        public int[] points;
        public int[] stationOrder;
        public string currentScene;
        public int currentQuestion;
    }

    private static PlayerData playerData;

    //Fisher Yates Shuffle
    private static void Shuffle(int[] list)
    {
        int i = list.Length-1;
        while (i >= 1)
        {
            int k = UnityEngine.Random.Range(0, i+1);
            int value = list[k];
            list[k] = list[i];
            list[i] = value;
            i--;
        }
    }

    public static void setNick(string nick)
    {
        playerData.nickname = nick;
        saveNick();
        saveToHardDrive();
    }

    public static void setCurrentScene(string scene)
    {
        playerData.currentScene = scene;
        saveCurrentScene();
        saveToHardDrive();
    }

    public static void setCurrentQuestion(int question)
    {
        playerData.currentQuestion = question;
        saveCurrentQuestion();
        saveToHardDrive();
    }

    public static int getCurrentQuestion()
    {
        return playerData.currentQuestion;
    }

    public static void incrementPoints(int station)
    {
        playerData.points[station] = playerData.points[station] + 1;
        savePoints();
        saveToHardDrive();
    }

    public static int[] Points
    {
        get { return playerData.points; }
        set { playerData.points = value; savePoints(); saveHash(); }
    }

    public static int[] StationOrder
    {
        get { return playerData.stationOrder; }
    }

    public static int getPoints(int station)
    {
        return playerData.points[station];
    }

    public static string getCurrentScene()
    {
        return playerData.currentScene;
    }

    public static void init()
    {
        playerData.points = new int[5];
        playerData.stationOrder = new int[5];
        playerData.nickname = "nick";
        playerData.currentScene = "Intro";
        playerData.currentQuestion = -1;
        loadAll();
    }

	private static void savePoints()
    {
        for (int station = 0; station < playerData.points.Length; station++)
        {
            PlayerPrefs.SetInt("s" + station, playerData.points[station]);
        }
    }

    private static void saveNick()
    {
        PlayerPrefs.SetString("nickname", playerData.nickname);
    }

    public static void saveAll()
    {
        savePoints();
        saveStationOrder();
        saveCurrentScene();
        saveActiveStations();
        saveNick();
        saveCurrentQuestion();
        saveDiscoveredStations();
        saveOpinions();
        saveToHardDrive();
    }

    public static void saveDiscoveredStations()
    {
        for (int i = 0; i < playerData.stationOrder.Length; i++)
        {
            if (StationData.stations[i].discovered) PlayerPrefs.SetString("sd_" + i, "t");
            else PlayerPrefs.SetString("sd_" + i, "f");
        }
    }

    public static void saveActiveStations()
    {
        for (int i = 0; i < playerData.stationOrder.Length; i++)
        {
            if (StationData.stations[i].active) PlayerPrefs.SetString("sa_" + i, "t");
            else PlayerPrefs.SetString("sa_" + i, "f");
        }
    }

    public static void saveOpinions()
    {
        for (int i = 0; i < playerData.stationOrder.Length; i++)
        {
            if (StationData.stations[i].opinion == StationData.Opinion.PRO) PlayerPrefs.SetString("sop_" + i, "p");
            else if (StationData.stations[i].opinion == StationData.Opinion.CONTRA) PlayerPrefs.SetString("sop_" + i, "c");
            else PlayerPrefs.SetString("sop_" + i, "n");
        }
    }

    private static void saveCurrentQuestion()
    {
        PlayerPrefs.SetInt("cq", playerData.currentQuestion);
    }

    private static void saveCurrentScene()
    {
        PlayerPrefs.SetString("cs", playerData.currentScene);
    }

    private static void saveStationOrder()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i<playerData.stationOrder.Length; i++)
        {
            sb.Append(playerData.stationOrder[i] + ".");
        }
        sb.Remove(sb.ToString().Length - 1, 1);
        Debug.Log("saving: so = " + sb.ToString());
        PlayerPrefs.SetString("so", sb.ToString());
    }

    public static void loadAll()
    {
        string hashStringRead = PlayerPrefs.GetString("h", "null");
        if (hashStringRead.Equals("null"))
        {
            createNewSave();
        }
        else
        {
            for (int station = 0; station < playerData.points.Length; station++)
            {
                playerData.points[station] = PlayerPrefs.GetInt("s" + station, 0);
            }

            string so_str = PlayerPrefs.GetString("so");
            string[] so_split = so_str.Split('.');
            try
            {
                for (int i = 0; i < playerData.stationOrder.Length; i++)
                {
                    playerData.stationOrder[i] = Int32.Parse(so_split[i]);
                }
            }
            catch (System.Exception)
            {
                Debug.Log("Could not read station order.");
                createNewSave();
                return;
            }

            playerData.currentScene = PlayerPrefs.GetString("cs", "Intro_StationChoice");
            Debug.Log("Current Scene loaded: " + playerData.currentScene);

            for (int i = 0; i < StationData.stations.Length; i++)
            {
                string v = PlayerPrefs.GetString("sa_"+i, "err");
                if (v.Equals("t"))
                    StationData.stations[i].active = true;
                else if (v.Equals("f"))
                    StationData.stations[i].active = false;
                else
                {
                    Debug.Log("Could not read active stations.");
                    createNewSave();
                    return;
                }


                v = PlayerPrefs.GetString("sd_" + i, "err");
                if (v.Equals("t"))
                    StationData.stations[i].discovered = true;
                else if (v.Equals("f"))
                    StationData.stations[i].discovered = false;
                else
                {
                    Debug.Log("Could not read discovered stations.");
                    createNewSave();
                    return;
                }

                v = PlayerPrefs.GetString("sop_" + i, "err");
                if (v.Equals("t"))
                    StationData.stations[i].opinion = StationData.Opinion.PRO;
                else if (v.Equals("f"))
                    StationData.stations[i].opinion = StationData.Opinion.CONTRA;
                else if (v.Equals("n"))
                    StationData.stations[i].opinion = StationData.Opinion.NONE;
                else
                {
                    Debug.Log("Could not read opinions.");
                    createNewSave();
                    return;
                }
            }

            playerData.nickname = PlayerPrefs.GetString("nickname", "nick");

            playerData.currentQuestion = PlayerPrefs.GetInt("cq", -1);
            /*
            string hashStringGenerated = generateHashFromData();
            Debug.Log("Hash generated: " + hashStringGenerated);
            Debug.Log("Hash in prefs: " + hashStringRead);
            if (!hashStringRead.Equals(hashStringGenerated))
            {
                Debug.Log("Save File corrupted!");
                createNewSave();
            }
            */
        }
        
    }

    public static void createNewSave()
    {
        Debug.Log("Creating new save.");
        for (int i = 0; i < playerData.points.Length; i++)
            playerData.points[i] = 0;

        //Randomize stations
        for (int i = 0; i < playerData.stationOrder.Length; i++)
        {
            playerData.stationOrder[i] = i;
        }
        Shuffle(playerData.stationOrder);

        playerData.currentScene = "Intro_StationChoice";
        playerData.nickname = "nick";
        playerData.currentQuestion = -1;

        StationData.populateStations();

        saveAll();
    }
    /*
    public void changePlayerPoints(int station, int points)
    {
        playerData.points[station] = points;
        savePoints();
    }
    */

    public static void saveHash()
    {
        string hashString = generateHashFromData();
        PlayerPrefs.SetString("h", hashString);
    }

    private static string generateHashFromData()
    {
        StringBuilder sb = new StringBuilder();
        for (int station = 0; station < playerData.points.Length; station++)
        {
            sb.Append("s" + station + "_" + playerData.points[station]);
        }
        sb.Append("so_");
        for (int i = 0; i < playerData.stationOrder.Length; i++)
        {
            sb.Append(playerData.points[i]+".");
        }
        sb.Remove(sb.ToString().Length - 1, 1);
        sb.Append("cs_");
        sb.Append(playerData.currentScene);

        sb.Append("sa_");
        for (int i = 0; i < StationData.stations.Length; i++)
        {
            sb.Append(StationData.stations[i].active + ".");
        }
        sb.Remove(sb.ToString().Length - 1, 1);

        sb.Append("sd_");
        for (int i = 0; i < StationData.stations.Length; i++)
        {
            sb.Append(StationData.stations[i].discovered + ".");
        }
        sb.Remove(sb.ToString().Length - 1, 1);

        sb.Append("sop_");
        for (int i = 0; i < StationData.stations.Length; i++)
        {
            sb.Append(StationData.stations[i].opinion + ".");
        }
        sb.Remove(sb.ToString().Length - 1, 1);

        sb.Append("nick_" + playerData.nickname);

        return generateHash(sb.ToString());
    }

    private static string generateHash(string data)
    {
        Debug.Log("Generating hash for data: " + data);
        byte[] byteData = Encoding.ASCII.GetBytes(data);
        SHA1 sha = new SHA1CryptoServiceProvider();
        byte[] hash = sha.ComputeHash(byteData);
        return Encoding.ASCII.GetString(hash);
    }

    public static void saveToHardDrive()
    {
        saveHash();
        PlayerPrefs.Save();
    }
}
