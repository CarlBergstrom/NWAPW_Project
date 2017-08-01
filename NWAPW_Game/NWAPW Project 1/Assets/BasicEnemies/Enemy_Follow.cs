using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Follow : MonoBehaviour
{

    //Variables involved with movement
    Vector2 currentPositionFollow;
    float axisController;
    float speed = 2.0f;
    float distanceToPlayerX;
    float distanceToPlayerY;
    int moveCounterFollow = 0;
    int moveDurationFollow = 30;
    bool shouldTurnFollow = true;
    bool ShouldFollowX = false;
    bool ShouldFollowY = false;
    bool ShouldMove = false;
    bool tooFarX = false;
    bool tooFarY = false;
    int distanceForStopX = 5;
    int distanceForStopY = 5;
    Animator follow_anim;

    //Variables involved in health
    int enemyHealthFollow = 2;
    public static bool anEnemyHasDied;


    // Use this for initialization
    void Start()
    {
        follow_anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 14)
        {
            TakeDamage(1);
        }
    }

    void RandomizeAxis()
    {
        if (shouldTurnFollow)
        {
            axisController = Random.Range(0.0f, 2.0f);
            if (axisController >= 0 && axisController < 1.0)
            {
                ShouldFollowX = true;
                ShouldFollowY = false;
            }
            else if (axisController >= 1.0 && axisController < 2.0)
            {
                ShouldFollowX = false;
                ShouldFollowY = true;
            }
            shouldTurnFollow = false;
        }
        moveCounterFollow += 1;
        if (moveCounterFollow >= moveDurationFollow)
        {
            moveCounterFollow = 0;
            shouldTurnFollow = true;
        }
    }

    void UpdateDirection()
    {

            if (tooFarY && !tooFarX)
            {
                if (distanceToPlayerY >= 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    Debug.Log("Successfully rotated down");
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    Debug.Log("Successfully rotated up");
            }
                ShouldMove = true;
            }

            else if (tooFarX && !tooFarY)
            {
                if (distanceToPlayerX >= 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 270);
                    Debug.Log("Successfully rotated left");
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                    Debug.Log("Successfully rotated right");
                }
                ShouldMove = true;
            }

            else if (tooFarX && tooFarY)
            {
                ShouldMove = false;
            }

            else if (ShouldFollowX)
            {
                if (distanceToPlayerX >= 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 270);
                    Debug.Log("Successfully rotated left");
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                    Debug.Log("Successfully rotated right");
                }
                ShouldMove = true;
            }

            else if (ShouldFollowY)
            {
                if (distanceToPlayerY >= 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    Debug.Log("Successfully rotated down");
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    Debug.Log("Successfully rotated up");
                }
                ShouldMove = true;
            }

    }

    // Update is called once per frame
    void Update()
    {
        if (CameraRoomFollow.gameHasStarted)
        {
            currentPositionFollow[0] = transform.position.x;
            currentPositionFollow[1] = transform.position.y;

            distanceToPlayerX = currentPositionFollow[0] - charMovement.PlayerPos[0];
            distanceToPlayerY = currentPositionFollow[1] - charMovement.PlayerPos[1];

            if(distanceToPlayerX > distanceForStopX || distanceToPlayerX < -distanceForStopX || (distanceToPlayerY <= 0.5 && distanceToPlayerY >= -0.5))
            {
                tooFarX = true;
            }
            else
            {
                tooFarX = false;
            }
            if(distanceToPlayerY > distanceForStopY || distanceToPlayerY < -distanceForStopY || (distanceToPlayerX <= 0.5 && distanceToPlayerX >= -0.5))
            {
                tooFarY = true;
            }
            else
            {
                tooFarY = false;
            }

            bool isWalking = (Mathf.Abs(currentPositionFollow[0]) + Mathf.Abs(currentPositionFollow[1])) > 0;
            follow_anim.SetBool("walk", isWalking);

            RandomizeAxis();
            UpdateDirection();
            if (ShouldMove)
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
            //Debug.Log("X too far: " + tooFarX + " Y too far: " + tooFarY);
        }
    }

    void TakeDamage(int damage)
    {
        enemyHealthFollow -= damage;
        if (enemyHealthFollow <= 0)
        {
            follow_anim.SetTrigger("die");
            Destroy(gameObject, 1.7f);
        }
    }

}
