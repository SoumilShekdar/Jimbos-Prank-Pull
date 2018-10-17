using UnityEngine;
using System.Collections;

public class BackgroundmUsic : MonoBehaviour {
	private AudioSource audio;
	public static BackgroundmUsic Instance;
	// Use this for initialization
	void Start () {
		audio = this.GetComponent<AudioSource> ();
		if (PlayerPrefs.GetInt ("MusicOnOff") != 1) {
			playMusic ();
		}
	}
	void Awake(){
		if (Instance) {
			DestroyImmediate (gameObject);
		} else {
			Instance = this;
		}
	}
	// Update is called once per frame
	void Update () {
		DontDestroyOnLoad (this.gameObject);
	}
	public void playMusic(){
		Debug.Log ("PlayMusic");
		if (audio.isPlaying) {
			audio.Stop ();
		} else {
			audio.Play ();
		}
	}
}
