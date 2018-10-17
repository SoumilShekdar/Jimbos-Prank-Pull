using UnityEngine;
using System.Collections;

public class NPCSitMovement : MonoBehaviour {
    public Transform player;
    public float upSitSpeed;
    public float downSitSpeed;
    private bool sitting;
    private Animator animationController;
	// Use this for initialization
	void Start () {
        upSitSpeed = -0.25f;
        downSitSpeed = 0.25f;
        sitting = false;
        animationController = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.localPosition.x > 0) {
			if (this.transform.localPosition.x <= player.transform.localPosition.x + 0.5f) {
			
				startSitiing ();
			}
			if (this.transform.localPosition.x + 0.5f <= player.transform.localPosition.x) {
				sitting = true;
				StartCoroutine (fallinDown ());
			}
		}
    }
    void startSitiing()
    {
		this.gameObject.SetActive(true);
        if (sitting == false)
        {
            animationController.SetBool("Sitting", true);
            if (this.transform.localPosition.y > 0)
            {
                this.transform.Translate(0f, upSitSpeed * Time.deltaTime, 0f);
            }
            if (this.transform.localPosition.y < 0)
            {
                this.transform.Translate(0f, downSitSpeed * Time.deltaTime, 0f);
            }
        }
    }
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Chair")) {
			sitting = true;
			animationController.SetBool ("Sitting", false);
			animationController.SetBool ("Sat", true);
		}
	}
	IEnumerator fallinDown(){
		animationController.SetBool("Sitting", false);
		animationController.SetBool ("Fall", true);
		yield return new WaitForSeconds(0.25f);
		animationController.SetBool ("Fall", false);
		yield return new WaitForSeconds(0.5f);
		this.gameObject.SetActive(false);

	}
}
