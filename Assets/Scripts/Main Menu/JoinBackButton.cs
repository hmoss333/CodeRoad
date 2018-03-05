using UnityEngine;
using System.Collections;

public class JoinBackButton : MonoBehaviour {

	public UITexture background;
	
	private bool on = false;
	
	public UIPanel joinPanel;
	public UIPanel optionsPanel;
	
	public void switching() {
		on = !on;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	public void OnClick() {
		
		background.mainTexture = Resources.Load ("background") as Texture;
		
		on = !on;
		
		joinPanel.alpha = 0;
		optionsPanel.alpha = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
