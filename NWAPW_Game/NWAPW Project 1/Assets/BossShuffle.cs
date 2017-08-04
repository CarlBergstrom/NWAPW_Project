using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShuffle : MonoBehaviour {

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
    bool shouldChooseAction = true;

    public Animator anim;

	// Use this for initialization
	void Start () {
		
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

        }
        if (fightStarted)
        {

            dirCounter += 1;
            if (dirCounter >= dirTime)
            {
                dirCounter = 0;
                shouldChangeDirection = true;
            }
        }
    }

    void chooseAttack()
    {
        if (attackCounter >= 2)
        {
            //Set to be vulnerable
            shouldChangeDirection = false;
            anim.SetBool("walk", false);
        }
        else if (shouldChooseAction)
        {
            attackController = Random.Range(0, 5);
            if (attackController > 0.0 && attackController <= 1.0)
            {
                //Spit
                anim.SetBool("walk", false);
                attackCounter += 1;
                isProjectiling = true;
            }
            else if (attackController > 1.0 && attackController <= 2.0)
            {
                //Bite
                anim.SetBool("walk", false);
                attackCounter += 1;
                isBiting = true;
            }
            else if (attackController > 2.0 && attackController <= 3.0)
            {
                //Spawn Enemy if no existing spawned enemies exist
                anim.SetBool("walk", false);
                attackCounter += 1;
                isProjectiling = true;
            }
            else if (attackController > 3.0 && attackController <= 5.0)
            {
                //Walk, do nothing
                anim.SetBool("walk", true);
                isWalking = true;
            }
        }
    }

    void PerformAction()
    {

    }
}
