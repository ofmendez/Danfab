﻿/* *********************************************************
FileName: StatesOfButton.cs
Authors: Fabian Mendez <ofmendez@gmail.com>
Create Date: 14.11.2017
Modify Date: 27.11.2017 
********************************************************* */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;


public class StatesOfButton : MonoBehaviour {
	public UnityEvent[] onClickState;
	int activeState;

	void Awake(){
		this.GetComponent<Button>().onClick.AddListener(RunEvent);
	}

	public void RunEvent () {
		if(activeState < onClickState.Length ){
			onClickState[activeState].Invoke();
		}else{
			Debug.Log("ERROR, NO ESTABLECIDO ESTADO VALIDO DENTRO DEL RANGO");
		}
	}

	public void SetBunchOfEvents (int _i) {
		activeState = _i;
	}
}
