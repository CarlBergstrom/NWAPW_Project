#pragma strict

static var isGoingUp : boolean;

function OnTriggerEnter2D(other: Collider2D){
	isGoingUp = true;
}
function OnTriggerExit2D(other : Collider2D){
	isGoingUp = false;
}