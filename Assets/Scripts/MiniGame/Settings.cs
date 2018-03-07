using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;
using UnityEngine.EventSystems;

public class Settings : MonoBehaviour {

    const float minScanSpeed = 0.05f;
    const float maxScanSpeed = 9.00f;
    float scanTime = 0.0f;
    float saveSettingsTime = 0.0f;
    bool minusSignPressed = false;
    bool plusSignPressed = false;

    enum gameMode
    {
        freePlay,
        challenge
    }

    gameMode currentSelectedMode;

    public GameObject mainCanvas;
    public GameObject settingsCanvas;
    public GameObject challengeCanvas;
    public GameObject exitCanvas;
    public GameObject tutorialStoryCanvas;
    public GameObject stemdashInfoCanvas;
    public GameObject parentalGateCanvas;

    public AudioSource menuMusic;

    public Toggle voiceToggle;
    public Toggle musicToggle;
    public Toggle scanToggle;

    public GameObject freePlayButton;
    public GameObject challengeButton;
    public GameObject settingsButton;
    public GameObject tutorialButton;
    public GameObject exitButton;
    public GameObject backButton;

    public GameObject movementButton;
    public GameObject abilitiesButton;
    public GameObject loopsButton;
    public GameObject combosButton;
    public static int scanSelection;
    public static int scanSelection2;
    public Text scanSpeedTxt;
    public Text saveFeedBackTxt;
    bool clickedSettings;
    bool buttonChoosen;
    float scanSpeed = 1.00f;

    //Parental Gate variables
    public Text[] Button_ParentalGate_Labels;
    int parentalGateFirstNumber;
    int parentalGateSecondNumber;
    int parentalGateAnswer;
    public Text parentalGateFirstNumberText;
    public Text parentalGateSecondNumberText;

    /*STEMDash Variables*/
    public Dropdown playerList;
    public Dropdown chatTimesList;
    public Dropdown fontSizeList;

    public GameObject STEMDashOptions;
    public GameObject AddPlayerCanvas;
    public GameObject AddFirstPlayerCanvas;
    public GameObject DeletePlayerCanvas;
    public GameObject stemDashCanvas;
    public GameObject chattingSettingsCanvas;
    public GameObject addingPlayerStatusCanvas;
    public GameObject deletePlayerStatusCanvas;
    public GameObject STEMDashInviteCanvas;
    public GameObject playTimeOverCanvas;

    public GameObject logoutBtn;
    public GameObject STEMDashOptionsBtn;
    public GameObject STEMDashBtn;

    //Text
    public Text addChildUserExistsError;
    public Text addFirstChildUserExistsError;
    public Text addChildDuplicateError;
    public Text addFirstChildDuplicateError;
    public Text addChildNoLetterError;
    public Text addFirstChildNoLetterError;
    public Text addChildMaxCountError;
    public Text addFirstChildMaxCountError;
    public Text addPlayerStatusText;
    public Text deletePlayerText;
    public Text deletePlayerStatusText;

    public InputField childBeingAdded;
    public InputField firstChildBeingAdded;

    GameObject turtleTongueAndEyes;
    GameObject turtleBody;
    Button LogOut;
    Stack<GameObject> currentCanvas = new Stack<GameObject>();

    //Chat area variables
    float messageTimer = 0.0f;
    bool messageActive = false;
    bool displayingMessages = false;
    bool startFinished = false;
    bool showedPopup = false;
    public GameObject messageContainerPrefab;
    public EnhancedToggleGroup boxSizeGroup;
    public EnhancedToggleGroup chatOnOffToggleGroup;

    //public Toggle[] boxSizes;
    Queue<GameObject> messages = new Queue<GameObject>();

