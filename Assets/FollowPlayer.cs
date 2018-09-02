using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform PlayerTransform;
	private Vector3 _cameraOffset;

	[Range(0.01f, 1.0f)]
	public float SmoothFactor = 0.5f;
	public bool LookAtPlayer = false;
	public bool RotateArroundPlayer = false;
	public float RotationSpeed = 5.0f;

	// Use this for initialization
	void Start () {
		_cameraOffset = transform.position - PlayerTransform.position;	
	}
	
	// Update is called after Update methods
	void LateUpdate () {
		if (RotateArroundPlayer && Input.GetMouseButton(0)) {
			Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);
			_cameraOffset = camTurnAngle * _cameraOffset;
		}

		Vector3 newPos = PlayerTransform.position + _cameraOffset;
		transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

		if (LookAtPlayer || RotateArroundPlayer) {
			transform.LookAt(PlayerTransform);
		} 
	}
}
