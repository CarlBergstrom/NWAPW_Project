#pragma strict

var attackCount : int = 0;
var attackDur : int = 300;

function Start () {
	Physics2D.IgnoreLayerCollision(16, 9, true);
}

function OnCollisionEnter2D(coll: Collision2D){
	CharacterMovement.playerHealth -= 5;
	CharacterMovement.hasTakenDamage = true;
	Debug.Log("Player Health is currently: " + CharacterMovement.playerHealth + " And the player has " + CharacterMovement.playerLives + " Lives");
	Destroy(this.gameObject);
}

function Update () {
	attackCount += 1;
	if(attackCount > attackDur){
		Destroy(this.gameObject);
	}
}
