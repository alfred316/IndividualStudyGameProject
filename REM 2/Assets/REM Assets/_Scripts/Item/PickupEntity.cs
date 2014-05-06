using UnityEngine;
using System.Collections;

public class PickupEntity : MonoBehaviour, IPickupEntity {

	private void OnCollisionEnter(Collision collision) {
		// collision.gameObject.GetComponent(ItemPickup) returns the itempickup object if the 
		// gameObject is able to be picked up, otherwise it returns null.

		if (collision.gameObject.GetComponent("ItemPickup")) {
			Pickup(collision.gameObject);
		}
	}

	public void Pickup(GameObject other) {
		((ItemPickup) other.GetComponent("ItemPickup")).OnPickup(gameObject);
	}
}
