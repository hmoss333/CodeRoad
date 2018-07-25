using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    Test story;
    int scanCount;

    public GameObject player;
    GameObject moveBackground;
    public Text move;
    public Text showMoves;
    List<string> movement = new List<string>();
    List<string> movementListCreation = new List<string>();
    string size;

    bool growthSwitch;
    bool shrinkSwitch;

    bool facingRight;
    bool turned;

    bool spinOrRoll;

    bool jumpSwitch;
    bool jumpReset;

    public static int index;
    int countTillLineSkip;

    Vector3 resetAfterSpinOrRoll;
    Vector3 resetAfterJump;

    int saveStartLocation;
    int countLoops;
    public Text howManyTimesToLoop;
    float loopsFromSlider;
    public Slider myLoops;

    string startFormat;
    string endFormat;
    int movementLengthCollection;
    bool loopState;

    public AudioClip[] mySounds;
    public AudioClip[] winSound;

    public Button[] myButtons;
    int buttonCount;
    bool buttonChosen;
    bool playing;

    int tutorialCount;
    public Text help;
    public GameObject canvas;
    public GameObject winCanvas;
    public GameObject tutorialCanvas;
    public GameObject tryAgainCanvas;
    public GameObject background;

    public GameObject homeButton;

    Light directionalLight;

    private bool key3Press = false;
    private bool key2Press = false;
    private bool key1Press = false;
    private bool keyspacePress = false;
    private bool keyenterPress = false;

    private bool objectApp = false;

    private Event e;

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
		
	}
