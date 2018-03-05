using UnityEngine;
using System.Collections;

public class InfoPanel : MonoBehaviour {

	public UITexture background;

	private bool on = false;
	
	public UIPanel infoPanel;
	public UIPanel frontPanel;
	
	public AudioSource backgroundMusic;

	public void infoButton() {
		background.mainTexture = Resources.Load ("background") as Texture;
		
		on = !on;
		
		backgroundMusic.Stop();
		
		infoPanel.alpha = 1;
		frontPanel.alpha = 0;
	}
	
	public void backInfo() {
		background.mainTexture = Resources.Load ("coderoad_opening") as Texture;
		
		on = !on;
		
		if (PlayerPrefs.GetInt("voice") == 0) 
		{
			backgroundMusic.Play();
		}	
		
		infoPanel.alpha = 0;
		frontPanel.alpha = 1;
	}

	public void switching() {
		on = !on;
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
	
	}
}
