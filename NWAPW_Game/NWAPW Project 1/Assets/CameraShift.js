#pragma strict

function Start () {
	
}

function Update () {
	if(RoomTransfer.isGoingUp){
		transform.Translate(0, 10, 0);
	}
	else if(RoomTransferDown.isGoingDown){
		transform.Translate(0,-10,0);
	}
}
