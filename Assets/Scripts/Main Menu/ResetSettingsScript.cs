using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResetSettingsScript : MonoBehaviour {

	public GameObject education;
	public GameObject therapy;
	public UIToggle highlightCheck;
	public UIToggle typingCheck;
	public UIToggle voiceCheck;
	public UIToggle educationCheck;
	public UIToggle therapyCheck;

	public UISprite educationBack;
	public UISprite therapyBack;
	
	public UISprite playBackground; 

	public UISlider printSlider;
	
	private Color orig;
	private Color half;


    // Use this for initialization
    void Start () {
		orig = playBackground.color;
		half = new Color(playBackground.color.r/2, playBackground.color.g/2, playBackground.color.b/2);
    }

	public void OnClick() {
        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetInt("firstTime", 1); //needed to prevent game from resetting PlayerPrefs again on restart; see: setPrefs.cs

        highlightCheck.value = true;
		typingCheck.value = false;
		voiceCheck.value = true;
		PlayerPrefs.SetInt("highlight",0);
		PlayerPrefs.SetInt("typing",0);
		PlayerPrefs.SetInt("voice",0);
        PlayerPrefs.SetInt("minigames", 1);
        PlayerPrefs.SetInt("tutorial", 0);
        PlayerPrefs.SetInt("tutorialMiniGame", 0);
        PlayerPrefs.SetInt("tutorialMiniGameStory", 0);
        PlayerPrefs.SetFloat("speedOfLabel", 1f);
        PlayerPrefs.SetInt("MiniGameTutorial", 0);
        PlayerPrefs.SetInt("levelSelect", 0);

        PlayerPrefs.SetInt("MovementChallenge", 0);
        PlayerPrefs.SetInt("AbilitiesChallenge", 0);
        PlayerPrefs.SetInt("LoopChallenge", 0);
        PlayerPrefs.SetInt("ComboChallenge", 0);


        //		educationCheck.value = false;
        //		educationBack.color = half;
        //		education.GetComponent<Collider>().enabled = false;
        //		PlayerPrefs.SetInt("educationOn",0);

        educationCheck.value = true;
		educationBack.color = orig;
		education.GetComponent<Collider>().enabled = true;
		PlayerPrefs.SetInt("educationOn",1);

		therapyCheck.value = false;
		therapyBack.color = half;
		therapy.GetComponent<Collider>().enabled = false;
		PlayerPrefs.SetInt("therapyOn",0);

		printSlider.value = 0.5f;
		PlayerPrefs.SetFloat("printSize",printSlider.value);

        PlayerPrefs.Save();
        Debug.Log("Prefs Reset");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
