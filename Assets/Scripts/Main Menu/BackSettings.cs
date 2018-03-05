using UnityEngine;
using System.Collections;

public class BackSettings : MonoBehaviour {
	
	private bool on = false;

	public UITexture background;

	public UIPanel settingsPanel;
	public UIPanel frontPanel;

	public AudioSource backgroundMusic;

	public void switching() {
		on = !on;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	public void OnClick() {

		background.mainTexture = Resources.Load ("coderoad_opening") as Texture;

			on = !on;

		if (PlayerPrefs.GetInt("voice") == 0) 
		{
			backgroundMusic.Play();
		}


			settingsPanel.alpha = 0;
			frontPanel.alpha = 1;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
