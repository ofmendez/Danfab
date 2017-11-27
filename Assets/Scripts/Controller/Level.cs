/* *********************************************************
FileName: Level.cs
Authors: Fabian Mendez <ofmendez@gmail.com>, 
		 Daniel Rodriguez <dlsusp@gmail.com>
Create Date: 14.11.2017
Modify Date: 27.11.2017 
********************************************************* */
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour {

	PatternScreen patternScreen;
	public InputField editor;
	public int levelNumber =0;
	public bool testWithArrays;
	public bool testWithArraysInitialized;
	public bool testWithOnlyPositives;
	TextEditorController  actualEditor;
	LevelTimer timer;
	private bool levelStarted;

	void Start () {
		patternScreen  = GetComponentInChildren<PatternScreen>(true);
		actualEditor  = GetComponentInChildren<TextEditorController>(true);
		timer  = GetComponentInChildren<LevelTimer>(true);
		patternScreen.gameObject.SetActive(true);
		patternScreen.FirstLaunch();
		patternScreen.goButton.onClick.AddListener(GoButton);
//		PlayerPrefs.DeleteAll();
	}

	public void SetupLevel(){
		patternScreen  = patternScreen?patternScreen: GetComponentInChildren<PatternScreen>(true);
		timer  = timer?timer: GetComponentInChildren<LevelTimer>(true);
		actualEditor  = actualEditor?actualEditor: GetComponentInChildren<TextEditorController>(true);
		patternScreen.gameObject.SetActive(true);
		patternScreen.FirstLaunch();
		timer.ResetTime();
		actualEditor.ResetEditor();
		levelStarted =false;
		
	}


	public void GoButton(){
		patternScreen.gameObject.SetActive(false);
		if (!levelStarted){
			levelStarted = true;
			timer.StartCount();
		}
	}

	public void TestLevel (){
		string textToTest = "";
		int hits = 0;
		int expected =0;
		int cases = 10;
		for (int i = (testWithOnlyPositives? 0:-cases); i <= cases; i++){
			textToTest = GetTextToTest(i);
			Fa.main.EvalCode(textToTest);
			Debug.Log(" compara:_ "+MyConsole.main.mText.text.Trim(' ', '\r', '\n' ) + " ...con... "+GetOut(i));
			hits += MyConsole.main.mText.text.Trim(' ', '\r', '\n' ) == GetOut(i) ? 1 :0;
			expected ++;
			MyConsole.main.ClearText();
			textToTest = "";
		}
		if (hits == expected ){
				LaunchSuccessView();
		}
	}


	void LaunchSuccessView(){
		actualEditor  =actualEditor?actualEditor: GetComponentInChildren<TextEditorController>(true);
		ViewController.main.LevelSucess(levelNumber);
		SuccessController.main.SetNLines( actualEditor.GetLinesCount());
		SuccessController.main.SetTime( timer.GetSeconds() );
	}


	string GetTextToTest(int i){
		string result = "";
		if(testWithArraysInitialized){
			result = buildList(i)+" " 
					 + editor.text;
		}else if(testWithArrays){
			result = "  lista entrada de "+Mathf.Abs(i)+" " 
					 + editor.text;
		}else{
			result = " entrada : "+i+" " 
					 + editor.text ;
		}
		return result;
	}


	string buildList(int i){
		int _p1 = Mathf.Abs(i);
		System.Random rnd = new System.Random();
		int[] numbers = Enumerable.Range(-_p1/2,_p1+1).OrderBy(r => rnd.Next()).ToArray();
		string result = string.Format("varofmendez :0  lista entrada de "+_p1+1);
		int k=0;
		foreach (int n in numbers) {
			result +=" entrada en "+k+" : "+n;
			k++;
		}

		return result;
	}

	string GetOut(int i){
		Del fn = (b=> (""));
		switch (levelNumber) {
		    case 1:
		      fn= FuncLvl1;
		      break;
		    case 2:
		      fn= FuncLvl2;
		      break;
		    case 3:
		      fn= FuncLvl3;
		      break;
		    case 4:
		      fn= FuncLvl4;
		      break;
		    case 5:
		      fn= FuncLvl5;
		      break;
  		    case 6:
		      fn= FuncLvl6;
		      break;
  		    case 7:
		      fn= FuncLvl7;
		      break;
		}
		return fn(i);
	}

	public delegate string Del(int _p);

	string FuncLvl1(int i){
		return (i+1).ToString();
	}

	string FuncLvl2(int i){
		return i>0 ? "verdadero":"falso";
	}

	string FuncLvl3(int i){
		return Mathf.Abs(i).ToString();
	}	

	string FuncLvl4(int i){
		return Mathf.Abs(i).ToString(); 
	}	

	string FuncLvl5(int i){
        string result = "[ ";
        for (int k = 0; k < i; k++){
            result += k +  (k==i-1 ?" ":", ");
        }
        result += "]";
		return result;
	}

	string FuncLvl6(int i){
		int _p1 = Mathf.Abs(i);
		System.Random rnd = new System.Random();
		string result =""+ Enumerable.Range(-_p1/2,_p1+1).Max();
		return result;
	}	
	
	string FuncLvl7(int i){
		int n = Mathf.Abs(i);

		return Fibonacci(i);
	}	

	string Fibonacci(int n) {
        int a = 0;
        int b = 1;
        for (int i = 0; i < n; i++) {
            int temp = a;
            a = b;
            b = temp + b;
        }
        return a.ToString();
    }
}