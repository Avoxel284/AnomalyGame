// Avoxel284
// Controls some UI for showing FPS & stamina

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour {
	public TextMeshProUGUI uiText;
	public GameObject player;
	public GameObject staminaBar;
	public GameObject interactNotif;
	public bool interactNotifEnabled;
	private float deltaTime;
	private GameObject staminaBarFill;

	void Start() {
		staminaBarFill = staminaBar.transform.GetChild(0).gameObject;
	}

	void Update() {
		var stamina = player.GetComponent<PlayerController>().stamina;
		staminaBarFill.transform.localScale = new Vector3((stamina / 100.0f), 1, 1);
		if (player.GetComponent<PlayerController>().staminaRequiresRegen)
			staminaBar.transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 100, 100, 177);
		else
			staminaBar.transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 177);

		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
		float fps = 1.0f / deltaTime;
		uiText.text = Mathf.Ceil(fps).ToString() + " FPS";

		interactNotif.GetComponent<TextMeshProUGUI>().enabled = interactNotifEnabled;
	}
}