#pragma strict


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
static var playerHealth : int = 100;
static var canTakeDamage : boolean = true;
static var hasTakenDamage : boolean = false;
static var isStunned : boolean = false;
var stunCounter : int = 0;
var stunDuration : int = 10;
static var playerHasDied : boolean = false;
static var initialSpawnLocation : Vector2;
static var playerLives : int = 3;
static var playerOutOfLives : boolean = false;


function Start(){
	Physics2D.IgnoreLayerCollision(8, 12, true);
	Physics2D.IgnoreLayerCollision(8, 13, true);
	initialSpawnLocation[0] = transform.position.x;
	initialSpawnLocation[1] = transform.position.y;
	Debug.Log("Player Health is currently: " + playerHealth + " And the player has " + playerLives + " Lives");
}

function OnCollisionEnter2D(coll: Collision2D){
	if (coll.gameObject.layer == 9){
		if(Random_Movement.enemyIsAttacking){
			hasTakenDamage = true;
			playerHealth -= 10;
			Debug.Log("Player Health is currently: " + playerHealth + " And the player has " + playerLives + " Lives");
		}
		else{
			//Enemy and player bump away from each other, possibly change
		}
	}

}

function UpdateHealth(){
	if(playerHealth > 100){
		playerHealth = 100;
	}
	else if(playerHealth == 0){
		playerHasDied = true;
		playerLives -=1;
		Debug.Log("Player Health is currently: " + playerHealth + " And the player has " + playerLives + " Lives");
		if(playerLives == 0){
			playerOutOfLives = true;
			Debug.Log("The player has died");
		}
		else{
			transform.position = initialSpawnLocation;
			playerHealth = 100;
			curRoom = 1;
		}

	}
	if(hasTakenDamage && canTakeDamage){
		translationY = -Input.GetAxis ("Vertical") * speedY * 10;
		translationX = -Input.GetAxis ("Horizontal") * speedX * 10;
		hasTakenDamage = false;
		isStunned = true;
		canTakeDamage = false;
	}
	else if(isStunned){
		translationY = 0;
		translationX = 0;
		stunCounter += 1;
	}
	if(stunCounter > stunDuration){
		stunCounter = 0;
		isStunned = false;
		canTakeDamage = true;
	}
}

function Update () {
    // Get the horizontal and vertical axis.
    // By default they are mapped to the arrow keys.
    // The value is in the range -1 to 1

	if(CameraShift.gameHasStarted){
		if(!playerOutOfLives){
			UpdatePickups();

			translationY = Input.GetAxis ("Vertical") * speedY;
			translationX = Input.GetAxis ("Horizontal") * speedX;


			UpdateHealth();

			// Make it move 10 meters per second instead of 10 meters per frame...
			translationY *= Time.deltaTime;
			translationX *= Time.deltaTime;

			//Translate each axis
			transform.Translate (0, translationY, 0);
			transform.Translate (translationX, 0, 0);

			UpdateRoom();
	
			//Debug log for testing static  variables that cannot be easily seen
			if(false){
				//Debug.Log("Currently in room " + curRoom);
				Debug.Log("Player Health is currently: " + playerHealth);
			}
		}
	}
}

function UpdatePickups(){
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
	if(TreasurePickUp.playerHasPickedUpTreasure){
		TreasurePickUp.playerHasPickedUpTreasure = false;
		playerHealth += 5;
	}
}

function UpdateRoom(){
	if(RoomTransfer.isGoingUp && curRoom == 1){
		transform.Translate(0, 3, 0);
		curRoom = 2;
	}
	else if(RoomTransferDown.isGoingDown && curRoom == 2){
		transform.Translate(0, -3, 0);
		curRoom = 1;
	}
	else if(SecretRoomTransition.isGoingSecret && curRoom == 2){
		transform.Translate(-4, 0, 0);
		curRoom = 3;
	}
	else if(SecretRoomReturn.isReturningSecret && curRoom == 3){
		transform.Translate(4,0,0);
		curRoom = 2;
	}
}

