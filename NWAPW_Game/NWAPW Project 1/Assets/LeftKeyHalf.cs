using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftKeyHalf : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            charMovementGood.hasLeftKeyHalf = true;
            Destroy(gameObject);
        }
    }
}
