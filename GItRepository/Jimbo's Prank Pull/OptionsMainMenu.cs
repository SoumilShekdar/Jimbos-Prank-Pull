using UnityEngine;
using System.Collections;

public class OptionsMainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void play(){
		if (PlayerPrefs.GetInt ("TutorialOnOff") == 1) {
			Application.LoadLevel ("mainGame");
		} else {
			Application.LoadLevel("Tutorial");
		}
	}
	public void settings(){
		Application.LoadLevel ("Settings");
	}
	public void achievements(){
		Application.LoadLevel ("Achievements");
	}
}
