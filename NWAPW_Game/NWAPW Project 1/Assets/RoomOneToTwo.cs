using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomOneToTwo : MonoBehaviour {

    public static bool playerGoingOneToTwo = false;

	// Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(15, 9, true);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        playerGoingOneToTwo = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        playerGoingOneToTwo = false;
    }
}
