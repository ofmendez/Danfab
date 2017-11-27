/* *********************************************************
FileName: TextEditorController.cs
Authors: Fabian Mendez <ofmendez@gmail.com>, 
		 Daniel Rodriguez <dlsusp@gmail.com>
Create Date: 14.11.2017
Modify Date: 27.11.2017 
********************************************************* */
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TextEditorController  : MonoBehaviour {

	InputField inField;
	public Text textToShow;


	void Start () {
		ResetEditor();
	}

	public void ResetEditor(){
		if(!inField){
			inField =  GetComponent<InputField>();
			inField.onValueChanged.AddListener(x => ChangeText());
		}
		textToShow.text = "";
		inField.text = "";
	}

	public int GetLinesCount() {
		return inField.text.Split('\n').Length;
	}

	public void AppendText(string _t){
		inField.text += _t;
	}


	public void ChangeText(){
		textToShow.text = Regex.Replace(inField.text,  @"\bsi\b"	,	 "<color=\"#f92672\">si</color>");
		textToShow.text = Regex.Replace(textToShow.text,  @"\bentrada\b"	,	 "<color=\"#a6e22e\">entrada</color>");
		textToShow.text = Regex.Replace(textToShow.text,  @"\bfalso\b"	,	 "<color=\"#66d9ef\">falso</color>");
		textToShow.text = Regex.Replace(textToShow.text,  @"\bverdadero\b"	,	 "<color=\"#66d9ef\">verdadero</color>");
		textToShow.text = Regex.Replace(textToShow.text,  @"\bmientras\b"	,	 "<color=\"#f92672\">mientras</color>");
		textToShow.text = Regex.Replace(textToShow.text,  @"\bfin\b"	,	 "<color=\"#f92672\">fin</color>");
		textToShow.text = Regex.Replace(textToShow.text,  @"\bentonces\b"	,	 "<color=\"#f92672\">entonces</color>");
		textToShow.text = Regex.Replace(textToShow.text,  @"\blista\b"	,	 "<color=\"#f92672\">lista</color>");
		textToShow.text = Regex.Replace(textToShow.text,  @"\btamaño de\b"	,	 "<color=\"#f92672\">tamaño de</color>");
		textToShow.text = Regex.Replace(textToShow.text,  @"\bsino\b"	,	 "<color=\"#f92672\">sino</color>");
		textToShow.text = Regex.Replace(textToShow.text,  @"\bo_si\b"	,	 "<color=\"#f92672\">o_si</color>");
		textToShow.text = Regex.Replace(textToShow.text,  @"\bcuando\b"	,	 "<color=\"#f92672\">cuando</color>");
		textToShow.text = Regex.Replace(textToShow.text,  @"\bescoge\b"	,	 "<color=\"#f92672\">escoge</color>");
		textToShow.text = Regex.Replace(textToShow.text,  @"\bimprima\b"	,	 "<color=\"#f92672\">imprima</color>");
		textToShow.text = Regex.Replace(textToShow.text,  @"\busa\b"	,	 "<color=\"#f92672\">usa</color>");
		textToShow.text = Regex.Replace(textToShow.text,  @"\bmenorque\b"	,	 "<color=\"#f92672\">menorque</color>");
		textToShow.text = Regex.Replace(textToShow.text,  @"\bmenorigual\b"	,	 "<color=\"#f92672\">menorigual</color>");
		textToShow.text = Regex.Replace(textToShow.text,  @"\bmayorque\b"	,	 "<color=\"#f92672\">mayorque</color>");
		textToShow.text = Regex.Replace(textToShow.text,  @"\bmayorigual\b"	,	 "<color=\"#f92672\">mayorigual</color>");
		textToShow.text = Regex.Replace(textToShow.text,  @"\bigual\b"	,	 "<color=\"#f92672\">igual</color>");
		textToShow.text = Regex.Replace(textToShow.text,  @"\bdiferente\b"	,	 "<color=\"#f92672\">diferente</color>");
		textToShow.text = Regex.Replace(textToShow.text,  @"\bnegar\b"	,	 "<color=\"#f92672\">negar</color>");
		textToShow.text = Regex.Replace(textToShow.text,  @"\by_logico\b"	,	 "<color=\"#f92672\">y_logico</color>");
		textToShow.text = Regex.Replace(textToShow.text,  @"\bo_logico\b"	,	 "<color=\"#f92672\">o_logico</color>");
	}

	
}
