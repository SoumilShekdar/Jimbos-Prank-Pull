using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialControls : MonoBehaviour {
	private SpriteRenderer sr;
	public Sprite lore;
	public Sprite Tutorial1;
	public Sprite Tutorial2;
	public Sprite Tutorial3;
	public Button dontShow;
	private int off;
	// Use this for initialization
	void Start () {
		dontShow.gameObject.SetActive (false);
		sr = this.GetComponent<SpriteRenderer> ();
		sr.sprite = lore;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touches.Length > 0) {
			Touch t = Input.GetTouch (0);
			if (t.phase == TouchPhase.Began) {
				if (sr.sprite == Tutorial3) {
					Application.LoadLevel ("mainGame");
				}
				if (sr.sprite == Tutorial2) {
					sr.sprite = Tutorial3;
				}
				if (sr.sprite == Tutorial1) {
					sr.sprite = Tutorial2;
				}
				if (sr.sprite == lore) {
					sr.sprite = Tutorial1;
				}
			}
		}
	}
	public void dontShowAgain(){
		off = 1;
		PlayerPrefs.SetInt ("TutorialOnOff", off);
		dontShow.gameObject.SetActive (true);
	}
}
