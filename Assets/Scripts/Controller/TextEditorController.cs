using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEditorController  : MonoBehaviour {

	InputField inField;
	public GameObject line;
	// List<GameObject> lines = new List<GameObject>();


	// Use this for initialization
	void Start () {
		inField = GetComponent<InputField>();
		inField.onValueChanged.AddListener(delegate{ ChangeText(); });
	}

	public void AppendText(string _t){
		inField.text += _t;
	}

	void ChangeText(){
		inField.text = inField.text.Replace("si", "<color=\"#f92672\"><b>si</b></color>");
	}
	// public void AppendBlueText(string _t){
		
	// }
	// public void AppendWhiteText(string _t){

	// }

	public void NewLine () {
		 GameObject newLine = Instantiate(line, line.transform.parent ,false) as GameObject;
		 newLine.SetActive(true);
		 //lines.Add(newLine);
     // go.transform.parent = transform;
	}
	
}
