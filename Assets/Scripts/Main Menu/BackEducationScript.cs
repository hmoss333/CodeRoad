using UnityEngine;
using System.Collections;

public class BackEducationScript : MonoBehaviour {

	private bool on = false;

	public UITexture background;
	
	public UIPanel key1cover;
	public UIPanel key2cover;
	public UIPanel key3cover;
	public UIPanel keyEntercover;
	public UIPanel keySpacecover;

	public UIPanel settingsPanel;
	public UIPanel helpPanel;

	public void switching() {
		on = !on;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	public void OnClick() {
		background.mainTexture = Resources.Load ("background") as Texture;

			key1cover.alpha = 0;
			key2cover.alpha = 0;
			key3cover.alpha = 0;
			keyEntercover.alpha = 0;
			keySpacecover.alpha = 0;

			settingsPanel.alpha = 255;
			helpPanel.alpha = 0;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
