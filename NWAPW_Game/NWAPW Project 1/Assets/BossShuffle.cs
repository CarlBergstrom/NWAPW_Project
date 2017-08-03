using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShuffle : MonoBehaviour {

    bool shouldChangeDirection = true;
    int dirCounter = 0;
    int dirTime = 60;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (CameraRoomFollow.isInBossRoom)
        {
            if(Random.Range(-1,1) >= 0)
            {
                transform.Translate(5 * Time.deltaTime, 0, 0);
                shouldChangeDirection = false;
            }
            else
            {
                transform.Translate(-5 * Time.deltaTime, 0, 0);
                shouldChangeDirection = false;
            }
            dirCounter += 1;
            if(dirCounter >= dirTime)
            {
                dirCounter = 0;
                shouldChangeDirection = true;
            }
        }
	}
}
