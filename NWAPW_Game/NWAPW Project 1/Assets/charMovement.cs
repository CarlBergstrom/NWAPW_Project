using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMovement : MonoBehaviour
{

    Animator anim;

    //Variables Controlling Attacking
    public int damage = 1;
    public float mrange = 1;
    public Transform meleePoint;
	public Transform hp_follow;
	bool atkRecharge = false;
	int RechargeTime = 0;
    public static bool hasSword = false; //WIP

    float speed = 5;

    public static int curRoom = 1;

    public static Vector3 PlayerPos;

    //Variables controlling upgrades
    int SpeedCounter = 0;
    int SpeedDuration = 120;

    //Variables controlling Health and Death
	public static int playerHealth = 10;
    public static int playerLives = 3;
    public static bool playerHasDied = false;
    public static bool playerOutOfLives = false;
    public static bool canTakeDamage = true;
    public static bool playerHasTakenDamage = false;
    public static Vector2 respawnLocation;
    int stunCounter = 0;
    bool isStunned = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        Physics2D.IgnoreLayerCollision(8, 12, true);
        Physics2D.IgnoreLayerCollision(8, 13, true);
		Physics2D.IgnoreLayerCollision (8, 14, true);
        respawnLocation[0] = transform.position.x;
        respawnLocation[1] = transform.position.y;
        PlayerPos[0] = transform.position.x;
        PlayerPos[1] = transform.position.y;
        PlayerPos[2] = -10;
    }


	void takedamageP(int Edamage)
    {
  	    playerHealth -= Edamage;
    	playerHasTakenDamage = true;
		int hpLowerBy = Edamage;
		Collider2D[] hpSense = Physics2D.OverlapCircleAll(hp_follow.position, 0f);
		if (Edamage == 1) 
		{
			Debug.Log ("message to HP sent");
			hpSense[0].SendMessage ("hpDown1", SendMessageOptions.DontRequireReceiver);
		}
		if (Edamage == 2) 
		{
			hpSense[0].SendMessage ("hpDown2", SendMessageOptions.DontRequireReceiver);		}
		if (Edamage == 3) 
		{
			hpSense[0].SendMessage ("hpDown3", SendMessageOptions.DontRequireReceiver);
		}
		if (Edamage == 4) 
		{
			hpSense[0].SendMessage ("hpDown4", SendMessageOptions.DontRequireReceiver);
		}
		if (Edamage == 5) 
		{
			hpSense[0].SendMessage ("hpDown5", SendMessageOptions.DontRequireReceiver);
		}
		if (Edamage == 6) 
		{
			hpSense[0].SendMessage ("hpDown6", SendMessageOptions.DontRequireReceiver);
		}
		if (Edamage == 7) 
		{
			hpSense[0].SendMessage ("hpDown7", SendMessageOptions.DontRequireReceiver);
		}
		if (Edamage == 8) 
		{
			hpSense[0].SendMessage ("hpDown8", SendMessageOptions.DontRequireReceiver);
		}
		if (Edamage == 9) 
		{
			hpSense[0].SendMessage ("hpDown9", SendMessageOptions.DontRequireReceiver);
		}
		if (Edamage == 10) 
		{
			hpSense[0].SendMessage ("hpDown10", SendMessageOptions.DontRequireReceiver);
		}
    }

    void UpdateCollisions()
    {
        if (PickupSpeed.playerHasSpeedBoost)
        {
            speed = 10;
            SpeedCounter += 1;
            if(SpeedCounter >= SpeedDuration)
            {
                SpeedCounter = 0;
                PickupSpeed.playerHasSpeedBoost = false;
            }
        }
        else
        {
            speed = 5;
        }
    }

    void UpdateRooms()
    {
        if (RoomOneToTwo.playerGoingOneToTwo)
        {
            transform.Translate(0, -4, 0);
            curRoom = 2;
        }
        if (RoomTwoToOne.playerGoingTwoToOne)
        {
            transform.Translate(0, -4, 0);
            curRoom = 1;
        }
    }

    void stunFor(int stunDuration)
    {
        if(stunCounter < stunDuration)
        {
            speed = 0;
            stunCounter += 1;
        }
        else
        {
            isStunned = false;
            speed = 5;
        }

    }


    void UpdatePos()
    {
        PlayerPos[0] = transform.position.x;
        PlayerPos[1] = transform.position.y;
    }

    void UpdateHealth()
    {
        if (playerHasTakenDamage)
        {
            speed = -12;
            isStunned = true;
            playerHasTakenDamage = false;
        }
        else if (isStunned)
        {
            stunFor(10);
        }
        if (playerHealth <= 0)
        {
            playerLives -= 1;
            transform.position = respawnLocation;
            playerHasDied = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraRoomFollow.gameHasStarted)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
			bool walk = (Mathf.Abs(horizontal) + Mathf.Abs(vertical)) > 0;
            UpdateCollisions();
            UpdatePos();

			if (walk)
			{
				anim.SetBool("walk", true);
			}

			if (!walk)
			{
				anim.SetBool("walk", false);
			}

			// right
			if (horizontal > 0.01)
			{
				transform.rotation = Quaternion.Euler(0, 0, 90);
			}

			// left
			if (horizontal < -0.01)
			{
				transform.rotation = Quaternion.Euler(0, 0, 270);
			}

			// up
			if (vertical > 0.01)
			{
				transform.rotation = Quaternion.Euler(0, 0, 180);
			}

			// down
			if (vertical < -0.01)
			{
				transform.rotation = Quaternion.Euler(0, 0, 0);
			}

			transform.Translate(horizontal * Time.deltaTime * speed, vertical * Time.deltaTime * speed, 0, Space.World);

            if (Input.GetButton("stab")) //Implement hasSword later
            {
                if (!atkRecharge)
                {
                    Collider2D[] hitObjects = Physics2D.OverlapCircleAll(meleePoint.position, mrange);
                    anim.SetTrigger("melee");
                    anim.SetBool("stab", true);
                    atkRecharge = true;
                    anim.SetBool("recharge", true);
                    anim.SetBool("walk", false);

                    if (hitObjects.Length >= 1)
                    {
                        hitObjects[1].SendMessage("takedamage", damage, SendMessageOptions.DontRequireReceiver);
                    }

                }
            }
            if (atkRecharge)
            {
                RechargeTime += 1;
                if (RechargeTime >= 15)
                {
                    RechargeTime = 0;
                    atkRecharge = false;
                    anim.SetBool("recharge", false);
                    anim.SetBool("stab", false);
                }
            }
				
			}

            if (!Input.GetButton("stab"))
            {
                anim.SetBool("stab", false);
            }

            UpdateHealth();


        }
    }