    Color myColor = new Color(0.258f, 0.941f, 0.090f, 1);
    void Awake()
    {
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            GameObject musicController = GameObject.FindGameObjectWithTag("MusicController");
            if (musicController != null)
                Destroy(musicController);
        }
    }

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt("Voice") == 1) { voiceToggle.isOn = true; } else { voiceToggle.isOn = false; }
        if (PlayerPrefs.GetInt("Music") == 1) { musicToggle.isOn = true; menuMusic.Play(); } else { musicToggle.isOn = false; }
        if (PlayerPrefs.GetInt("Scan") == 1) { scanToggle.isOn = true; } else { scanToggle.isOn = false; scanSelection = 3; }

        initSTEMDash();
        buttonChoosen = false;
        scanSelection = 0;
        scanSelection2 = 0;

        scanToggle.onValueChanged.AddListener(delegate
        {
            changeMode(scanToggle, "Scan");
        });

        voiceToggle.onValueChanged.AddListener(delegate
        {
            changeMode(voiceToggle, "Voice");
        });
        musicToggle.onValueChanged.AddListener(delegate
        {
            changeMode(musicToggle, "Music");
        });
        Debug.Log("Type: Scan, Value: " + PlayerPrefs.GetInt("Scan"));

        checkToggleStates();
    }

    public void three20x480Portrait() { Screen.SetResolution(320, 480, true); }
    public void eight00x480Portrait() { Screen.SetResolution(800, 480, true); }
    public void one024x600Portrait() { Screen.SetResolution(1024, 600, true); }

    void changeMode(Toggle toggle, string type)
    {
        int toggleOption = (toggle.isOn) ? 1 : 0;
        Debug.Log("Type: " + type + ", Value: " + toggleOption);
        PlayerPrefs.SetInt(type, toggleOption);
    }

    public void minusSignBeingPressed()
    {
        minusSignPressed = true;
    }
    public void minusSignBeingRelease()
    {
        minusSignPressed = false;
    }
    public void plusSignBeingPressed()
    {
        plusSignPressed = true;
    }
    public void plusSignBeingRelease()
    {
        plusSignPressed = false;
    }

    public void incrementScanSpeed()
    {
        scanSpeed += 0.05f;
        float currentValue = (float) System.Math.Round(scanSpeed, 2);
        scanSpeed = (currentValue > maxScanSpeed) ? scanSpeed = minScanSpeed : scanSpeed = currentValue;
        scanSpeedTxt.text = scanSpeed.ToString("0.00") + " Seconds";
        PlayerPrefs.SetFloat("scanSpeed", scanSpeed);
    }
    public void decrementScanSpeed()
    {
        scanSpeed -= 0.05f;
        float currentValue = (float) System.Math.Round(scanSpeed, 2);
        scanSpeed = (currentValue < minScanSpeed) ? scanSpeed = maxScanSpeed : scanSpeed = currentValue;
        scanSpeedTxt.text = scanSpeed.ToString("0.00") + " Seconds";
        PlayerPrefs.SetFloat("scanSpeed", scanSpeed);
    }
    void Update()
    {
        checkLoginStatus();
        addChildRoutine();
        deleteChildRoutine();
        controlRoutine();
        saveSettingsRoutine();

        if (minusSignPressed)
        {
            scanTime += Time.deltaTime;
            if (scanTime > 0.15f)
            {
                decrementScanSpeed();
                scanTime = 0.0f;
            }
        }

        if (plusSignPressed)
        {
            scanTime += Time.deltaTime;
            if (scanTime > 0.15f)
            {
                incrementScanSpeed();
                scanTime = 0.0f;
            }
        }


        if (!displayingMessages)
        {
            handleReceivedMessages();
        }

        if (Input.anyKeyDown)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) return;

            if ((PlayerPrefs.GetInt("Scan") == 1))
            {
                if (!clickedSettings)
                {
                    if (mainCanvas.active)
                    {
                        if (scanSelection == 0)
                        {
                            tutorial();
                        }
                        else if (scanSelection == 1)
                        {
                            freePlay();
                        }
                        else if (scanSelection == 2)
                        {
                            showChallenge();
                        } else if (scanSelection == 3)
                        {
                            showSettings();
                        }
                    }
                    else if (challengeCanvas.active)
                    {
                        if (scanSelection2 == 0)
                        {
                            MovementChallenge();
                        }
                        else if (scanSelection2 == 1)
                        {
                            AbilitiesChallenge();
                        }
                        else if (scanSelection2 == 2)
                        {
                            LoopChallenge();
                        }
                        else if (scanSelection2 == 3)
                        {
                            ComboChallenge();
                        }
                        else if (scanSelection2 == 4)
                        {
                            showMain();
                        }
                    }
                }
            }
        }
    }

    void ParentalGate()
    {
        parentalGateFirstNumber = Random.Range(4, 10);
        parentalGateSecondNumber = Random.Range(4, 10);
        parentalGateAnswer = parentalGateFirstNumber * parentalGateSecondNumber;
        parentalGateFirstNumberText.text = parentalGateFirstNumber.ToString();
        parentalGateSecondNumberText.text = parentalGateSecondNumber.ToString();


        int randomIndex = Random.Range(0, 4);
        int wrongAnswer = 0;
        Button_ParentalGate_Labels[randomIndex].text = parentalGateAnswer.ToString();
        if (randomIndex == 3) {// 
            for (int i = 0; i < randomIndex; i++) {
                //	randomNumber=Random.Range (0, 100);
                //	while(randomNumber==parentalGateAnswer){
                //		randomNumber=Random.Range (0, 100);
                //	}
                wrongAnswer = parentalGateAnswer + Random.Range(1, 10);
                Button_ParentalGate_Labels[i].text = wrongAnswer.ToString();
            }
        } else if (randomIndex == 0) {
            for (int i = 1; i < 4; i++) {
                wrongAnswer = parentalGateAnswer + Random.Range(1, 10);
                Button_ParentalGate_Labels[i].text = wrongAnswer.ToString();
            }
        } else {
            for (int i = 0; i < randomIndex; i++) {
                wrongAnswer = parentalGateAnswer + Random.Range(1, 10);
                Button_ParentalGate_Labels[i].text = wrongAnswer.ToString();
            }
            for (int i = randomIndex + 1; i < 4; i++) {
                wrongAnswer = parentalGateAnswer - Random.Range(1, 10);
                Button_ParentalGate_Labels[i].text = wrongAnswer.ToString();
            }
        }
    }
    public void ParentalGateCheckAnswer() {
        Text answerChoice = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>();
        if (answerChoice.text == parentalGateAnswer.ToString()) {
            showSTEMDash();
        } else {
            showMain();
        }
    }

    void LoadLevel(string level)
    {
        LoadManager.level = level;
        SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Additive);
    }

    public void MovementChallenge()
    {
        combosButton.SetActive(false);
        loopsButton.SetActive(false);
        abilitiesButton.SetActive(false);
        StartCoroutine(movementChallengeLoad());
    }

    IEnumerator movementChallengeLoad()
    {
        int playCount = PlayerPrefs.GetInt("playCount");
        PlayerPrefs.SetInt("playCount", ++playCount);
        if (PlayerPrefs.GetInt("Voice") == 1)
        {
            movementButton.GetComponent<AudioSource>().Play();
        }
        yield return new WaitForSeconds(2);
        LoadLevel("Movement1");
        //Application.LoadLevel("Movement1");
    }

    public void AbilitiesChallenge()
    {
        combosButton.SetActive(false);
        loopsButton.SetActive(false);
        movementButton.SetActive(false);
        StartCoroutine(abilitiesChallengeLoad());
    }

    IEnumerator abilitiesChallengeLoad()
    {
        if (PlayerPrefs.GetInt("Voice") == 1)
        {
            abilitiesButton.GetComponent<AudioSource>().Play();
        }
        int playCount = PlayerPrefs.GetInt("playCount");
        PlayerPrefs.SetInt("playCount", ++playCount);
        yield return new WaitForSeconds(2);
        LoadLevel("Abilities1");
        //Application.LoadLevel("Abilities1");
    }

    public void LoopChallenge()
    {
        abilitiesButton.SetActive(false);
        combosButton.SetActive(false);
        movementButton.SetActive(false);
        StartCoroutine(loopChallengeLoad());
    }

    IEnumerator loopChallengeLoad()
    {
        if (PlayerPrefs.GetInt("Voice") == 1)
        {
            loopsButton.GetComponent<AudioSource>().Play();
        }
        int playCount = PlayerPrefs.GetInt("playCount");
        PlayerPrefs.SetInt("playCount", ++playCount);
        yield return new WaitForSeconds(2);
        LoadLevel("Loops1");
        //Application.LoadLevel("Loops1");
    }

    public void ComboChallenge()
    {
        abilitiesButton.SetActive(false);
        loopsButton.SetActive(false);
        movementButton.SetActive(false);
        StartCoroutine(comboChallengeLoad());
    }

    IEnumerator comboChallengeLoad()
    {
        if (PlayerPrefs.GetInt("Voice") == 1)
        {
            combosButton.GetComponent<AudioSource>().Play();
        }
        int playCount = PlayerPrefs.GetInt("playCount");
        PlayerPrefs.SetInt("playCount", ++playCount);
        yield return new WaitForSeconds(2);
        LoadLevel("Combos1");
        //Application.LoadLevel("Combos1");
    }

    IEnumerator challengeLoad()
    {
        if (PlayerPrefs.GetInt("Voice") == 1)
        {
            challengeButton.GetComponent<AudioSource>().Play();
        }
        yield return new WaitForSeconds(1);
        challengeButton.SetActive(false);
        mainCanvas.SetActive(false);
        exitCanvas.SetActive(false);
        challengeCanvas.SetActive(true);
    }

    IEnumerator challengeLoadSTEM()
    {
        if (PlayerPrefs.GetInt("Voice") == 1)
        {
            challengeButton.GetComponent<AudioSource>().Play();
        }
        yield return new WaitForSeconds(1.0f);
        challengeButton.SetActive(false);
        mainCanvas.SetActive(false);
        exitCanvas.SetActive(false);
        challengeCanvas.SetActive(true);
    }


    public void showChallenge()
    {
        tutorialButton.SetActive(false);
        freePlayButton.SetActive(false);
        settingsButton.SetActive(false);
        exitButton.SetActive(false);
        stemDashCanvas.SetActive(false);
        AddFirstPlayerCanvas.SetActive(false);

        STEMDashOptionsBtn.SetActive(false);
        if (LoginToPortal.Instance.userIsLoggedIn)
        {
            pollingData.Instance.retrieveData("tommyTurtle");
            currentSelectedMode = gameMode.challenge;
        } else
        {
            StartCoroutine(challengeLoad());
        }
    }

    public void freePlay()
    {
        settingsButton.SetActive(false);
        challengeButton.SetActive(false);
        tutorialButton.SetActive(false);
        exitButton.SetActive(false);
        stemDashCanvas.SetActive(false);

        STEMDashOptionsBtn.SetActive(false);

        if (LoginToPortal.Instance.userIsLoggedIn)
        {
            pollingData.Instance.retrieveData("tommyTurtle");
            currentSelectedMode = gameMode.freePlay;
        }
        else
        {
            StartCoroutine(freePlayLoad());
        }
    }

    public void exit()
    {
        settingsButton.SetActive(false);
        challengeButton.SetActive(false);
        tutorialButton.SetActive(false);
        freePlayButton.SetActive(false);
        exitButton.SetActive(false);
        mainCanvas.SetActive(false);
        stemDashCanvas.SetActive(false);
        exitCanvas.SetActive(true);
        AddFirstPlayerCanvas.SetActive(false);
    }

    public void dontExitGame() {
        settingsButton.SetActive(true);
        challengeButton.SetActive(true);
        tutorialButton.SetActive(true);
        freePlayButton.SetActive(true);
        exitButton.SetActive(true);
        tutorialStoryCanvas.SetActive(false);
        stemDashCanvas.SetActive(false);
        mainCanvas.SetActive(true);
        exitCanvas.SetActive(false);
        AddFirstPlayerCanvas.SetActive(false);
    }
    public void exitGame() { Application.Quit(); }

    public void showStory()
    {
        settingsButton.SetActive(false);
        challengeButton.SetActive(false);
        STEMDashOptionsBtn.SetActive(false);
        freePlayButton.SetActive(false);
        exitButton.SetActive(false);
        exitCanvas.SetActive(false);
        stemDashCanvas.SetActive(false);
        AddFirstPlayerCanvas.SetActive(false);
        StartCoroutine(loadStory());

    }
    IEnumerator loadStory()
    {
        if (PlayerPrefs.GetInt("Voice") == 1)
        {
            tutorialButton.GetComponent<AudioSource>().Play();
        }
        yield return new WaitForSeconds(1.5f);
        tutorialStoryCanvas.SetActive(true);
        mainCanvas.SetActive(false);
        tutorialButton.SetActive(false);
    }

    IEnumerator freePlayLoad()
    {
        if (PlayerPrefs.GetInt("Voice") == 1)
        {
            freePlayButton.GetComponent<AudioSource>().Play();
        }
        int playCount = PlayerPrefs.GetInt("playCount");
        PlayerPrefs.SetInt("playCount", ++playCount);
        yield return new WaitForSeconds(1);
        LoadLevel("Main");
        //Application.LoadLevel("Main");
    }

    IEnumerator freePlayLoadSTEM()
    {
        if (PlayerPrefs.GetInt("Voice") == 1)
        {
            freePlayButton.GetComponent<AudioSource>().Play();
        }
        yield return new WaitForSeconds(1.0f);
        LoadLevel("Main");
        //Application.LoadLevel("Main");
    }

    public void tutorial()
    {
        if (!LoginToPortal.Instance.userIsLoggedIn)
        {
            int playCount = PlayerPrefs.GetInt("playCount");
            PlayerPrefs.SetInt("playCount", ++playCount);
        }
        LoadLevel("Tutorial");
        //Application.LoadLevel("Tutorial");
    }
    public void showstemDashInfo()
    {
        stemdashInfoCanvas.SetActive(true);
        mainCanvas.SetActive(false);
    }

    public IEnumerator colorChange()
    {
        if (scanSelection == 0)
        {
            tutorialButton.GetComponent<Image>().color = Color.white;
            freePlayButton.GetComponent<Image>().color = myColor;
            challengeButton.GetComponent<Image>().color = myColor;
            settingsButton.GetComponent<Image>().color = myColor;
        }
        else if (scanSelection == 1)
        {

            tutorialButton.GetComponent<Image>().color = myColor;
            freePlayButton.GetComponent<Image>().color = Color.white;
            challengeButton.GetComponent<Image>().color = myColor;
            settingsButton.GetComponent<Image>().color = myColor;
        }
        else if (scanSelection == 2)
        {
            tutorialButton.GetComponent<Image>().color = myColor;
            freePlayButton.GetComponent<Image>().color = myColor;
            challengeButton.GetComponent<Image>().color = Color.white;
            settingsButton.GetComponent<Image>().color = myColor;
        }
        else if (scanSelection == 3)
        {
            tutorialButton.GetComponent<Image>().color = myColor;
            freePlayButton.GetComponent<Image>().color = myColor;
            challengeButton.GetComponent<Image>().color = myColor;
            settingsButton.GetComponent<Image>().color = Color.white;
        }


        if (scanSelection2 == 0)
        {
            movementButton.GetComponent<Image>().color = Color.white;
            abilitiesButton.GetComponent<Image>().color = myColor;
            loopsButton.GetComponent<Image>().color = myColor;
            combosButton.GetComponent<Image>().color = myColor;
            backButton.GetComponent<Image>().color = myColor;
        }
        else if (scanSelection2 == 1)
        {
            movementButton.GetComponent<Image>().color = myColor;
            abilitiesButton.GetComponent<Image>().color = Color.white;
            loopsButton.GetComponent<Image>().color = myColor;
            combosButton.GetComponent<Image>().color = myColor;
            backButton.GetComponent<Image>().color = myColor;
        }
        else if (scanSelection2 == 2)
        {
            movementButton.GetComponent<Image>().color = myColor;
            abilitiesButton.GetComponent<Image>().color = myColor;
            loopsButton.GetComponent<Image>().color = Color.white;
            combosButton.GetComponent<Image>().color = myColor;
            backButton.GetComponent<Image>().color = myColor;
        }
        else if (scanSelection2 == 3)
        {
            movementButton.GetComponent<Image>().color = myColor;
            abilitiesButton.GetComponent<Image>().color = myColor;
            loopsButton.GetComponent<Image>().color = myColor;
            combosButton.GetComponent<Image>().color = Color.white;
            backButton.GetComponent<Image>().color = myColor;
        }
        else if (scanSelection2 == 4)
        {
            movementButton.GetComponent<Image>().color = myColor;
            abilitiesButton.GetComponent<Image>().color = myColor;
            loopsButton.GetComponent<Image>().color = myColor;
            combosButton.GetComponent<Image>().color = myColor;
            backButton.GetComponent<Image>().color = Color.white;
        }
        yield return new WaitForSeconds(PlayerPrefs.GetFloat("scanSpeed"));

        if (scanSelection == 0 || scanSelection == 1) { scanSelection += 1; } else if (scanSelection == 2) { scanSelection = 0; }
        if (scanSelection2 < 4) { scanSelection2 += 1; } else if (scanSelection2 == 4) { scanSelection2 = 0; }

        if (PlayerPrefs.GetInt("Scan") == 1)
            StartCoroutine(colorChange());
    }

    public void checkToggleStates()
    {
        if (voiceToggle.isOn) { PlayerPrefs.SetInt("Voice", 1); } else { PlayerPrefs.SetInt("Voice", 0); }
        if (musicToggle.isOn) {
            PlayerPrefs.SetInt("Music", 1);
            if (menuMusic.isPlaying)
                menuMusic.volume = 0.3f;
            else
            {
                menuMusic.Play();
                menuMusic.volume = 0.3f;
            }
        } else {
            PlayerPrefs.SetInt("Music", 0);
            menuMusic.volume = 0;
        }
        if (scanToggle.isOn)
        {
            PlayerPrefs.SetInt("Scan", 1);
            StopAllCoroutines();
            StartCoroutine(colorChange());
        } else {
            PlayerPrefs.SetInt("Scan", 0);
            tutorialButton.GetComponent<Image>().color = myColor;
            freePlayButton.GetComponent<Image>().color = myColor;
            challengeButton.GetComponent<Image>().color = myColor;
            settingsButton.GetComponent<Image>().color = myColor;
            movementButton.GetComponent<Image>().color = myColor;
            abilitiesButton.GetComponent<Image>().color = myColor;
            backButton.GetComponent<Image>().color = myColor;
            loopsButton.GetComponent<Image>().color = myColor;
        }
    }


    public void showSettings()
    {
        tutorialButton.SetActive(false);
        freePlayButton.SetActive(false);
        challengeButton.SetActive(false);
        exitButton.SetActive(false);
        stemDashCanvas.SetActive(false);

        STEMDashOptionsBtn.SetActive(false);
        AddFirstPlayerCanvas.SetActive(false);
        addingPlayerStatusCanvas.SetActive(false);

        StartCoroutine(settingsLoad());
    }


    public IEnumerator settingsLoad()
    {
        if (PlayerPrefs.GetInt("Voice") == 1)
        {
            settingsButton.GetComponent<AudioSource>().Play();
        }

        if (AddPlayerCanvas.activeInHierarchy || DeletePlayerCanvas.activeInHierarchy)
            yield return null;
        else
            yield return new WaitForSeconds(1);

        AddPlayerCanvas.SetActive(false);
        DeletePlayerCanvas.SetActive(false);
        turtleBody.SetActive(false);
        turtleTongueAndEyes.SetActive(false);
        mainCanvas.SetActive(false);
        exitCanvas.SetActive(false);
        stemDashCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
        AddFirstPlayerCanvas.SetActive(false);
        deletePlayerStatusCanvas.SetActive(false);
    }

    public void showMain()
    {

        settingsCanvas.SetActive(false);
        parentalGateCanvas.SetActive(false);
        challengeCanvas.SetActive(false);
        exitButton.SetActive(true);
        mainCanvas.SetActive(true);
        settingsButton.SetActive(true);
        tutorialButton.SetActive(true);
        freePlayButton.SetActive(true);
        challengeButton.SetActive(true);
        stemDashCanvas.SetActive(false);
        STEMDashOptionsBtn.SetActive(true);
        AddFirstPlayerCanvas.SetActive(false);
        addingPlayerStatusCanvas.SetActive(false);
        STEMDashInviteCanvas.SetActive(false);
        playTimeOverCanvas.SetActive(false);
        challengeCanvas.SetActive(false);
        stemdashInfoCanvas.SetActive(false);
        tutorialStoryCanvas.SetActive(false);

        if (!turtleBody.activeSelf && !turtleTongueAndEyes.activeSelf)
        {
            turtleBody.SetActive(true);
            turtleTongueAndEyes.SetActive(true);
        }

        checkToggleStates();
    }
    void showDeleteStatus()
    {
        deletePlayerStatusCanvas.SetActive(true);
        DeletePlayerCanvas.SetActive(false);
        deletePlayerStatusText.text = "Deleting player, please wait...";
    }

    /*STEMDash Methods*/

    public void saveSettings()
    {
        string settings = "{";
        settings += "\"gameName\": \"tommyTurtle\",";
        settings += "\"email\": \"" + SaveAndLoad.dashEmail + "\",";
        settings += "\"Voice\": \"" + PlayerPrefs.GetInt("Voice") + "\",";
        settings += "\"Music\": \"" + PlayerPrefs.GetInt("Music") + "\",";
        settings += "\"Scan\": \"" + PlayerPrefs.GetInt("Scan") + "\",";
        settings += "\"scanSpeed\": \"" + PlayerPrefs.GetFloat("scanSpeed") + "\",";
        settings += "\"fontSizeIndex\": \"" + PlayerPrefs.GetInt("fontSizeIndex") + "\"";
        settings += "}";
        SaveSettings.Instance.saveSettings(settings);
    }
    public void showSTEMDashInvite()
    {
        STEMDashInviteCanvas.SetActive(true);
        mainCanvas.SetActive(false);
        turtleBody.SetActive(false);
        turtleTongueAndEyes.SetActive(false);
    }
    void showPlayTimeOverCanvas()
    {
        playTimeOverCanvas.SetActive(true);
        mainCanvas.SetActive(false);
        turtleBody.SetActive(false);
        turtleTongueAndEyes.SetActive(false);
    }

    void controlRoutine()
    {
        //If the data was retrived succesfully
        //Should return regardless of internet connection
        if (controlHours.dataRetrieved)
        {
            Debug.Log("Made it to control routine");
            string currentPlayer = PlayerPrefs.GetString("CurrentPlayer");
            currentPlayer = currentPlayer.ToLower();
            string childEmail = currentPlayer + "_" + SaveAndLoad.dashEmail;
            controlHours.dataRetrieved = false;

            Debug.Log(childEmail);

            switch (controlHours.childTimes.Count)
            {
                case 0:                                                     //Dictionary is empty. Nothing was loaded
                    Debug.Log("Dictionary is empty");
                    if (currentSelectedMode == gameMode.challenge)
                    {
                        Debug.Log("Current selected mode is challenge");
                        StartCoroutine(challengeLoadSTEM());
                    }
                    else if (currentSelectedMode == gameMode.freePlay)
                    {
                        Debug.Log("Current selected mode is free play");
                        StartCoroutine(freePlayLoadSTEM());
                    }

                    break;
                default:                                                    //Dictionary is not empty. Loaded
                    Debug.Log("Dictionary is not empty");
                    if (controlHours.childTimes[childEmail] > 0.0003f)
                    {
                        Debug.Log("Child can play");
                        if (currentSelectedMode == gameMode.challenge)
                        {
                            Debug.Log("Current selected mode is challenge");
                            StartCoroutine(challengeLoadSTEM());
                        }
                        else if (currentSelectedMode == gameMode.freePlay)
                        {
                            Debug.Log("Current selected mode is free play");
                            StartCoroutine(freePlayLoadSTEM());
                        }
                    } else
                    {
                        Debug.Log("Child can not play");
                        showPlayTimeOverCanvas();
                    }
                    break;
            }
        }
    }

    public void deletePlayer()
    {
        showDeleteStatus();
        DeletePlayer.Instance.deleteChild(PlayerPrefs.GetString("CurrentPlayer"));
    }

    IEnumerator pauseForDeleteSuccessText()
    {
        yield return new WaitForSeconds(1.0f);
        playerList.ClearOptions();
        if (SaveAndLoad.listOfPlayers.Count > 0)
        {
            playerList.AddOptions(SaveAndLoad.listOfPlayers);
            SaveAndLoad.setCurrentPlayer(SaveAndLoad.listOfPlayers[0]);
            resetDropdownOptions();
            showSettings();
        }
        else
        {
            addNewPlayerCanvas();
        }
    }

    //Handles deleting tasks
    void deleteChildRoutine()
    {
        //Deleted successfully
        if (DeletePlayer.Instance.deleteSuccess)
        {
            DeletePlayer.Instance.deleteSuccess = false;
            deletePlayerStatusText.text = "Success!";
            StartCoroutine(pauseForDeleteSuccessText());
        }
    }

    void addNewPlayerCanvas()
    {
        AddPlayerCanvas.SetActive(false);
        DeletePlayerCanvas.SetActive(false);
        turtleBody.SetActive(false);
        turtleTongueAndEyes.SetActive(false);
        mainCanvas.SetActive(false);
        exitCanvas.SetActive(false);
        stemDashCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
        AddFirstPlayerCanvas.SetActive(true);
    }

    void initOneSignal()
    {
        OneSignal.StartInit("c21d4781-77a2-4df3-adfc-52dcfbcbcd9d")
                .InFocusDisplaying(OneSignal.OSInFocusDisplayOption.None)
                .HandleNotificationReceived(HandleNotificationReceived)
                .EndInit();
    }

    void initSTEMDash()
    {
        turtleBody = GameObject.Find("Turtle");
        turtleTongueAndEyes = GameObject.Find("Bip01");
        boxSizeGroup.OnChange += updateBoxSize;
        chatOnOffToggleGroup.OnChange += updateChatOnOff;
        setInitialBoxSize();
        setInitialOnOffToggle();
        setInitialChatTime();
        setInitialScanSpeed();
        setInitialFontSize();
        initOneSignal();

        SaveAndLoad.LoadDash();
        if (LoginToPortal.Instance.userIsLoggedIn)
        {
            LoginToPortal.Instance.justLoggedIn = false;
            TimeManager.Instance.init();
            if (SaveAndLoad.listOfPlayers.Count > 0)
            {
                playerList.ClearOptions();
                playerList.AddOptions(SaveAndLoad.listOfPlayers);
                if (PlayerPrefs.GetString("CurrentPlayer") != "")
                {
                    SaveAndLoad.setCurrentPlayer(PlayerPrefs.GetString("CurrentPlayer"));
                    resetDropdownOptions();
                } else
                {
                    Debug.Log("Called from User is logged in");
                    ChatArea.Instance.init();
                }
            } else
            {
                addNewPlayerCanvas();
            }

            STEMDashOptions.SetActive(true);
            logoutBtn.SetActive(true);
            STEMDashBtn.SetActive(false);
            string[] parentName = SaveAndLoad.dashEmail.Split('@');
            OneSignal.SendTag(SaveAndLoad.dashEmail, parentName[0]);
        } else
        {
            if (SaveAndLoad.dashEmail != "")
            {
                LoginToPortal.Instance.Login(SaveAndLoad.dashEmail, SaveAndLoad.dashPassword);
                showMain();
            } else
            {
                Debug.Log("PlayCount: " + PlayerPrefs.GetInt("playCount"));
                if (PlayerPrefs.GetInt("playCount") > 9)
                {
                    PlayerPrefs.SetInt("playCount", 0);
                    showSTEMDashInvite();
                }
                else
                    showMain();
            }

            logoutBtn.SetActive(false);
            STEMDashOptions.SetActive(false);
            STEMDashBtn.SetActive(true);
        }

        /*STEMDash Dropodown Lists*/
        playerList.onValueChanged.AddListener(delegate
        {
            OnPlayerListChanged(playerList);
        });

        chatTimesList.onValueChanged.AddListener(delegate
        {
            OnChatWaitTimeChanged(chatTimesList);
        });

        fontSizeList.onValueChanged.AddListener(delegate
        {
            OnFontSizeChanged(fontSizeList);
        });
    }

    //Called when your app is in focus and a notificaiton is recieved.
    // The name of the method can be anything as long as the signature matches.
    // Method must be static or this object should be marked as DontDestroyOnLoad
    private static void HandleNotificationReceived(OSNotification notification) {
        OSNotificationPayload payload = notification.payload;
        string message = payload.body;

        print("GameControllerExample:HandleNotificationReceived: " + message);
        print("displayType: " + notification.displayType);
    }

    void showAddingChildStatus()
    {
        currentCanvas.Clear();
        addPlayerStatusText.text = "Adding new player, please wait...";
        if (AddFirstPlayerCanvas.activeInHierarchy)
        {
            currentCanvas.Push(AddFirstPlayerCanvas);
            AddFirstPlayerCanvas.SetActive(false);
        }
        else if (AddPlayerCanvas.activeInHierarchy)
        {
            currentCanvas.Push(AddPlayerCanvas);
            AddPlayerCanvas.SetActive(false);
        }
        addingPlayerStatusCanvas.SetActive(true);
    }

    void resetDropdownOptions()
    {
        playerList.ClearOptions();
        playerList.AddOptions(SaveAndLoad.listOfPlayers);
        for (int i = 0; i < SaveAndLoad.listOfPlayers.Count; i++)
        {
            if (playerList.options[i].text == PlayerPrefs.GetString("CurrentPlayer"))
            {
                playerList.value = i;
                break;
            }
        }
        Debug.Log("Called from reset dropdown");
        ChatArea.Instance.close();
        ChatArea.Instance.init();
    }

    void handleReceivedMessages()
    {
        if (LoginToPortal.Instance.userIsLoggedIn && SaveAndLoad.listOfPlayers.Count > 0)
        {
            if (ClientGlobals.messageBuffer.ContainsKey(PlayerPrefs.GetString("CurrentPlayer")))
            {
                Debug.Log("MessageBuffer Count: " + ClientGlobals.messageBuffer[PlayerPrefs.GetString("CurrentPlayer")].Count);
            }
            //If the chat feature is on, display
            if (PlayerPrefs.GetInt("isOn") == 1)
            {
                if (ClientGlobals.messageBuffer.ContainsKey(PlayerPrefs.GetString("CurrentPlayer")))
                {
                    while (ClientGlobals.messageBuffer[PlayerPrefs.GetString("CurrentPlayer")].Count > 0)
                    {
                        ClientGlobals.messageQueue.Enqueue(ClientGlobals.messageBuffer[PlayerPrefs.GetString("CurrentPlayer")].Dequeue());
                    }
                }
                while (ClientGlobals.messageQueue.Count > 0)
                {
                    Debug.Log("Received Messages");
                    GameObject messageContainer = Instantiate(messageContainerPrefab);
                    TMP_Text message = messageContainer.GetComponentInChildren<TMP_Text>();
                    message.text = ClientGlobals.messageQueue.Dequeue();
                    ClientGlobals.messageBuffer[PlayerPrefs.GetString("CurrentPlayer")].Enqueue(message.text);
                    messageContainer.SetActive(false);
                    messages.Enqueue(messageContainer);
                    if (ClientGlobals.messageQueue.Count == 0)
                        StartCoroutine(showMessages());
                }
            }
        }
    }

    IEnumerator showMessages()
    {
        ClientGlobals.chatTimer = PlayerPrefs.GetFloat("chatTime");
        displayingMessages = true;
        while (messages.Count > 0)
        {
            GameObject message = messages.Dequeue();
            ClientGlobals.messageBuffer[PlayerPrefs.GetString("CurrentPlayer")].Dequeue();
            RawImage container = message.GetComponentInChildren<RawImage>();
            MoveChatBox chatBoxSize = message.GetComponentInChildren<MoveChatBox>();
            message.SetActive(true);
            chatBoxSize.MoveDown = true;
            while (ClientGlobals.chatTimer >= 0.0f)
            {
                ClientGlobals.chatTimer -= Time.deltaTime;
                yield return null;
            }
            //yield return new WaitForSeconds(7.0f);
            chatBoxSize.MoveUp = true;
            yield return new WaitForSeconds(1.0f);
            if (message != null)
                Destroy(message);

            if (messages.Count > 0)
                ClientGlobals.chatTimer = PlayerPrefs.GetFloat("chatTime");
        }
        displayingMessages = false;
    }

    public void addChild()
    {

        if (AddFirstPlayerCanvas.activeInHierarchy)
            AddChild.Instance.AddUserChild(firstChildBeingAdded.text);
        else if (AddPlayerCanvas.activeInHierarchy)
            AddChild.Instance.AddUserChild(childBeingAdded.text);
        showAddingChildStatus();
    }

    IEnumerator pauseForSuccessText()
    {
        yield return new WaitForSeconds(1.0f);
        if (currentCanvas.Count > 0)
            currentCanvas.Pop().SetActive(true);

        resetDropdownOptions();
        if (AddFirstPlayerCanvas.activeInHierarchy)
            showMain();
        else if (AddPlayerCanvas.activeInHierarchy)
            showSettings();
    }

    void saveSettingsRoutine()
    {
        if(SaveSettings.Instance.saveWentOkay)
        {
            saveFeedBackTxt.text = "Saved";
            saveSettingsTime += Time.deltaTime;
            if(saveSettingsTime >= 3.0f)
            {
                SaveSettings.Instance.saveWentOkay = false;
                saveSettingsTime = 0.0f;
                saveFeedBackTxt.text = "";
            }
        }

        if(SaveSettings.Instance.saveWentBad)
        {
            saveFeedBackTxt.text = "Not Saved";
            saveSettingsTime += Time.deltaTime;
            if(saveSettingsTime >= 3.0f)
            {
                SaveSettings.Instance.saveWentBad = false;
                saveSettingsTime = 0.0f;
                saveFeedBackTxt.text = "";
            }
        }


    }

    //Add child tasks
    void addChildRoutine()
    {
        //Add Child Routines
        if (AddChild.Instance.finishedAddingChild)
        {
            addPlayerStatusText.text = "Success!";
            AddChild.Instance.finishedAddingChild = false;
            StartCoroutine(pauseForSuccessText());
        }

        //Add child error messages 
        if (AddChild.Instance.emailExists)
        {
            if (currentCanvas.Count > 0)
                currentCanvas.Pop().SetActive(true);

            if (AddFirstPlayerCanvas.activeInHierarchy)
                addFirstChildUserExistsError.text = AddChild.Instance.playerExistsMessage;
            else if (AddPlayerCanvas.activeInHierarchy)
                addChildUserExistsError.text = AddChild.Instance.playerExistsMessage;
        } else
        {
            if (AddFirstPlayerCanvas.activeInHierarchy)
                addFirstChildUserExistsError.text = "";
            else if (AddPlayerCanvas.activeInHierarchy)
                addChildUserExistsError.text = "";
        }

        //Duplicate name
        if (AddChild.Instance.duplicateName)
        {
            if (currentCanvas.Count > 0)
                currentCanvas.Pop().SetActive(true);

            if (AddFirstPlayerCanvas.activeInHierarchy)
                addFirstChildDuplicateError.text = AddChild.Instance.dupeNameMessage;
            else if (AddPlayerCanvas.activeInHierarchy)
                addChildDuplicateError.text = AddChild.Instance.dupeNameMessage;
        }
        else
        {
            if (AddFirstPlayerCanvas.activeInHierarchy)
                addFirstChildDuplicateError.text = "";
            else if (AddPlayerCanvas.activeInHierarchy)
                addChildDuplicateError.text = "";
        }

        //Does not contain a letter 
        if (AddChild.Instance.notContainsLetter)
        {
            if (currentCanvas.Count > 0)
                currentCanvas.Pop().SetActive(true);

            if (AddFirstPlayerCanvas.activeInHierarchy)
                addFirstChildNoLetterError.text = AddChild.Instance.notLetterMessage;
            else if (AddPlayerCanvas.activeInHierarchy)
                addChildNoLetterError.text = AddChild.Instance.notLetterMessage;
        }
        else
        {
            if (AddFirstPlayerCanvas.activeInHierarchy)
                addFirstChildNoLetterError.text = "";
            else if (AddPlayerCanvas.activeInHierarchy)
                addChildNoLetterError.text = "";
        }

        //List count exceeded
        if (AddChild.Instance.listCountExceeded)
        {
            if (currentCanvas.Count > 0)
                currentCanvas.Pop().SetActive(true);

            if (AddFirstPlayerCanvas.activeInHierarchy)
                addFirstChildMaxCountError.text = AddChild.Instance.listCountExeededMessage;
            else if (AddPlayerCanvas.activeInHierarchy)
                addChildMaxCountError.text = AddChild.Instance.listCountExeededMessage;
        }
        else
        {
            if (AddFirstPlayerCanvas.activeInHierarchy)
                addFirstChildMaxCountError.text = "";
            else if (AddPlayerCanvas.activeInHierarchy)
                addChildMaxCountError.text = "";
        }
    }

    public void showSTEMDashOptions()
    {
        tutorialButton.SetActive(false);
        freePlayButton.SetActive(false);
        challengeButton.SetActive(false);
        settingsButton.SetActive(false);
        exitButton.SetActive(false);

        ParentalGate();
        StartCoroutine(parentalGateCanvasLoad());
    }

    IEnumerator parentalGateCanvasLoad()
    {
        if (chattingSettingsCanvas.activeInHierarchy)
        {
            yield return null;
            showSTEMDash();
        }
        else
        {
            yield return new WaitForSeconds(1.0f);
            mainCanvas.SetActive(false);
            chattingSettingsCanvas.SetActive(false);
            parentalGateCanvas.SetActive(true);
            if (PlayerPrefs.GetInt("Voice") == 1)
            {
                parentalGateCanvas.GetComponent<AudioSource>().Play();
                movementButton.GetComponent<AudioSource>().Play();
            }
        }
    }
    void showSTEMDash()
    {
        mainCanvas.SetActive(false);
        chattingSettingsCanvas.SetActive(false);
        parentalGateCanvas.SetActive(false);
        stemDashCanvas.SetActive(true);
    }

    public void showSTEMDashLogin()
    {
        STEMDashController.CurrentMenu = STEMDashController.STEMDashMenu.Login;
        SceneManager.LoadScene("loginSignupForms");
    }

    public void showSTEMDashSignup()
    {
        STEMDashController.CurrentMenu = STEMDashController.STEMDashMenu.Signup;
        SceneManager.LoadScene("loginSignupForms");
    }

    public void showChatSettings()
    {
        chattingSettingsCanvas.SetActive(true);
        stemDashCanvas.SetActive(false);
    }

    public void showAddPlayerCanvas()
    {
        AddPlayerCanvas.SetActive(true);
        DeletePlayerCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
        stemDashCanvas.SetActive(false);
    }

    public void showDeletePlayerCanvas()
    {
        AddPlayerCanvas.SetActive(false);
        DeletePlayerCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
        stemDashCanvas.SetActive(false);
        deletePlayerText.text = "Are you sure you want to delete " + PlayerPrefs.GetString("CurrentPlayer") + "?";
    }

    public void openWebPortal()
    {
        Application.OpenURL("https://stemdash.com"); 
    }

    public void openCompanionPage()
    {
        Application.OpenURL("http://www.codingwithtommy.com"); 
    }

    void checkLoginStatus()
    {
        /*
        Handle if the User just logged in
        */
        if (LoginToPortal.Instance.justLoggedIn)
        {
            string [] parentName = SaveAndLoad.dashEmail.Split('@');
            OneSignal.SendTag(SaveAndLoad.dashEmail, parentName[0]);
            if (SaveAndLoad.listOfPlayers.Count > 0)
            {
                Debug.Log("Just logged in called");
                playerList.ClearOptions();
                playerList.AddOptions(SaveAndLoad.listOfPlayers);
                if(PlayerPrefs.GetString("CurrentPlayer") != "")
                {
                    SaveAndLoad.setCurrentPlayer(PlayerPrefs.GetString("CurrentPlayer"));
                    resetDropdownOptions();
                } else 
                {
                    ChatArea.Instance.init();
                }
            } else
            {
                addNewPlayerCanvas();
            }
            TimeManager.Instance.init();

            STEMDashOptions.SetActive(true);
            LogOut = logoutBtn.GetComponent<Button>();
            LogOut.onClick.AddListener(logoutOfSTEMDash);
            logoutBtn.SetActive(true);
            STEMDashBtn.SetActive(false);
            LoginToPortal.Instance.justLoggedIn = false;
        }
    }

    /*Event Listeners for Dropdown Lists*/
    void OnPlayerListChanged(Dropdown pl)
    {
        SaveAndLoad.setCurrentPlayer(pl.options[pl.value].text);
        Debug.Log("Called from on player list changed");
        ChatArea.Instance.close();
        ChatArea.Instance.init();
    }

    void OnChatWaitTimeChanged(Dropdown cw)
    {
        string[] chatSecond = cw.options[cw.value].text.Split(' ');
        PlayerPrefs.SetFloat("chatTime", float.Parse(chatSecond[0]));
        PlayerPrefs.SetString("chatTimes", cw.options[cw.value].text);
    }

    void OnFontSizeChanged(Dropdown fl)
    {
        switch (fl.value) {
            case 0:
                PlayerPrefs.SetInt("fontSize", 25);
                PlayerPrefs.SetInt("fontSizeIndex", 0);
                break;
            case 1:
                PlayerPrefs.SetInt("fontSize", 30);
                PlayerPrefs.SetInt("fontSizeIndex", 1);
                break;
            case 2:
                PlayerPrefs.SetInt("fontSize", 35);
                PlayerPrefs.SetInt("fontSizeIndex", 2);
                break;
        }
    }


    public void logoutOfSTEMDash()
    {
        SaveAndLoad.Logout(); 
        logoutBtn.SetActive(false);
        STEMDashBtn.SetActive(true);
        STEMDashOptions.SetActive(false);
    }

     void setPopupDays()
    {
        //Calculate what day of the week is 7 days from this instant.

        if (!(PlayerPrefs.HasKey("popupFlag")))
        {
            System.DateTime today = System.DateTime.Now;
            System.TimeSpan duration = new System.TimeSpan(7, 0, 0, 0);
            System.DateTime answer = today.Add(duration);
            string futureDate = answer.ToString();
            PlayerPrefs.SetString("popupDate", futureDate);
            PlayerPrefs.SetInt("popupFlag", 1);
        } else
        {
            System.DateTime today = System.DateTime.Now;
            System.TimeSpan duration = new System.TimeSpan(30, 0, 0, 0);
            System.DateTime answer = today.Add(duration);
            string futureDate = answer.ToString();
            PlayerPrefs.SetString("popupDate", futureDate);
        }
        showedPopup = true;
    }

    void setInitialChatTime()
    {
        int index = 0;
        if (PlayerPrefs.GetString("chatTimes") != "")
        {
            for(int i = 0; i < chatTimesList.options.Count; i++)
            {
                if (chatTimesList.options[i].text == PlayerPrefs.GetString("chatTimes"))
                {
                    chatTimesList.value = i;
                    index = i;
                    break;
                }
            }
            string[] chatSecond = chatTimesList.options[index].text.Split(' ');
            PlayerPrefs.SetFloat("chatTime", float.Parse(chatSecond[0]));
            PlayerPrefs.SetString("chatTimes", chatTimesList.options[index].text);
        }
        else
        {
            PlayerPrefs.SetString("chatTimes", chatTimesList.options[0].text);
            string[] chatSecond = chatTimesList.options[0].text.Split(' ');
            PlayerPrefs.SetFloat("chatTime", float.Parse(chatSecond[0]));
        }
    }
    void setInitialScanSpeed()
    {
        float ss = PlayerPrefs.GetFloat("scanSpeed");
        if(ss != 0)
        {
            scanSpeed = ss;
            scanSpeedTxt.text = scanSpeed.ToString("0.00") + " Seconds";
        } else
        {
            scanSpeed = 1.00f;
            PlayerPrefs.SetFloat("scanSpeed", scanSpeed);
            scanSpeedTxt.text = scanSpeed.ToString("0.00") + " Seconds";
        }
    }
    void setInitialFontSize()
    {
        int fontSizeIndex = PlayerPrefs.GetInt("fontSizeIndex");
        switch(fontSizeIndex)
        {
            case 0:
                fontSizeList.value = 0;
                PlayerPrefs.SetInt("fontSize", 25);
                break;
            case 1:
                fontSizeList.value = 1;
                PlayerPrefs.SetInt("fontSize", 30);
                break;
            case 2:
                fontSizeList.value = 2;
                PlayerPrefs.SetInt("fontSize", 35);
                break;
            default:
                fontSizeList.value = 0;
                PlayerPrefs.SetInt("fontSize", 25);
                break;
        }
    }

    void setInitialBoxSize()
    {
        if (PlayerPrefs.GetString("boxSize") != "")
        {
            Toggle[] chatBoxSize = boxSizeGroup.GetComponentsInChildren<Toggle>();
            switch (PlayerPrefs.GetString("boxSize"))
            {
                case "small":
                    chatBoxSize[0].isOn = true;
                    chatBoxSize[1].isOn = false;
                    chatBoxSize[2].isOn = false;
                    break;
                case "medium":
                    chatBoxSize[0].isOn = false;
                    chatBoxSize[1].isOn = true;
                    chatBoxSize[2].isOn = false;
                    break;
                case "large":
                    chatBoxSize[0].isOn = false;
                    chatBoxSize[1].isOn = false;
                    chatBoxSize[2].isOn = true;
                    break;
            }
        }
        else
        {
            PlayerPrefs.SetString("boxSize", "small");
        }
    }

    void setInitialOnOffToggle()
    {
        Toggle[] chatOnOff = chatOnOffToggleGroup.GetComponentsInChildren<Toggle>();
        if (PlayerPrefs.HasKey("isOn"))
        {
            switch (PlayerPrefs.GetInt("isOn"))
            {
                case 0:
                    chatOnOff[0].isOn = true;
                    chatOnOff[1].isOn = false;
                    break;
                case 1:
                    chatOnOff[0].isOn = false;
                    chatOnOff[1].isOn = true;
                    break;
            }
        }
        else
        {
            PlayerPrefs.SetInt("isOn", 1);
            chatOnOff[1].isOn = true;
        }
    }

    void updateBoxSize(Toggle currentToggle)
    {
        switch (currentToggle.name)
        {
            case "SmallToggle":
                Debug.Log("Small");
                PlayerPrefs.SetString("boxSize", "small");
                break;
            case "MediumToggle":
                Debug.Log("Medium");
                PlayerPrefs.SetString("boxSize", "medium");
                break;
            case "LargeToggle":
                Debug.Log("Large");
                PlayerPrefs.SetString("boxSize", "large");
                break;
        }
    }

    void updateChatOnOff(Toggle currentToggle)
    {
        switch (currentToggle.name)
        {
            case "chatOnToggle":
                Debug.Log("Chat is on");
                PlayerPrefs.SetInt("isOn", 1);
                break;
            case "chatOffToggle":
                Debug.Log("Chat is off");
                PlayerPrefs.SetInt("isOn", 0);
                break;
        }
    }

    public void openStemDashApp()
    {
            #if UNITY_IOS
                    Application.OpenURL("https://itunes.apple.com/us/app/stemdash-portal/id1247870271");
            #elif UNITY_ANDROID
                    Application.OpenURL("https://play.google.com/store/apps/details?id=com.zyrobotics.stemdash");
            #endif
    }
}
