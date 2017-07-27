#pragma strict


var cameraPos : Vector2;

function Update () {
	
	cameraPos = ProjectileSpawner.curPos;
	transform.position.x = cameraPos[0];
	transform.position.y = cameraPos[1];
}
