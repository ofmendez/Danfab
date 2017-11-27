/* *********************************************************
FileName: TextTyper.cs
Authors: Fabian Mendez <ofmendez@gmail.com>, 
         Daniel Rodriguez <dlsusp@gmail.com>
Create Date: 14.11.2017
Modify Date: 27.11.2017 
********************************************************* */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
 
public class TextTyper : MonoBehaviour {
 
     public float letterPause = 0.2f;
     public float waitTime = 3;
     public List<GameObject> toEnable;
     public List<GameObject> toDisable;
 
     string message;
     Text textComp;
 
     void OnEnable () {
        StopAllCoroutines();
        textComp = textComp? textComp : GetComponent<Text>();
        message = textComp.text;
        textComp.text = "";
        StartCoroutine(TypeText ());
     }
 
     IEnumerator TypeText () {
         foreach (char letter in message.ToCharArray()) {
             textComp.text += letter;
             yield return 0;
             yield return new WaitForSeconds (letterPause);
         }
         yield return new WaitForSeconds (waitTime);
         foreach (GameObject g in toEnable) {
         	g.SetActive(true);
         }
         foreach (GameObject g in toDisable) {
         	g.SetActive(false);
         }
     }
 }