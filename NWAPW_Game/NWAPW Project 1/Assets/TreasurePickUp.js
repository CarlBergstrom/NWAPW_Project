#pragma strict

static var playerHasPickedUpTreasure : boolean = false;

function Start () {
	Physics2D.IgnoreLayerCollision(11, 9, true);
}

function OnTriggerEnter2D(other: Collider2D){
	playerHasPickedUpTreasure = true;
	transform.Translate(0,1,0);
	Destroy(this.gameObject);
}

function OnApplicationQuit(){
	Destroy(this.gameObject);
}
