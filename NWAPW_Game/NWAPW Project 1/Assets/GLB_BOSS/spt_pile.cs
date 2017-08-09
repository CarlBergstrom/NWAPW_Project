using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spt_pile : MonoBehaviour {

	public int Edamage;
	public float range;
	public GameObject Player;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D (Collider2D collision)
	{
		// not biting
		if(collision.gameObject.layer == 8)
		{
			Player.SendMessage("takedamageP", Edamage, SendMessageOptions.DontRequireReceiver);
		}
	}


    void OnTriggerStay2D(Collider2D collision)
    {
        // not biting
        if (collision.gameObject.layer == 8)
        {
            Player.SendMessage("takedamageP", Edamage, SendMessageOptions.DontRequireReceiver);
        }
    }
    void Update ()
	{
		Destroy(gameObject, 2f);
	}
}
