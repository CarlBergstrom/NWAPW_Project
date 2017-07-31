using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpeed : MonoBehaviour
{

    public static bool playerHasSpeedBoost = false;

    // Use this for initialization
    void Start()
    {
        Physics2D.IgnoreLayerCollision(11, 9, true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        playerHasSpeedBoost = true;
        Destroy(gameObject);
    }
       
    void OnApplicationQuit()
    {
        Destroy(gameObject);
    }
}
