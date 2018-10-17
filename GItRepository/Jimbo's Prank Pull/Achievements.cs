using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Achievements : MonoBehaviour {
	public Text noOfGames;
	public Text highScore;
	// Use this for initialization
	void Start () {
		noOfGames.text = PlayerPrefs.GetInt ("NumberOfGames").ToString ();
		highScore.text = PlayerPrefs.GetInt("High Score").ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
