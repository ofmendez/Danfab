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
	// Use this for initialization
	void Start () {
		timerText = GetComponent<Text>();
	}
	
	
	// Update is called once per frame
	void Update () {
		if(playing){
			time += Time.deltaTime;
			minutes = Mathf.Floor(time / 60);
	 		seconds = (time % 60);

			timerText.text =minutes.ToString("00")+":"+seconds.ToString("00");
		}
	}

	public void SetPlaying(bool _s){
		playing = _s;
	}

}

	