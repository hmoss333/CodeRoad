using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayMiniGame : MonoBehaviour {

    //public float timer = 0.1f;
    //public string levelToLoad = "1stScene";
    //public string altLevelToLoad = "Tutorial";
    public GameObject challengeMenu; //can change this to Canvas and use alpha if need be (check which is better for performance)
    public GameObject challengeAvatar;
    public GameObject characterSelectMenu;
    public GameObject[] avatars;
    public GameObject currentAvatar;
    int currentAvatarNum;
    public Text avatarName;

    public UITexture background;
    private bool on = true;
    private bool loading = false;

    public UILabel loadingLabel;
    public UIPanel frontPanel;
    public UICamera uiCam;

    public static bool returnFromChallenge = false;

    //LoadingScreen ls;

    public void switching()
    {
        on = !on;
    }
    // Use this for initialization
    void Start()
    {
        TurnOffAvatars(avatars);
        characterSelectMenu.SetActive(false);
        challengeMenu.SetActive(false);
        challengeAvatar.SetActive(false);
        currentAvatarNum = 0;
        currentAvatar = SetAvatar(avatars, currentAvatarNum);
        SetAvatarName(currentAvatarNum);

        //if (PlayerPrefs.GetInt("MiniGameTutorial") == 0)
        //    tutorialMode = true;
        //else
        //    tutorialMode = false;

        if (returnFromChallenge)
        {
            SetChallengeScreen();
            returnFromChallenge = false;
        }
    }

    public void OnClick()
    {
        if (on)
        {
            SetChallengeScreen();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TurnOffAvatars(GameObject[] avatarList)
    {
        foreach (GameObject avatar in avatarList)
        {
            avatar.SetActive(false);
        }
    }

    GameObject SetAvatar(GameObject[] avatarList, int posNum)
    {
        TurnOffAvatars(avatarList);

        GameObject tempAvatar = avatarList[posNum];
        SetAvatarName(posNum);
        tempAvatar.SetActive(true);

        return tempAvatar;
    }

    void SetAvatarName(int avatarPos)
    {
        switch (avatarPos)
        {
            case 0:
                avatarName.text = "Tommy Turtle";
                break;
            case 1:
                avatarName.text = "Ollie Owl";
                break;
            case 2:
                avatarName.text = "Leo Lion";
                break;
            case 3:
                avatarName.text = "Eleanor Elephant";
                break;
            case 4:
                avatarName.text = "Cathy Cat";
                break;
            case 5:
                avatarName.text = "Dudley Dog";
                break;
            default:
                avatarName.text = "NULL";
                Debug.Log("There is no character for this position. Please update this function to include any new characters.");
                break;
        }
    }

    public void NextAvatar( )
    {
        TurnOffAvatars(avatars);
        if (currentAvatarNum < avatars.Length-1)
            currentAvatarNum++;
        else
            currentAvatarNum = 0;
        currentAvatar = SetAvatar(avatars, currentAvatarNum);
    }

    public void PreviousAvatar( )
    {
        TurnOffAvatars(avatars);
        if (currentAvatarNum > 0)
            currentAvatarNum--;
        else
            currentAvatarNum = avatars.Length-1;
        currentAvatar = SetAvatar(avatars, currentAvatarNum);
    }

    public void SetChallengeScreen ()
    {
        frontPanel.alpha = 0f;
        background.mainTexture = Resources.Load("background_challenge") as Texture;
        challengeMenu.SetActive(true);
        challengeAvatar.SetActive(true);
    }

    public void PlayLevel(int levelNum)
    {
        
    }

    public void ChallengeMovements ()
    {
        characterSelectMenu.SetActive(false);

        MiniGame.isMainMenuGame = true;
        MiniGame.currentLevel = MiniGame.Level.Movement1;

        if (!loading)
        {
            StartCoroutine(GoToScene("MiniGame"));
            loading = true;
        }
    }

    public void ChallengeAbilities()
    {
        characterSelectMenu.SetActive(false);

        MiniGame.isMainMenuGame = true;
        MiniGame.currentLevel = MiniGame.Level.Abilities1;

        if (!loading)
        {
            StartCoroutine(GoToScene("MiniGame"));
            loading = true;
        }
    }

    public void ChallengeLoops()
    {
        characterSelectMenu.SetActive(false);

        MiniGame.isMainMenuGame = true;
        MiniGame.currentLevel = MiniGame.Level.Loops1;

        if (!loading)
        {
            StartCoroutine(GoToScene("MiniGame"));
            loading = true;
        }
    }

    public void ChallengeCombos()
    {
        characterSelectMenu.SetActive(false);

        MiniGame.isMainMenuGame = true;
        MiniGame.currentLevel = MiniGame.Level.Combos1;

        if (!loading)
        {
            StartCoroutine(GoToScene("MiniGame"));
            loading = true;
        }
    }

    public void Tutorial()
    {
        characterSelectMenu.SetActive(false);

        MiniGame.isMainMenuGame = true;
        MiniGame.currentLevel = MiniGame.Level.Tutorial;

        if (!loading)
        {
            StartCoroutine(GoToScene("MiniGame"));
            loading = true;
        }
    }

    public void FreePlay()
    {
        characterSelectMenu.SetActive(true);
        MiniGame.isMainMenuGame = true;
        MiniGame.currentLevel = MiniGame.Level.FreePlay;

        //if (!loading)
        //{
        //    StartCoroutine(GoToScene("MiniGame"));
        //    loading = true;
        //}
    }

    public void StartGame()
    {
        if (!loading)
        {
            StartCoroutine(GoToScene("MiniGame"));
            loading = true;
        }
    }

    public void ChallengeBack ()
    {
        characterSelectMenu.SetActive(false);
        challengeMenu.SetActive(false);
        challengeAvatar.SetActive(false);
        frontPanel.alpha = 1f;
        background.mainTexture = Resources.Load("coderoad_opening") as Texture;
    }

    IEnumerator GoToScene(string sceneName)
    {
        uiCam.enabled = false;
        //SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Additive);
        LoadingScreen.LoadScene("MiniGame");
        challengeMenu.SetActive(false);
        challengeAvatar.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadSceneAsync(sceneName);
    }

}
