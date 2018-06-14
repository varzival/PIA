using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class videoSetup : MonoBehaviour {

    public RawImage image;
    public VideoPlayer videoPlayer;
    public Text loadingText;

    void Start()
    {
        Application.runInBackground = true;
        //StartCoroutine(playVideo());
    }

    public IEnumerator playVideo()
    {
        videoPlayer.playOnAwake = false;
        videoPlayer.Prepare();

        //Wait until Movie is prepared
        WaitForSeconds waitTime = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            loadingText.text = "Lade...";
            Debug.Log("Preparing Movie");
            yield return waitTime;
            break;
        }

        Debug.Log("Done Preparing Movie ");
        loadingText.text = "";

        //Assign the Texture from Movie to RawImage to be displayed
        image.texture = videoPlayer.texture;

        //Play Movie 
        videoPlayer.Play();

        while (videoPlayer.isPlaying)
        {
            yield return null;
        }
        Debug.Log("Done Playing Movie ");
    }
}
