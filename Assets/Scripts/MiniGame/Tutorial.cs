using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
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

    public Button[] myButtons;
    int buttonCount;
    bool buttonChoosen;

    int tutorialCount;

    public GameObject canvas;

    // Use this for initialization
    void Start()
    {
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
        showMoves.fontSize = 25;// PlayerPrefs.GetInt("fontSize");
        tutorialCount = 0;

        loopState = false;
        loopsFromSlider = 2;
        howManyTimesToLoop.text = "Times To Loop : " + loopsFromSlider;
        countLoops = 0;
        saveStartLocation = -1;
        countTillLineSkip = 0;
        growthSwitch = true;
        shrinkSwitch = true;

        turned = false;
        facingRight = true;

        spinOrRoll = false;

        jumpSwitch = true;
        jumpReset = false;

        startFormat = "<b><color=#00ff00ff>";
        endFormat = "</color></b>";
        movementLengthCollection = 0;

        buttonChoosen = false;
        buttonCount = 0;
        playSound(15);
        StartCoroutine(buttonFlash());
       }

  
    // Update is called once per frame
    void Update()
    {
        Debug.Log(tutorialCount);
        if (Input.anyKeyDown)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) return;

            if ((PlayerPrefs.GetInt("Scan") == 1))
            {                                  
                    if (tutorialCount == 0) { addWalkForward(); }else
                    if (tutorialCount == 1) { play(); }else
                    if (tutorialCount == 2) { clearList(); }else
                    if (tutorialCount == 3) { addWalkForward(); }else
                    if (tutorialCount == 4) { addWalkBackward(); }else
                    if (tutorialCount == 5) { play(); }else
                    if (tutorialCount == 6) { clearList(); }else
                    if (tutorialCount == 7) { mainMenu(); }                
            }
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
    }

    public void addSpin() { movement.Add("Spin"); showMoves.text = showMoves.text + "Spin..."; lineSkip(4); playSound(11); if (tutorialCount == 8) { tutorialCount++; } if (tutorialCount == 12) { tutorialCount++; } }
    public void addGrow() { movement.Add("Grow"); showMoves.text = showMoves.text + "Grow..."; lineSkip(4); playSound(5); if (tutorialCount == 8) { tutorialCount++; } }
    public void addShrink() { movement.Add("Shrink"); showMoves.text = showMoves.text + "Shrink..."; lineSkip(6); playSound(9); if (tutorialCount == 8) { tutorialCount++; } }
    public void addTurn() { movement.Add("Turn"); showMoves.text = showMoves.text + "Turn..."; lineSkip(4); playSound(13); if (tutorialCount == 8) { tutorialCount++; } }

    public void addJump()
    {
        movement.Add("Jump");
        if (tutorialCount == 8)
         {
            showMoves.text = showMoves.text + "Jump..."; lineSkip(4); playSound(6);
            tutorialCount++; 
         }

          if (tutorialCount == 11)
           {
            showMoves.text = ""; showMoves.text = showMoves.text + "Jump..."; movement.Clear(); movement.Add("Jump"); lineSkip(4); playSound(6);
            tutorialCount++;
           } 
     }

    public void addWalkForward()
    {
        movement.Add("Forward");
        if (tutorialCount == 0)
        {
            showMoves.text = ""; showMoves.text = showMoves.text + "Forward..."; lineSkip(7); playSound(4);
            tutorialCount++;
        }
        if(tutorialCount == 3)
        {
            showMoves.text = ""; showMoves.text = showMoves.text + "Forward..."; lineSkip(7); playSound(4);
            tutorialCount++;
        }
        if (tutorialCount == 8) { tutorialCount++; }
    }


    public void addWalkBackward()
    {
        movement.Add("Backward");
        if (tutorialCount == 4)
        {
            showMoves.text = showMoves.text + "Backward..."; lineSkip(8); playSound(0);
            tutorialCount++;
        }

        if (tutorialCount == 8) { tutorialCount++; }
    }

    public void addSing() { movement.Add("Sing"); showMoves.text = showMoves.text + "Sing..."; lineSkip(4); playSound(10); if (tutorialCount == 8) { tutorialCount++; } }

    public void startLoop()
    {
        if (!loopState)
        {
            movement.Add("Begin Loop");
            if (tutorialCount == 7)
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
            if (tutorialCount == 9)
            {
                //showMoves.text = "";
                movement.Add("End Loop"); showMoves.text = showMoves.text + "End Loop..."; lineSkip(8);
                loopState = false;
                playSound(3);

                tutorialCount++;
            }
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
        playSound(2);
        movementLengthCollection = 0;
        movement.Clear();
        move.text = "List Of Moves Cleared";
        showMoves.text = "";
        player.transform.localScale = new Vector3(2, 2, 2);
        player.transform.rotation = Quaternion.Euler(0, 90, 0);
        player.transform.position = new Vector3(-2.64f, -3.72f, 0.28f);

        if (tutorialCount == 2)
        {
           playSound(17);
           showMoves.text = "Tap <b><color=yellow>Forward</color></b>, <b><color=yellow>Backward</color></b>, and then <b><color=yellow>Play</color></b>. Make Tommy move to where he began.";
           tutorialCount++;
        }

        if (tutorialCount == 6)
        {
            playSound(18);
            showMoves.text = "Tap <b><color=yellow>Begin Loop</color></b>.\nTap a command.\nTap <b><color=yellow>End Loop</color></b> and then <b><color=yellow>Play</color></b>.\nTommy moves many times over and over again. ";
            tutorialCount++;
        }
    
    }
    public void play()
    {
        StartCoroutine(playStart());
    }

    public IEnumerator playStart()
    {
        playSound(8);
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
        else { move.text = "Must Close All Loops To Play"; }

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
        if (PlayerPrefs.GetInt("Voice") == 1)
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
        checkTutorial();
        move.text = "Done Moving";
    }


    public void checkTutorial()
    {
        if (tutorialCount == 1)
        {
            tutorialCount++;
            showMoves.text = "Tap <b><color=yellow>Play</color></b> to make Tommy move again.\n\nTap <b><color=yellow>Clear</color></b> for the next learn to code lesson.";
            playSound(16);
        }
        if (tutorialCount == 5)
        {
            tutorialCount++;
        }

        if(tutorialCount == 10)
         {
            showMoves.text = "Tap 2 commands and then Tap <b><color=yellow>Erase</color></b>.\n<b><color=yellow>Erase</color></b> takes away the last command.";
            tutorialCount++;
            playSound(19);
         }

         if(tutorialCount == 14) 
         {
            showMoves.text = "You did it! Congratulations! Time to practice your coding skills in Free Play or Challenge.";
            tutorialCount++;
            playSound(20);
        }
    }

    IEnumerator buttonFlash()
    {
        int buttonToFlash = 0;
        if(tutorialCount == 0) { buttonToFlash = 6; }
        if(tutorialCount == 1) { buttonToFlash = 10; }
        if(tutorialCount == 2) { buttonToFlash = 11; }
        if(tutorialCount == 3) { buttonToFlash = 6; }
        if(tutorialCount == 4) { buttonToFlash = 7; }
        if(tutorialCount == 5) { buttonToFlash = 10; }
        if(tutorialCount == 6) { buttonToFlash = 11; }
        if(tutorialCount == 7) { buttonToFlash = 8; }
        if(tutorialCount == 8) { buttonToFlash = 4; }
        if(tutorialCount == 9) { buttonToFlash = 9; }
        if(tutorialCount == 10) { buttonToFlash = 10; }
        if(tutorialCount == 11) { buttonToFlash = 4; }
        if (tutorialCount == 12) { buttonToFlash = 3; }
        if(tutorialCount == 13) { buttonToFlash = 13; }
        if(tutorialCount == 14) { buttonToFlash = 10; }
        if(tutorialCount == 15) { buttonToFlash = 12; }

        myButtons[buttonToFlash].GetComponent<Image>().color = Color.white;
        yield return new WaitForSeconds(0.5f);        
        myButtons[buttonToFlash].GetComponent<Image>().color = new Color(0.258f, 0.941f, 0.090f, 1);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(buttonFlash());
    }


    IEnumerator jump()
    {
        yield return new WaitForSeconds(.5f);
        jumpSwitch = false;
    }

    void playSound(int num)
    {
        if (PlayerPrefs.GetInt("Voice") == 1)
        {
            GetComponent<AudioSource>().clip = mySounds[num];
            GetComponent<AudioSource>().Play();
        }
    }

    public void mainMenu()
    {
        StartCoroutine(mainMenuStart());
    }
    IEnumerator mainMenuStart()
    {
        playSound(7);
        canvas.SetActive(false);
        if (!SceneManager.GetSceneByName("LoadingScreen").isLoaded)
            SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Additive);
        yield return new WaitForSeconds(1.5f);
        //LoadManager.level = "MenuScreen";
        SceneManager.LoadSceneAsync("MenuScreen");
    }

}
