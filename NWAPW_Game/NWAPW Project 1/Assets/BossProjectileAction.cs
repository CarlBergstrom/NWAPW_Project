using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileAction : MonoBehaviour {

    float spawnDetermine = 0;
    public Transform bossSpawnPrefab;
    public Transform slimeGlobPrefab;

	// Update is called once per frame
	void Update () {
        transform.Translate(0, -8 * Time.deltaTime, 0);
        Destroy(gameObject, 1.0f);
	}
    private void OnDestroy()
    {
        spawnDetermine = Random.Range(0, 5);
        if(spawnDetermine >= 4.0)
        {
            //Spawn Boss Monster, 20% chance
            Instantiate(bossSpawnPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            //Spawn glob pile, 80% chance
            Instantiate(slimeGlobPrefab, transform.position, Quaternion.identity);
        }
    }
}
