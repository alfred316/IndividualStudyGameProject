

function OnTriggerEnter (other : Collider) {
	if (other.CompareTag("Player")) {
		Application.LoadLevel("Third");
	}
}
