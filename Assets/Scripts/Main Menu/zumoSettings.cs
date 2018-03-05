using UnityEngine;
using System.Collections;

public class zumoSettings : MonoBehaviour {
		
	public UITexture background;

	private bool on = true;

	public UIPanel settingsPanel;
	public UIPanel frontPanel;

	public UIToggle highlightCheck;
	public UIToggle typingCheck;
	public UIToggle voiceCheck;

	public AudioSource backgroundMusic;

	public UISlider printSlider;

	private bool start;

	public void switching() {
		on = !on;
	}

	// Use this for initialization
	void Start () {
		//SceneManager.therapyOn = false;
		//Debug.Log(SceneManager.therapyOn);
		//start = SceneManager.therapyOn;
		//Debug.Log(start);
		SceneManager_.checkTherapyOn = !SceneManager_.therapyOn;
		SceneManager_.checkEducationOn = !SceneManager_.educationOn;

		printSlider.value = PlayerPrefs.GetFloat("printSize");
		if (PlayerPrefs.GetInt("FirstPrint") == 0) {
			PlayerPrefs.SetInt("FirstPrint",1);
			printSlider.value = 0.5f;
		}
        if (PlayerPrefs.GetInt("voice") == 0)
        {
            backgroundMusic.PlayDelayed(1);
        }
        //therapy.collider.enabled = false;
        //education.collider.enabled = false;

    }
	
	public void OnClick() {
		background.mainTexture = Resources.Load ("background") as Texture;

			on = !on;

		backgroundMusic.Stop();
			settingsPanel.alpha = 1;
		frontPanel.alpha = 0;
             
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
