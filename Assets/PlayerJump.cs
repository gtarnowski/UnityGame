using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {
	private CharacterController controller;

	private float verticalVelocity;
	private float gravity = 14.0f;
	private float jumpForce = 6.0f;


	// Use this for initialization
	void Start () {
		controller = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.isGrounded) {
			verticalVelocity = -gravity * Time.deltaTime;
			if (Input.GetKeyDown(KeyCode.Space)) {
				verticalVelocity = jumpForce;
			} 
		} else {
			verticalVelocity -= gravity * Time.deltaTime;
		}

		Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
			moveVector.x = Input.GetAxis("Horizontal") * 5.0f;
			moveVector.y = verticalVelocity;
			moveVector.z = Input.GetAxis("Vertical") * 5.0f;
			controller.Move(moveVector * Time.deltaTime);
	}
}
