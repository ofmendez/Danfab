/* *********************************************************
FileName: TypesEvent.cs
Authors: Fabian Mendez <ofmendez@gmail.com>, 
		 Daniel Rodriguez <dlsusp@gmail.com>
Create Date: 14.11.2017
Modify Date: 27.11.2017 
********************************************************* */
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[System.Serializable]
public class FloatEvent : UnityEvent<float> {}
[System.Serializable]
public class SpriteEvent : UnityEvent<Sprite> {}

