using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Settings : MonoBehaviour {
	public Button sound;
	public Button music;
	public Button tutorial;
	public Button tip;
	public GameObject musicController;
	// Use this for initialization
	void Start () {
		musicController = GameObject.FindGameObjectWithTag ("BackGroundMusic");
		if (PlayerPrefs.GetInt ("SoundOnOff") == 1) {
			sound.GetComponentInChildren<Text>().text = "O F F";
		}
		else{
			sound.GetComponentInChildren<Text>().text = "O N";
		}
		if (PlayerPrefs.GetInt ("MusicOnOff") == 1) {
			music.GetComponentInChildren<Text>().text = "O F F";
		}
		else {
			music.GetComponentInChildren<Text>().text = "O N";
		}
		if (PlayerPrefs.GetInt ("TutorialOnOff") == 1) {
			tutorial.GetComponentInChildren<Text>().text = "O F F";
		}
		else {
			tutorial.GetComponentInChildren<Text>().text = "O N";
		}
		if (PlayerPrefs.GetInt ("TipOnOff") == 1) {
			tip.GetComponentInChildren<Text>().text = "O F F";
		}
		else {
			tip.GetComponentInChildren<Text>().text = "O N";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SoundOnOff(){
		if (PlayerPrefs.GetInt ("SoundOnOff") == 0) {
			PlayerPrefs.SetInt ("SoundOnOff", 1);
			sound.GetComponentInChildren<Text>().text = "O F F";
		}
		else{
			PlayerPrefs.SetInt ("SoundOnOff", 0);
			sound.GetComponentInChildren<Text>().text = "O N";
		}
	}
	public void MusicOnOff(){
		if (PlayerPrefs.GetInt ("MusicOnOff") == 0) {
			PlayerPrefs.SetInt ("MusicOnOff", 1);
			music.GetComponentInChildren<Text>().text = "O F F";
			BackgroundmUsic backgroudnMusic = musicController.GetComponent<BackgroundmUsic> ();
			backgroudnMusic.playMusic ();
		}
		else {
			PlayerPrefs.SetInt ("MusicOnOff", 0);
			music.GetComponentInChildren<Text>().text = "O N";
			BackgroundmUsic backgroudnMusic = musicController.GetComponent<BackgroundmUsic> ();
			backgroudnMusic.playMusic ();
		}
	}
	public void TutorialOnOff(){
		if (PlayerPrefs.GetInt ("TutorialOnOff") == 0) {
			PlayerPrefs.SetInt ("TutorialOnOff", 1);
			tutorial.GetComponentInChildren<Text>().text = "O F F";
		}
		else {
			PlayerPrefs.SetInt ("TutorialOnOff", 0);
			tutorial.GetComponentInChildren<Text>().text = "O N";
		}
	}
	public void TipOnOff(){
		if (PlayerPrefs.GetInt ("TipOnOff") == 0) {
			PlayerPrefs.SetInt ("TipOnOff", 1);
			tip.GetComponentInChildren<Text>().text = "O F F";
		}
		else {
			PlayerPrefs.SetInt ("TipOnOff", 0);
			tip.GetComponentInChildren<Text>().text = "O N";
		}
	}
	public void MainMenu(){
		Application.LoadLevel ("mainMenu");
	}
}
