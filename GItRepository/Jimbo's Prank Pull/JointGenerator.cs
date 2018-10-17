using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JointGenerator : MonoBehaviour {
    public Transform chairUp;
    public Transform chairDown;
    public Transform NPCUp1;
    public Transform NPCUp2;
    public Transform NPCUp3;
    public Transform NPCUp4;
    public Transform NPCUp5;
    public Transform NPCDown1;
    public Transform NPCDown2;
    public Transform NPCDown3;
    public Transform NPCDown4;
    public Transform NPCDown5;
    public int noOfChairSpawn;
    private int spawnedChairs;
    private Vector2 upChairPositionBase;
    private Vector2 downChairPositionBase;
    private Vector2 upNPCPositionBase;
    private Vector2 downNPCPositionBase;
    private Vector2 spawnPosition;
    public float recycleDistance;
    private float xPosition;
    private Queue<Transform> spawnedChairUpQueue;
    private Queue<Transform> spawnedNPCUpQueue;
    private Queue<Transform> spawnedChairDownQueue;
    private Queue<Transform> spawnedNPCDownQueue;
    System.Random rnd = new System.Random();
	public float endOfRandomRange;
	public float startOfRandomRange;
    // Use this for initialization
    void Start () {
        spawnedChairUpQueue = new Queue<Transform>(spawnedChairs);
        spawnedNPCUpQueue = new Queue<Transform>(spawnedChairs);
        spawnedChairDownQueue = new Queue<Transform>(spawnedChairs);
        spawnedNPCDownQueue = new Queue<Transform>(spawnedChairs);
        spawnedChairs = 0;
        xPosition = 1.5f;
        upChairPositionBase = new Vector2(0f, 0.32f);
        upNPCPositionBase = new Vector2(0f, 0.60f);
        downChairPositionBase = new Vector2(0f, -0.32f);
        downNPCPositionBase = new Vector2(0f, -0.52f);
		endOfRandomRange = 1f;
		startOfRandomRange = 0.5f;
        

                  
	}

	// Update is called once per frame
	void Update () {
        for (; spawnedChairs < noOfChairSpawn; spawnedChairs++)
        {
            xPosition += Random.Range(startOfRandomRange, endOfRandomRange);
            int randomNumber = rnd.Next(1, 3);
			//Debug.Log (noOfChairSpawn);

            if (randomNumber % 2 == 0)//even
            {

                Transform generatedUpChair = (Transform)Instantiate(chairUp);
                upChairPositionBase.x = xPosition;
                generatedUpChair.localPosition = upChairPositionBase;
                spawnedChairUpQueue.Enqueue(generatedUpChair);
                int randomNPCUpNumber = rnd.Next(1, 6);
                if (randomNPCUpNumber == 1)
                {
                    Transform generatedUpNPC = (Transform)Instantiate(NPCUp1);
                    upNPCPositionBase.x = xPosition;
                    generatedUpNPC.localPosition = upNPCPositionBase;
                    spawnedNPCUpQueue.Enqueue(generatedUpNPC);
                }
                if (randomNPCUpNumber == 2)
                {
                    Transform generatedUpNPC = (Transform)Instantiate(NPCUp2);
                    upNPCPositionBase.x = xPosition;
                    generatedUpNPC.localPosition = upNPCPositionBase;
                    spawnedNPCUpQueue.Enqueue(generatedUpNPC);
                }
                if (randomNPCUpNumber == 3)
                {
                    Transform generatedUpNPC = (Transform)Instantiate(NPCUp3);
                    upNPCPositionBase.x = xPosition;
                    generatedUpNPC.localPosition = upNPCPositionBase;
                    spawnedNPCUpQueue.Enqueue(generatedUpNPC);
                }
                if (randomNPCUpNumber == 4)
                {
                    Transform generatedUpNPC = (Transform)Instantiate(NPCUp4);
                    upNPCPositionBase.x = xPosition;
                    generatedUpNPC.localPosition = upNPCPositionBase;
                    spawnedNPCUpQueue.Enqueue(generatedUpNPC);
                }
                if (randomNPCUpNumber == 5)
                {
                    Transform generatedUpNPC = (Transform)Instantiate(NPCUp5);
                    upNPCPositionBase.x = xPosition;
                    generatedUpNPC.localPosition = upNPCPositionBase;
                    spawnedNPCUpQueue.Enqueue(generatedUpNPC);
                }
            }
            else//odd
            {

                Transform generatedDownChair = (Transform)Instantiate(chairDown);
                downChairPositionBase.x = xPosition;
                generatedDownChair.localPosition = downChairPositionBase;
                spawnedChairDownQueue.Enqueue(generatedDownChair);
                int randomNPCDownNumber = rnd.Next(1, 6);
                if (randomNPCDownNumber == 1)
                {
                    Transform generatedDownNPC = (Transform)Instantiate(NPCDown1);
                    downNPCPositionBase.x = xPosition;
                    generatedDownNPC.localPosition = downNPCPositionBase;
                    spawnedNPCDownQueue.Enqueue(generatedDownNPC);
                }
                if (randomNPCDownNumber == 2)
                {
                    Transform generatedDownNPC = (Transform)Instantiate(NPCDown2);
                    downNPCPositionBase.x = xPosition;
                    generatedDownNPC.localPosition = downNPCPositionBase;
                    spawnedNPCDownQueue.Enqueue(generatedDownNPC);
                }
                if (randomNPCDownNumber == 3)
                {
                    Transform generatedDownNPC = (Transform)Instantiate(NPCDown3);
                    downNPCPositionBase.x = xPosition;
                    generatedDownNPC.localPosition = downNPCPositionBase;
                    spawnedNPCDownQueue.Enqueue(generatedDownNPC);
                }
                if (randomNPCDownNumber == 4)
                {
                    Transform generatedDownNPC = (Transform)Instantiate(NPCDown4);
                    downNPCPositionBase.x = xPosition;
                    generatedDownNPC.localPosition = downNPCPositionBase;
                    spawnedNPCDownQueue.Enqueue(generatedDownNPC);
                }
                if (randomNPCDownNumber == 5)
                {
                    Transform generatedDownNPC = (Transform)Instantiate(NPCDown5);
                    downNPCPositionBase.x = xPosition;
                    generatedDownNPC.localPosition = downNPCPositionBase;
                    spawnedNPCDownQueue.Enqueue(generatedDownNPC);
                }

            }
        }
        recycleObjects();
        
	} 
    void recycleObjects()
    {
        if (spawnedChairUpQueue.Peek().localPosition.x + recycleDistance < PlayerMovement.distanceTraveled)
        {
			Transform generatedUpChair = spawnedChairUpQueue.Dequeue ();
			Destroy (generatedUpChair.gameObject);
			Debug.Log ("spawnedchair");
            spawnedChairs--;
        }
        if (spawnedNPCUpQueue.Peek().localPosition.x + recycleDistance < PlayerMovement.distanceTraveled)
        {
            Transform generatedUpNPC = spawnedNPCUpQueue.Dequeue();
            Destroy(generatedUpNPC.gameObject);
			Debug.Log ("spawnedchair");
        }
        if (spawnedChairDownQueue.Peek().localPosition.x + recycleDistance < PlayerMovement.distanceTraveled)
        {
            Transform generatedDownChair = spawnedChairDownQueue.Dequeue();
            Destroy(generatedDownChair.gameObject);
			Debug.Log ("spawnedchair");
            spawnedChairs--;
        }
        if (spawnedNPCDownQueue.Peek().localPosition.x + recycleDistance < PlayerMovement.distanceTraveled)
        {
            Transform generatedDownNPC = spawnedNPCDownQueue.Dequeue();
            Destroy(generatedDownNPC.gameObject);
			Debug.Log ("spawnedchair");
        }
    }

/*
	// Update is called once per frame
	void Update () {
		
		for (; spawnedChairs < noOfChairSpawn; spawnedChairs++)
		{
			xPosition += Random.Range(0.5f, 1f);
			int randomNumber = rnd.Next(1, 3);
			Debug.Log (noOfChairSpawn);

			if (randomNumber % 2 == 0)//even
			{

				Transform generatedUpChair = recycleChair();
				upChairPositionBase.x = xPosition;
				generatedUpChair.localPosition = upChairPositionBase;
				spawnedChairUpQueue.Enqueue(generatedUpChair);
				int randomNPCUpNumber = rnd.Next(1, 6);
				if (randomNPCUpNumber == 1)
				{
					Transform generatedUpNPC = (Transform)Instantiate(NPCUp1);
					upNPCPositionBase.x = xPosition;
					generatedUpNPC.localPosition = upNPCPositionBase;
					spawnedNPCUpQueue.Enqueue(generatedUpNPC);
				}
				if (randomNPCUpNumber == 2)
				{
					Transform generatedUpNPC = (Transform)Instantiate(NPCUp2);
					upNPCPositionBase.x = xPosition;
					generatedUpNPC.localPosition = upNPCPositionBase;
					spawnedNPCUpQueue.Enqueue(generatedUpNPC);
				}
				if (randomNPCUpNumber == 3)
				{
					Transform generatedUpNPC = (Transform)Instantiate(NPCUp3);
					upNPCPositionBase.x = xPosition;
					generatedUpNPC.localPosition = upNPCPositionBase;
					spawnedNPCUpQueue.Enqueue(generatedUpNPC);
				}
				if (randomNPCUpNumber == 4)
				{
					Transform generatedUpNPC = (Transform)Instantiate(NPCUp4);
					upNPCPositionBase.x = xPosition;
					generatedUpNPC.localPosition = upNPCPositionBase;
					spawnedNPCUpQueue.Enqueue(generatedUpNPC);
				}
				if (randomNPCUpNumber == 5)
				{
					Transform generatedUpNPC = (Transform)Instantiate(NPCUp5);
					upNPCPositionBase.x = xPosition;
					generatedUpNPC.localPosition = upNPCPositionBase;
					spawnedNPCUpQueue.Enqueue(generatedUpNPC);
				}
			}
			else//odd
			{

				Transform generatedDownChair = (Transform)Instantiate(chairDown);
				downChairPositionBase.x = xPosition;
				generatedDownChair.localPosition = downChairPositionBase;
				spawnedChairDownQueue.Enqueue(generatedDownChair);
				int randomNPCDownNumber = rnd.Next(1, 6);
				if (randomNPCDownNumber == 1)
				{
					Transform generatedDownNPC = (Transform)Instantiate(NPCDown1);
					downNPCPositionBase.x = xPosition;
					generatedDownNPC.localPosition = downNPCPositionBase;
					spawnedNPCDownQueue.Enqueue(generatedDownNPC);
				}
				if (randomNPCDownNumber == 2)
				{
					Transform generatedDownNPC = (Transform)Instantiate(NPCDown2);
					downNPCPositionBase.x = xPosition;
					generatedDownNPC.localPosition = downNPCPositionBase;
					spawnedNPCDownQueue.Enqueue(generatedDownNPC);
				}
				if (randomNPCDownNumber == 3)
				{
					Transform generatedDownNPC = (Transform)Instantiate(NPCDown3);
					downNPCPositionBase.x = xPosition;
					generatedDownNPC.localPosition = downNPCPositionBase;
					spawnedNPCDownQueue.Enqueue(generatedDownNPC);
				}
				if (randomNPCDownNumber == 4)
				{
					Transform generatedDownNPC = (Transform)Instantiate(NPCDown4);
					downNPCPositionBase.x = xPosition;
					generatedDownNPC.localPosition = downNPCPositionBase;
					spawnedNPCDownQueue.Enqueue(generatedDownNPC);
				}
				if (randomNPCDownNumber == 5)
				{
					Transform generatedDownNPC = (Transform)Instantiate(NPCDown5);
					downNPCPositionBase.x = xPosition;
					generatedDownNPC.localPosition = downNPCPositionBase;
					spawnedNPCDownQueue.Enqueue(generatedDownNPC);
				}

			}
		}


	} 
	Transform recycleChair()
	{
		Transform generatedUpChair = null;
		if (spawnedChairUpQueue.Count > 0) {
			if (spawnedChairUpQueue.Peek ().localPosition.x + recycleDistance < PlayerMovement.distanceTraveled) {
				generatedUpChair = spawnedChairUpQueue.Dequeue ();
				//Destroy (generatedUpChair.gameObject);
				Debug.Log ("spawnedchair");
				spawnedChairs--;
			}
			else
			{
				generatedUpChair = (Transform)Instantiate (chairUp);
				Debug.Log ("did not find spawnedchair");
			}
		}
		else
		{
			generatedUpChair = (Transform)Instantiate (chairUp);
			Debug.Log ("did not find spawnedchair");
		}

		return generatedUpChair;
	}

	void recycleObjects()
	{
		if (spawnedChairUpQueue.Peek().localPosition.x + recycleDistance < PlayerMovement.distanceTraveled)
		{
			Transform generatedUpChair = spawnedChairUpQueue.Dequeue ();
			Destroy (generatedUpChair.gameObject);
			Debug.Log ("spawnedchair");
			spawnedChairs--;
		}
		if (spawnedNPCUpQueue.Peek().localPosition.x + recycleDistance < PlayerMovement.distanceTraveled)
		{
			Transform generatedUpNPC = spawnedNPCUpQueue.Dequeue();
			Destroy(generatedUpNPC.gameObject);
			Debug.Log ("spawnedchair");
			//spawnedChairs--;
		}
		if (spawnedChairDownQueue.Peek().localPosition.x + recycleDistance < PlayerMovement.distanceTraveled)
		{
			Transform generatedDownChair = spawnedChairDownQueue.Dequeue();
			Destroy(generatedDownChair.gameObject);
			Debug.Log ("spawnedchair");
			spawnedChairs--;
		}
		if (spawnedNPCDownQueue.Peek().localPosition.x + recycleDistance < PlayerMovement.distanceTraveled)
		{
			Transform generatedDownNPC = spawnedNPCDownQueue.Dequeue();
			Destroy(generatedDownNPC.gameObject);
			Debug.Log ("spawnedchair");
			//spawnedChairs--;
		}
	}

	*/  
}
