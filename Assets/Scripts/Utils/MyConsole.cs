/* *********************************************************
FileName: MyConsole.cs
Authors: Fabian Mendez <ofmendez@gmail.com>, 
		 Daniel Rodriguez <dlsusp@gmail.com>
Create Date: 14.11.2017
Modify Date: 27.11.2017 
********************************************************* */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class  MyConsole : Singleton< MyConsole> {


	public Text mText;

	public void AppendText(string _t){
		mText.text += _t+"\n"; 
	}

	public void ClearText(){
		mText.text = ""; 
	}
	
	
}
