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

	void hpDown1()
	{
		Debug.Log ("recieved hpDown1");
		if (!Invul)
		{
			anim.SetTrigger ("damage");
		}
		Invul = true;
	}

	void hpDown2()
	{
		if (!Invul)
		{
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
		}
		Invul = true;
	}

	void hpDown3()
	{
		if (!Invul)
		{
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
		}
		Invul = true;
	}

	void hpDown4()
	{
		if (!Invul)
		{
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
		}
		Invul = true;
	}

	void hpDown5()
	{
		if (!Invul)
		{
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
		}
		Invul = true;
	}

	void hpDown6()
	{
		if (!Invul)
		{
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
		}
		Invul = true;
	}

	void hpDown7()
	{
		if (!Invul)
		{
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
		}
		Invul = true;
	}

	void hpDown8()
	{
		if (!Invul)
		{
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
		}
		Invul = true;
	}

	void hpDown9()
	{
		if (!Invul)
		{
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
		}
		Invul = true;
	}

	void hpDown10()
	{
		if (!Invul)
		{
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
			anim.SetTrigger ("damage");
		}
		Invul = true;
	}

    void hpUp()
    {
        anim.SetTrigger("restore");
    }

    void hpUp2()
    {
        anim.SetTrigger("restore");
        anim.SetTrigger("restore");
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
        if (charMovementGood.playerHasPickedUpHealth)
        {
            hpUp2();
            charMovementGood.playerHasPickedUpHealth = false;
        }
	}
}