using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeGrabber : MonoBehaviour {

	public void Start_close(){
		gameObject.SetActive (!gameObject.activeSelf);
	}
}
