#pragma strict

static var isReturningSecret : boolean = false;

function OnTriggerEnter2D(other: Collider2D){
	isReturningSecret = true;
}
function OnTriggerExit2D(other: Collider2D){
	isReturningSecret = false;
}
