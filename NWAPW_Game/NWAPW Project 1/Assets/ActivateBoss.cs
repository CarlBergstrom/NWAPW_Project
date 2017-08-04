using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBoss : MonoBehaviour {

    public static bool isAtBoss = false;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isAtBoss = true;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
