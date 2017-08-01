using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPPickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Collider2D[] pickedUp = Physics2D.OverlapCircleAll (transform.position, 0.5f);
		if (pickedUp.Length >= 1) {
			Debug.Log ("Message sent to Player");
			pickedUp [0].SendMessage ("PlayerRegen1", SendMessageOptions.DontRequireReceiver);
		}
	}
}
