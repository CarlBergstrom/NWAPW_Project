using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRespawnPoint : MonoBehaviour {

    public static bool playerHasNewRespawn = false;
    public Transform CheckedRespawn;
    public Transform UncheckedRespawn;
    bool playerHasCheckedThis = false;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8 && !playerHasCheckedThis)
        {
            playerHasNewRespawn = true;
            playerHasCheckedThis = true;
            Instantiate(CheckedRespawn, transform.position, Quaternion.identity, UncheckedRespawn);
            
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
