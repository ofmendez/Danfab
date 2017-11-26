using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEditorController  : MonoBehaviour {

	InputField inField;
	public GameObject line;
	// public GameObject txtRed;
	// public GameObject txtBlue;
	// public GameObject txtWhite;
	List<GameObject> lines = new List<GameObject>();


	// Use this for initialization
	void Start () {
		inField = GetComponent<InputField>();
	}

	public void AppendText(string _t){
		inField.text += _t;
	}
	// public void AppendBlueText(string _t){
		
	// }
	// public void AppendWhiteText(string _t){

	// }

	public void NewLine () {
		 GameObject newLine = Instantiate(line, line.transform.parent ,false) as GameObject;
		 newLine.SetActive(true);
		 lines.Add(newLine);
     // go.transform.parent = transform;
	}
	
}
