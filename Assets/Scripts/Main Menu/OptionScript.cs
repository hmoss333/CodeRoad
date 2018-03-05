using UnityEngine;
using System.Collections;

public class OptionScript : MonoBehaviour {
	
	public UITexture background;
	
	private bool on = false;
	
	public UIPanel optionsPanel;
	public UIPanel frontPanel;

	public AudioSource backgroundMusic;
	
	public void switching() {
		on = !on;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	public void OnClick() {
		background.mainTexture = Resources.Load ("background") as Texture;
		
		on = !on;

		backgroundMusic.Stop();
		
		optionsPanel.alpha = 1;
		frontPanel.alpha = 0;
	}
	

	
	// Update is called once per frame
	void Update () {
		
	}
}
