using UnityEngine;
using System.Collections;

public class printKeyStorage : MonoBehaviour {

	public UISlider printSlider;

	public void printSize() {
		PlayerPrefs.SetFloat("printSize",printSlider.value);
	}

	public void printSmall() {
		if (PlayerPrefs.GetInt("printSmall") == 0) {
			PlayerPrefs.SetInt("printSmall",1);
			PlayerPrefs.SetInt("printMedium",0);
			PlayerPrefs.SetInt("printLarge",0);
		} else {
			PlayerPrefs.SetInt("printSmall",0);
		}
	}

	public void printMedium() {
		if (PlayerPrefs.GetInt("printMedium") == 0) {
			PlayerPrefs.SetInt("printSmall",0);
			PlayerPrefs.SetInt("printMedium",1);
			PlayerPrefs.SetInt("printLarge",0);
		} else {
			PlayerPrefs.SetInt("printMedium",1);
		}
	}

	public void printLarge() {
		if (PlayerPrefs.GetInt("printLarge") == 0) {
			PlayerPrefs.SetInt("printSmall",0);
			PlayerPrefs.SetInt("printMedium",0);
			PlayerPrefs.SetInt("printLarge",1);
		} else {
			PlayerPrefs.SetInt("printLarge",0);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
