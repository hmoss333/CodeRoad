using UnityEngine;
using System.Collections;

public class AboutBackButton : MonoBehaviour {

	public UITexture background;

	private bool on = false;

	public UIPanel aboutPanel;
	public UIPanel optionsPanel;
	
	public void switching() {
		on = !on;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	public void OnClick() {

		background.mainTexture = Resources.Load ("coderoad_opening") as Texture;
			on = !on;

			aboutPanel.alpha = 0;
			optionsPanel.alpha = 1;

	}
	
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
