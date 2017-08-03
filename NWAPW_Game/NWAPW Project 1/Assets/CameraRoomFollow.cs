using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoomFollow : MonoBehaviour {

    Vector3 gameOverScreen;
    Vector3 gameStartScreen;
    public static bool gameHasStarted = false;
    float targetOrtho;
    float playerOrtho = 9;
    float initialOrtho;
    float bossOrtho = 15;
    float smoothSpeed = 4.0f;
    public static bool isInBossRoom = false;
    bool gameOver = false;

	// Use this for initialization
	void Start () {
        gameOverScreen[0] = -40;
        gameOverScreen[1] = -50;
        gameOverScreen[2] = -10;
        gameStartScreen[0] = 0;
        gameStartScreen[1] = -70;
        gameStartScreen[2] = -10;
        targetOrtho = Camera.main.orthographicSize;
        initialOrtho = Camera.main.orthographicSize;
    }
	
	// Update is called once per frame
	void Update () {
        if (!gameHasStarted && !gameOver)
        {
            transform.position = gameStartScreen;
            if (Input.GetButtonDown("stab"))
            {
                transform.position = charMovementGood.PlayerPos;
                gameHasStarted = true;
                targetOrtho = playerOrtho;
            }
        }
        else if (gameOver)
        {
            if (Input.GetButtonDown("stab"))
            {
                //gameOver = false;
            }
        }
        else
        {

            if (charMovementGood.playerHasDied)
            {
                if (charMovementGood.playerOutOfLives)
                {
                    gameOver = true;
                    gameHasStarted = false;
                    transform.position = gameOverScreen;
                    Camera.main.orthographicSize = initialOrtho;
                }
                else
                {
                    transform.position = charMovementGood.PlayerPos;
                    Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
                }
            }
            if (!gameOver)
            {
                if (isInBossRoom)
                {
                    targetOrtho = bossOrtho;
                }
                else
                {
                    targetOrtho = playerOrtho;
                }
                transform.position = charMovementGood.PlayerPos;
                Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
            }

        }
        
    }

}
