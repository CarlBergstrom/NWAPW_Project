using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 0.5f);
        Physics2D.IgnoreLayerCollision(14, 0, true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
