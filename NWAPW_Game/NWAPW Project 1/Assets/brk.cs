using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brk : MonoBehaviour
{

    public int health;

    public void takedamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
}