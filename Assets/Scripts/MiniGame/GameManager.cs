using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [Header("Robot Controls")]
    public float speed = 0.25f;
    float spawnRate = 5f;
    public bool fastMode = false;
    public GameObject[] robotList; //Array of all available robots to pick from
    public List<GameObject> tempList; //stores a list of random bots for each play session
    private bool spawning = false;
    int turnCount = 5;
    [HideInInspector] public int totalTurns;

    [Header("Comparison Controls")]
    public int correctNum = 0;
    public int incorrectNum = 0;
	Transform targetCheckBox;
    Transform targetCompareBox;
    GameObject targetRobot;
    [HideInInspector] public GameObject pickedRobot;
    float compareTime = 1f;
    private bool checking;
    private int giveTargetCount = 0;
    private int targetCount = 0;

    [Header("Gamestate Checks")]
    public bool gameOver = false;
    public bool isMainMenuGame;
    UIManager uim;

    [Header("Scrolling Ground Variables")]
    GameObject ground;
    float offset;

    [Header("Audio Elements")]
    public AudioClip correctSound;
    public AudioClip incorrectSound;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        if (!isMainMenuGame)
        {
            Scene scene = SceneManager.GetSceneByName("MiniGame_Story");
            if (SceneManager.GetActiveScene() != scene)
                SceneManager.SetActiveScene(scene);
        }

        turnCount = 5;
        //turnCount = 1; //for testing purposes
        totalTurns = turnCount;
        speed = 0.25f;
        correctNum = 0;
        incorrectNum = 0;
        gameOver = false;

        targetCheckBox = GameObject.Find("CheckBox").transform;
        targetCompareBox = GameObject.Find("CompareBox").transform;

        ground = GameObject.Find("Ground");

        audioSource = GetComponent<AudioSource>();
        uim = GetComponent<UIManager>();

        //Needed for when replaying mini game
        if (PlayerPrefs.GetInt("levelSelect") == 1)
        {
            spawnRate = 8f;
            Debug.Log("Spawn Rate: " + spawnRate);
            RandomArray(3);
        }
        else if (PlayerPrefs.GetInt("levelSelect") == 2)
        {
            spawnRate = 6.5f;
            Debug.Log("Spawn Rate: " + spawnRate);
            RandomArray(5);
        }
        else if (PlayerPrefs.GetInt("levelSelect") == 3)
        {
            spawnRate = 5f;
            Debug.Log("Spawn Rate: " + spawnRate);
            RandomArray(robotList.Length);
        }

        if (PlayerPrefs.GetInt("levelSelect") != 0)
            RandomTarget();

        SetDifficulty();
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("levelSelect") != 0 )
        {
            offset += (speed * Time.deltaTime) * 2f; // / 10.0f;
            ground.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0.305f));

            //Speed Controls
            if (fastMode)
                speed = 0.5f;
            else
                speed = 0.35f;

            //Game is Running
            if (!gameOver)
            {
                if (!spawning)
                {
                    spawning = true;
                    StartCoroutine(CreateRobots());
                }

                if (turnCount <= 0)
                {
                    Debug.Log("Game Over");
                    gameOver = true;
                    Destroy(pickedRobot);
                    Destroy(targetRobot);
                    pickedRobot = null;
                    targetRobot = null;
                }
            }

            //Compare Robots
            if (pickedRobot && !checking)
            {
                checking = true;
                StartCoroutine(PickRobot());
            }
        }
    }

    public void SetDifficulty ()
    {
        if (PlayerPrefs.GetInt("levelSelect") == 1)
        {
            targetCount = 1; //number of incorrect bots between matches
            spawnRate = 8f;
            Debug.Log("Spawn Rate: " + spawnRate);
        }
        else if (PlayerPrefs.GetInt("levelSelect") == 2)
        {
            targetCount = 2; //number of incorrect bots between matches
            spawnRate = 6.5f;
            Debug.Log("Spawn Rate: " + spawnRate);
        }
        else if (PlayerPrefs.GetInt("levelSelect") == 3)
        {
            targetCount = 2; //number of incorrect bots between matches; previously 3
            spawnRate = 5f;
            Debug.Log("Spawn Rate: " + spawnRate);
        }
    }

    GameObject PickRandom ()
    {
        int targetIndex;
        GameObject targetObject;

        //if (PlayerPrefs.GetInt("levelSelect") == 1)
        //    targetIndex = Random.Range(0, 3);
        //else
            targetIndex = Random.Range(0, tempList.Count);

        targetObject = tempList[targetIndex];
        return targetObject;
    }

    public void RandomTarget ()
    {
        if (targetRobot == null)
            targetRobot = Instantiate(PickRandom(), targetCheckBox.position, Quaternion.identity);
        targetRobot.GetComponent<ConveyorRobot>().enabled = false;
    }

    public void RandomArray (int totalObjectCount)
    {
        tempList = new List<GameObject>();
        tempList.Clear();
        GameObject tempBot;

        bool isDupe = false;

        for (int i = 0; i < totalObjectCount; i++)
        {
            tempBot = robotList[Random.Range(0, robotList.Length)];

            if (tempList.Contains(tempBot))
                isDupe = true;

            if (!isDupe)
                tempList.Add(tempBot);
            else
                i -= 1;

            isDupe = false;
        }
    }

    IEnumerator CreateRobots ()
    {
        GameObject newRobot;
		GameObject tempBot;

        //Spawns randomly
        if (giveTargetCount < targetCount)
        {
			tempBot = PickRandom ();

			newRobot = Instantiate(tempBot, tempBot.transform.position, Quaternion.identity);
            

            ////These robots should not match the target, but still be randomized
            ////This section may need to be reverted later based on feedback
            //if (newRobot.GetComponent<ConveyorRobot>().ID == targetRobot.GetComponent<ConveyorRobot>().ID)
            //{
            //    Destroy(newRobot);
            //    StartCoroutine(CreateRobots());
            //    Debug.Log("wrong spawn");
            //}

            //else
            giveTargetCount++;
        }
        else
        {
			int tempID = targetRobot.GetComponent<ConveyorRobot> ().ID;
			tempBot = robotList [tempID];

			newRobot = Instantiate(tempBot, tempBot.transform.position, Quaternion.identity);
            newRobot.GetComponent<ConveyorRobot>().enabled = true;
            giveTargetCount = 0;
        }

        yield return new WaitForSeconds((spawnRate / speed) * 0.25f);
        spawning = false;
    }

    IEnumerator PickRobot ()
    {
        GameObject tempRobot = Instantiate(pickedRobot, targetCompareBox.position, Quaternion.identity);
        tempRobot.transform.SetParent(targetCompareBox, true); //not really necissary, but keeps heirarchy clean
        tempRobot.GetComponent<ConveyorRobot>().enabled = false;
        Destroy(pickedRobot);
        pickedRobot = tempRobot;
        yield return new WaitForSeconds(compareTime);
        CheckIfMatch();
    }

    void CheckIfMatch ()
    {
        if (pickedRobot.GetComponent<ConveyorRobot>().ID == targetRobot.GetComponent<ConveyorRobot>().ID && checking)
        {
            audioSource.clip = correctSound;
            audioSource.Play();
            uim.correct.alpha = 1f;
            targetCompareBox.GetComponent<UISprite>().color = Color.green;
            Debug.Log("Success!");
            StartCoroutine(CheckReset(true));
        }
        else
        {
            audioSource.clip = incorrectSound;
            audioSource.Play();
            uim.incorrect.alpha = 1f;
            targetCompareBox.GetComponent<UISprite>().color = Color.red;
            Debug.Log("Try again!");
            StartCoroutine(CheckReset(false));
        }
    }

    IEnumerator CheckReset (bool isCorrect)
    {
        yield return new WaitForSeconds(1f);
        if (isCorrect)
        {
            correctNum++;
            turnCount--;
            uim.turns.text = turnCount.ToString();
            //giveTargetCount = 0;

            Destroy(pickedRobot);
            Destroy(targetRobot);
            pickedRobot = null;
            targetRobot = null;

            if (!gameOver)
            {
                RandomTarget();
                checking = false;
            }
        }
        else
        {
            incorrectNum++;
            Destroy(pickedRobot);
            pickedRobot = null;
            checking = false;
        }

        uim.correct.alpha = 0f;
        uim.incorrect.alpha = 0f;
        targetCompareBox.GetComponent<UISprite>().color = Color.white;
    }
}
