using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gloop_move : MonoBehaviour {

    //Variables involved with movement
    Vector2 currentPosition;
	public int health;
	public int speed;
	public int Edamage;
	public float range;
    bool shouldTurn = true;

	Animator anim;

    //Variables involved in health
    int enemyHealth = 2;
    public static bool anEnemyHasDied;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 14)
        {
            enemyHealth -= 1;
        }
    }
		
	
	// Update is called once per frame
	void Update () {
		Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, range);
		if (hitObjects.Length >= 1)
		{
			hitObjects[0].SendMessage("takedamageP", Edamage, SendMessageOptions.DontRequireReceiver);
		}
    }

	void takedamage(int damage)
	{
		health -= damage;
		if (health <= 0) 
		{
			anim.SetTrigger ("die");
			Destroy (gameObject, 1.7f);
		}
	}
		
}