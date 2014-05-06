#pragma strict

var enemy : Transform;
var enemyArea1 : Transform;
var enemyArea2 : Transform;
var enemyArea3 : Transform;
var enemyArea4 : Transform;
var enemyArea5 : Transform;
public var enemyCount = 0;
var timeDelay = 0.0;

function SpawnEnemy1()
{
Instantiate (enemy, enemyArea1.position, enemyArea1.rotation);
}

function SpawnEnemy2()
{
Instantiate (enemy, enemyArea2.position, enemyArea2.rotation);
}
function SpawnEnemy3()
{
Instantiate (enemy, enemyArea3.position, enemyArea3.rotation);
}

function SpawnEnemy4()
{
Instantiate (enemy, enemyArea4.position, enemyArea4.rotation);
}

function SpawnEnemy5()
{
Instantiate (enemy, enemyArea5.position, enemyArea5.rotation);
}

function Start()
{

}

function OnTriggerStay(triggerCollider : Collider)
{
if (triggerCollider.transform.name == ("Player01"))
{
while (enemyCount < 1){
//timeDelay += Time.deltaTime;
/*
if (timeDelay > 2.0)
{
*/
SpawnEnemy1();
SpawnEnemy2();
SpawnEnemy3();
SpawnEnemy4();
SpawnEnemy5();
enemyCount += 1;
/*
timeDelay = 0.0;
}
*/
}
}
}