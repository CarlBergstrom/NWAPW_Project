using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    //Variables involved with movement
    Vector2 currentPosition;
    float toTranslateX;
    float toTranslateY;
    bool translateXnotY;

    //Variables involved in health
    int enemyHealth = 2;
    public static bool anEnemyHasDied;


	// Use this for initialization
	void Start () {

	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 14)
        {
            enemyHealth -= 1;
        }
    }

    void RandomizeTranslate()
    {

    }
	
	// Update is called once per frame
	void Update () {
        currentPosition[0] = transform.position.x;
        currentPosition[1] = transform.position.y;

    }
}
