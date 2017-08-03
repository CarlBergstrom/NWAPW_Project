using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallUpgradeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            charMovement.hasFireball = true;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
