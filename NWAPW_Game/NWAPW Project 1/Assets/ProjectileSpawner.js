#pragma strict

var isLeft : boolean = true;
var FireballSpawner : GameObject;
var Character : GameObject = FireballSpawner.transform.parent.gameObject;
var hitTarget : LayerMask;
var curPos : Vector2;
public var FireBallLeftPrefab : Transform;
public var FireBallRightPrefab : Transform;
public var Enemy1 : Transform;
public var Enemy2 : Transform;
var spawnEnemy1 : boolean = true;
var spawnRandomPos : Vector2;
var spawnDetermine : float;

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
			Destroy (hitLeft.transform.gameObject, 0.1);
			spawnInRandomPos();
		}
	}
	else{
		var hitRight : RaycastHit2D = Physics2D.Raycast(gameObject.transform.position, Vector2.right, 10, hitTarget);
		Effect(isLeft);
		if(hitRight.collider != null){
			//Debug.DrawLine (curPos, hitRight.point);
			Destroy (hitRight.transform.gameObject, 0.1);
			spawnInRandomPos();
		}
	}
}

function Effect(isLeft){ //Eventually add in the trail and instantiate both as children of a parent object
	if(isLeft){
		Instantiate (FireBallLeftPrefab, curPos, Quaternion.identity);
	}
	else{
		Instantiate (FireBallRightPrefab, curPos, Quaternion.identity);
	}
}

function chooseSpawnRandom(){
	spawnDetermine = Random.Range(-1, 1);
	if(spawnDetermine >= 0){
		spawnEnemy1 = true;
	}
	else{
		spawnEnemy1 = false;
	}

	spawnRandomPos[0] = Random.Range(-6,6);
	spawnRandomPos[1] = Random.Range(-2.5,2);
}

function spawnInRandomPos(){
	chooseSpawnRandom();
	if(spawnEnemy1){
		Instantiate (Enemy1, spawnRandomPos, Quaternion.identity);
	}
	else{
		Instantiate (Enemy2, spawnRandomPos, Quaternion.identity);
	}
}