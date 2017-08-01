using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gloop_move : MonoBehaviour {

    //Variables involved with movement
    Vector2 currentPosition;
    float dirController;
    float speed = 2.5f;
    int moveCounter = 0;
    int moveDuration = 30;
	public int health;
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

    void RandomizeRotation()
    {
        if (shouldTurn)
        {
            dirController = Random.Range(0.0f, 4.0f);
            if (dirController >= 0 && dirController < 1.0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (dirController >= 1.0 && dirController < 2.0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (dirController >= 2.0 && dirController < 3.0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (dirController >= 3.0 && dirController < 4.0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 270);
            }
            shouldTurn = false;
        }
        moveCounter += 1;
        if(moveCounter >= moveDuration)
        {
            moveCounter = 0;
            shouldTurn = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        currentPosition[0] = transform.position.x;
        currentPosition[1] = transform.position.y;

		bool isWalking = (Mathf.Abs(currentPosition[0]) + Mathf.Abs(currentPosition[1])) > 0;
		anim.SetBool ("walk", isWalking);

        RandomizeRotation();
        transform.Translate(0, speed * Time.deltaTime, 0);

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
