using UnityEngine;
using System.Collections;

public class TestVisionBehavior : EnemyVisionBehavior {

	private double visionRadius = 1.0f;
	private GameObject player;
	private Color defaultColor;
	// Use this for initialization
	void Start () {
		player = (GameObject)GameObject.FindGameObjectWithTag("Player");
		defaultColor = gameObject.renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
		if (CheckVisible(player)) {
			gameObject.renderer.material.color = Color.red;
		} else {
			gameObject.renderer.material.color = defaultColor;
		}
	}

	private double getVisionRadius() {
		return visionRadius;
	}
}
