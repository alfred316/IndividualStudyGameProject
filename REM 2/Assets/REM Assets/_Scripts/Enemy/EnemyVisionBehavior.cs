/*
 * 
 *  Authors: Brendon Roberto
 *  Project: Project REM
 *  Date: 1/30/2013
 * 
 */

using UnityEngine;
using System.Collections.Generic;

public abstract class EnemyVisionBehavior : MonoBehaviour, IVisionEntity 
{

	// Use this for initialization
	void Start () {
		// dummy
	}
	
	// Update is called once per frame
	void Update () {
		// dummy
	}

	public bool CheckLOS(GameObject target) {
		// Line of sight is clear if we can cast a ray between this position and the target's position.
		if (target) {
			// Construct the exclusionList
			List<GameObject> exclusionList = new List<GameObject>();
			exclusionList.Add(this.gameObject);
			exclusionList.Add(target);

			return VectorUtils.CanCastRay(this.transform.position, target.transform.position, exclusionList);
		} else {
			return false;
		}
	}

	public bool CheckVisionRadius(GameObject target) {
		// Check that the distance between this object and the target is less than the visionRadius
		if (target) {
			return VectorUtils.Distance(this.transform.position, target.transform.position) < getVisionRadius();;
		} else {
			return false;
		}
	}

	public bool CheckVisible(GameObject target) {
		// If the target is both within Vision Radius, and Line of Sight, then it is visible.
		if (target) {
			return this.CheckVisionRadius(target) && this.CheckLOS(target);
		} else {
			return false;
		}
	}

	private double getVisionRadius() {
		return 10.0f;
	}
}
