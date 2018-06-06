using UnityEngine;
using System.Collections;

public class setPrefs : MonoBehaviour {

    void Awake()
    {
        //PlayerPrefs.DeleteAll(); //Stricktly for testing purposes

        if (PlayerPrefs.GetInt("firstTime") == 0)
        {
            PlayerPrefs.DeleteAll();

            PlayerPrefs.SetInt("firstTime", 1);

            PlayerPrefs.SetInt("highlight", 0);
            PlayerPrefs.SetInt("typing", 0);
            PlayerPrefs.SetInt("voice", 0);
            PlayerPrefs.SetInt("minigames", 1);

            PlayerPrefs.SetInt("educationOn", 1);
            PlayerPrefs.SetInt("therapyOn", 0);

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

            PlayerPrefs.Save();
        }

    }

	// Use this for initialization
	void Start ()
    {        
    }
	
	// Update is called once per frame
	void Update () {	
	}
}
