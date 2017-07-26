#pragma strict

var isLeft : boolean = true;
var FireballSpawner : GameObject;
var Character : GameObject = FireballSpawner.transform.parent.gameObject;
var hitTarget : LayerMask;
var curPos : Vector2;
public var FireBallPrefab : Transform;
var SpawnRotationLeft : int = 0;
var SpawnRotationRight : int = 180;

function Start () {
	
}

function UpdateCurPos(){
	curPos[0] = Character.transform.position.x;
	curPos[1] = Character.transform.position.y;
	if(Input.GetAxis("Horizontal") > 0.5){
		isLeft = false;
	}
	else if(Input.GetAxis("Horizontal") < -0.5){
		isLeft = true;
	}
}

function Update () {
	UpdateCurPos();


	if(Input.GetButtonDown("Fire1")){
		shoot();
	}
}
function shoot(){
	if(isLeft){
		var hitLeft : RaycastHit2D = Physics2D.Raycast(gameObject.transform.position, Vector2.left, 10, hitTarget);
		Effect(isLeft);
		if(hitLeft.collider != null){
			//Debug.DrawLine (curPos, hitLeft.point);
		}
	}
	else{
		var hitRight : RaycastHit2D = Physics2D.Raycast(gameObject.transform.position, Vector2.right, 10, hitTarget);
		Effect(isLeft);
		if(hitRight.collider != null){
			//Debug.DrawLine (curPos, hitRight.point);
		}
	}
}

function Effect(isLeft){ //Eventually add in the trail and instantiate both as children of a parent object
	if(isLeft){
		Instantiate (FireBallPrefab, curPos, Quaternion.identity);
	}
	else{
		Instantiate (FireBallPrefab, curPos, Quaternion.identity);
	}
}