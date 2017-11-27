/* *********************************************************
FileName: PatternScreen.cs
Authors: Fabian Mendez <ofmendez@gmail.com>, 
		 Daniel Rodriguez <dlsusp@gmail.com>
Create Date: 14.11.2017
Modify Date: 27.11.2017 
********************************************************* */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatternScreen : MonoBehaviour {

	public GameObject FrameTyper;
	public GameObject TextPattern;
	public Button goButton;


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
	
}
