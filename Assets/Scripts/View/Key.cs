using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour {

	Button key;
	string keyName;
	public bool overrideTxt;
	public string textToOverride;
	// Use this for initialization
	void Start () {
		key = GetComponent<Button>();
		keyName = overrideTxt ? textToOverride : GetComponentInChildren<Text>().text;
		// key.onClick.AddListener(() => TextEditorController.main.AppendText(keyName));
	}
	

}
