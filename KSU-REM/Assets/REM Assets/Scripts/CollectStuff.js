#pragma strict

var player : Transform;

function Start () {

}

function Update () {

}

function OnCollisionEnter (collision: Collision){

if (collision.transform == player)

{
Destroy(gameObject);
}

}