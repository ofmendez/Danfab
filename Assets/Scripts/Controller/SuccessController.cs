/* *********************************************************
FileName: SuccessController.cs
Authors: Fabian Mendez <ofmendez@gmail.com>, 
		 Daniel Rodriguez <dlsusp@gmail.com>
Create Date: 14.11.2017
Modify Date: 27.11.2017 
********************************************************* */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessController : Singleton< SuccessController> {

	public Text nLines;
	public Text time;
	public Text complex;


	public void SetNLines ( int n) {
		nLines.text = ""+n;
		System.Random rnd = new System.Random();
		complex.text = ""+rnd.Next(20,100);
	}

	public void SetTime ( int n) {
		time.text = ""+n;
	}

}