/* *********************************************************
FileName: LevelTimer.cs
Authors: Fabian Mendez <ofmendez@gmail.com>, 
		 Daniel Rodriguez <dlsusp@gmail.com>
Create Date: 14.11.2017
Modify Date: 27.11.2017 
********************************************************* */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour {
	bool playing;
	Text timerText;
	float time;
	float minutes;
	float seconds;


	void Start () {
		timerText = GetComponent<Text>();
	}

	public void ResetTime(){
		timerText = timerText ?timerText : GetComponent<Text>();
		time =0;
		timerText.text ="00:00";
		playing = false;
	}
	
	public void StartCount(){
		ResetTime();
		playing = true;
	}

	public int GetSeconds(){
		time += Time.deltaTime;
		minutes = Mathf.Floor(time / 60);
		return (int)(time % 60);
	}


	void Update () {
		if(playing){
			time += Time.deltaTime;
			minutes = Mathf.Floor(time / 60);
	 		seconds = (time % 60);
			timerText.text =minutes.ToString("00")+":"+seconds.ToString("00");
		}
	}


}

	