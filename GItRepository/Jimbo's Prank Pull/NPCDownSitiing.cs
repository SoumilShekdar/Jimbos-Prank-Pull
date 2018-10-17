using UnityEngine;
using System.Collections;

public class NPCDownSitiing : MonoBehaviour {
    public Transform player;
    private Vector2 sitPosition;
    
    
    void Start () {

        

    }
	
	// Update is called once per frame
	void Update () {
        if (this.transform.localPosition.x <= player.transform.localPosition.x)
        {
            
            StartCoroutine(Sit());
        }
    }
    IEnumerator Sit()
    {
    
        sitPosition = new Vector2(this.transform.localPosition.x, -0.46f);
        yield return new WaitForSeconds(0.1f);
        this.transform.position = sitPosition;
    }
}
