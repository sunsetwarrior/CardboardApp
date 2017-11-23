using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePhoto : MonoBehaviour {

	public Material skybox1;
	public Material skybox2;
	public Material skybox3;
	public Material skybox4;

	public GameObject bg1;
	public GameObject bg2;
	public GameObject bg3;
	public GameObject bg4;

	void Awake(){
		RenderSettings.skybox = skybox1;
		bg1.SetActive (true);
		bg2.SetActive (false);
		bg3.SetActive (false);
		bg4.SetActive (false);
	}
    public void ChangeSkybox()
    {
		if (RenderSettings.skybox.Equals(skybox1)) {
			bg2.SetActive (true);
			bg1.SetActive (false);
			RenderSettings.skybox = skybox2;
		} else if (RenderSettings.skybox.Equals(skybox2)) {
			bg2.SetActive (false);
			bg3.SetActive (true);
			RenderSettings.skybox = skybox3;	
		}else if(RenderSettings.skybox.Equals(skybox3))
        {
			bg3.SetActive (false);
			bg4.SetActive (true);
			RenderSettings.skybox = skybox4;
		}else if(RenderSettings.skybox.Equals(skybox4))
        {
			bg4.SetActive (false);
			bg1.SetActive (true);
			RenderSettings.skybox = skybox1;
		}
    }
}
