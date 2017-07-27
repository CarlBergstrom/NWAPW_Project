#pragma strict


var speedY : float = 0.05;
var speedX : float = 0.05;
var Character : Transform;
var EnemyWallOne : Transform;
var EnemyWallTwo : Transform;
static var curRoom : int = 1;


function Start(){
	Physics2D.IgnoreCollision(Character.GetComponent.<Collider2D>(), EnemyWallOne.GetComponent.<Collider2D>());
	Physics2D.IgnoreCollision(Character.GetComponent.<Collider2D>(), EnemyWallTwo.GetComponent.<Collider2D>());
}

function Update () {
    // Get the horizontal and vertical axis.
    // By default they are mapped to the arrow keys.
    // The value is in the range -1 to 1

    var translationY : float = Input.GetAxis ("Vertical") * speedY;
    var translationX : float = Input.GetAxis ("Horizontal") * speedX;

    // Make it move 10 meters per second instead of 10 meters per frame...
    translationY *= Time.deltaTime;
    translationX *= Time.deltaTime;

	// Move translation along the object's z-axis
	transform.Translate (0, translationY, 0);
	// Rotate around our y-axis
	transform.Translate (translationX, 0, 0);
	if(RoomTransfer.isGoingUp){
		transform.Translate(0, 4.3, 0);
		curRoom = 2;
	}
	else if(RoomTransferDown.isGoingDown){
		transform.Translate(0, -4.3, 0);
		curRoom = 1;
	}

}

