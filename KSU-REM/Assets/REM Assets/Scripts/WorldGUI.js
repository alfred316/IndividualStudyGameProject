#pragma strict

var dmtIcon : Texture2D;
var blueOrbIcon : Texture2D;
var redOrbIcon : Texture2D;
//var rifleIcon : Texture2D;

function Start () {

}

function Update () {

}

function OnGUI() {

var dmtNumberName = PlayerCounter.dmtCounter;
var dmtName = dmtNumberName.ToString();

var blueOrbNumberName = PlayerCounter.blueOrbCounter;
var blueOrbName = blueOrbNumberName.ToString();

//var rifleStatusName = PlayerProjectileShooter.rifleOn;
//var rifleStatus = rifleStatusName.ToString();


var redOrbNumberName = PlayerCounter.redOrbCounter;
var redOrbName = redOrbNumberName.ToString();

GUI.Label(Rect(55,60,50,25), dmtName);
GUI.Box(Rect(10,10,100,90), dmtIcon);

GUI.Label(Rect(175,60,50,25), redOrbName);
GUI.Box(Rect(140, 10, 100, 90), redOrbIcon);

GUI.Label(Rect(325,60,50,25), blueOrbName);
GUI.Box(Rect(300, 10, 100, 90), blueOrbIcon);


//GUI.Label(Rect(400,60,50,25), rifleStatus);
//GUI.Box(Rect(400, 10, 50, 50), rifleIcon);


GUI.Label(Rect(500,40,300,25), "Welcome to the adventures of sombrero man!");
GUI.Label(Rect(500,60,300,25), "Right click to move!");
GUI.Label(Rect(500,20,300,25), "Move over objects to collect them! ");

}