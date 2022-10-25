// Avoxel284
// Script to make billboards, billboards.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {
	void Update() {
		transform.LookAt(Camera.main.transform.position, Vector3.up);
		transform.Rotate(new Vector3(90, 0, 0));
	}
}