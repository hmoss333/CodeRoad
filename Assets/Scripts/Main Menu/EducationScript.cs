using UnityEngine;
using System.Collections;

public class EducationScript : MonoBehaviour {

	private bool on = false;

	public UITexture background;
	
	public UIPanel key1cover;
	public UIPanel key2cover;
	public UIPanel key3cover;
	public UIPanel keyEntercover;
	public UIPanel keySpacecover;

	public UIPanel settingsPanel;
	
	public GameObject therapyback;
	public GameObject educationback;

	public UISprite playBackground; 

	public UIPopupList key1pop;
	public UIPopupList key2pop;
	public UIPopupList key3pop;
	public UIPopupList keyEnterpop;
	public UIPopupList keySpacepop;

	public void switching() {
		on = !on;
	}

	public void switchEducation() {
		SceneManager_.educationOn = !SceneManager_.educationOn;
	}

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt("key1music") == 1) {
			key1pop.value = "Sound Effects";
		}
		if (PlayerPrefs.GetInt("key1anim1") == 1) {
			key1pop.value = "Animation Effects";
		}
		if (PlayerPrefs.GetInt("key1anim2") == 1) {
			key1pop.value = "Anim 2";
		}
		if (PlayerPrefs.GetInt("key1anim3") == 1) {
			key1pop.value = "Anim 3";
		}
		if (PlayerPrefs.GetInt("key1newobj") == 1) {
			key1pop.value = "Animate Object";
		}
		if (PlayerPrefs.GetInt("key1back") == 1) {
			key1pop.value = "Back Page";
		}
		if (PlayerPrefs.GetInt("key1next") == 1) {
			key1pop.value = "Next Page";
		}
		if (PlayerPrefs.GetInt("key1repeat") == 1) {
			key1pop.value = "Repeat Page";
		}
		
		if (PlayerPrefs.GetInt("key2music") == 1) {
			key2pop.value = "Sound Effects";
		}
		if (PlayerPrefs.GetInt("key2anim1") == 1) {
			key2pop.value = "Animation Effects";
		}
		if (PlayerPrefs.GetInt("key2anim2") == 1) {
			key2pop.value = "Anim 2";
		}
		if (PlayerPrefs.GetInt("key2anim3") == 1) {
			key2pop.value = "Anim 3";
		}
		if (PlayerPrefs.GetInt("key2newobj") == 1) {
			key2pop.value = "Animate Object";
		}
		if (PlayerPrefs.GetInt("key2back") == 1) {
			key2pop.value = "Back Page";
		}
		if (PlayerPrefs.GetInt("key2next") == 1) {
			key2pop.value = "Next Page";
		}
		if (PlayerPrefs.GetInt("key2repeat") == 1) {
			key2pop.value = "Repeat Page";
		}
		
		if (PlayerPrefs.GetInt("key3music") == 1) {
			key3pop.value = "Sound Effects";
		}
		if (PlayerPrefs.GetInt("key3anim1") == 1) {
			key3pop.value = "Animation Effects";
		}
		if (PlayerPrefs.GetInt("key3anim2") == 1) {
			key3pop.value = "Anim 2";
		}
		if (PlayerPrefs.GetInt("key3anim3") == 1) {
			key3pop.value = "Anim 3";
		}
		if (PlayerPrefs.GetInt("key3newobj") == 1) {
			key3pop.value = "Animate Object";
		}
		if (PlayerPrefs.GetInt("key3back") == 1) {
			key3pop.value = "Back Page";
		}
		if (PlayerPrefs.GetInt("key3next") == 1) {
			key3pop.value = "Next Page";
		}
		if (PlayerPrefs.GetInt("key3repeat") == 1) {
			key3pop.value = "Repeat Page";
		}
		
		if (PlayerPrefs.GetInt("keySpacemusic") == 1) {
			keySpacepop.value = "Sound Effects";
		}
		if (PlayerPrefs.GetInt("keySpaceanim1") == 1) {
			keySpacepop.value = "Animation Effects";
		}
		if (PlayerPrefs.GetInt("keySpaceanim2") == 1) {
			keySpacepop.value = "Anim 2";
		}
		if (PlayerPrefs.GetInt("keySpaceanim3") == 1) {
			keySpacepop.value = "Anim 3";
		}
		if (PlayerPrefs.GetInt("keySpacenewobj") == 1) {
			keySpacepop.value = "Animate Object";
		}
		if (PlayerPrefs.GetInt("keySpaceback") == 1) {
			keySpacepop.value = "Back Page";
		}
		if (PlayerPrefs.GetInt("keySpacenext") == 1) {
			keySpacepop.value = "Next Page";
		}
		if (PlayerPrefs.GetInt("keySpacerepeat") == 1) {
			keySpacepop.value = "Repeat Page";
		}
		
		if (PlayerPrefs.GetInt("keyEntermusic") == 1) {
			keyEnterpop.value = "Sound Effects";
		}
		if (PlayerPrefs.GetInt("keyEnteranim1") == 1) {
			keyEnterpop.value = "Animation Effects";
		}
		if (PlayerPrefs.GetInt("keyEnteranim2") == 1) {
			keyEnterpop.value = "Anim 2";
		}
		if (PlayerPrefs.GetInt("keyEnteranim3") == 1) {
			keyEnterpop.value = "Anim 3";
		}
		if (PlayerPrefs.GetInt("keyEnternewobj") == 1) {
			keyEnterpop.value = "Animate Object";
		}
		if (PlayerPrefs.GetInt("keyEnterback") == 1) {
			keyEnterpop.value = "Back Page";
		}
		if (PlayerPrefs.GetInt("keyEnternext") == 1) {
			keyEnterpop.value = "Next Page";
		}
		if (PlayerPrefs.GetInt("keyEnterrepeat") == 1) {
			keyEnterpop.value = "Repeat Page";
		}
	}
	
	public void OnClick() {
		if ((PlayerPrefs.GetInt("educationOn") == 1) && (PlayerPrefs.GetInt("therapyOn") == 0)) {
			background.mainTexture = Resources.Load ("zumosettings") as Texture;

			key1cover.alpha = 255;
			key2cover.alpha = 255;
			key3cover.alpha = 255;
			keyEntercover.alpha = 255;
			keySpacecover.alpha = 255;

			therapyback.GetComponent<Collider>().enabled = false;
			educationback.GetComponent<Collider>().enabled = true;

			settingsPanel.alpha = 0;

			//on = !on;

		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
