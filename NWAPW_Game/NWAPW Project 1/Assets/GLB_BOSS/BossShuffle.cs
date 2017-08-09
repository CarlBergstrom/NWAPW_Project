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
    public bool shouldWalkLeft = true;

    public int Bdamage = 2;
    public float range = 10;

    int actionTimer = 180;
    int actionCounter = 0;
    int vulnCounter = 0;
    int vulnTimer = 180;
    bool isVuln = false;

    public GameObject Player;
    public GameObject BossHpBar;


    public Transform GlbrProjectile;
    bool phaseTwo = false;
    public static bool BossHasDied = false;

    public Animator anim;

	// Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(17, 18, true);
	}

    private void OnDestroy()
    {
        CameraRoomFollow.isInBossRoom = false;
        ActivateBoss.isAtBoss = false;
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

        if (BossHealth <=0)
        {
            fightStarted = false;
            //Boss has died

            //Animation triggers here

            Destroy(gameObject, 3.5f);

            //Spawn bridge here
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            if (!isBiting)
            {
                Player.SendMessage("takedamageP", 2);
            }
            else
            {
                Player.SendMessage("takedamageP", 4);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            if (!isBiting)
            {
                Player.SendMessage("takedamageP", 2);
            }
            else
            {
                Player.SendMessage("takedamageP", 4);
            }
        }
    }

    void chooseAttack()
    {
        if (attackCounter >= 4)
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
                    if (!hasProjectiled)
                    {
                        anim.SetBool("walk", false);
                        attackCounter += 1;
                        isProjectiling = true;
                        isBiting = false;
                        isWalking = false;
                        shouldChooseAction = false;
                    }
                    else
                    {
                        anim.SetBool("walk", true);
                        isWalking = true;
                        isBiting = false;
                        isProjectiling = false;
                        shouldChooseAction = false;
                    }
                }
                else if (attackController > 1.0 && attackController <= 2.0)
                {
                    //Bite
                    if (!hasBitten)
                    {
                        anim.SetBool("walk", false);
                        attackCounter += 1;
                        isBiting = true;
                        isProjectiling = false;
                        isWalking = false;
                        shouldChooseAction = false;
                    }
                    else
                    {
                        anim.SetBool("walk", true);
                        isWalking = true;
                        isBiting = false;
                        isProjectiling = false;
                        shouldChooseAction = false;
                    }
                }
                else if (attackController > 2.0 && attackController <= 3.0)
                {
                    //Spawn Enemy if no existing spawned enemies exist
                    if (!hasProjectiled)
                    {
                        anim.SetBool("walk", false);
                        attackCounter += 1;
                        isProjectiling = true;
                        isBiting = false;
                        isWalking = false;
                        shouldChooseAction = false;
                    }
                    else
                    {
                        anim.SetBool("walk", true);
                        isWalking = true;
                        isBiting = false;
                        isProjectiling = false;
                        shouldChooseAction = false;
                    }
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
                    if (!hasProjectiled)
                    {
                        anim.SetBool("walk", false);
                        attackCounter += 1;
                        isProjectiling = true;
                        isBiting = false;
                        isWalking = false;
                        shouldChooseAction = false;
                    }
                    else
                    {
                        anim.SetBool("walk", true);
                        isWalking = true;
                        isBiting = false;
                        isProjectiling = false;
                        shouldChooseAction = false;
                    }
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
                transform.Translate(-5 * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.Translate(5 * Time.deltaTime, 0, 0);
            }
            if(transform.position.x >= charMovementGood.PlayerPos.x)
            {
                shouldWalkLeft = true;
            }
            else if(transform.position.x < charMovementGood.PlayerPos.x)
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
                isVuln = false;
            }
        }
        else if (isBiting)
        {
            actionCounter += 1;
            if(actionCounter <= 30)
            {
                transform.Translate(0, -10 * Time.deltaTime, 0);
                //Bite animation
            }
            else if (actionCounter > 30 && actionCounter <= 60)
            {
                transform.Translate(0, 10 * Time.deltaTime, 0);
            }
            else
            {
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
                Instantiate(GlbrProjectile, transform.position, Quaternion.identity);
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

    void takedamage(int damage)
    {
        BossHealth -= damage;
        Debug.Log("Boss HP is currently: " + BossHealth);
        if (BossHealth % 4 == 0)
        {
            BossHpBar.SendMessage("BossDmg");
            Debug.Log("Damage Recieved");
        }
    }
}
