using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoomFollow : MonoBehaviour {

    Vector3 gameOverScreen;
    Vector3 gameStartScreen;
    public static bool gameHasStarted = false;

	// Use this for initialization
	void Start () {
        gameOverScreen[0] = 0;
        gameOverScreen[1] = -20;
        gameOverScreen[2] = -10;
        gameStartScreen[0] = 0;
        gameStartScreen[1] = -30;
        gameStartScreen[2] = -10;
    }
	
	// Update is called once per frame
	void Update () {
        if (!gameHasStarted)
        {
            transform.position = gameStartScreen;
            if (Input.GetButtonDown("stab"))
            {
                transform.position = charMovement.PlayerPos;
                gameHasStarted = true;
            }
        }
        else
        {

            if (charMovement.playerHasDied)
            {
                if (charMovement.playerOutOfLives)
                {
                    transform.position = gameOverScreen;
                }
                else
                {
                    transform.position = charMovement.PlayerPos;
                }
            }

            transform.position = charMovement.PlayerPos;

        }
    }

}
