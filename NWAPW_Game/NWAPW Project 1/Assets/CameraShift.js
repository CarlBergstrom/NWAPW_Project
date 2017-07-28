#pragma strict

var roomOnePosition : Vector3;
var roomTwoPosition : Vector3;
var roomThreePosition : Vector3;
var gameOverScreen : Vector3;
var gameStartScreen : Vector3;
static var gameHasStarted : boolean = false;


function Start () {
	roomOnePosition[0] = 0;
	roomOnePosition[1] = 0;
	roomOnePosition[2] = -10;
	roomTwoPosition[0] = 0;
	roomTwoPosition[1] = 10;
	roomTwoPosition[2] = -10;
	roomThreePosition[0] = -21.25;
	roomThreePosition[1] = 10;
	roomThreePosition[2] = -10;
	gameOverScreen[0] = 0;
	gameOverScreen[1] = -20;
	gameOverScreen[2] = -10;
	gameStartScreen[0] = 0;
	gameStartScreen[1] = -30;
	gameStartScreen[2] = -10;
}

function Update () {
	if(!gameHasStarted){
		if(Input.GetKeyDown("space")){
			transform.position = roomOnePosition;
			gameHasStarted = true;
		}
	}

	if(CharacterMovement.playerOutOfLives){
		transform.position = gameOverScreen;
		gameHasStarted = false;
	}
	else if(CharacterMovement.playerHasDied){
		transform.position = roomOnePosition;
	}

	if(RoomTransfer.isGoingUp && CharacterMovement.curRoom == 1){
		transform.position = roomTwoPosition;
	}
	else if(RoomTransferDown.isGoingDown && CharacterMovement.curRoom == 2){
		transform.position = roomOnePosition;
	}
	else if(SecretRoomTransition.isGoingSecret && CharacterMovement.curRoom == 2){
		transform.position = roomThreePosition;
	}
	else if(SecretRoomReturn.isReturningSecret && CharacterMovement.curRoom == 3){
		transform.position = roomTwoPosition;
	}
}
