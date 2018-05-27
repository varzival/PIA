using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPauseButton : MonoBehaviour {

    public VideoPlayer vp;
    public GameObject pauseImage;
    public videoSetup vs;

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
            pauseImage.SetActive(true);
        }
        else
        {
            vp.Play();
            pauseImage.SetActive(false);
        }
    }
}
