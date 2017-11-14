using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class  MyConsole : Singleton< MyConsole> {


	public Text mText;

	public void AppendText(string _t){
		mText.text += "\n"+_t; 
	}

	public void ClearText(){
		mText.text = ""; 
	}
	
	
}
