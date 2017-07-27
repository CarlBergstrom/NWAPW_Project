#pragma strict

public var inDoorway : boolean;

function OnTriggerEnter2D(other: Collider2D){
	inDoorway = true;
}