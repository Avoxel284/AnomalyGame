// Avoxel284
// Script that controls interactables

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
	public float interactRange = 5.0f;
	public UIController playerUI;

	void Update() {
		RaycastHit hit;
		playerUI.interactNotifEnabled = false;

		if (Physics.Raycast(GetComponent<Camera>().transform.position, GetComponent<Camera>().transform.forward, out hit, interactRange)) {
			var obj = hit.transform.gameObject;

			switch (obj.tag) {
				case "Eye":
					obj.GetComponent<Eye>().TriggerEye();
					break;

				case "Lever":
					playerUI.interactNotifEnabled = true;
					if (Input.GetKeyDown(KeyCode.E))
						obj.GetComponent<LeverController>().active = !obj.GetComponent<LeverController>().active;
					break;
			}
		}
	}
}
