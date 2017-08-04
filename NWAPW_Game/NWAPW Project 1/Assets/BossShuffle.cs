using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShuffle : MonoBehaviour {

    int BossHealth = 40;

    bool shouldChangeDirection = false;
    int dirCounter = 0;
    int dirTime = 60;


    bool fightStarted = false;
    bool hasRoared = false;


    int attackCounter = 0; //For determening when to become vulnerable
    int attackController; //Randomized, use for determining which attack to use
    bool isBiting = false;
    bool hasBitten = false;
    bool isProjectiling = false;
    bool hasProjectiled = false;
    bool isWalking = false;


    bool shouldChooseAction = false;
    bool shouldWalkLeft = true;


    int actionTimer = 180;
    int actionCounter = 0;
    int vulnCounter = 0;
    int vulnTimer = 180;
    bool isVuln = false;


    public Transform GlbrProjectile;
    bool phaseTwo = false;
    public static bool BossHasDied = false;

    public Animator anim;

	// Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(17, 18, true);
	}
	
	// Update is called once per frame
	void Update () {
        if (!fightStarted && CameraRoomFollow.isInBossRoom)
        {
            anim.SetBool("wake", true);
        }

        if(!hasRoared && ActivateBoss.isAtBoss)
        {
            CameraRoomFollow.cameraShouldShake = true;
            anim.SetBool("roar", true);
            fightStarted = true;
            hasRoared = true;
        }

        if (ActivateBoss.isAtBoss && shouldChangeDirection)
        {
            CameraRoomFollow.cameraShouldShake = false;
            anim.SetBool("walk", true);
            anim.SetBool("roar", false);
            anim.SetBool("wake", false);
            isWalking = true;
            shouldChangeDirection = false;
        }
        if (fightStarted)
        {
            chooseAttack();
            PerformAction();
            dirCounter += 1;
            if (dirCounter >= dirTime)
            {
                dirCounter = 0;
                shouldChangeDirection = true;
            }
        }
        if(BossHealth <= 20)
        {
            phaseTwo = true;
        }
    }

    void chooseAttack()
    {
        if (attackCounter >= 2)
        {
            //Set to be vulnerable
            shouldChangeDirection = false;
            shouldChooseAction = false;
            isWalking = false;
            isProjectiling = false;
            isBiting = false;
            isVuln = true;
            anim.SetBool("walk", false);
        }
        else if (shouldChooseAction)
        {
            attackController = Random.Range(0, 5);
            if (phaseTwo)
            {
                if (attackController > 0.0 && attackController <= 1.0)
                {
                    //Spit
                    anim.SetBool("walk", false);
                    attackCounter += 1;
                    isProjectiling = true;
                    isBiting = false;
                    isWalking = false;
                    shouldChooseAction = false;
                }
                else if (attackController > 1.0 && attackController <= 2.0)
                {
                    //Bite
                    anim.SetBool("walk", false);
                    attackCounter += 1;
                    isBiting = true;
                    isProjectiling = false;
                    isWalking = false;
                    shouldChooseAction = false;
                }
                else if (attackController > 2.0 && attackController <= 3.0)
                {
                    //Spawn Enemy if no existing spawned enemies exist
                    anim.SetBool("walk", false);
                    attackCounter += 1;
                    isProjectiling = true;
                    isBiting = false;
                    isWalking = false;
                    shouldChooseAction = false;
                }
                else if (attackController > 3.0 && attackController <= 5.0)
                {
                    //Walk, do nothing
                    anim.SetBool("walk", true);
                    isWalking = true;
                    isBiting = false;
                    isProjectiling = false;
                    shouldChooseAction = false;
                }
            }
            else
            {
                if(attackController > 0.0 && attackController <= 3.0)
                {
                    //Walk, do nothing
                    anim.SetBool("walk", true);
                    isWalking = true;
                    isBiting = false;
                    isProjectiling = false;
                    shouldChooseAction = false;
                }
                else if(attackController > 3.0 && attackController <= 5.0)
                {
                    anim.SetBool("walk", false);
                    attackCounter += 1;
                    isProjectiling = true;
                    isBiting = false;
                    isWalking = false;
                    shouldChooseAction = false;
                }
            }
            
           
        }
    }

    void PerformAction()
    {
        if (isWalking)
        {
            if (shouldWalkLeft)
            {
                transform.Translate(5 * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.Translate(-5 * Time.deltaTime, 0, 0);
            }
            if(transform.position.x >= 158)
            {
                shouldWalkLeft = true;
            }
            else if(transform.position.x <= 142)
            {
                shouldWalkLeft = false;
            }
            actionCounter += 1;
            if(actionCounter >= actionTimer)
            {
                actionCounter = 0;
                isWalking = false;
                shouldChooseAction = true;
                hasProjectiled = false;
                hasBitten = false;
            }
        }
        else if (isVuln)
        {
            vulnCounter += 1;
            if(vulnCounter >= vulnTimer)
            {
                shouldChooseAction = true;
                vulnCounter = 0;
                attackCounter = 0;
            }
        }
        else if (isBiting)
        {
            actionCounter += 1;
            if(actionCounter <= 30)
            {
                transform.Translate(0, 3 * Time.deltaTime, 0);
                //Bite animation
            }
            else if (actionCounter > 30 && actionCounter <= 60)
            {
                transform.Translate(0, -3 * Time.deltaTime, 0);
                hasBitten = true;
                shouldChooseAction = true;
                actionCounter = 0;
                isBiting = false;
                hasProjectiled = false;
            }
        }
        else if (isProjectiling)
        {
            if (!hasProjectiled)
            {
                //Instantiate(GlbrProjectile, transform.position, Quaternion.identity);
                hasProjectiled = true;
            }
            actionCounter += 1;
            if(actionCounter >= 90)
            {
                isProjectiling = false;
                shouldChooseAction = true;
                hasBitten = false;
                actionCounter = 0;
                hasProjectiled = true;
            }

        }
    }
}
