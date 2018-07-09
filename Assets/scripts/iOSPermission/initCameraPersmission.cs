using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initCameraPersmission : MonoBehaviour {

	public AskCameraPermission perm;

	// Use this for initialization
	void Start () {
		perm.VerifyPermission ();		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
