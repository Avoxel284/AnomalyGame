// Avoxel284
// The main anomaly controller script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyController : MonoBehaviour {
	public GameObject player;
	public float speed = 4.0f;
	public float detectRange = 20.0f;

	void Update() {
		float dist = Vector3.Distance(player.transform.position, transform.position);
		if (dist <= detectRange)
			transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
	}
}