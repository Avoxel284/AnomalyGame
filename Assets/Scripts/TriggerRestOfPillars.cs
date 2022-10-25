// Avoxel284

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRestOfPillars : MonoBehaviour {
	public GameObject pillarsGroup;
	public GameObject eye01;
    public GameObject sectorDoorGroup;
    private bool debounce = false;

	void OnTriggerEnter(Collider collision) {
        if (debounce) return;
		if (collision.CompareTag("Player") && eye01.GetComponent<Eye>().achieved) {
            debounce = true;
			pillarsGroup.GetComponent<Animator>().Play("Base Layer.PillarsAnimation");
			pillarsGroup.GetComponent<AudioSource>().Play();
            sectorDoorGroup.GetComponent<Animator>().Play("Base Layer.SectorDoorsAnimation");
		}
	}
}
