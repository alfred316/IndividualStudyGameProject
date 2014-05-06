#pragma strict

static var dmtCounter = 0;
static var blueOrbCounter=0;
static var redOrbCounter=0;
static var playerHealth = 3;

function Start () {
playerHealth =3;
}

function Update () {

if (playerHealth <= 0)
{

Application.LoadLevel("GameOver");

}


}

function OnCollisionEnter(collision : Collision){

if (collision.transform.name == ("DMT"))
{

dmtCounter += 1;

}

else if (collision.transform.name == ("blueOrb"))
{

blueOrbCounter += 1;

}

else if (collision.transform.name == ("redOrb"))
{

redOrbCounter += 1;

}

else if (collision.transform.name == ("Enemy") && playerHealth >0)
{

playerHealth -= 1;

}

else if (collision.transform.name == ("Bullet(Clone)")&& playerHealth > 0)
{

playerHealth -= 1;

}

}