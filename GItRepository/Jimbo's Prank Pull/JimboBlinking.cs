using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JimboBlinking : MonoBehaviour {
	
	public Text Jimbo;
	string textToFlash = "Jimbo !!!";
	string blankText =" ";
	bool isBlinking = true;

	void Start(){
		StartCoroutine (blink ());
	}
	void  Update(){
		
	}
	IEnumerator blink(){
		while (isBlinking) {
			Jimbo.text = textToFlash;
			yield return new WaitForSeconds(0.5f);
			Jimbo.text = blankText;
			yield return new WaitForSeconds(0.5f);
		}
	}
		
}