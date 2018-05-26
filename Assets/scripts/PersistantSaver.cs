using System.Collections;
using System.Collections.Generic;

using System.Security.Cryptography;
using System.Text;
using System;
using UnityEngine;

public class PersistantSaver {

    public struct PlayerData
    {
        public int[] points;
        public int[] stationOrder;
        public string currentScene;
    }

    private static PlayerData playerData;

    //Fisher Yates Shuffle
    public static void Shuffle(int[] list)
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
        loadAll();
    }

	public static void savePoints()
    {
        for (int station = 0; station < playerData.points.Length; station++)
        {
            PlayerPrefs.SetInt("s" + station, playerData.points[station]);
        }
    }

    public static void saveAll()
    {
        savePoints();
        saveStationOrder();
        saveCurrentScene();
        saveHash();
        PlayerPrefs.Save();
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

            StringBuilder sb = new StringBuilder();
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

            string hashStringGenerated = generateHashFromData();
            if (!hashStringRead.Equals(hashStringGenerated))
            {
                Debug.Log("Save File corrupted!");
                createNewSave();
            }
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

        saveAll();
    }
    /*
    public void changePlayerPoints(int station, int points)
    {
        playerData.points[station] = points;
        savePoints();
    }
    */

    private static void saveHash()
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
}
