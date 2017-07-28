#pragma strict

static var fireballPassed : boolean = false;

function OnTriggerEnter2D(other: Collider2D){
	fireballPassed = true;
}