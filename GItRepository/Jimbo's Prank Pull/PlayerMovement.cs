using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    public static float distanceTraveled;
    // Use this for initialization
    void Start () {
		speed = 1.35f;
	}
	
	// Update is called once per frame
	void Update () {
		PlayerTouchControls playerTouchContols = this.GetComponent<PlayerTouchControls> ();
		if (playerTouchContols.gameActive == true) {
			transform.Translate (speed * Time.deltaTime, 0f, 0f);
			distanceTraveled = transform.localPosition.x;
		}
	}
}
