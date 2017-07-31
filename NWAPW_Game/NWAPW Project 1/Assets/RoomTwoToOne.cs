using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTwoToOne : MonoBehaviour {

    public static bool playerGoingTwoToOne = false;

    // Use this for initialization
    void Start()
    {
        Physics2D.IgnoreLayerCollision(15, 9, true);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        playerGoingTwoToOne = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        playerGoingTwoToOne = false;
    }
}
