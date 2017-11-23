using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilderToText : MonoBehaviour {

	Text text;
	public Dropdown letters;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}

	public void textUpdate(float value){
		text.text = Mathf.RoundToInt (value) + "";
	}

	public void textUpdateFloat(float value){
		text.text = value.ToString ("#.0");
	}

	public void textUpdatePercent(float value){
		text.text = Mathf.RoundToInt (value) + "°";
	}

	public void textUpdateString(int value){
		switch(letters.value){
		case 0:
			text.text += "a";
			break;
		case 1:
			text.text += "b";
			break;
		case 2:
			text.text += "c";
			break;
		case 3:
			text.text += "d";
			break;
		case 4:
			text.text += "e";
			break;
		case 5:
			text.text += "f";
			break;
		case 6:
			text.text += "g";
			break;
		case 7:
			text.text += "h";
			break;
		case 8:
			text.text += "i";
			break;
		case 9:
			text.text += "j";
			break;
		case 10:
			text.text += "k";
			break;
		case 11:
			text.text += "l";
			break;
		case 12:
			text.text += "m";
			break;
		case 13:
			text.text += "n";
			break;
		case 14:
			text.text += "o";
			break;
		case 15:
			text.text += "p";
			break;
		case 16:
			text.text += "q";
			break;
		case 17:
			text.text += "r";
			break;
		case 18:
			text.text += "s";
			break;
		case 19:
			text.text += "t";
			break;
		case 20:
			text.text += "u";
			break;
		case 21:
			text.text += "v";
			break;
		case 22:
			text.text += "w";
			break;
		case 23:
			text.text += "x";
			break;
		case 24:
			text.text += "y";
			break;
		case 25:
			text.text += "z";
			break;
		case 26:
			text.text += " ";
			break;
		}
	}
}
