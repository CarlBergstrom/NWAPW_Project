#pragma strict

function Start () {
	Physics2D.IgnoreLayerCollision(11, 9, true);
}

function OnTriggerEnter2D(other: Collider2D){
	transform.Translate(0,1,0);
	Destroy(this.gameObject);
}

function OnApplicationQuit(){
	Destroy(this.gameObject);
}
