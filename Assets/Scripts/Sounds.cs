/* *********************************************************
FileName: Sounds.cs
Authors: Fabian Mendez <ofmendez@gmail.com>
Create Date: 14.11.2017
Modify Date: 27.11.2017 
********************************************************* */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Sounds : Singleton<Sounds> {
[Header("Audio Sources:")]
	public AudioSource gameTheme;
	public AudioSource pauseTheme;
	public AudioSource ambientTheme;
	public AudioSource enemyFire;
	public AudioSource electricShootBegin;
	public AudioSource electricShootLoop;
	public AudioSource dynamoDeath;
[Header("Mixers:")]
	public AudioMixerSnapshot gameStateMaster;
	public AudioMixerSnapshot pauseStateMaster;
	public AudioMixerSnapshot gameStateTheme;
	public AudioMixerSnapshot pauseStateTheme;

	List<AudioSource> sources = new List<AudioSource>();

	void Start(){
		sources.Add(gameTheme);
		sources.Add(pauseTheme);
		sources.Add(ambientTheme);
		sources.Add(enemyFire);
		sources.Add(electricShootBegin);
		sources.Add(electricShootLoop);
		sources.Add(dynamoDeath);
	}

	public void SetPausedAudio(){
		PlayPauseTheme();
		pauseStateMaster.TransitionTo(0.8f);
		pauseStateTheme.TransitionTo(0.8f);
	}

	public void SetInGameAudio(){
		PlayGameTheme();
		PlayAmbientTheme();
		gameStateMaster.TransitionTo(0.8f);
		gameStateTheme.TransitionTo(0.8f);
	}

	public void PlayEnemyFire(){
		enemyFire.PlayOneShot(enemyFire.clip, enemyFire.volume);
	}

	public void PlayElectricShoot(){
		if(!electricShootBegin.isPlaying && !electricShootLoop.isPlaying){
			electricShootBegin.Play();
			electricShootLoop.PlayScheduled(AudioSettings.dspTime+electricShootBegin.clip.length);
		}
	}

	public void PlayDynamoDeath(){
		if(!dynamoDeath.isPlaying)
			dynamoDeath.Play();
	}

	public void StopAll (){
		foreach (AudioSource s in sources) {
			s.Stop();
		}
	}

	public void StopElectricShoot(){
		electricShootBegin.Stop();
		electricShootLoop.Stop();
	}
	
	void PlayGameTheme(){
		if(!gameTheme.isPlaying)
			gameTheme.Play();
	}

	void PlayAmbientTheme(){
		if(!ambientTheme.isPlaying)
			ambientTheme.Play();
	}

	void PlayPauseTheme(){
		if(!pauseTheme.isPlaying)
			pauseTheme.Play();
	}


}
