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
