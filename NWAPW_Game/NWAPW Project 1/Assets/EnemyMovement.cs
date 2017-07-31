using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    //Variables involved with movement
    Vector2 currentPosition;
    float dirController;
    float speed = 2.5f;
    int moveCounter = 0;
    int moveDuration = 30;
    bool shouldTurn = true;

    //Variables involved in health
    int enemyHealth = 2;
    public static bool anEnemyHasDied;


	// Use this for initialization
	void Start () {

	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 14)
        {
            enemyHealth -= 1;
        }
    }

    void RandomizeRotation()
    {
        if (shouldTurn)
        {
            dirController = Random.Range(0.0f, 4.0f);
            if (dirController >= 0 && dirController < 1.0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (dirController >= 1.0 && dirController < 2.0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (dirController >= 2.0 && dirController < 3.0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (dirController >= 3.0 && dirController < 4.0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 270);
            }
            shouldTurn = false;
        }
        moveCounter += 1;
        if(moveCounter >= moveDuration)
        {
            moveCounter = 0;
            shouldTurn = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        currentPosition[0] = transform.position.x;
        currentPosition[1] = transform.position.y;

        RandomizeRotation();
        transform.Translate(0, speed * Time.deltaTime, 0);

    }
}
