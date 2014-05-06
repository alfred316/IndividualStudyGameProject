/*
 * 
 *  Authors: Brendon Roberto
 *  Project: Project REM
 *  Date: 1/30/2013
 * 
 */

using UnityEngine;
using System.Collections;

public interface IVisionEntity
{
	bool CheckLOS(GameObject target);
	bool CheckVisionRadius(GameObject target);
	bool CheckVisible(GameObject target);
}