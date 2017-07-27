#pragma strict

var speedY : float = 0.2;
var speedX : float = 0.2;
var speedMaxPos : float = 7;
var speedMinPos : float = 4;
var speedMaxNeg : float = -7;
var speedMinNeg : float = -4;
var isForwardY : boolean = true;
var isStopY : boolean = false;
var isForwardX : boolean = true;
var isStopX : boolean = false;
var translationY : float = 0.0;
var translationX : float = 0.0;
var dirControlY : float = 0.0;
var dirControlX : float = 0.0;
var runCounter : float = 0;
var counterCycles : float = 0;
var runNewCount : boolean = false;
var newPosition : Vector2;
var currentPosition : Vector2;
var toTranslate : Vector2;
var Treasure1Prefab : Transform;
var Upgrade1Prefab : Transform;
var isGoingX : boolean = true;
var determineXorY : float = 0;


function OnApplicationQuit(){
	ProjectileSpawner.enemyShouldDrop = false;
}

function OnDestroy(){
	if(ProjectileSpawner.enemyShouldDrop){
		if(Random.Range(-1,10) < 0){
			Instantiate(Upgrade1Prefab, transform.position, Quaternion.identity);
		}
		else{
			Instantiate(Treasure1Prefab, transform.position, Quaternion.identity);
		}
	}
}

function randomizeTranslate () {
	//Randomize Y axis movement
	counterCycles = runCounter/ 60;
	if(counterCycles % 1 == 0){
		runNewCount = true;
	}
	else{
		runNewCount = false;
	}
	if(runNewCount){
		dirControlY = Random.Range(-10, 10);
		if (dirControlY < 0){
			isForwardY = false;
			isStopY = false;
		}
		else if(dirControlY > 0){
			isForwardY = true;
			isStopY = false;
		}
		else if(dirControlY == 0){
			isForwardY = false;
			isStopY = true;
		}
		if(isForwardY){
			translationY = Random.Range(speedMinPos, speedMaxPos) * speedY;
		}
		else if(isStopY){
			translationY = 0.0;
		}
		else{
			translationY = Random.Range(speedMinNeg, speedMaxNeg) * speedY;
		}

		//Randomize X axis movement
		dirControlX = Random.Range(-10, 10);
		if (dirControlX < 0){
			isForwardX = false;
			isStopX = false;
		}
		else if(dirControlX > 0){
			isForwardX = true;
			isStopX = false;
		}
		else if(dirControlX == 0){
			isForwardX = false;
			isStopX = true;
		}
		if(isForwardX){
			translationX = Random.Range(speedMinPos, speedMaxPos) * speedX;
		}
		else if(isStopX){
			translationX = 0.0;
		}
		else{
			translationX = Random.Range(speedMinNeg, speedMaxNeg) * speedX;
		}
	}
	runCounter += 1;
	
}

function Update () {

	randomizeTranslate();
	currentPosition[0] = transform.position.x;
	currentPosition[1] = transform.position.y;
	//Collider2D.OnTriggerEnter2D(Collider2D);

	// Make it move 10 meters per second instead of 10 meters per frame...
	if(runNewCount){
		determineXorY = Random.Range(-0.9,0.9);
		if(determineXorY < 0){
			isGoingX = false;
		}
		else{
			isGoingX = true;
		}
	    translationY *= Time.deltaTime;
		translationX *= Time.deltaTime;
		if(isGoingX){
			toTranslate[0] = translationX;
			toTranslate[1] = 0;
		}
		else{
			toTranslate[0] = 0;
			toTranslate[1] = translationY;
		}
	}  
	newPosition = currentPosition + toTranslate;

	transform.position = newPosition;
}
