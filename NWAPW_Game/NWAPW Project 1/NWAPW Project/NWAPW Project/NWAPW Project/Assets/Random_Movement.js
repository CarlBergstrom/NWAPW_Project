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
var dirControlY : float = Random.Range(-1,1);
var dirControlX : float = Random.Range(-1,1);
var runCounter : float = 0;
var counterCycles : float = 0;
var runNewCount : boolean = false;

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

	// Make it move 10 meters per second instead of 10 meters per frame...
	if(runNewCount){
	    translationY *= Time.deltaTime;
		translationX *= Time.deltaTime;
	}
  
	    // Move translation along the object's z-axis
	    transform.Translate (0, translationY, 0);
	    // Rotate around our y-axis
	    transform.Translate (translationX, 0, 0);

		
}
