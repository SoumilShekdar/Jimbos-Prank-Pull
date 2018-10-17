using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public float cameraSpeed;
	public GameObject player;
	// Use this for initialization
	void Start () {
		PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
		cameraSpeed = playerMovement.speed;
	}
	
	// Update is called once per frame
	void Update () {
		PlayerTouchControls playerTouchContorls = player.GetComponent<PlayerTouchControls> ();
		if (playerTouchContorls.gameActive == true) {
			transform.Translate (cameraSpeed * Time.deltaTime, 0f, 0f);
		}
    }
}
