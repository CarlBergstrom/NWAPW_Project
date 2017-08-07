using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

    public Animator anim;
    bool isOpenned = false;
    int OpenDelayCounter = 0;
    public static bool isOpenning;

	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            if (charMovementGood.hasFullKey)
            {
                //Open Door
                anim.SetBool("unlock", true);
                isOpenned = true;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if (isOpenned)
        {
            OpenDelayCounter += 1;
            if(OpenDelayCounter >= 30)
            {
                anim.SetBool("open", true);
                anim.SetBool("unlock", false);
                isOpenning = true;
                if(OpenDelayCounter >= 240)
                {
                    anim.SetBool("open", false);
                    isOpenning = false;
                }
            }
        }
	}
}
