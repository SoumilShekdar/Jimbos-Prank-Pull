using UnityEngine;
using System.Collections;

public class NPCUpSitiing : MonoBehaviour {
    public Transform player;
    private Vector2 sitPosition;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(this.transform.localPosition.x <= player.transform.localPosition.x)
        {
            StartCoroutine(Sit());
        }
	}
    IEnumerator Sit()
    {
        sitPosition = new Vector2(this.transform.localPosition.x, 0.56f);
        yield return new WaitForSeconds(0.1f);
        this.transform.position = sitPosition;
    }
}
