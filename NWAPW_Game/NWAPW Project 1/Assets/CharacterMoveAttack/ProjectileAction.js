#pragma strict

var moveSpeed : int = 5;

function Update () {
	transform.Translate(Vector3.left* Time.deltaTime * moveSpeed);
	Destroy (gameObject, 1.0);
}
