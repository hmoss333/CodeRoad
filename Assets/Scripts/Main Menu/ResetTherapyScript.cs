using UnityEngine;
using System.Collections;

public class ResetTherapyScript : MonoBehaviour {

	public UIToggle key1;
	public UIToggle key2;
	public UIToggle key3;
	public UIToggle keyEnter;
	public UIToggle keySpace;

	// Use this for initialization
	void Start () {
	
	}

	public void OnClick() {
		key1.value = true;
		key2.value = true;
		key3.value = true;
		keyEnter.value = true;
		keySpace.value = true;
		PlayerPrefs.SetInt("key1toggle",0);
		PlayerPrefs.SetInt("key2toggle",0);
		PlayerPrefs.SetInt("key3toggle",0);
		PlayerPrefs.SetInt("keyEntertoggle",0);
		PlayerPrefs.SetInt("keySpacetoggle",0);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
