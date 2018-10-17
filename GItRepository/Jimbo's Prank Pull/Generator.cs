using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Generator : MonoBehaviour {
    public Transform cube;
    public int numberOfObject;
    public Vector3 startPosition;
    private Vector3 nextPosition;
	public float recycleDistance;
	private Queue<Transform> objectQueue;


    // Use this for initialization
    void Start () {

		objectQueue = new Queue<Transform> (numberOfObject);
        nextPosition = startPosition;
		for(int i =0 ;i < numberOfObject; i++)
		{


			Transform generatedObject = (Transform)Instantiate(cube);
			generatedObject.localPosition = nextPosition;
			nextPosition.x += generatedObject.localScale.x;
			objectQueue.Enqueue (generatedObject);

		}

	}
	
	// Update is called once per frame
	void Update () {
		//if (objectQueue.Peek ().localPosition.x + recycleDistance < Movement.distanceTraveled) {
			//Transform generatedObject = objectQueue.Dequeue ();
			//generatedObject.localPosition = nextPosition;
			//nextPosition.x += generatedObject.localScale.x;
			//objectQueue.Enqueue (generatedObject);
		//}
        

	}
}
