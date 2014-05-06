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

public static class VectorUtils : object 
{
	private static double epsilon = 0.01f;


	// Primitive raycasting function. Only works with points, not whole objects. Will need implementation using bounding boxes.
	// Returns true if the ray from start to end is clear of obstructions.
	// exclude parameter is the list of GameObjects to exclude from the check.
	public static bool CanCastRay(Vector3 start, Vector3 end, List<GameObject> exclusionList) {
		bool result = true;

		// Action to pass to ForEachObjectInScene
		Action<GameObject> checkCollision = obj =>
		{
			// If this object is located on the line between start and end, there is a collision
			if (VectorUtils.SegmentContainsPoint(start, end, obj.transform.position)) {
				// Use closure of outer function to change result variable to false;
				result = false;
			}
		};

		// Remove the list of excluded objects from the final list
		List<GameObject> objects = SceneUtils.GetAllObjectsInScene();
		foreach (GameObject excluded in exclusionList) {
			objects.Remove(excluded);
		}

		SceneUtils.ForEachObjectInArray(objects, checkCollision);

		return result;
	}

	// Calculate distance between two points
	public static double Distance(Vector3 start, Vector3 end) {
		return Math.Sqrt(Math.Pow(start.x - end.x, 2) + Math.Pow(Math.Sqrt(Math.Pow(start.y - end.y, 2) + Math.Pow(start.z - end.z, 2)), 2));
	}

	// Returns true if point lies between start and end
	public static bool SegmentContainsPoint(Vector3 start, Vector3 end, Vector3 point) {
		double difference = VectorUtils.Distance(start, point) + VectorUtils.Distance(point, end) - VectorUtils.Distance(start, end);
		// if (start, point) + (point, end) is within epsilon of (start, end), then point is within the line segment.
		return (-epsilon < difference) && (difference < epsilon);
	}
}
