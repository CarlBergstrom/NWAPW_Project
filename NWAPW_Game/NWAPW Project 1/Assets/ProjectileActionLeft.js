#pragma strict

var moveSpeed : int = 100;

function Update () {
	transform.Translate(Vector3.left* Time.deltaTime * moveSpeed);
	Destroy (gameObject, 0.5);
}
