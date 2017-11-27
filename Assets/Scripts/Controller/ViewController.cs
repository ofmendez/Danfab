using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : Singleton< ViewController> {

	public List<GameObject> menus = new List<GameObject>();
	public List<Level> levels = new List<Level>();
	[Space(10)]
	public GameObject success;
	public MenuLevelsController menuLevel;
	Level actualLevel; 
	int LastLevelSuccess;

	void  MyAwake () {
		Screen.SetResolution(432,768,false);
	}

	void Start () {
		// SetAllInactive();
		// menus[0].SetActive(true);
	}

	// public void LaunchMenu(int _l){
	// 	SetAllInactive();
	// 	menus[_l].SetActive(true);
	// }

	public void LaunchLevelsMenu(){
		SetAllInactive();
		menuLevel.gameObject.SetActive(true);
		menuLevel.SetMaxAviable(LastLevelSuccess);

	}

	public void LaunchLevel(int _l){
		levels[_l-1].gameObject.SetActive(true);
		levels[_l-1].SetupLevel();
		actualLevel = levels[_l-1];
	}

	public void LevelSucess(int _l){
		LastLevelSuccess = _l;
		SetAllInactive();
		success.SetActive(true);
	}



	void SetAllInactive(){
		foreach (GameObject m in menus) {
			m.SetActive(false);
		}
		foreach (Level l in levels) {
			l.gameObject.SetActive(false);
		}
	}
	
}
