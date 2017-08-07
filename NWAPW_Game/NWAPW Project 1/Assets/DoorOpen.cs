using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
