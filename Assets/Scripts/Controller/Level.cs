using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour {

	public GameObject patternScreen;
	public InputField editor;
	public int levelNumber =0;
	public bool testWithArrays;
	public bool testWithArraysInitialized;

	void Start () {
		patternScreen.SetActive(true);
	}

	public void TestLevel (){
		string textToTest = "";
		int hits = 0;
		int cases = 10;
		for (int i = -cases; i <= cases; i++){
			textToTest = GetTextToTest(i);
			Fa.main.EvalCode(textToTest);
			// Debug.Log(" compara:_ "+MyConsole.main.mText.text.Trim(' ', '\r', '\n' ) + " ...con... "+GetOut(i));
			hits += MyConsole.main.mText.text.Trim(' ', '\r', '\n' ) == GetOut(i) ? 1 :0;
			MyConsole.main.ClearText();
			textToTest = "";
		}
		if (hits == (cases*2)+1 ){
			ViewController.main.LevelSucess(levelNumber);
		}
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
		return (i+1).ToString();
	}	
}