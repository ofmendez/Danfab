using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatternScreen : MonoBehaviour {

	public GameObject FrameTyper;
	public GameObject TextPattern;
	public Button goButton;
	// Use this for initialization
	public void FirstLaunch () {
		FrameTyper.SetActive(true);
		TextPattern.SetActive(false);
		goButton.gameObject.SetActive(false);
	}

	public void ShowPattern(){
		gameObject.SetActive(true);
		FrameTyper.SetActive(false);
		TextPattern.SetActive(true);
		goButton.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
