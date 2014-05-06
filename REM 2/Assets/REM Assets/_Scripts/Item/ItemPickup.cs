using UnityEngine;
using System.Collections;

public class ItemPickup : MonoBehaviour {

	public void OnPickup(GameObject sender) {
		// Broadcast item pickup to GUI and other listeners.
		Debug.Log(this);
		Messenger.Broadcast<GameObject>("ItemPickup", gameObject);
	}
}
