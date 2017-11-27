/* *********************************************************
FileName: MenuLevelsController.cs
Authors: Fabian Mendez <ofmendez@gmail.com>, 
		 Daniel Rodriguez <dlsusp@gmail.com>
Create Date: 14.11.2017
Modify Date: 27.11.2017 
********************************************************* */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLevelsController : MonoBehaviour {
	public List<Button> buttonMenus = new List<Button>();

	public void SetMaxAviable(int max){
		int active = 0;
		foreach ( Button b in buttonMenus ) {
			if(active <= max){
				b.GetComponent<Animator>().enabled = true;
				b.interactable = true;
			}else{
				b.GetComponent<Animator>().enabled = false;
				b.interactable = false;
			}
			active ++;
		}

	}
}
