// Avoxel284
// Controller script for levers

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class LeverController : MonoBehaviour {
	public bool active = false;
	private bool activeLastValue;
	public float activeRotation = 45.0f;
	public float inactiveRotation = -45.0f;
	public float moveRate = 10.0f;
	public GameObject interactTarget;
	public Vector3 activePosition;
	public Vector3 inactivePosition;

	private bool animating;
	private Transform handle;

	void Start() {
		handle = transform.GetChild(1);
		activeLastValue = active;
	}

	void Update() {
		if (active != activeLastValue) {
			animating = true;
			if (interactTarget.TryGetComponent(out AudioSource comp)) {
				Debug.Log(comp);
				comp.Play();
			}
		}
		activeLastValue = active;

		switch (active) {
			case true:
				handle.rotation = Quaternion.Euler(activeRotation, handle.rotation.y, handle.rotation.z);
				if (!animating) return;
				interactTarget.transform.localPosition = Vector3.Lerp(interactTarget.transform.localPosition, activePosition, moveRate * Time.deltaTime);
				if (interactTarget.transform.localPosition == activePosition) animating = false;

				break;
			case false:
				handle.rotation = Quaternion.Euler(inactiveRotation, handle.rotation.y, handle.rotation.z);
				if (!animating) return;
				interactTarget.transform.localPosition = Vector3.Lerp(interactTarget.transform.localPosition, inactivePosition, moveRate * Time.deltaTime);
				if (interactTarget.transform.localPosition == inactivePosition) animating = false;

				break;
		}
	}
}
