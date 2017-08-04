using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightKeyHalf : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            charMovementGood.hasRightKeyHalf = true;
            Destroy(gameObject);
        }
    }
}
