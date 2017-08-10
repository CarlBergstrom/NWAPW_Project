using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp_Down : MonoBehaviour {

	Animator anim;
	bool Invul = false;
	int InvulTime = 0;

	void Start()
	{
		anim = GetComponent<Animator> ();
	}
		
	void UpdateAnim()
	{
		
	}

	void Update()
	{
		if (Invul)
		{
			InvulTime += 1;
			if (InvulTime >= 60)
			{
				Invul = false;
				InvulTime = 0;
			}
		}
        if (charMovementGood.playerHasDied)
        {
            anim.SetTrigger("retry");
            charMovementGood.playerHasDied = false;
        }
		if (charMovementGood.playerHealth == 0)
		{
			anim.SetTrigger ("hp0");
		}
		if (charMovementGood.playerHealth == 1)
		{
			anim.SetTrigger ("hp1");
		}
		if (charMovementGood.playerHealth == 2)
		{
			anim.SetTrigger ("hp2");
		}
		if (charMovementGood.playerHealth == 3)
		{
			anim.SetTrigger ("hp3");
		}
		if (charMovementGood.playerHealth == 4)
		{
			anim.SetTrigger ("hp4");
		}
		if (charMovementGood.playerHealth == 5)
		{
			anim.SetTrigger ("hp5");
		}
		if (charMovementGood.playerHealth == 6)
		{
			anim.SetTrigger ("hp6");
		}
		if (charMovementGood.playerHealth == 7)
		{
			anim.SetTrigger ("hp7");
		}
		if (charMovementGood.playerHealth == 8)
		{
			anim.SetTrigger ("hp8");
		}
		if (charMovementGood.playerHealth == 9)
		{
			anim.SetTrigger ("hp9");
		}
		if (charMovementGood.playerHealth == 10)
		{
			anim.SetTrigger ("hp10");
		}
		Debug.Log ("HP is at " + charMovementGood.playerHealth);

	}
}