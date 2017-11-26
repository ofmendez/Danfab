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
