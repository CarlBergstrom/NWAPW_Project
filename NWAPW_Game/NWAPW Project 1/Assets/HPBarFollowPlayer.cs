using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarFollowPlayer : MonoBehaviour {

    Vector3 PositionRelativeToPlayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PositionRelativeToPlayer[0] = charMovement.PlayerPos[0];
        PositionRelativeToPlayer[1] = charMovement.PlayerPos[1];
        PositionRelativeToPlayer[2] = -4;
        PositionRelativeToPlayer[0] -= 7.25f;
        PositionRelativeToPlayer[1] += 3.25f;

        transform.position = PositionRelativeToPlayer;
    }
}
