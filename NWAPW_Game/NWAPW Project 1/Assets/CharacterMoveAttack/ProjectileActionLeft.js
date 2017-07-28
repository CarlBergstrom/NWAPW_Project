#pragma strict

var moveSpeed : int = 30;

function Start(){
	Physics2D.IgnoreLayerCollision(14, 0, true);
	Physics2D.IgnoreLayerCollision(14, 8, true);
	Physics2D.IgnoreLayerCollision(14, 12, true);
	Physics2D.IgnoreLayerCollision(14, 15, true);
	Physics2D.IgnoreLayerCollision(14, 11, true);
}

function Update () {
	if(DeleteFireBall.fireballPassed){
		DeleteFireBall.fireballPassed = false;
		Destroy(this.gameObject);
	}
	if(Random_Movement.enemyHit){
		Random_Movement.enemyHit = false;
		Destroy(this.gameObject);
	}
	transform.Translate(Vector3.left* Time.deltaTime * moveSpeed);
	Destroy (gameObject, 0.5);
}
