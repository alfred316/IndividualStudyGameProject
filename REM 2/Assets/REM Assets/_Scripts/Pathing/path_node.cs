/*
 * Type: Door pathing script
 * Author: Matthew Riedel
 * Started: 2/11/2014
 * 
 * Line of Sight function taken from Brendon Roberto's vision script
 */

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// All path_nodes automatically find eachother and map paths between themselves.
/// Place them in doorways within clear line of site of another path_node.
/// </summary>
public class path_node : MonoBehaviour {

	//Make class variables
	public bool isActive;				//Says whether or not a node is accessible
	public static path_node[] nodeList;	//Store a pointer to each node for reference (once for all nodes)
	public int[,] pathTable;			//Store a table of shortest distances to each node [0=nodeDist, 1=nodeIndex][value]
	private List<int> adjacentNodes;	//Store indices to nodes that are within clear line of site of this node
	private int frameCount;

	/// <summary>
	/// Get the next node in the path to a given node
	/// </summary>
	public path_node getNodeTo(path_node target) {
		int nodeIndex = 0;
		for(int i=0; i<nodeList.Length; ++i)
			if(nodeList[i] == target)
				nodeIndex = i;
		return nodeList[pathTable[1, nodeIndex]];		
	}
	
	
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
	/// Standard distance formula from node to target
	/// </summary>
	public float distTo(GameObject target){
	
		//Set x, y and z variables to make the code readable
		float X = transform.position.x, Y = transform.position.y, Z = transform.position.z;
		float otherX = target.transform.position.x, otherY = target.transform.position.y, otherZ = target.transform.position.z;
		
		//Set the distance in the path table
		return Mathf.Sqrt (((X - otherX) * (X - otherX)) + ((Y - otherY) * (Y - otherY)) + ((Z - otherZ) * (Z - otherZ)));
	}
	
	
	/// <summary>
	/// Force all the nodes to re-create thier tables 
	/// (use if the nodes change)
	/// </summary>
	public void resetPaths(){

		//Restart all path_nodes
		nodeList = (path_node[])FindObjectsOfType(typeof(path_node));
		foreach (path_node nextNode in nodeList) {
			nextNode.frameCount = 0;
			nextNode.Start();
		}
	}


	//Init the nodes before Start is called
	void Awake () {
	
		//init stuff
		isActive = true;
		adjacentNodes = new List<int>();
		nodeList = (path_node[])FindObjectsOfType(typeof(path_node));
	}


	//Use this for initialization (after Awake)
	void Start () {
	
		//Init the path table to -1 (In this case -1 = infinity)
		pathTable = new int[2, nodeList.Length];
			
		//Set adjacent node's distance and index
		for(int i=0; i<nodeList.Length; ++i) {
			pathTable[0,i] = -1;
			if (nodeList[i].isActive && CheckLOS(nodeList[i].gameObject)){
				
				//Set the distance in the path table
				pathTable[0, i] = (int)distTo(nodeList[i].gameObject);
				pathTable[1, i] = i;
				
				//Add the adjacent node index
				adjacentNodes.Add(i);
			}
		}
	}

	
	//Update is called once per frame
	void Update () {

		//Only run until the door map max width has been reached
		if (frameCount < nodeList.Length) {

			//Update the pathing array with the new node data
			foreach(int nodeIndex in adjacentNodes){
				
				//Check if any node's entries (plus the distance to that node) are closer than previous path
				if(nodeList[nodeIndex].isActive) {
							
					//Compare the distances of the node tables and find the shortest path
					for(int i = 0; i < nodeList[nodeIndex].pathTable.Length; ++i) {
						if((pathTable[0, i] < 0) || (pathTable[0, i] > nodeList[nodeIndex].pathTable[0, i] + pathTable[0, nodeIndex])){
						
							//Set the distance to the closer node and the node's index
							pathTable[0, i] = nodeList[nodeIndex].pathTable[0, i] + pathTable[0, nodeIndex];
							pathTable[1, i] = nodeIndex;
						}
					}
				}
			}
			++frameCount;
		}
	}
}
