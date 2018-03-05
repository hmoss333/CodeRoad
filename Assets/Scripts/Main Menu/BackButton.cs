using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

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
		background.mainTexture = Resources.Load ("coderoad_opening") as Texture;
			
			on = !on;
			
		if (PlayerPrefs.GetInt("voice") == 0) 
		{
			backgroundMusic.Play();
		}	

		optionsPanel.alpha = 0;
		frontPanel.alpha = 1;
	}
	
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
