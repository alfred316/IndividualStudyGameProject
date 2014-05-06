/*
 * 
 *  Authors: Brendon Roberto
 *  Project: Project REM
 *  Date: 1/30/2013
 * 
 */

using UnityEngine;
using System;
using System.Collections.Generic;

public static class SceneUtils : object 
{

	// Returns a list of all active objects in the current scene.
	public static List<GameObject> GetAllObjectsInScene() {

		// Adds all objects in the current scene, including inactive, invisible, and inoperative objects
		List<GameObject> allObjects = new List<GameObject>((GameObject[])GameObject.FindObjectsOfType (typeof(GameObject)));

		// Remove the inactive, invisible, and inoperative objects.
		foreach (GameObject obj in allObjects) {
			if (!obj.activeInHierarchy) {
				allObjects.Remove(obj);
			}
		}

		return allObjects;
	}

	// Runs the provided function on each GameObject in the scene
	public static void ForEachObjectInScene(Action<GameObject> action) {
		List<GameObject> allObjects = GetAllObjectsInScene();

		foreach (GameObject obj in allObjects) {
			action(obj);
		}
	}

	public static void ForEachObjectInArray(List<GameObject> array, Action<GameObject> action) {
		foreach (GameObject obj in array) {
			action(obj);
		}
	}
}
