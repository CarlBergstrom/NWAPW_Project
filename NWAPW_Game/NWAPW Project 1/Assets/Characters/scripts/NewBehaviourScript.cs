using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	//Inspector Variables
	double  playerSpeed = 5.0;
	//speed player moves

	void Update ()
	{

		MoveForward (); // Player Movement 
	}

	void MoveForward ()
	{
		Debug.Log("dededed");
		if (Input.GetKey ("up") || Input.GetKey ("W")) {//Press up arrow key to move forward on the Y AXIS
			transform.Translate (0,(float)playerSpeed * Time.deltaTime, 0);
		}
		if (Input.GetKey ("down") || Input.GetKey ("S")) {//Press up arrow key to move forward on the Y AXIS
			transform.Translate (0,(float)-playerSpeed * Time.deltaTime, 0);
		}
		if (Input.GetKey ("left")|| Input.GetKey ("A")) {//Press up arrow key to move forward on the Y AXIS
			transform.Translate ((float)-playerSpeed * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey ("right")|| Input.GetKey ("D")) {//Press up arrow key to move forward on the Y AXIS
			transform.Translate ((float)playerSpeed * Time.deltaTime, 0, 0);
		}
	}
}