using UnityEngine;
using System.Collections;
public class CameraController : MonoBehaviour 
{
	public GameObject target;
	// Higher number provides greatly reduced "realistic" camera vibration
	public float damping = 1;
	Vector3 offset;
	void Start() {
		offset = transform.position - target.transform.position;
	}
	void Update() {
	}
	void LateUpdate() {
		Vector3 desiredPosition = target.transform.position + offset;
		Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
		transform.position = position;
		transform.LookAt(target.transform.position);
	}
	// LateUpdate is called once per frame after player movement
}