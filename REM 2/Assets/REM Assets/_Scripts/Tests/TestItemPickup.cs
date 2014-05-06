using UnityEngine;
using System;
using System.Collections;

public class TestItemPickup : MonoBehaviour {

	private int pickups;
	private String lastItem;
	// Use this for initialization
	void Start () {
		pickups = 0;
		Messenger.AddListener<GameObject>("ItemPickup", OnItemPickup);
	}
	
	void OnItemPickup(GameObject item) {
		Debug.Log("inside OnItemPickup");
		Debug.Log(item);
		lastItem = item.ToString();
		pickups++;
		Destroy(item);
	}

	// Update is called once per frame
	void OnGUI() {
		GUI.TextArea(new Rect(10, 10, 500, 50), String.Format("Pickups: {0}\nLast Item Picked Up: {1}", pickups, lastItem));
	}
}
