using UnityEngine;
using System.Collections;

public class RoundedDownNPCSit : MonoBehaviour {
    public Transform player;
    private Vector2 sitPosition;
    private float NPCPosition;
    private float PlayerPosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        PlayerPosition = Mathf.Round(player.transform.localPosition.x * 10f) / 10f;
        NPCPosition = Mathf.Round(this.transform.localPosition.x * 10f) / 10f;
        if(NPCPosition == PlayerPosition)
        {
            StartCoroutine(Sit());
        }
	}
    IEnumerator Sit()
    {
        sitPosition = new Vector2(this.transform.localPosition.x, -0.46f);
        yield return new WaitForSeconds(0.07f);
        this.transform.position = sitPosition;
    }
}
