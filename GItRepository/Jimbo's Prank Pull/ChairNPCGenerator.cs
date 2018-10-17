using UnityEngine;
using System.Collections;

public class ChairNPCGenerator : MonoBehaviour {
    public Transform chairUp;
    public Transform chairDown;
    public Transform NPCUp;
    public Transform NPCDown;
    public int noOfChairUp;
    public int noOfChairDown;
    private int spawnedChairUp;
    private int spawnedChairDown;
    private Vector2 positionUp;
    private Vector2 positionDown;
    private Vector2 nextPositionChairUp;
    private Vector2 nextPositionNPCUp;
    private Vector2 nextPositionChairDown;
    private Vector2 nextPositionNPCDown;
    
    // Use this for initialization
    void Start () {
        spawnedChairUp = 0;
        spawnedChairDown = 0;
        nextPositionChairUp = new Vector2(0f, 0.42f);
        nextPositionNPCUp = new Vector2(0f, 0.62f);
        nextPositionChairDown = new Vector2(0f, -0.42f);
        nextPositionNPCDown = new Vector2(0f, -0.62f);

        for (; spawnedChairUp < noOfChairUp; spawnedChairUp++)
        {
            positionUp = new Vector2(Random.Range(0.5f, 2.0f), 0f);
            nextPositionChairUp += positionUp;
            Transform generatedChairUp = (Transform)Instantiate(chairUp);
            generatedChairUp.localPosition = nextPositionChairUp;
            nextPositionNPCUp += positionUp;
            Transform generatedNPCUp = (Transform)Instantiate(NPCUp);
            generatedNPCUp.localPosition = nextPositionNPCUp;
        }
        for (; spawnedChairDown < noOfChairDown; spawnedChairDown++)
        {
            positionDown = new Vector2(Random.Range(0.5f, 2.0f), 0f);
            nextPositionChairDown += positionDown;
            Transform generatedChairDown = (Transform)Instantiate(chairDown);
            generatedChairDown.localPosition = nextPositionChairDown;
            nextPositionNPCDown += positionDown;
            Transform generatedNPCDown = (Transform)Instantiate(NPCDown);
            generatedNPCDown.localPosition = nextPositionNPCDown;   
        }
    }
	
	// Update is called once per frame
    
	void Update () {
        
       
        
	}
}
