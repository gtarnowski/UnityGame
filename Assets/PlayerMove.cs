using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	public float moveSpeed;
	public float jumpHeight;
	private Rigidbody rigidBody;

	void Start () {
		moveSpeed = 3f;
		rigidBody = GetComponent<Rigidbody>();
	}
	void FixedUpdate() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			rigidBody.velocity = new Vector3(0, 10 * jumpHeight * Time.deltaTime, 0);
		}	
	}
	void Update () {
		transform.Translate(
			moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime,
			0f,
			moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime
		);	
	}
}
