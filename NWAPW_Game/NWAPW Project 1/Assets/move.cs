using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    Animator anim;
    public int damage;
    public float mrange;
    public Transform meleePoint;
	bool atkRecharge = false;
	int RechargeTime = 0;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        float speed = 5;
        bool walk = (Mathf.Abs(horiz) + Mathf.Abs(vert)) > 0;

        if (Input.GetButton ("stab"))
        {
			if (!atkRecharge)
			{
            	Collider2D[] hitObjects = Physics2D.OverlapCircleAll (meleePoint.position, mrange);
            	anim.SetTrigger("melee");
            	anim.SetBool("stab", true);
				atkRecharge = true;
				anim.SetBool ("recharge", true);
				anim.SetBool("walk", false);

				if (hitObjects.Length >= 1)
				{
					hitObjects [0].SendMessage ("takedamage", damage, SendMessageOptions.DontRequireReceiver);
				}

            }
        }
		if (atkRecharge) {
			RechargeTime += 1;
			if (RechargeTime >= 30) {
				RechargeTime = 0;
				atkRecharge = false;
				anim.SetBool ("recharge", false);
				anim.SetBool ("stab", false);
			}
		}

        if (!Input.GetButton("stab"))
        {
            anim.SetBool("stab", false);
        }

        if (walk)
        {
            anim.SetBool("walk", true);
        }

        if (!walk)
        {
            anim.SetBool("walk", false);
        }


        // right
        if (horiz > 0.01)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        // left
        if (horiz < -0.01)
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }

        // up
        if (vert > 0.01)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        // down
        if (vert < -0.01)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        transform.Translate(horiz * Time.deltaTime * speed, vert * Time.deltaTime * speed, 0, Space.World);


    }
}
