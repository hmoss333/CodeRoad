using UnityEngine;
using System.Collections;

public class TherapyKeyStorage : MonoBehaviour {

	private bool on = false;

	public void switching() {
		on = !on;
	}

	public void key1toggle() {
		if (on) {
			if (PlayerPrefs.GetInt("key1toggle") == 0) {
				PlayerPrefs.SetInt("key1toggle",1);
			} else {
				PlayerPrefs.SetInt("key1toggle",0);
			}
		}
	}

	public void key2toggle() {
		if (on) {
			if (PlayerPrefs.GetInt("key2toggle") == 0) {
				PlayerPrefs.SetInt("key2toggle",1);
			} else {
				PlayerPrefs.SetInt("key2toggle",0);
			}
		}
	}

	public void key3toggle() {
		if (on) {
			if (PlayerPrefs.GetInt("key3toggle") == 0) {
				PlayerPrefs.SetInt("key3toggle",1);
			} else {
				PlayerPrefs.SetInt("key3toggle",0);
			}
		}
	}

	public void keyEntertoggle() {
		if (on) {
			if (PlayerPrefs.GetInt("keyEntertoggle") == 0) {
				PlayerPrefs.SetInt("keyEntertoggle",1);
			} else {
				PlayerPrefs.SetInt("keyEntertoggle",0);
			}
		}
	}

	public void keySpacetoggle() {
		if (on) {
			if (PlayerPrefs.GetInt("keySpacetoggle") == 0) {
				PlayerPrefs.SetInt("keySpacetoggle",1);
			} else {
				PlayerPrefs.SetInt("keySpacetoggle",0);
			}
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
