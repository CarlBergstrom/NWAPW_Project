#pragma strict

static var playerHasUpgradeGreen = false;

function Start () {
	Physics2D.IgnoreLayerCollision(11, 9, true);
}

function OnTriggerEnter2D(other: Collider2D){
	playerHasUpgradeGreen = true;
	Destroy(this.gameObject);
}

function OnApplicationQuit(){
	Destroy(this.gameObject);
}

