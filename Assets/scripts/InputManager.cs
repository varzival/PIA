using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class InputManager : MonoBehaviour {

    public InputField inpNick;
    public InputField inpGameID;
    public ServerRequester requester;

    // Use this for initialization
    void Start()
    {
    }

    public void setNickAndChangeScene()
    {
        if (inpNick.text == null || inpNick.text.Equals("") || inpGameID.text == null || inpGameID.text.Equals(""))
        {
            return;
        }
        else
        {
            Debug.Log("New nickname: " + inpNick.text);
            PersistantSaver.playerData.nickname = inpNick.text;
            Debug.Log("New GameId: " + inpGameID.text);
            PersistantSaver.playerData.gameId = inpGameID.text;
            requester.signUp();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
