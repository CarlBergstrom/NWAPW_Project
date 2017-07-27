#pragma strict

static var isGoingDown : boolean;

function OnTriggerEnter2D(other: Collider2D){
	isGoingDown = true;
}
function OnTriggerExit2D(other : Collider2D){
	isGoingDown = false;
}