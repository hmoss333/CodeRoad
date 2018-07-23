using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChallenegeMenu : MonoBehaviour {

    public GameObject challengeMenu; //can change this to Canvas and use alpha if need be (check which is better for performance)
    public GameObject challengeAvatar;
    public GameObject characterSelectMenu;
    public GameObject[] avatars;
    public GameObject currentAvatar;
    int currentAvatarNum;
    public Text avatarName;
    public AudioClip[] avatarNamesAudio;
    public AudioSource audioSource;

    public UITexture background;
    private bool on = true;
    private bool loading = false;

    public UILabel loadingLabel;
    public UIPanel frontPanel;
    public UICamera uiCam;

    public Toggle hintToggle;

    public static bool returnFromChallenge = false;

    // Use this for initialization
    void Start () {
        TurnOffAvatars(avatars);

        //challengeMenu = GetComponent<CanvasGroup>();
        //challengeMenu.alpha = 0f;
        challengeMenu.SetActive(false);
        characterSelectMenu.SetActive(false);
        challengeAvatar.SetActive(false);
        currentAvatarNum = 0;
        currentAvatar = SetAvatar(avatars, currentAvatarNum);
        SetAvatarName(currentAvatarNum);

        hintToggle.isOn = true;
        ToggleHints();

        if (returnFromChallenge)
        {
            SetChallengeScreen();
            returnFromChallenge = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
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
                GameManager.avatars = GameManager.Avatars.turtle;
                break;
            case 1:
                avatarName.text = "Ollie Owl";
                GameManager.avatars = GameManager.Avatars.owl;
                break;
            case 2:
                avatarName.text = "Leo Lion";
                GameManager.avatars = GameManager.Avatars.lion;
                break;
            case 3:
                avatarName.text = "Eleanor Elephant";
                GameManager.avatars = GameManager.Avatars.elephant;
                break;
            case 4:
                avatarName.text = "Cathy Cat";
                GameManager.avatars = GameManager.Avatars.cat;
                break;
            case 5:
                avatarName.text = "Dudley Dog";
                GameManager.avatars = GameManager.Avatars.dog;
                break;
            default:
                avatarName.text = "NULL";
                Debug.Log("There is no character for this position. Please update this function to include any new characters.");
                break;
        }
    }

    public void NextAvatar()
    {
        TurnOffAvatars(avatars);
        if (currentAvatarNum < avatars.Length - 1)
            currentAvatarNum++;
        else
            currentAvatarNum = 0;
        currentAvatar = SetAvatar(avatars, currentAvatarNum);

        audioSource.Stop();
        audioSource.clip = avatarNamesAudio[currentAvatarNum];
        audioSource.Play();
    }

    public void PreviousAvatar()
    {
        TurnOffAvatars(avatars);
        if (currentAvatarNum > 0)
            currentAvatarNum--;
        else
            currentAvatarNum = avatars.Length - 1;
        currentAvatar = SetAvatar(avatars, currentAvatarNum);

        audioSource.Stop();
        audioSource.clip = avatarNamesAudio[currentAvatarNum];
        audioSource.Play();
    }

    public void SetChallengeScreen()
    {
        frontPanel.alpha = 0f;
        background.mainTexture = Resources.Load("background_challenge") as Texture;
        //challengeMenu.alpha = 1f;
        challengeMenu.SetActive(true);
        challengeAvatar.SetActive(true);
    }

    public void PlayLevel(int levelNum)
    {
        MiniGame.isMainMenuGame = true;
        characterSelectMenu.SetActive(false);

        switch (levelNum)
        {
            case -1:
                MiniGame.currentLevel = MiniGame.Level.Tutorial;
                break;
            case 0:
                characterSelectMenu.SetActive(true);
                audioSource.Stop();
                audioSource.clip = avatarNamesAudio[currentAvatarNum];
                audioSource.Play();
                MiniGame.currentLevel = MiniGame.Level.FreePlay;
                break;
            case 1:
                MiniGame.currentLevel = MiniGame.Level.Level1;
                break;
            case 2:
                MiniGame.currentLevel = MiniGame.Level.Level2;
                break;
            case 3:
                MiniGame.currentLevel = MiniGame.Level.Level3;
                break;
            case 4:
                MiniGame.currentLevel = MiniGame.Level.Level4;
                break;
            case 5:
                MiniGame.currentLevel = MiniGame.Level.Level5;
                break;
            case 6:
                MiniGame.currentLevel = MiniGame.Level.Level6;
                break;
            case 7:
                MiniGame.currentLevel = MiniGame.Level.Level7;
                break;
            case 8:
                MiniGame.currentLevel = MiniGame.Level.Level8;
                break;
            case 9:
                MiniGame.currentLevel = MiniGame.Level.Level9;
                break;
            case 10:
                MiniGame.currentLevel = MiniGame.Level.Level10;
                break;
            case 11:
                MiniGame.currentLevel = MiniGame.Level.Level11;
                break;
            case 12:
                MiniGame.currentLevel = MiniGame.Level.Level12;
                break;
            case 13:
                MiniGame.currentLevel = MiniGame.Level.Story2;
                break;
            case 14:
                MiniGame.currentLevel = MiniGame.Level.Story3;
                break;
            case 15:
                MiniGame.currentLevel = MiniGame.Level.Story4;
                break;
            case 16:
                MiniGame.currentLevel = MiniGame.Level.Story5;
                break;
            case 17:
                MiniGame.currentLevel = MiniGame.Level.Story6;
                break;
            case 18:
                MiniGame.currentLevel = MiniGame.Level.Story7;
                break;
            default:
                Debug.Log("Unable to select challenge level");
                break;
        }

        if (!loading && MiniGame.currentLevel != MiniGame.Level.FreePlay)
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
    }

    public void StartGame()
    {
        if (!loading)
        {
            StartCoroutine(GoToScene("MiniGame"));
            loading = true;
        }
    }

    public void ChallengeBack()
    {
        characterSelectMenu.SetActive(false);
        //challengeMenu.alpha = 0f;
        challengeMenu.SetActive(false);
        challengeAvatar.SetActive(false);
        frontPanel.alpha = 1f;
        background.mainTexture = Resources.Load("coderoad_opening") as Texture;
    }
    
    public void ToggleHints()
    {
        if (hintToggle.isOn)
            MiniGame.tutorialMode = true;
        else
            MiniGame.tutorialMode = false;
    }

    IEnumerator GoToScene(string sceneName)
    {
        uiCam.enabled = false;
        SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Additive);
        LoadingScreen.LoadScene("MiniGame");
        challengeMenu.GetComponent<CanvasGroup>().alpha = 0f;
        //challengeMenu.SetActive(false);
        challengeAvatar.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadSceneAsync(sceneName);
    }
}
