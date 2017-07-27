#pragma strict

var isLeft : boolean = true;
var FireballSpawner : GameObject;
var Character : GameObject;
var hitTarget : LayerMask;
var hitTarTreasure : LayerMask;
static var curPos : Vector2;
var FireBallLeftPrefab : Transform;
var FireBallRightPrefab : Transform;
var Enemy1 : Transform;
var Enemy2 : Transform;
var spawnEnemy1 : boolean = true;
var spawnRandomPos : Vector2;
var spawnDetermine : float;
static var roomOneSpawnMaxX : float = 6;
static var roomOneSpawnMinX : float = -6;
static var roomOneSpawnMaxY : float = 2;
static var roomOneSpawnMinY : float = -2.5;
static var roomTwoSpawnMaxX : float = 7;
static var roomTwoSpawnMinX : float = -6.5;
static var roomTwoSpawnMaxY : float = 12.5;
static var roomTwoSpawnMinY : float = 6.5;
var shouldRespawn : boolean = true; //Eventually make static, for now still working on it
static var enemyShouldDrop : boolean = true;


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
		var hitTreasureLeft : RaycastHit2D = Physics2D.Raycast(gameObject.transform.position, Vector2.left, 10, hitTarTreasure);
		Effect(isLeft);
		if(hitLeft.collider != null){
			//Debug.DrawLine (curPos, hitLeft.point);
			Destroy (hitLeft.transform.gameObject, 0.1);
			spawnInRandomPos();
		}
		else if(hitTreasureLeft.collider != null){
			Destroy (hitTreasureLeft.transform.gameObject, 0.1);
		}
	}
	else{
		var hitRight : RaycastHit2D = Physics2D.Raycast(gameObject.transform.position, Vector2.right, 10, hitTarget);
		var hitTreasureRight : RaycastHit2D = Physics2D.Raycast(gameObject.transform.position, Vector2.right, 10, hitTarTreasure);
		Effect(isLeft);
		if(hitRight.collider != null){
			//Debug.DrawLine (curPos, hitRight.point);
			Destroy (hitRight.transform.gameObject, 0.1);
			if(shouldRespawn){
				spawnInRandomPos();
			}
		}
		else if(hitTreasureRight.collider != null){
			Destroy (hitTreasureRight.transform.gameObject, 0.1);
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
	if(CharacterMovement.curRoom == 1){
		spawnRandomPos[0] = Random.Range(roomOneSpawnMinX,roomOneSpawnMaxX);
		spawnRandomPos[1] = Random.Range(roomOneSpawnMinY,roomOneSpawnMaxY);
	}
	else if(CharacterMovement.curRoom == 2){
		spawnRandomPos[0] = Random.Range(roomTwoSpawnMinX,roomTwoSpawnMaxX);
		spawnRandomPos[1] = Random.Range(roomTwoSpawnMinY,roomTwoSpawnMaxY);
	}

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