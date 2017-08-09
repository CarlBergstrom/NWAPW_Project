using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHP : MonoBehaviour {
	Animator anim;
	
	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animator>();
	}
	
	void BossDmg()
	{
		anim.SetTrigger("hpDown4");
		//anim.ResetTrigger ("hpDown4");
	}
	
}
