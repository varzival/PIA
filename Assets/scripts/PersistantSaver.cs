using System.Collections;
using System.Collections.Generic;

using System.Security.Cryptography;
using System.Text;
using System;
using UnityEngine;

using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class PersistantSaver {

    [Serializable]
    public struct PlayerData
    {
        public string nickname;
        public string gameId;
        public int[] points;
        public int[] stationOrder;
        public string currentScene;
        public int currentQuestion;
        public StationStats[] stationStats;
    }

    [System.Serializable]
    public enum Opinion
    {
        PRO,
        CONTRA,
        NONE
    }

    [Serializable]
    public struct StationStats
    {
        public bool active;
        public bool discovered;
        public Opinion opinion;
        public int points;
    }

    public static PlayerData playerData;

    //Fisher Yates Shuffle
    private static void Shuffle(int[] list)
    {
        int i = list.Length - 1;
        while (i >= 1)
        {
            int k = UnityEngine.Random.Range(0, i + 1);
            int value = list[k];
            list[k] = list[i];
            list[i] = value;
            i--;
        }
    }

    public static void incrementPoints(int station)
    {
        playerData.points[station]++;
        //saveToHardDrive();
    }

    public static int getCurrentStation()
    {

        for (int i = 0; i < StationData.getStationCount(); i++)
        {
            int num = playerData.stationOrder[i];
            if (playerData.stationStats[num].active) return num;
        }
        return -1;
    }


    public static void saveToHardDrive()
    {
        string jsonPd = JsonUtility.ToJson(playerData);
        string hash = generateHash(jsonPd);
        PlayerPrefs.SetString("h", hash);
        PlayerPrefs.SetString("pd", jsonPd);
        PlayerPrefs.Save();
    }

    public static void loadAll()
    {
        string jsonPd = PlayerPrefs.GetString("pd", "err");
        string hashRead = PlayerPrefs.GetString("h", "err");
        if (jsonPd.Equals("err"))
        {
            Debug.Log("No player data found.");
            createNewSave();
            return;
        }

        if (hashRead.Equals("err"))
        {
            Debug.Log("No hash found.");
            createNewSave();
            return;
        }

        string hashGenerated = generateHash(jsonPd);

        if (!hashGenerated.Equals(hashRead))
        {
            Debug.Log("Hash read: "+hashRead+" , Hash Generated: "+hashGenerated+" . Save File corrupted.");
            createNewSave();
            return;
        }

        playerData = JsonUtility.FromJson<PlayerData>(jsonPd);
    }

    

    public static void createNewSave()
    {
        Debug.Log("Creating new save.");
        int stationCount = StationData.getStationCount();
        
        playerData.nickname = "nick";
        playerData.currentScene = "Intro_StationChoice";
        //playerData.currentScene = "End";
        playerData.currentQuestion = -1;
        playerData.gameId = "ID";

        playerData.points = new int[stationCount];
        for (int i = 0; i < playerData.points.Length; i++)
            playerData.points[i] = 0;

        //Randomize stations
        playerData.stationOrder = new int[stationCount];
        for (int i = 0; i < playerData.stationOrder.Length; i++)
        {
            playerData.stationOrder[i] = i;
        }
        Shuffle(playerData.stationOrder);

        playerData.stationStats = new StationStats[stationCount];
        for (int i = 0; i<playerData.stationStats.Length; i++)
        {
            playerData.stationStats[i].active = true;
            playerData.stationStats[i].discovered = false;
            playerData.stationStats[i].opinion = Opinion.NONE;
            playerData.stationStats[i].points = 0;
        }

        saveToHardDrive();
    }

    public static void init()
    {
        //deleteEverything de = new deleteEverything();
        //de.delete();
        loadAll();
    }

    public static string generateHash(string data)
    {
        Debug.Log("Generating hash for data: " + data);
        byte[] byteData = Encoding.ASCII.GetBytes(data);
        SHA1 sha = new SHA1CryptoServiceProvider();
        byte[] hash = sha.ComputeHash(byteData);
        return new SoapHexBinary(hash).ToString().ToLower();
    }
}
