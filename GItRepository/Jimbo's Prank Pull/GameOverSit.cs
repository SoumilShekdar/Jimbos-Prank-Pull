using UnityEngine;
using System.Collections;

public class GameOverSit : MonoBehaviour {
    public GameObject player;
    
    	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Chair")){
			
			player.gameObject.GetComponent<PlayerTouchControls>().endGameNPCSit();
        }
    }
}
