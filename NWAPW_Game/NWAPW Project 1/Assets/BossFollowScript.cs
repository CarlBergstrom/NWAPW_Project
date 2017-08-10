using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollowScript : MonoBehaviour {

    //Variables involved with movement
    public static Vector2 currentPositionFollow;
    float axisController;
    float speed = 4.0f;
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
    bool tooCloseX = false;
    bool tooCloseY = false;
    int distanceForStopX = 5;
    int distanceForStopY = 5;
    public int health;
    public int Edamage;
    public float range;
    bool shouldTurn = true;
    public Transform Barsense;
    public Transform heartPickup;
    float dropDetermin = 0;
    bool canDealDamage = true;

    int knockbackCounter = 0;
    bool shouldBeKnockedBack = false;

    Animator follow_anim;
    Animator anim;

    //Variables involved in health
    int enemyHealth = 2;
    public static bool anEnemyHasDied;
    public static bool anEnemyHasTakenDamage = false;
    int dyingCounter = 0;
    int dyingDuration = 100;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        follow_anim = GetComponent<Animator>();
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

        if ((tooFarY || tooCloseY) && !(tooFarX || tooCloseX))
        {
            if (distanceToPlayerY >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                //Debug.Log("Successfully rotated down");
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
                //Debug.Log("Successfully rotated up");
            }
            ShouldMove = true;
        }

        else if ((tooFarX || tooCloseX) && !(tooFarY || tooCloseY))
        {
            if (distanceToPlayerX >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 270);
                //Debug.Log("Successfully rotated left");
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                //Debug.Log("Successfully rotated right");
            }
            ShouldMove = true;
        }

        else if (tooFarX && tooFarY)
        {
            ShouldMove = false;
        }

        else if (tooCloseX && tooCloseY)
        {
            ShouldMove = true;
        }

        else if (ShouldFollowX)
        {
            if (distanceToPlayerX >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 270);
                //Debug.Log("Successfully rotated left");
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                //Debug.Log("Successfully rotated right");
            }
            ShouldMove = true;
        }

        else if (ShouldFollowY)
        {
            if (distanceToPlayerY >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                //Debug.Log("Successfully rotated down");
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
                //Debug.Log("Successfully rotated up");
            }
            ShouldMove = true;
        }

    }

    void KnockbackFromHit()
    {
        if (charMovementGood.PlayerPos.x > currentPositionFollow.x && (charMovementGood.PlayerPos.y - currentPositionFollow.y <= 1.5 && charMovementGood.PlayerPos.y - currentPositionFollow.y >= -2))
        {
            //Player to the right of the enemy
            transform.Translate(12 * Time.deltaTime, 0, 0, Space.World);
        }
        else if (charMovementGood.PlayerPos.x < currentPositionFollow.x && (charMovementGood.PlayerPos.y - currentPositionFollow.y <= 1.5 && charMovementGood.PlayerPos.y - currentPositionFollow.y >= -2))
        {
            //Player to the left of the enemy
            transform.Translate(-12 * Time.deltaTime, 0, 0, Space.World);
        }
        else if (charMovementGood.PlayerPos.y > currentPositionFollow.y && (charMovementGood.PlayerPos.x - currentPositionFollow.x <= 1.5 && charMovementGood.PlayerPos.x - currentPositionFollow.x >= -2))
        {
            //Player above of the enemy
            transform.Translate(0, 12 * Time.deltaTime, 0, Space.World);
        }
        else if (charMovementGood.PlayerPos.x < currentPositionFollow.x && (charMovementGood.PlayerPos.x - currentPositionFollow.x <= 1.5 && charMovementGood.PlayerPos.x - currentPositionFollow.x >= -2))
        {
            //Player below of the enemy
            transform.Translate(0, -12 * Time.deltaTime, 0, Space.World);
        }
        knockbackCounter += 1;
        if (knockbackCounter >= 5)
        {
            shouldBeKnockedBack = false;
            knockbackCounter = 0;
        }
    }

    void UpdateHealth()
    {
        if (Gloop_move.anEnemyHasTakenDamage)
        {
            //Knockback
            shouldBeKnockedBack = true;
        }
        else if (shouldBeKnockedBack)
        {
            KnockbackFromHit();
        }
        else
        {
            speed = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraRoomFollow.gameHasStarted)
        {
            currentPositionFollow[0] = transform.position.x;
            currentPositionFollow[1] = transform.position.y;

            distanceToPlayerX = currentPositionFollow[0] - charMovementGood.PlayerPos[0];
            distanceToPlayerY = currentPositionFollow[1] - charMovementGood.PlayerPos[1];

            if (distanceToPlayerX > distanceForStopX || distanceToPlayerX < -distanceForStopX)
            {
                tooFarX = true;
                tooCloseX = false;
            }
            else if (distanceToPlayerY <= 0.5 && distanceToPlayerY >= -0.5)
            {
                tooCloseX = true;
                tooFarX = false;
            }
            else
            {
                tooCloseX = false;
                tooFarX = false;
            }
            if (distanceToPlayerY > distanceForStopY || distanceToPlayerY < -distanceForStopY)
            {
                tooCloseY = false;
                tooFarY = true;
            }
            else if (distanceToPlayerX <= 0.5 && distanceToPlayerX >= -0.5)
            {
                tooFarY = false;
                tooCloseY = true;
            }
            else
            {
                tooCloseY = false;
                tooFarY = false;
            }

            bool isWalking = (Mathf.Abs(currentPositionFollow[0]) + Mathf.Abs(currentPositionFollow[1])) > 0;
            follow_anim.SetBool("walk", isWalking);

            RandomizeAxis();
            UpdateDirection();
            if (ShouldMove && !Gloop_move.anEnemyHasDied && !shouldBeKnockedBack && !charMovementGood.playerKnockedBack)
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, range);
            if (hitObjects.Length > 2 && canDealDamage)
            {
                hitObjects[2].SendMessage("takedamageP", Edamage, SendMessageOptions.DontRequireReceiver);
                //Debug.Log("Enemy has hit: " + hitObjects[2].name);
            }
            if (anEnemyHasDied)
            {
                canDealDamage = false;
                dyingCounter += 1;
                if (dyingCounter >= dyingDuration)
                {
                    dyingCounter = 0;
                    canDealDamage = true;
                    anEnemyHasDied = false;
                }
            }
            //Debug.Log("X too far: " + tooFarX + " Y too far: " + tooFarY);
        }
    }
}
