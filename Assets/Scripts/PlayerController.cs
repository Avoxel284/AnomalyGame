// Avoxel284
// The main player controller script with bonus stamina system

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float stamina = 100.0f;
	public float staminaMax = 100.0f;
	public float staminaMin = 20.0f;
	public bool staminaRequiresRegen = false;
	public float lookSpeed = 2.0f;
	public float lookXClamp = 40.0f;
	public Vector3 spawnLocation;
	public float walkSpeed = 7f;
	public float runSpeed = 11.5f;
	public float staminaDepleteRate = 20.0f;
	public float staminaIncreaseRate = 16.0f;
	public bool keepAmbientLight = false;

	[HideInInspector]
	public bool canMove = true;

	CharacterController characterController;
	Vector3 vel = Vector3.zero;
	float rotationX = 0;


	void Start() {
		if (!keepAmbientLight)
			RenderSettings.ambientLight = new Color32(7, 7, 7, 255);

		characterController = GetComponent<CharacterController>();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update() {
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		Vector3 right = transform.TransformDirection(Vector3.right);
		Vector3 down = transform.TransformDirection(Vector3.down);

		bool isRunning = Input.GetKey(KeyCode.LeftShift);

		if (!canMove) return;
		if (isRunning && (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) && !staminaRequiresRegen) {
			if (stamina == 0.0f)
				staminaRequiresRegen = true;
			else
				stamina = Mathf.Clamp(stamina - (staminaDepleteRate * Time.deltaTime), 0.0f, staminaMax); // reduce stamina until 0

		} else {
			stamina = Mathf.Clamp(stamina + (staminaIncreaseRate * Time.deltaTime), 0.0f, staminaMax); // add stamina until 100
			if (stamina > staminaMin) staminaRequiresRegen = false;
		}
		if (staminaRequiresRegen) isRunning = false;

		float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
		float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
		vel = (forward * curSpeedX) + (right * curSpeedY) + (down * 9.8f);

		// moving character
		characterController.Move(vel * Time.deltaTime);

		// rotating camera & character
		rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
		rotationX = Mathf.Clamp(rotationX, -lookXClamp, lookXClamp);
		Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
		transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

	}

	public void Respawn() {
		// Respawn script
		transform.position = spawnLocation;
	}
}