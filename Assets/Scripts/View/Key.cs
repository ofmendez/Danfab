﻿/* *********************************************************
FileName: Key.cs
Authors: Fabian Mendez <ofmendez@gmail.com>, 
		 Daniel Rodriguez <dlsusp@gmail.com>
Create Date: 14.11.2017
Modify Date: 27.11.2017 
********************************************************* */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour {

	Button key;
	string keyName;
	public bool overrideTxt;
	public string textToOverride;

	void Start () {
		key = GetComponent<Button>();
		keyName = overrideTxt ? textToOverride : GetComponentInChildren<Text>().text;
		// key.onClick.AddListener(() => TextEditorController.main.AppendText(keyName));
	}
	

}
