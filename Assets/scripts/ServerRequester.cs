using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ServerRequester : MonoBehaviour
{
    public GameObject popup;
	public GameObject idInputPopup;
	public InputField idInput;
    public Text popupText;
    public float popupTime = 3.0f;
    public string nextScene;

    static readonly string adress = "https://pia-server.herokuapp.com";

    void Start()
    {
        popup.SetActive(false);
    }

    void showPopup(string text)
    {
        StartCoroutine(displayText(text));
    }

    IEnumerator displayText(string text)
    {
		idInputPopup.SetActive (false);
        popupText.text = text;
        popup.SetActive(true);
        yield return new WaitForSecondsRealtime(popupTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void changeScene()
    {
        StartCoroutine(changeSceneCoroutine());
    }

    IEnumerator changeSceneCoroutine()
    {
        yield return new WaitForSecondsRealtime(popupTime);
        SceneManager.LoadScene(nextScene);
    }

    public void sendPoints()
    {
		if (idInput.text == null || idInput.text.Equals (""))
			return;
        StartCoroutine(UploadPoints(idInput.text));
    }


    public void signUp()
    {
        //StartCoroutine(UploadAccountData());
		SceneManager.LoadScene(nextScene);
    }
    
	/*
    IEnumerator UploadAccountData()
    {
        string hash = PersistantSaver.generateHash(PersistantSaver.playerData.nickname + PersistantSaver.playerData.gameId + "super secret code");
        UnityWebRequest req = UnityWebRequest.Get(adress + "/signUp?" + "nick=" + PersistantSaver.playerData.nickname + "&gameId=" + PersistantSaver.playerData.gameId + "&hash=" + hash);
        Debug.Log("Sending: " + adress + "/signUp?" + "nick=" + PersistantSaver.playerData.nickname + "&gameId=" + PersistantSaver.playerData.gameId + "&hash=" + hash);
        yield return req.SendWebRequest();
        if (req.isNetworkError || req.isHttpError)
        {
            Debug.Log("Code: "+ req.responseCode+" Text:"+req.downloadHandler.text);
            showPopup("Konnte Server nicht erreichen.");
        }
        else
        {
            if (req.responseCode == 210L)
            {
                Debug.Log(req.downloadHandler.text);
                showPopup("Spiel mit angegebener ID existiert nicht!");
            }
            else if (req.responseCode == 211L)
            {
                Debug.Log(req.downloadHandler.text);
                showPopup("Nickname ist bereits belegt!");
            }
            else if (req.responseCode == 200L)
            {
                showPopup("Account angelegt!");
                changeScene();
            }
            else
            {
                Debug.Log(req.downloadHandler.text);
                showPopup("Unbekannter Fehler.");
            }
        }

    }
    */

    IEnumerator UploadPoints(string gameId)
    {
        int[] points = PersistantSaver.playerData.points;
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < points.Length; i++)
        {
            sb.Append(points[i] + "-");
        }
        sb.Remove(sb.Length - 1, 1);
        string pointstring = sb.ToString();

        sb = new StringBuilder();
        for (int i = 0; i < StationData.getStationCount(); i++)
        {
            PersistantSaver.Opinion op = PersistantSaver.playerData.stationStats[i].opinion;
            switch(op)
            {
                case PersistantSaver.Opinion.PRO:
                    sb.Append("p-");
                    break;
                case PersistantSaver.Opinion.CONTRA:
                    sb.Append("c-");
                    break;
                case PersistantSaver.Opinion.NONE:
                    sb.Append("n-");
                    break;
                default:
                    Debug.Log("PARAMETER ERROR");
                    break;
            }
        }
        sb.Remove(sb.Length - 1, 1);
        string opstring = sb.ToString();

        string hash = PersistantSaver.generateHash(PersistantSaver.playerData.nickname + gameId + pointstring + opstring + "super secret code");
		UnityWebRequest req = UnityWebRequest.Get(adress + "/sendPoints?" + "points=" + pointstring + "&opinions=" + opstring + "&nick="+PersistantSaver.playerData.nickname + "&gameId=" + gameId.ToLower() + "&hash=" + hash);
        yield return req.SendWebRequest();

        if (req.isNetworkError || req.isHttpError)
        {
            Debug.Log(req.downloadHandler.text);
            showPopup("Konnte Server nicht erreichen.");
        }
        else
        {
            if (req.responseCode == 210L)
            {
                Debug.Log(req.downloadHandler.text);
                showPopup("Spiel mit angegebener ID existiert nicht!");
            }
            else if (req.responseCode == 200L)
            {
                showPopup("Punkte erfolgreich verschickt!");
                changeScene();
            }
            else
            {
                Debug.Log(req.downloadHandler.text);
                showPopup("Unbekannter Fehler.");
            }
        }

    }
}
