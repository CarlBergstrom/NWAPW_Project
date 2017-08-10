using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloopHP : MonoBehaviour {
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void GloopDmgDwn()
	{
		if (Gloop_move.health == 2)
		{
			anim.SetTrigger ("Ehp2");
		}
		if (Gloop_move.health == 1)
		{
			anim.SetTrigger ("Ehp1");
		}
		if (Gloop_move.health == 0)
		{
			anim.SetTrigger ("Ehp0");
		}
	}

}
