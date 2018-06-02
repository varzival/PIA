using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteEverything : MonoBehaviour {

	public void delete()
    {
        PersistantSaver.createNewSave();
        Debug.Log("Deleted Everything");
        Application.Quit();
    }
}
