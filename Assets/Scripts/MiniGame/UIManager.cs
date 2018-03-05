using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    Test storyScript;
    GameManager gm;
    ArmControl ac;
    public Camera mainCam;
    public Camera uiCam;
	Event e;

    [Header("UI Buttons")]
    public UISprite speedButton;
    public UISprite pauseButton;
    public UISprite playButton;

    [Header("UI Panels")]
    public UIPanel pauseMenu;
    public UISprite tutorialMenu;
    public UISprite levelSelectMenu;
    public UISprite endMenu;

    [Header("UI Elements")]
    public UISprite correct;
    public UISprite incorrect;
    public UILabel turns;
    //public UILabel correctNum;
    //public UILabel incorrectNum;

    [Header("Scoring")]
    public UILabel correctLabel;
    public UILabel incorrectLabel;
    public UISprite star1;
    public UISprite star2;
    public UISprite star3;

    //[Header("Loading Screen")]
    //LoadingScreen ls;

	bool key1Press = false;
	bool key2Press = false;
	bool key3Press = false;
	bool keyspacePress = false;
	bool keyenterPress = false;
	bool objectApp = false;

	/// <summary>
	/// This will be called whenever the iCade state changes i.e. it will get called for ALL events
	/// </summary>
	/// <param name="state"></param>
	/// 
#if UNITY_IOS
	void iCadeStateCallback(int state)
	{
		print("iCade state change. Current state="+state);
	}

	/// <summary>
	/// This will be called whenever there's a button up event in iCade. It will get called for buttons and axis, since axis movement also translates into key presses
	/// </summary>
	/// <param name="button"></param>
	void iCadeButtonUpCallback(char button)
	{
		print("Button up event. Button " + button + " up");
	}

	/// <summary>
	/// This will be called whenever there's a button down event in iCade. It will get called for buttons and axis, since axis movement also translates into key presses
	/// </summary>
	/// <param name="button"></param>
	void iCadeButtonDownCallback(char button)
	{
		print("Button down event. Button " + button + " down");
		if (button == 'w') {
			key1Press = true;
		} 
		if (button == 'x') {
			key2Press = true;
		}
		if (button == 'd') {
			key3Press = true;
		}
		if (button == 'a') {
			keyspacePress = true;
		}
		if (button == 'y') {
			keyenterPress = true;
		}
		objectApp = true;
	}

	void iCadeKeyPressedCallback(int i)
	{
		//print ("Any old key pressed from Scan Mode");
//		if (!trying && !comparing)
//			trying = true;
	}
