/*
 * Type: Door pathing script
 * Author: Matthew Riedel
 * Started: 2/15/2014
 */
 
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Uses all current path_nodes in the room to help an object find its way to any given target
/// </summary>
public class path_finder : MonoBehaviour {

	//So you don't get stuck on a node
	private static int bufferZone = 3;
	private GameObject lastTarget = null;
	private path_node trackPoint = null;
	private path_node endNode = null;

	//This function was taken from Brendon Roberto's vision script
	/// <summary>
	/// Check if there is clear line of site from this node to target
	/// </summary>
	public bool CheckLOS(GameObject target) {
		// Line of sight is clear if we can cast a ray between this position and the target's position.
		if (target) {
			// Construct the exclusionList
			List<GameObject> exclusionList = new List<GameObject>();
			exclusionList.Add(this.gameObject);
			exclusionList.Add(target);
			
			return VectorUtils.CanCastRay(this.transform.position, target.transform.position, exclusionList);
		}
		return false;
	}


	/// <summary>
	/// Get a vector to move toward based on a target
	/// If no path is available, return the target's coordinates
	/// </summary>
	public Vector3 pathTo(GameObject target) {

		//Check if targets have changed
		if ((!lastTarget) || lastTarget != target) {
			lastTarget = target;
			trackPoint = endNode = null;
		}
	
		//Check if the path nodes are even needed
		if (CheckLOS (target)) {
			trackPoint = endNode = null;
			return target.transform.position;
		}

		//Check if there is already a point to move to
		if (trackPoint && trackPoint.distTo (gameObject) > bufferZone)
			return trackPoint.transform.position;
		
		//Find the best node to track to if one must be found
		int destIndex = -1, distToTarget = -1;
		for(int i=0; i<path_node.nodeList.Length; ++i){
			if(path_node.nodeList[i].CheckLOS(target) && (distToTarget == -1 || distToTarget > path_node.nodeList[i].distTo(target))){
				destIndex = i;
				endNode = path_node.nodeList[i];
				distToTarget = (int)endNode.distTo(target);
			}
		}
		
		//Find the best node to track from
		int returnIndex = -1;
		if(destIndex != -1){
			distToTarget = -1;
			for(int i=0; i<path_node.nodeList.Length; ++i){
				if(path_node.nodeList[i].CheckLOS(this.gameObject) && (distToTarget == -1 || distToTarget > path_node.nodeList[i].pathTable[0, destIndex])){
					returnIndex = i;
					distToTarget = path_node.nodeList[i].pathTable[0, destIndex];
				}
			}
		}
		//If no node exits, try your luck running straight at them
		else return target.transform.position;
			
		//Return the position of the best node
		if(returnIndex != -1){
			if(distToTarget <= bufferZone) trackPoint = path_node.nodeList[returnIndex].getNodeTo(path_node.nodeList[destIndex]);
			else trackPoint = path_node.nodeList[returnIndex];
			return trackPoint.transform.position;
		}
		//If no node exists, run at them again
		else return target.transform.position;
	}
	
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}
}
