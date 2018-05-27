using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteEverything : MonoBehaviour {

	public void delete()
    {
        PersistantSaver.createNewSave();
        Application.Quit();
    }
}
