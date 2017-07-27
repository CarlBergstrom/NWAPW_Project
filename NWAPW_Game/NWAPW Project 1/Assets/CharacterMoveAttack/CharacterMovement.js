﻿#pragma strict


var speedY : float = 5;
var speedX : float = 5;
var Character : Transform;
var EnemyWallOne : Transform;
var EnemyWallTwo : Transform;
var SecretEnemyWall : Transform;
static var curRoom : int = 1;
var translationY : float;
var translationX : float;
var speedTimer : int = 0;


function Start(){
	Physics2D.IgnoreCollision(Character.GetComponent.<Collider2D>(), EnemyWallOne.GetComponent.<Collider2D>());
	Physics2D.IgnoreCollision(Character.GetComponent.<Collider2D>(), EnemyWallTwo.GetComponent.<Collider2D>());
	Physics2D.IgnoreCollision(Character.GetComponent.<Collider2D>(), SecretEnemyWall.GetComponent.<Collider2D>());
}

function Update () {
    // Get the horizontal and vertical axis.
    // By default they are mapped to the arrow keys.
    // The value is in the range -1 to 1

	if(UpgradePickup.playerHasUpgradeGreen && speedTimer < 120){
		speedX = 10;
		speedY = 10;
		speedTimer += 1;
	}
	else if(speedTimer >= 120){
		UpgradePickup.playerHasUpgradeGreen = false;
		speedX = 5;
		speedY = 5;
		speedTimer = 0;
	}

    translationY = Input.GetAxis ("Vertical") * speedY;
    translationX = Input.GetAxis ("Horizontal") * speedX;

    // Make it move 10 meters per second instead of 10 meters per frame...
    translationY *= Time.deltaTime;
    translationX *= Time.deltaTime;

	// Move translation along the object's z-axis
	transform.Translate (0, translationY, 0);
	// Rotate around our y-axis
	transform.Translate (translationX, 0, 0);
	if(RoomTransfer.isGoingUp){
		transform.Translate(0, 3, 0);
		curRoom = 2;
	}
	else if(RoomTransferDown.isGoingDown){
		transform.Translate(0, -3, 0);
		curRoom = 1;
	}
	else if(SecretRoomTransition.isGoingSecret){
		transform.Translate(-3, 0, 0);
		curRoom = 3;
	}
	Debug.Log("Currently in room " + curRoom);
}

