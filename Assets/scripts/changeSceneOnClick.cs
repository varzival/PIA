using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class changeSceneOnClick : MonoBehaviour {

	public void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void loadCurrentScene()
    {
        SceneManager.LoadScene(PersistantSaver.getCurrentScene());
    }
}
