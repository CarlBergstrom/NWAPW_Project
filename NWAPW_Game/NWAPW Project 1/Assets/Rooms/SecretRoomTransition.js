#pragma strict

static var isGoingSecret : boolean;

function OnTriggerEnter2D(other: Collider2D){
	isGoingSecret = true;
}
function OnTriggerExit2D(other : Collider2D){
	isGoingSecret = false;
}
