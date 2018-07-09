using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class VideoSlider : MonoBehaviour {

	public VideoPlayer vp;
	private Slider slider;
	private bool updateLock;

	public void dragged()
	{
		if (!vp.isPrepared)
			return;
		vp.frame = (long) (vp.frameCount * slider.value);
	}

	public void lockUpdate()
	{
		updateLock = true;
	}

	public void unlockUpdate()
	{
		updateLock = false;
	}


	// Use this for initialization
	void Start () {
		slider = gameObject.GetComponent<Slider> ();
		updateLock = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (updateLock)
			return;
		slider.value = ((float)vp.frame) / ((float)vp.frameCount);
	}
}
