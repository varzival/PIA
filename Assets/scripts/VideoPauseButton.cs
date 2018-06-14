using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPauseButton : MonoBehaviour {

    public VideoPlayer vp;
    public GameObject pauseImage;
    public videoSetup vs;
    public Text pauseText;

    void OnDisable()
    {
        vp.Stop();
    }

    void OnEnable()
    {
        StartCoroutine(vs.playVideo());
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onPause()
    {
        if (vp.isPlaying)
        {
            vp.Pause();
            pauseText.text = "Pausiert";
            //pauseImage.SetActive(true);
        }
        else
        {
            vp.Play();
            pauseText.text = "";
            //pauseImage.SetActive(false);
        }
    }
}
