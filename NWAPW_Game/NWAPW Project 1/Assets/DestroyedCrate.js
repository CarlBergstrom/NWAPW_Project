#pragma strict

var Treasure1Prefab : Transform;

function OnApplicationQuit(){
	ProjectileSpawner.enemyShouldDrop = false;
}

function OnDestroy(){
	if(ProjectileSpawner.enemyShouldDrop){
		Instantiate(Treasure1Prefab, transform.position, Quaternion.identity);
	}
}
