#pragma strict

var Treasure1Prefab : Transform;

function OnDestroy(){
	Instantiate(Treasure1Prefab, transform.position, Quaternion.identity);
}
