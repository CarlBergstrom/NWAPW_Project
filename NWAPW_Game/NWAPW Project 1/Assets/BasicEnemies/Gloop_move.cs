using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gloop_move : MonoBehaviour {

    //Variables involved with movement
	public int health;
	public int Edamage;
	public float range;
    bool shouldTurn = true;
    public Transform Barsense;
    public Transform heartPickup;
    float dropDetermin = 0;


    bool canDealDamage = true;

	Animator anim;

    //Variables involved in health
    int enemyHealth = 2;
    public static bool anEnemyHasDied;
    public static bool anEnemyHasTakenDamage = false;
    int dyingCounter = 0;
    int dyingDuration = 100;


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
		if (hitObjects.Length > 2 && canDealDamage)
		{
			hitObjects[2].SendMessage("takedamageP", Edamage, SendMessageOptions.DontRequireReceiver);
            //Debug.Log("Enemy has hit: " + hitObjects[2].name);
		}
        if (anEnemyHasDied)
        {
            canDealDamage = false;
            dyingCounter += 1;
            if(dyingCounter >= dyingDuration)
            {
                dyingCounter = 0;
                canDealDamage = true;
                anEnemyHasDied = false;
            }
        }
    }

	void takedamage(int damage)
	{
		health -= damage;
        Collider2D[] barS = Physics2D.OverlapCircleAll(Barsense.position, 0.25f);
        anEnemyHasTakenDamage = true;
        if (barS.Length > 1)
        {
            //Debug.Log("Sensed " + barS[1].name);
            barS[1].SendMessage("GloopDmgDwn");
        }
        if (health <= 0) 
		{
            dropDetermin = Random.Range(-1, 1);
            anEnemyHasDied = true;
			anim.SetTrigger ("die");
            Instantiate(heartPickup, transform.position, transform.rotation);
			Destroy (gameObject, 1.7f);
		}
	}
		
}
