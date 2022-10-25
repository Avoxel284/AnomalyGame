// Avoxel284
// The main script for controlling the eyes

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour {
	public List<Texture2D> eyeAnimTextures;
	public AudioSource eyeClosingSFX;
	public GameObject pillar;
	public bool achieved = false;

	public void TriggerEye() {
		if (achieved) return;

		achieved = true;
		StartCoroutine("AnimateEye");
		eyeClosingSFX.Play();
		pillar.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = true;
		pillar.transform.GetChild(2).GetComponent<ParticleSystem>().Play();
	}

	IEnumerator AnimateEye() {
		for (int i = 0; i < eyeAnimTextures.Count; i++) {
			gameObject.GetComponent<MeshRenderer>().material.SetTexture("_BaseMap", eyeAnimTextures[i]);
			yield return new WaitForSeconds(.4f);
		}
	}

}
