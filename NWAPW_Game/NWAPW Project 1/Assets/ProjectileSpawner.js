#pragma strict

var isLeft : boolean = true;
var FireballSpawner : GameObject;
var hitTarget : LayerMask;
var fireFrom : Vector2;
var fireTo : Vector2;


function Start () {
	
}

function Update () {
	if(Input.GetAxis("Horizontal") > 0.5){
		isLeft = false;
	}
	else if(Input.GetAxis("Horizontal") < -0.5){
		isLeft = true;
	}

	if(Input.GetButtonDown("Fire1")){
		fireFrom[0] = (gameObject.transform.postition.x * Input.GetAxis("Horizontal"));
		fireFrom[1] = gameObject.transform.position.y;
		fireTo[0] = gameObject.transform.position.x * Input.GetAxis("Horizontal") * 10;
		fireTo[1] = gameObject.tranform.position.y;
		var hit : RaycastHit2D = Physics2D.Raycast(fireFrom, fireFrom - fireTo, 10, hitTarget);
	}
}
