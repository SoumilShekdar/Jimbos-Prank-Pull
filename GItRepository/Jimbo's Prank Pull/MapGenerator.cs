using UnityEngine;
using System.Collections;
using System;

public class MapGenerator : MonoBehaviour {
    public Transform player;
    public Transform b1;
    public Transform b2;
    public Vector3 startPoint;
    private Vector3 nextPoint;
	// Use this for initialization
	void Start () {
		Console.Write ("Start");
        nextPoint = startPoint;
	}
	
	// Update is called once per frame
	void Update () {
        
		nextPoint = startPoint;	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("background1"))
        {
			//Debug.Log ("b1 Enter");
            nextPoint.x += player.transform.position.x;
            b2.transform.position = nextPoint;

        }
        if (other.gameObject.CompareTag("background2"))
        {
			//Debug.Log ("b2 Enter");
            nextPoint.x += player.transform.position.x;
            b1.transform.position = nextPoint;
        }
    }
}
