using UnityEngine;
using System.Collections;

public class BackTherapyScript : MonoBehaviour {

	private bool on = false;

	public UITexture background;

	public UIPanel keyPanel;
	
	public UIPanel settingsPanel;
	public UIPanel helpPanel;
	
	public void switching() {
		on = !on;
	}
	// Use this for initialization
	void Start () {

	}
	
	public void OnClick() {
			/*
			therapyBackground.alpha = 255;
			therapyLabel.alpha = 255;
			educationBackground.alpha = 255;
			educationLabel.alpha = 255;
			*/
		background.mainTexture = Resources.Load ("stemsettings") as Texture;

			on = !on;

			keyPanel.alpha = 0;
			helpPanel.alpha = 0;
			settingsPanel.alpha = 255;

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
