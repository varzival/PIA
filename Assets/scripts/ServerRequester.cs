using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerRequester : MonoBehaviour
{
    static readonly string adress = "localhost";
    static readonly int port = 8000;
    static readonly string method = "sendPoints";

    void Start()
    {
        sendPoints("Unity Points");
    }


    public void sendPoints(string points)
    {
        StartCoroutine(Upload(points));
    }

    IEnumerator Upload(string points)
    {
        UnityWebRequest req = UnityWebRequest.Get(adress + ":" + port + "/" + method + "?" + "points=" + points);
        yield return req.SendWebRequest();
        if (req.isNetworkError || req.isHttpError)
        {
            Debug.Log(req.error);
        }
        else
        {
            // Show results as text
            Debug.Log(req.downloadHandler.text);
        }

    }
}