#endif

    // Use this for initialization
    void Start()
    {
#if UNITY_IOS
		iCadeInput.Activate(true);
		
		//Register some callbacks
		iCadeInput.AddICadeEventCallback(iCadeStateCallback);
		iCadeInput.AddICadeButtonUpCallback(iCadeButtonUpCallback);
		iCadeInput.AddICadeButtonDownCallback(iCadeButtonDownCallback);
#endif

        playing = false;
        moveBackground = GameObject.Find("MoveBackground");
        switch(PlayerPrefs.GetInt("fontSizeIndex"))
        {
            case 0:
                moveBackground.transform.localScale = new Vector2(1.0f, 1.0f);
                break;
            case 1:
                moveBackground.transform.localScale = new Vector2(1.0f, 1.2f);
                break;
            case 2:
                moveBackground.transform.localScale = new Vector2(1.0f, 1.5f);
                break;
        }
        showMoves.fontSize = (int)(25 * PlayerPrefs.GetFloat("printSize")) + 20;//25;// PlayerPrefs.GetInt("fontSize");
        help.fontSize = (int)(27 * PlayerPrefs.GetFloat("printSize")) + 23;//25;// PlayerPrefs.GetInt("fontSize")-5;
        tutorialCount = 0;

        loopState = false;
        loopsFromSlider = 2;
        howManyTimesToLoop.text = "Times To Loop : " + loopsFromSlider;
        countLoops = 0;
        saveStartLocation = -1;
        countTillLineSkip = 0;
        growthSwitch = true;
        shrinkSwitch = true;
        buttonChosen = false;
        scanCount = 0;

        turned = false;
        facingRight = true;

        spinOrRoll = false;

        jumpSwitch = true;
        jumpReset = false;

        startFormat = "<b><color=#00ff00ff>";
        endFormat = "</color></b>";
        movementLengthCollection = 0;

        if (!MiniGame.isMainMenuGame)
            story = GameObject.FindObjectOfType<Test>();
        directionalLight = GameObject.FindObjectOfType<Light>();

        buttonCount = 0;
        //playSound(15);

        if (!MiniGame.isMainMenuGame)
        {
            //launch tutorial on/off screen to set the buttonFlash
            homeButton.SetActive(false);
            canvas.SetActive(false);
            tutorialCanvas.SetActive(true);
        }
        else
        {
            GetComponent<AudioListener>().enabled = true;
            homeButton.SetActive(true);
            StartCoroutine(buttonFlash());
            playSound(15);
        }
    }

    IEnumerator scanner()
    {
        if (scanCount == 0) { buttonCount = 6; }
        if (scanCount == 1) { buttonCount = 7; }
        else if (scanCount == 2) { buttonCount = 10; }
        else if (scanCount == 3) { buttonCount = 11; }
        else if (scanCount == 4) { buttonCount = 12; }

        if (buttonCount >= 10)
        {
            myButtons[buttonCount].GetComponent<Image>().color = new Color(0.258f, 0.941f, 0.090f, 1);
            yield return new WaitForSeconds(PlayerPrefs.GetFloat("scanSpeed"));
            myButtons[buttonCount].GetComponent<Image>().color = Color.white;
        }
        else
        {
            myButtons[buttonCount].GetComponent<Image>().color = Color.white;
            yield return new WaitForSeconds(PlayerPrefs.GetFloat("scanSpeed"));
            myButtons[buttonCount].GetComponent<Image>().color = new Color(0.549f, 0.776f, 0.251f, 1);
        }

        scanCount++;

        if (scanCount > 5) { scanCount = 0; }
        while (playing)
            yield return null;
        StartCoroutine(scanner());
    }

    void checkScanPosition()
    {
        if (buttonCount == 0) { addGrow(); }
        else if (buttonCount == 1) { addShrink(); }
        else if (buttonCount == 2) { addTurn(); }
        else if (buttonCount == 3) { addSpin(); }
        else if (buttonCount == 4) { addJump(); }
        else if (buttonCount == 5) { addSing(); }
        else if (buttonCount == 6) { addWalkForward(); }
        else if (buttonCount == 7) { addWalkBackward(); }
        else if (buttonCount == 8) { startLoop(); }
        else if (buttonCount == 9) { endLoop(); }
        else if (buttonCount == 10) { play(); }
        else if (buttonCount == 11) { clearList(); }
        else if (buttonCount == 12) { mainMenu(); } //erase(); }
        else if (buttonCount == 13) { mainMenu(); }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1") == true)
        {
            key1Press = true;
            objectApp = true;
        }
        if (Input.GetKeyDown("2") == true)
        {
            key2Press = true;
            objectApp = true;
        }
        if (Input.GetKeyDown("3") == true)
        {
            key3Press = true;
            objectApp = true;
        }
        if (Input.GetKeyDown("space") == true)
        {
            keyspacePress = true;
            objectApp = true;
        }
        if (e != null)
        {
            if (e.keyCode.ToString() == "10" && e.type == EventType.keyDown)
            {
                keyenterPress = true;
                objectApp = true;
            }
        }

        //Debug.Log(tutorialCount);
        if (key1Press || key2Press || key3Press || keyspacePress || keyenterPress || objectApp) //Input.anyKeyDown)
        {
            //if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) return;

            if (winCanvas.activeSelf) { mainMenu(); }
            else if (tutorialCanvas.activeSelf) { TutorialOn(); }
            else if (tryAgainCanvas.activeSelf) { clearList(); }
            else if ((PlayerPrefs.GetInt("Scan") == 1 || MiniGame.tutorialMode) || MiniGame.isMainMenuGame)// && !playing)
            {
                checkScanPosition();
            }

            key1Press = false;
            key2Press = false;
            key3Press = false;
            keyspacePress = false;
            keyenterPress = false;
            objectApp = false;
        }


        if (move.text.Contains("Forward"))
        {
            if (facingRight)
            {
                if (player.transform.position.x < 6.7)
                {
                    player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(player.transform.position.x + 2, player.transform.position.y, 0), Time.deltaTime * 1);
                }
            }
            else
            {
                if (player.transform.position.x > -7.4)
                {
                    player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(player.transform.position.x - 2, player.transform.position.y, 0), Time.deltaTime * 1);
                }
            }
        }

        if (move.text.Contains("Backward"))
        {
            if (facingRight)
            {
                if (player.transform.position.x > -7.4)
                {
                    player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(player.transform.position.x - 2, player.transform.position.y, 0), Time.deltaTime * 1);
                }
            }
            else
            {
                if (player.transform.position.x < 6.7)
                {
                    player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(player.transform.position.x + 2, player.transform.position.y, 0), Time.deltaTime * 1);
                }
            }
        }


        if (move.text.Contains("Spin")) { spinOrRoll = true; player.transform.Rotate(0, Time.deltaTime * 370, 0); }

        if (move.text.Contains("Grow") && growthSwitch)
        {
            if (player.transform.localScale.x < 3)
            {
                player.transform.localScale = new Vector3(player.transform.localScale.x + .5f, player.transform.localScale.y + .5f, player.transform.localScale.z + .5f);
            }
            growthSwitch = false;
        }

        if (move.text.Contains("Shrink") && shrinkSwitch)
        {
            if (player.transform.localScale.x > .5f)
            {
                player.transform.localScale = new Vector3(player.transform.localScale.x - .5f, player.transform.localScale.y - .5f, player.transform.localScale.z - .5f);
            }
            shrinkSwitch = false;
        }

        if (move.text.Contains("Jump"))
        {
            if (jumpSwitch)
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 2, 0), Time.deltaTime * 4);
            }
            else
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(player.transform.position.x, player.transform.position.y - 2, 0), Time.deltaTime * 4);
            }
        }

        if (move.text.Contains("Turn"))
        {
            turned = true;
            player.transform.Rotate(0, Time.deltaTime * 180, 0);
        }

        if (SceneManager.GetSceneByName("LoadingScreen").isLoaded)
            directionalLight.gameObject.SetActive(false);
    }

    public void addSpin() {
        movement.Add("Spin");
        showMoves.text = showMoves.text + "Spin...";
        lineSkip(4); playSound(11); 
        if (tutorialCount == 8 || tutorialCount == 14) { tutorialCount++; } 
    }
    public void addGrow() { movement.Add("Grow"); showMoves.text = showMoves.text + "Grow..."; lineSkip(4); playSound(5); /*if (tutorialCount == 8) { tutorialCount++; }*/ }
    public void addShrink() { movement.Add("Shrink"); showMoves.text = showMoves.text + "Shrink..."; lineSkip(6); playSound(9); /*if (tutorialCount == 8) { tutorialCount++; }*/ }
    public void addTurn() { movement.Add("Turn"); showMoves.text = showMoves.text + "Turn..."; lineSkip(4); playSound(13); /*if (tutorialCount == 8) { tutorialCount++; }*/ }

    public void addJump()
    {
        movement.Add("Jump");
        showMoves.text = showMoves.text + "Jump..."; lineSkip(4); playSound(6);
        if (tutorialCount == 7 || tutorialCount == 13) //8)
         {
            //showMoves.text = showMoves.text + "Jump..."; lineSkip(4); playSound(6);
            tutorialCount++; 
         }
     }

    public void addWalkForward()
    {
        movement.Add("Forward");
        showMoves.text = ""; showMoves.text = showMoves.text + "Forward..."; lineSkip(7); playSound(4);
        if (tutorialCount == 0 || tutorialCount == 3 || tutorialCount == 12)
        {
            tutorialCount++;
        }
    }
    public void addWalkBackward()
    {
        movement.Add("Backward");
        showMoves.text = showMoves.text + "Backward..."; lineSkip(8); playSound(0);
        if (MiniGame.isMainMenuGame && (tutorialCount == 4 || tutorialCount == 15))
        {
            //showMoves.text = showMoves.text + "Backward..."; lineSkip(8); playSound(0);
            tutorialCount++;
        }
    }

    public void addSing() { movement.Add("Sing"); showMoves.text = showMoves.text + "Sing..."; lineSkip(4); playSound(10); /*if (tutorialCount == 8) { tutorialCount++; }*/ }

    public void startLoop()
    {
        if (!loopState)
        {
            movement.Add("Begin Loop");
            if (tutorialCount == 11) //7)
            {
                showMoves.text = "";
                showMoves.text = showMoves.text + "Begin Loop..."; lineSkip(10);
                loopState = true;
                playSound(1);
                tutorialCount++;
            }
        }              
    }
    public void endLoop()
    {
        if (loopState)
        {
            //if (tutorialCount == 9)
            //{
                //showMoves.text = "";
                movement.Add("End Loop"); showMoves.text = showMoves.text + "End Loop..."; lineSkip(8);
                loopState = false;
                playSound(3);

                tutorialCount++;
            //}
        }
    }

    void lineSkip(int counter)
    {
        countTillLineSkip += counter;
        if (countTillLineSkip >= 60)
        {
            showMoves.text = showMoves.text + "\n";
            countTillLineSkip = 0;
        }
    }

    public void erase()
    {
        if (movement.Count >= 1)
        {
            playSound(14);
            movement.RemoveAt(movement.Count - 1);

            showMoves.text = "";
            for (int i = 0; i < movement.Count; i++)
            {
                showMoves.text += movement[i] + "...";
            }

            if (tutorialCount == 13) { tutorialCount++; }
        }            
    }

    public void clearList()
    {
        if (!MiniGame.isMainMenuGame)
        {
            canvas.SetActive(true);
            tryAgainCanvas.SetActive(false);
            tutorialCount = 0;
        }

        playing = false;
        playSound(2);
        movementLengthCollection = 0;
        movement.Clear();
        move.text = "List Of Moves Cleared";
        showMoves.text = "";
        //player.GetComponent<Animation>().Play("Idle");
        player.transform.localScale = new Vector3(2, 2, 2);
        player.transform.rotation = Quaternion.Euler(0, 90, 0);
        player.transform.position = new Vector3(-2.95f, -3.72f, 0f);

        if (tutorialCount == 2)
        {
           playSound(17);
           help.text = "Tap <b><color=yellow>Forward</color></b> and then <b><color=yellow>Backward</color></b> \nto make Tommy walk around.";
           tutorialCount++;
        }

        if (tutorialCount == 6)
        {
            playSound(18);
            help.text = "Tap <b><color=yellow>Jump</color></b>, <b><color=yellow>Spin</color></b>, then <b><color=yellow>Play</color></b>.\nTommy loves this game. ";
                //"Tap <b><color=yellow>Loop</color></b>, <b><color=yellow>Jump</color></b>, then <b><color=yellow>Play</color></b>.\nTommy moves many times over and over again. ";
            tutorialCount++;
        }

        if (tutorialCount == 10)
        {
            playSound(19);
            help.text = "Tap <b><color=yellow>Loop</color></b>, <b><color=yellow>Forward</color></b>, <b><color=yellow>Jump</color></b>, <b><color=yellow>Spin</color></b>, <b><color=yellow>Backwards</color></b>, then <b><color=yellow>Play</color></b>.\nTommy moves many times over and over again. ";
            tutorialCount++;
        }

    }
    public void play()
    {
        if (!playing)
        {
            playing = true;
            StartCoroutine(playStart());
        }
    }

    public IEnumerator playStart()
    {
        playSound(8);
        buttonCount = 10;
        yield return new WaitForSeconds(1);
        facingRight = true;
        if (!loopState)
        {
            movementLengthCollection = 0;
            player.transform.localScale = new Vector3(2, 2, 2);
            player.transform.rotation = Quaternion.Euler(0, 90, 0);
            player.transform.position = new Vector3(-2.64f, -3.72f, 0.28f);
            StartCoroutine(playingMovement());
        }
        else {
            //move.text = "Must Close All Loops To Play";
            endLoop();
            movementLengthCollection = 0;
            player.transform.localScale = new Vector3(2, 2, 2);
            player.transform.rotation = Quaternion.Euler(0, 90, 0);
            player.transform.position = new Vector3(-2.64f, -3.72f, 0.28f);
            StartCoroutine(playingMovement());
        }

        if (MiniGame.isMainMenuGame && (tutorialCount == 1 || tutorialCount == 5 || tutorialCount == 9 || tutorialCount == 16)) { tutorialCount++; }

    }

    public void slider()
    {
        loopsFromSlider = myLoops.value;
        howManyTimesToLoop.text = "Times To Loop : " + loopsFromSlider;
    }

    void insertFormat(int i)
    {
        for (int h = 0; h < movement.Count; h++)
        {
            if (movement[h].Contains(startFormat))
            {
                if (movement[h].Contains("Right"))
                {
                    movement[h] = movement[h].Substring(startFormat.Length, 5);
                }
                else if (movement[h].Contains("Left") || movement[h].Contains("Turn") || movement[h].Contains("Spin") || movement[h].Contains("Jump") || movement[h].Contains("Grow") || movement[h].Contains("Sing"))
                {
                    movement[h] = movement[h].Substring(startFormat.Length, 4);
                }
                else if (movement[h].Contains("Shrink"))
                {
                    movement[h] = movement[h].Substring(startFormat.Length, 6);
                }
                else if (movement[h].Contains("Begin Loop"))
                {
                    movement[h] = movement[h].Substring(startFormat.Length, 10);
                }
                else if (movement[h].Contains("End Loop"))
                {
                    movement[h] = movement[h].Substring(startFormat.Length, 8);
                }
                else if (movement[h].Contains("Forward"))
                {
                    movement[h] = movement[h].Substring(startFormat.Length, 7);
                }
                else if (movement[h].Contains("Backward"))
                {
                    movement[h] = movement[h].Substring(startFormat.Length, 8);
                }
            }
        }

        showMoves.text = "";

        movement[i] = (startFormat + movement[i] + endFormat);

        for (int j = 0; j < movement.Count; j++)
        {
            showMoves.text += movement[j] + "...";
        }
    }

    void playMoveName(string move)
    {
        if (PlayerPrefs.GetInt("voice") == 0)
        {
            if (move.Contains("Grow")) { GetComponent<AudioSource>().clip = mySounds[5]; }
            if (move.Contains("Spin")) { GetComponent<AudioSource>().clip = mySounds[11]; }
            if (move.Contains("Turn")) { GetComponent<AudioSource>().clip = mySounds[13]; }
            if (move.Contains("Jump")) { GetComponent<AudioSource>().clip = mySounds[6]; }
            if (move.Contains("Sing")) { GetComponent<AudioSource>().clip = mySounds[10]; }
            if (move.Contains("Shrink")) { GetComponent<AudioSource>().clip = mySounds[9]; }
            if (move.Contains("Forward")) { GetComponent<AudioSource>().clip = mySounds[4]; }
            if (move.Contains("Backward")) { GetComponent<AudioSource>().clip = mySounds[0]; }
            if (move.Contains("Begin")) { GetComponent<AudioSource>().clip = mySounds[1]; }
            if (move.Contains("End")) { GetComponent<AudioSource>().clip = mySounds[3]; }

            GetComponent<AudioSource>().Play();
        }
    }

    IEnumerator playingMovement()
    {
        
        for (int i = 0; i < movement.Count; i++)
        {

            if (movement[i].Contains("Begin Loop")) { /*i++;*/ saveStartLocation = i; }

            if (movement[i].Contains("End Loop")) { countLoops++; if (countLoops < loopsFromSlider) { i = saveStartLocation; } else { countLoops = 0; } }

            if (movement[i].Contains("Roll") || movement[i].Contains("Spin"))
            {
                resetAfterSpinOrRoll = player.transform.eulerAngles;
                AnimatePlayer.run = true;
            }

            if (movement[i].Contains("Right") || movement[i].Contains("Left") || movement[i].Contains("Turn") || movement[i].Contains("Backward") || movement[i].Contains("Forward"))
            {
                AnimatePlayer.run = true;
            }

            if (movement[i].Contains("Sing"))
            {
                AnimatePlayer.sing = true;
            }

            if (movement[i].Contains("Jump"))
            {
                jumpReset = true; resetAfterJump = player.transform.position;
                AnimatePlayer.jump = true;
                StartCoroutine(jump());
            }

            insertFormat(i);

            move.text = movement[i];
            playMoveName(move.text);

            yield return new WaitForSeconds(1);
            AnimatePlayer.run = false;
            AnimatePlayer.jump = false;
            AnimatePlayer.sing = false;
            AnimatePlayer.playOnce = true;
            jumpSwitch = true;

            if (jumpReset)
            {
                player.transform.position = resetAfterJump;
                jumpReset = false;
            }

            if (spinOrRoll)
            {
                player.transform.eulerAngles = resetAfterSpinOrRoll;
                spinOrRoll = false;
            }

            if (!facingRight && turned)
            {
                player.transform.eulerAngles = new Vector3(0, 90, 0);
                facingRight = true;
            }
            else if (facingRight && turned)
            {
                player.transform.eulerAngles = new Vector3(0, 270, 0);
                facingRight = false;
            }

            growthSwitch = true;
            shrinkSwitch = true;
            turned = false;
        }
        //checkTutorial();
        //for (int i = 0; i < movement.Count; i++)
        //    Debug.Log(movement[i].ToString());

        if (!MiniGame.isMainMenuGame)
        {
            if (movement[0].Contains("Forward"))
                displayWinScreen();
            else
                displayErrorMessage();
        }
        else
            checkTutorial();
        move.text = "Done Moving";
        playing = false;
    }


    public void checkTutorial()
    {
        if (tutorialCount == 1)
        {
            //If in story mode, skip Looping and go straight to end
            if (!MiniGame.isMainMenuGame)
            {
                //tutorialCount = 14;
                //checkTutorial();
                StopCoroutine(buttonFlash());
                displayWinScreen();
            }
            else
            {
                tutorialCount++;
                help.text = "Tap <b><color=yellow>Clear</color></b> for the next lesson.";
                playSound(16);
            }
        }

        if (tutorialCount == 5)
        {
            //help.text = "Tap 2 commands and then Tap <b><color=yellow>Erase</color></b>.\n<b><color=yellow>Erase</color></b> takes away the last command.";
            //help.text = "Tap <b><color=yellow>Loop</color></b>, <b><color=yellow>Jump</color></b>, then <b><color=yellow>Play</color></b>.\nTommy moves many times over and over again. ";
            tutorialCount++;
            //playSound(19);
        }

        //if (tutorialCount == 10) 
        // {
        //    if (!MiniGame.isMainMenuGame)
        //    {
        //        help.text = "You did it! Congratulations! Lets see what else we can learn on the Code Road!";
        //        playSound(20);
        //    }
        //}

        if (tutorialCount == 17)
        {
            help.text = "You did it! Congratulations! Time to practice your coding skills in Free Play or Challenge.";
            playSound(20);
        }
    }
    void displayWinScreen()
    {
        canvas.SetActive(false);
        winCanvas.SetActive(true);
        //GetComponent<AudioSource>().Stop();
        //GetComponent<AudioSource>().clip = winSound[UnityEngine.Random.Range(0, winSound.Length)];
        playSound(20);
        //GetComponent<AudioSource>().Play();
        player.transform.eulerAngles = new Vector3(0, 180, 0);
        AnimatePlayer.win = true;
        AnimateFriend.win = true;
        PointHandler.completedChallenges += 1.0f;
    }
    void displayErrorMessage()
    {
        //showMoves.text = "Good try! Press Clear To Try Again";
        //if (PlayerPrefs.GetInt("voice") == 0)
        //{
        //    incorrectVoiceOver.Play();
        //    if (narration.isPlaying)
        //        narration.Stop();
        //}
        //PointHandler.incorrect += 1.0f;
        canvas.SetActive(false);
        tryAgainCanvas.SetActive(true);
    }

    IEnumerator buttonFlash()
    {
        int buttonToFlash = 0;

        //Forward, Play, Clear
        if(tutorialCount == 0) { buttonToFlash = 6; buttonCount = 6; }
        if (tutorialCount == 1) { buttonToFlash = 10; buttonCount = 10; }
        if(tutorialCount == 2) { buttonToFlash = 11; buttonCount = 11; }

        //Forward, Backward, Play, Clear
        if (tutorialCount == 3) { buttonToFlash = 6; }
        if (tutorialCount == 4) { buttonToFlash = 7; }
        if (tutorialCount == 5) { buttonToFlash = 10; }
        if (tutorialCount == 6) { buttonToFlash = 11; }

        //Jump, Spin, Play, Clear
        if (tutorialCount == 7) { buttonToFlash = 4; }
        if (tutorialCount == 8) { buttonToFlash = 3; }
        if (tutorialCount == 9) { buttonToFlash = 10; }
        if (tutorialCount == 10) { buttonToFlash = 11; }

        //Loop, Forward, Jump, Spin, Backwards, Menu
        if (tutorialCount == 11) { buttonToFlash = 8; }
        if (tutorialCount == 12) { buttonToFlash = 6; }
        if (tutorialCount == 13) { buttonToFlash = 4; }
        if (tutorialCount == 14) { buttonToFlash = 3; }
        if (tutorialCount == 15) { buttonToFlash = 7; }
        if (tutorialCount == 16) { buttonToFlash = 10; }
        if (tutorialCount == 17) { buttonToFlash = 12; }


        ////Old Ending to Tutorial
        ////Loop, Jump, Play, Menu
        //if (tutorialCount == 7) { buttonToFlash = 8; }
        //if (tutorialCount == 8) { buttonToFlash = 4; }
        //if (tutorialCount == 9) { buttonToFlash = 10; }
        //if (tutorialCount == 10) { buttonToFlash = 12; }

        buttonCount = buttonToFlash;

        if (buttonToFlash >= 10)
        {
            myButtons[buttonToFlash].GetComponent<Image>().color = new Color(0.258f, 0.941f, 0.090f, 1);
            yield return new WaitForSeconds(0.5f);
            myButtons[buttonToFlash].GetComponent<Image>().color = Color.white;
        }
        else
        {
            myButtons[buttonToFlash].GetComponent<Image>().color = Color.white;
            yield return new WaitForSeconds(0.5f);
            myButtons[buttonToFlash].GetComponent<Image>().color = new Color(0.549f, 0.776f, 0.251f, 1);
        }

        yield return new WaitForSeconds(0.5f);

        while (playing)
            yield return null;

        StartCoroutine(buttonFlash());
    }

    public void TutorialOn ()
    {
        MiniGame.tutorialMode = true;
        tutorialCanvas.SetActive(false);
        canvas.SetActive(true);
        playSound(15);
        StartCoroutine(buttonFlash());
    }
    public void TutorialOff ()
    {
        MiniGame.tutorialMode = false;
        tutorialCanvas.SetActive(false);
        canvas.SetActive(true);

        if (PlayerPrefs.GetInt("Scan") == 1)
        {
            StartCoroutine(scanner());
        }
    }

    IEnumerator jump()
    {
        yield return new WaitForSeconds(.5f);
        jumpSwitch = false;
    }

    void playSound(int num)
    {
        if (PlayerPrefs.GetInt("voice") == 0)
        {
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = mySounds[num];
            GetComponent<AudioSource>().Play();
        }
    }

    public void mainMenu()
    {
        //GetComponent<AudioSource>().Stop();
        StartCoroutine(mainMenuStart());
    }
    IEnumerator mainMenuStart()
    {
        //playSound(7);
        GetComponent<AudioSource>().Stop();
        canvas.SetActive(false);
        //directionalLight.gameObject.SetActive(false);
        if (!MiniGame.isMainMenuGame)
        {
            tryAgainCanvas.SetActive(false);
            background.SetActive(false);
            winCanvas.SetActive(false);
            //LoadingScreen.LoadScene("Empty");
            GetComponent<Camera>().enabled = false;
            if (!SceneManager.GetSceneByName("LoadingScreen").isLoaded)
                SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Additive);
            directionalLight.gameObject.SetActive(false);
            LoadingScreen.LoadScene("Empty");
            yield return new WaitForSeconds(1.5f);
            story.EndMiniGame();
            MiniGame.UnloadScene(MiniGame.currentLevel);
            SceneManager.UnloadSceneAsync("MiniGame");
        }
        else
        {
            ChallenegeMenu.returnFromChallenge = true;

            LoadingScreen.LoadScene("MenuScreen");
            if (!SceneManager.GetSceneByName("LoadingScreen").isLoaded)
                SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Additive);
            directionalLight.gameObject.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadSceneAsync("MenuScreen");
        }
    }

}
