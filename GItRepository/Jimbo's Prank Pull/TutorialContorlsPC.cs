using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TutorialContorlsPC : MonoBehaviour {

	private SpriteRenderer sr;
	public Sprite Tutorial1;
	public Sprite Tutorial2;
	public Sprite Tutorial3;
	public Button dontShow;
	private int off;
	// Use this for initialization
	void Start () {
		dontShow.gameObject.SetActive (false);
		sr = this.GetComponent<SpriteRenderer> ();
		sr.sprite = Tutorial1;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			if (sr.sprite == Tutorial3) {
				Application.LoadLevel ("mainGame");
			}
			if (sr.sprite == Tutorial2) {
				sr.sprite = Tutorial3;
			}
			if (sr.sprite == Tutorial1) {
				sr.sprite = Tutorial2;
			}

		}
	}
	public void dontShowAgain(){
		off = 1;
		PlayerPrefs.SetInt ("TutorialOnOff", off);
		dontShow.gameObject.SetActive (true);
	}
}
