using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

		float inputX = Input.GetAxisRaw("Horizontal");
		float inputY = Input.GetAxisRaw("Vertical");

		bool isWalking = (Mathf.Abs(inputX) + Mathf.Abs(inputY)) > 0;

		anim.SetBool ("isWalking", isWalking);
		if (isWalking)
		{
			anim.SetFloat ("X", inputX);
			anim.SetFloat ("Y", inputY);

			transform.position += new Vector3 (inputX, inputY, 0).normalized * 2 * Time.deltaTime;
		}
	}
}
