using UnityEngine;
using System.Collections;

public class TherapyScript : MonoBehaviour {

	private bool on = false;

	public UITexture background;
	
	public GameObject therapyback;
	public GameObject educationback;

	public UISprite playBackground; 

	public UIToggle key1;
	public UIToggle key2;
	public UIToggle key3;
	public UIToggle keyEnter;
	public UIToggle keySpace;

	public UIPanel keyPanel;
	public UIPanel settingsPanel;

	public void switching() {
		on = !on;
	}

	public void switchTherapy() {
		SceneManager_.therapyOn = !SceneManager_.therapyOn;
	}
	
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt("key1toggle") == 1) {
			key1.value = false;
		} else {
			key1.value = true;
		}
		if (PlayerPrefs.GetInt("key2toggle") == 1) {
			key2.value = false;
		} else {
			key2.value = true;
		}
		if (PlayerPrefs.GetInt("key3toggle") == 1) {
			key3.value = false;
		} else {
			key3.value = true;
		}
		if (PlayerPrefs.GetInt("keyEntertoggle") == 1) {
			keyEnter.value = false;
		} else {
			keyEnter.value = true;
		}
		if (PlayerPrefs.GetInt("keySpacetoggle") == 1) {
			keySpace.value = false;
		} else {
			keySpace.value = true;
		}
	}
	
	public void OnClick() {
		if ((PlayerPrefs.GetInt("therapyOn") == 1)  && (PlayerPrefs.GetInt("educationOn") == 0)) {

			therapyback.GetComponent<Collider>().enabled = true;
			educationback.GetComponent<Collider>().enabled = false;

			background.mainTexture = Resources.Load ("zumosettings") as Texture;

			keyPanel.alpha = 255;
			settingsPanel.alpha = 0;

			//on = !on;

		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