#endif



    private void Awake()
    {
        star1.alpha = 0f;
        star2.alpha = 0f;
        star3.alpha = 0f;
    }

    // Use this for initialization
    void Start () {
#if UNITY_IOS
		iCadeInput.Activate(true);

		//Register some callbacks
		iCadeInput.AddICadeEventCallback(iCadeStateCallback);
		iCadeInput.AddICadeButtonUpCallback(iCadeButtonUpCallback);
		iCadeInput.AddICadeButtonDownCallback(iCadeButtonDownCallback);
#endif
        
		storyScript = GameObject.FindObjectOfType<Test>();
        gm = GameObject.FindObjectOfType<GameManager>();
        ac = GameObject.FindObjectOfType<ArmControl>();
        mainCam = Camera.main;

        //ls = GameObject.FindObjectOfType<LoadingScreen>();

        correct.alpha = 0f;
        incorrect.alpha = 0f;
        turns.text = gm.totalTurns.ToString();
		e = Event.current;

        pauseMenu.alpha = 0f;
        endMenu.alpha = 0f;

        if (PlayerPrefs.GetInt("tutorialMiniGame") == 0 && gm.isMainMenuGame)
        {
            tutorialMenu.alpha = 1f;
            levelSelectMenu.alpha = 0f;
            pauseButton.alpha = 0f;
            speedButton.alpha = 0f;
        }
        else if (PlayerPrefs.GetInt("tutorialMiniGameStory") == 0 && !gm.isMainMenuGame)
        {
            tutorialMenu.alpha = 1f;
            levelSelectMenu.alpha = 0f;
            pauseButton.alpha = 0f;
            speedButton.alpha = 0f;
        }
        else if (PlayerPrefs.GetInt("levelSelect") == 0)
        {
            tutorialMenu.alpha = 0f;
            levelSelectMenu.alpha = 1f;
            pauseButton.alpha = 0f;
            speedButton.alpha = 0f;
        }
        else
        {
            tutorialMenu.alpha = 0f;
            levelSelectMenu.alpha = 0f;
            pauseButton.alpha = 1f;
            speedButton.alpha = 1f;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1") == true || key1Press) {
			objectApp = true;
		}
		if (Input.GetKeyDown ("2") == true || key2Press) {
			objectApp = true;
		}
		if (Input.GetKeyDown ("3") == true || key3Press) {
			objectApp = true;
		}
		if (Input.GetKeyDown ("space") == true || keyspacePress) {
			objectApp = true;
		}
		if (e != null) {
			if (e.keyCode.ToString () == "10" && e.type == EventType.keyDown || keyenterPress) {
				objectApp = true;
			}
		}


		if (gm.gameOver) {
			correctLabel.text = "Correct: " + gm.correctNum.ToString ();
			incorrectLabel.text = "Incorrect: " + gm.incorrectNum.ToString ();
			endMenu.alpha = 1f;
			pauseButton.alpha = 0f;
			speedButton.alpha = 0f;
			StartCoroutine (starGrow ());

			if (objectApp) {
				if (gm.isMainMenuGame) {
					//Debug.Log ("replay");
					ReplayButton ();
				} else {
					//Debug.Log ("continue story");
					ContinueStoryButton ();
				}
			}
		}
        else if (tutorialMenu.alpha == 1f)
        {
            if (objectApp)
            {
                ContinueTutorialButton();
            }
        }
        else if (PlayerPrefs.GetInt("levelSelect") == 0 && !gm.gameOver) 
		{
			if (objectApp) {
				LevelSelectBeginner_Button ();
			}
		}


		key1Press = false;
		key2Press = false;
		key3Press = false;
		keyspacePress = false;
		keyenterPress = false;
		objectApp = false;
	}

    //UI Interactions / move these to another script
    public void PauseButton()
    {
        Time.timeScale = 0;
        pauseButton.alpha = 0f;
        speedButton.alpha = 0f;
        pauseMenu.alpha = 1f;
        Debug.Log("paused");
    }

    public void ResumeButton()
    {
        Time.timeScale = 1f;
        pauseButton.alpha = 1f;
        speedButton.alpha = 1f;
        pauseMenu.alpha = 0f;
        Debug.Log("resumed");
    }

    public void HomeButton()
    {
        gm.gameOver = true;
        Time.timeScale = 1f;
        pauseMenu.alpha = 0f;
        endMenu.alpha = 0f;
        mainCam.enabled = false;

        SceneManager.LoadSceneAsync("LoadingScreen", LoadSceneMode.Additive);
        StartCoroutine(GoToScene("MenuScreen"));
    }

    public void ReplayButton ()
    {
        Time.timeScale = 1f;
        endMenu.alpha = 0f;
        SceneManager.LoadSceneAsync("LoadingScreen", LoadSceneMode.Additive);
        if (!gm.isMainMenuGame)
        {
            //ls.LoadScene("MiniGame_Story");
            //SceneManager.LoadSceneAsync("MiniGame_Story");
            StartCoroutine(GoToScene("MiniGame_Story"));
        }
        else
        {
            //ls.LoadScene("MiniGame");
            //SceneManager.LoadSceneAsync("MiniGame");
            StartCoroutine(GoToScene("MiniGame"));
        }
    }

    public void ContinueStoryButton ()
    {
        gm.gameOver = true;
        Time.timeScale = 1.0f;
        pauseMenu.alpha = 0f;
        endMenu.alpha = 0f;
        mainCam.enabled = false;
        storyScript.EndMiniGame();
    }

    public void ContinueTutorialButton()
    {
        //set tutorial to complete
        if (gm.isMainMenuGame)
            PlayerPrefs.SetInt("tutorialMiniGame", 1);
        else
            PlayerPrefs.SetInt("tutorialMiniGameStory", 1);
        tutorialMenu.alpha = 0f;
        levelSelectMenu.alpha = 1f;
        //pauseButton.alpha = 1f;
        //speedButton.alpha = 1f;
    }

    public void SpeedButton ()
    {
        bool fastMode = gm.fastMode;

        if (fastMode)
        {
            speedButton.GetComponent<UISprite>().spriteName = "Walk";
            Debug.Log("walk");
        }
        else
        {
            speedButton.GetComponent<UISprite>().spriteName = "Run";
            Debug.Log("run");
        }

        fastMode = !fastMode;
        gm.fastMode = fastMode;
    }

    public void PlayButton()
    {
        if (!(PlayerPrefs.GetInt("levelSelect") == 0) && Time.timeScale > 0)
            ac.trying = true;
    }

    IEnumerator starGrow()
    {
        if (gm.incorrectNum <= 3)
            star1.alpha = 1f;
        yield return new WaitForSeconds(0.5f);
        if (gm.incorrectNum <= gm.totalTurns / 2)
            star2.alpha = 1f;
        yield return new WaitForSeconds(0.5f);
        if (gm.incorrectNum == 0)
            star3.alpha = 1f;
    }

    public void LevelSelectBeginner_Button ()
    {
        Debug.Log("Beginner");
        PlayerPrefs.SetInt("levelSelect", 1);
        levelSelectMenu.alpha = 0f;
        pauseButton.alpha = 1f;
        speedButton.alpha = 1f;
        gm.SetDifficulty();
        gm.RandomArray(3);
        gm.RandomTarget();
    }
    public void LevelSelectAdvanced_Button()
    {
        Debug.Log("Advanced");
        PlayerPrefs.SetInt("levelSelect", 2);
        levelSelectMenu.alpha = 0f;
        pauseButton.alpha = 1f;
        speedButton.alpha = 1f;
        gm.SetDifficulty();
        gm.RandomArray(5);
        gm.RandomTarget();
    }
    public void LevelSelectExpert_Button()
    {
        Debug.Log("Expert");
        PlayerPrefs.SetInt("levelSelect", 3);
        levelSelectMenu.alpha = 0f;
        pauseButton.alpha = 1f;
        speedButton.alpha = 1f;
        gm.SetDifficulty();
        gm.RandomArray(gm.robotList.Length);
        gm.RandomTarget();
    }

    IEnumerator GoToScene (string sceneName)
    {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadSceneAsync(sceneName);

        if (SceneManager.GetActiveScene().name == "LoadingScreen")
            SceneManager.UnloadSceneAsync("LoadingScreen");
    }
}
