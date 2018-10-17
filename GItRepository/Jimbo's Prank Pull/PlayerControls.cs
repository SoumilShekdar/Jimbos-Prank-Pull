using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour {
    
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
	public Button home;
    private int score;
    private bool colliderEnter;
    public Text displayHighScore;
	public Sprite playerWalinkg;
	public Sprite playerUp;
	public Sprite playerDown;
	private Animator animationControllerPlayer;
	private SpriteRenderer sr;
	public GameObject rage;
	public Sprite endGameSit;
	public Sprite playerDie;
	private bool endGameVersion;

    // Use this for initialization
    void Start () {
        score = 0;
        scoreDisplay.text = "Score:" + " " + score;
        retry.gameObject.SetActive(false);
		home.gameObject.SetActive (false);
		sr = this.GetComponent<SpriteRenderer> ();
		animationControllerPlayer = this.GetComponent<Animator> ();
		rage.SetActive (false);
		animationControllerPlayer.enabled = true;
		endGameVersion = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        Swipe();
            

    }
    void OnTriggerEnter2D(Collider2D other)
    {
         
        if (other.gameObject.CompareTag("Chair"))
        {
            if (colliderEnter == false)
            {
                Debug.Log("MainColliderEnter");
                //other.gameObject.SetActive(false);
                if (other.transform.localPosition.y == 0.32f)
                {
                    Debug.Log("ChairUp");
                    other.transform.localPosition = new Vector2(other.transform.localPosition.x, 0.1f);
                }
                if(other.transform.localPosition.y == -0.32f)
                {
                    Debug.Log("ChairDown");
                    other.transform.localPosition = new Vector2(other.transform.localPosition.x, -0.1f);
                }
                score++;
                scoreDisplay.text = "Score:" + " " + score;
                colliderEnter = true;
            }
           
         }
        if (other.gameObject.CompareTag("BeforeCollider"))
        {
            if (colliderEnter == false)
            {
                
                Debug.Log("Before Collider Trigger");
                colliderEnter = true;
				StartCoroutine(endGame());
            }
        }       
        if (other.gameObject.CompareTag("AfterCollider"))
        {
            if (colliderEnter == false)
            {
                
                Debug.Log("After Collider Trigger");
				StartCoroutine(endGame());

            }
            Debug.Log("After Collider False Enter");
            colliderEnter = false;
        }
            
        
    }
    void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragStarted = true;
            dragStart = Input.mousePosition.y;
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (dragStarted)
            {
                dragEnd = Input.mousePosition.y;
                swipeDirection = dragEnd - dragStart;
                if (swipeDirection > 0)
                {
                    Debug.Log("Swipe Up");
					StartCoroutine(DownChairPullMovement());
                    
                    
                }
                if (swipeDirection < 0)
                {

                    Debug.Log("Swipe Down");
					StartCoroutine(UpChairPullMovement());
                    

                }
                dragStarted = false;
                
            }
        }
    }
    IEnumerator UpChairPullMovement()
    {
		animationControllerPlayer.enabled = false;
		sr.sprite = playerUp;
        movement = new Vector2(player.localPosition.x, 0.04f);
        player.localPosition = movement;
        yield return new WaitForSeconds(0.1f);
        movement = new Vector2(player.localPosition.x, 0f);
        player.localPosition = movement;
		sr.sprite = playerWalinkg;
		animationControllerPlayer.enabled = true;
    }
    IEnumerator DownChairPullMovement()
    {
		animationControllerPlayer.enabled = false;
		sr.sprite = playerDown;
        movement = new Vector2(player.localPosition.x, -0.04f);
        player.localPosition = movement;
        yield return new WaitForSeconds(0.1f);
        movement = new Vector2(player.localPosition.x, 0f);
        player.localPosition = movement;
		sr.sprite = playerWalinkg;
		animationControllerPlayer.enabled = true;
    }
	public void endGameNPCSit(){
		StartCoroutine(endGameNPCSitMainTask());
	}
	IEnumerator endGameNPCSitMainTask(){
		if (endGameVersion == false) {
			rage.SetActive (true);
			animationControllerPlayer.enabled = false;
			sr.sprite = endGameSit;
			yield return new WaitForSeconds (0.1f);
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
		endGameVersion = true;
		animationControllerPlayer.enabled = false;
		sr.sprite = playerDie;
		yield return new WaitForSeconds(0.025f);
        gameOver.text = "Game Over";
        retry.gameObject.SetActive(true);
		home.gameObject.SetActive (true);
        Time.timeScale = 0;
        if (score > PlayerPrefs.GetInt("High Score"))
        {
            
            PlayerPrefs.SetInt("High Score", score);
            PlayerPrefs.Save();
        }
        displayHighScore.text = "High Score :" + " " + PlayerPrefs.GetInt("High Score");
    }
}
