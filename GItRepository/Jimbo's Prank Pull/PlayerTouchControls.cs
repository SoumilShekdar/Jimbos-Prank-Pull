using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerTouchControls : MonoBehaviour {
    private float dragStart;
    private float dragEnd;
    private bool dragStarted = false;
    private float swipeDirection;
    private bool triggerEntered;
    private GameObject chair;
    public Transform player;
    private Vector2 movement;
    public Text scoreDisplay;
    public Text gameOver;
    public Button retry;
    private bool colliderEnter;
    private int score;
    public Text displayHighScore;
	public Button home;
	public Sprite playerWalinkg;
	public Sprite playerUp;
	public Sprite playerDown;
	private Animator animationControllerPlayer;
	private SpriteRenderer sr;
	public GameObject rage;
	public Sprite endGameSit;
	public Sprite playerDie;
	private bool endGameVersion;
	public AudioSource audio1;
	public AudioSource audio2;
	public AudioSource audio3;
	public Text finalScoreDisplay;
	//private int noOfGames;
	//public GameObject playerGO;
	//public GameObject NPC;
	public GameObject generator;
	public bool gameActive;
	public Text tip;

    // Use this for initialization
    void Start () {
		PlayerPrefs.SetInt ("NumberOfGames", PlayerPrefs.GetInt("NumberOfGames") + 1);
		PlayerPrefs.Save ();
        score = 0;
		finalScoreDisplay.text = " ";
		scoreDisplay.text = score.ToString();
        retry.gameObject.SetActive(false);
		home.gameObject.SetActive (false);
		sr = this.GetComponent<SpriteRenderer> ();
		animationControllerPlayer = this.GetComponent<Animator> ();
		rage.SetActive (false);
		animationControllerPlayer.enabled = true;
		endGameVersion = false;
		gameActive = true;
		tip.text = " ";
       	
    }
	
	// Update is called once per frame
	void Update () {
        
        Swipe();
        
    }
    void Swipe()
    {
        
        if(Input.touches.Length > 0)
        {
            //Debug.Log("Swipe Started");
            Touch t = Input.GetTouch(0);
            if(t.phase == TouchPhase.Began)
            {
                //Debug.Log("Swipe Started2");
                dragStarted = true;
                dragStart = t.position.y;
            }
            if (dragStarted)
            {
                //Debug.Log("dragStartedTrue");
                if (t.phase == TouchPhase.Ended)
                {
                    dragStarted = false;
                    //Debug.Log("SwipeEnded");
                    dragEnd = t.position.y;
                    swipeDirection = dragEnd - dragStart;
                    
                    if (swipeDirection > 0)
                    {
						StartCoroutine(DownChairPullMovement());
                    }
                    if (swipeDirection < 0)
                    {
						StartCoroutine(UpChairPullMovement());
                    }
                }                
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Chair"))
        {
            if (colliderEnter == false)
            {
                //other.gameObject.SetActive(false);
                if (other.transform.localPosition.y == 0.32f)
                {
                    //Debug.Log("ChairUp");
                    other.transform.localPosition = new Vector2(other.transform.localPosition.x, 0.19f);
                }
                if (other.transform.localPosition.y == -0.32f)
                {
                    //Debug.Log("ChairDown");
                    other.transform.localPosition = new Vector2(other.transform.localPosition.x, -0.19f);
                }
                score++;
				scoreDisplay.text = score.ToString();
                colliderEnter = true;
				if(score == 20){
					/*PlayerMovement playerMovement = playerGO.GetComponent<PlayerMovement> ();
					playerMovement.speed = 1.4f;*/
					JointGenerator jointGenerator = generator.GetComponent<JointGenerator> ();
					jointGenerator.endOfRandomRange = 0.95f;
				}
				if(score == 40){
					/*PlayerMovement playerMovement = playerGO.GetComponent<PlayerMovement> ();
					playerMovement.speed = 1.5f;*/
					JointGenerator jointGenerator = generator.GetComponent<JointGenerator> ();
					jointGenerator.endOfRandomRange = 0.9f;
				}
				if(score == 60){
					/*PlayerMovement playerMovement = playerGO.GetComponent<PlayerMovement> ();
					playerMovement.speed = 1.6f;*/
					JointGenerator jointGenerator = generator.GetComponent<JointGenerator> ();
					jointGenerator.endOfRandomRange = 0.8f;
				}
				if(score == 80){
					/*PlayerMovement playerMovement = playerGO.GetComponent<PlayerMovement> ();
					playerMovement.speed = 1.7f;*/
					JointGenerator jointGenerator = generator.GetComponent<JointGenerator> ();
					jointGenerator.endOfRandomRange = 0.7f;
					jointGenerator.startOfRandomRange = 0.45f;
				}
				if(score == 100){
					/*PlayerMovement playerMovement = playerGO.GetComponent<PlayerMovement> ();
					playerMovement.speed = 1.8f;*/
					JointGenerator jointGenerator = generator.GetComponent<JointGenerator> ();
					jointGenerator.endOfRandomRange = 0.65f;
					jointGenerator.startOfRandomRange = 0.4f;
				}
				if(score == 120){
					/*PlayerMovement playerMovement = playerGO.GetComponent<PlayerMovement> ();
					playerMovement.speed = 1.9f;*/
					JointGenerator jointGenerator = generator.GetComponent<JointGenerator> ();
					jointGenerator.endOfRandomRange = 0.6f;
					jointGenerator.startOfRandomRange = 0.35f;
				}
				if(score == 150){
					/*PlayerMovement playerMovement = playerGO.GetComponent<PlayerMovement> ();
					NPCSitMovement npcSitMovement = NPC.GetComponent<NPCSitMovement> ();
					npcSitMovement.upSitSpeed = -0.55f;
					npcSitMovement.downSitSpeed = 0.55f;
					playerMovement.speed = 2f;*/
					JointGenerator jointGenerator = generator.GetComponent<JointGenerator> ();
					jointGenerator.endOfRandomRange = 0.55f;
					jointGenerator.startOfRandomRange = 0.3f;
				}
            }

        }
        if (other.gameObject.CompareTag("BeforeCollider"))
        {
            if (colliderEnter == false)
            {
				StartCoroutine(endGame());
                Debug.Log("Before Collider Trigger");
                colliderEnter = true;
				if (PlayerPrefs.GetInt ("TipOnOff") == 1) {
					
				} else {
					tip.text = "Too Early !!!";
				}
            }
        }
        if (other.gameObject.CompareTag("AfterCollider"))
        {
            if (colliderEnter == false)
            {
				StartCoroutine(endGame());
               // Debug.Log("After Collider Trigger");
				if (PlayerPrefs.GetInt ("TipOnOff") == 1) {

				} else {
					tip.text = "Too Late !!!";
				}
                
            }
            colliderEnter = false;
        }


    }
	IEnumerator UpChairPullMovement()
    {
		//Debug.Log ("UpChairPull");
		if (gameActive) {
			if (PlayerPrefs.GetInt ("SoundOnOff") == 1) {

			} else {
				audio1.Play ();
			}
			animationControllerPlayer.enabled = false;
			sr.sprite = playerUp;
			movement = new Vector2 (player.localPosition.x, 0.04f);
			player.localPosition = movement;
			yield return new WaitForSeconds (0.1f);
			if (gameActive) {
				movement = new Vector2 (player.localPosition.x, 0f);
				player.localPosition = movement;
				sr.sprite = playerWalinkg;
				animationControllerPlayer.enabled = true;
			}
		}
    }
	IEnumerator DownChairPullMovement()
    {
		//Debug.Log ("DownChairPull");
		if (gameActive) {
			if (PlayerPrefs.GetInt ("SoundOnOff") == 1) {

			} else {
				audio1.Play ();
			}
			animationControllerPlayer.enabled = false;
			sr.sprite = playerDown;
			movement = new Vector2 (player.localPosition.x, -0.04f);
			player.localPosition = movement;
			yield return new WaitForSeconds (0.1f);
			if (gameActive) {
				movement = new Vector2 (player.localPosition.x, 0f);
				player.localPosition = movement;
				sr.sprite = playerWalinkg;
				animationControllerPlayer.enabled = true;
			}
		}
    }
	public void endGameNPCSit(){
		StartCoroutine(endGameNPCSitMainTask());
	}
	IEnumerator endGameNPCSitMainTask(){
		if (endGameVersion == false) {
			if (PlayerPrefs.GetInt ("SoundOnOff") == 1) {

			} else {
				audio2.Play ();
			}
			if (PlayerPrefs.GetInt ("TipOnOff") == 1) {

			} else {
				tip.text = "They Sat !!!";
			}
			gameActive = false;
			rage.SetActive (true);
			animationControllerPlayer.enabled = false;
			sr.sprite = endGameSit;
			yield return new WaitForSeconds (1f);
			scoreDisplay.text = " ";
			finalScoreDisplay.text = "Score:" + score;
			tip.text = " ";
			Time.timeScale = 0;
			gameOver.text = "Game Over";
			retry.gameObject.SetActive (true);
			home.gameObject.SetActive (true);
			if (score > PlayerPrefs.GetInt ("High Score")) {

				PlayerPrefs.SetInt ("High Score", score);
				PlayerPrefs.Save ();
			}
			displayHighScore.text = "High Score :" + " " + PlayerPrefs.GetInt ("High Score");
		}
	}
    IEnumerator endGame()
    {
		if (PlayerPrefs.GetInt ("SoundOnOff") == 1) {

		} else {
			audio3.Play ();
		}
		gameActive = false;
		endGameVersion = true;
		animationControllerPlayer.enabled = false;
		sr.sprite = playerDie;
		yield return new WaitForSeconds(1f);
		scoreDisplay.text = " ";
		finalScoreDisplay.text = "Score:" + score;
		tip.text = " ";
        gameOver.text = "Game Over";
        retry.gameObject.SetActive(true);
		home.gameObject.SetActive (true);
        Time.timeScale = 0;
		if(score > PlayerPrefs.GetInt("High Score"))
        {
			PlayerPrefs.SetInt("High Score", score);
            PlayerPrefs.Save();
        }
		displayHighScore.text = "High Score :" + " " + PlayerPrefs.GetInt("High Score");
    }
}
