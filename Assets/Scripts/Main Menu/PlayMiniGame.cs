using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMiniGame : MonoBehaviour {

    //public float timer = 0.1f;
    //public string levelToLoad = "1stScene";
    //public string altLevelToLoad = "Tutorial";
    public GameObject challengeMenu;
    public GameObject challengeAvatar;
    public UITexture background;
    private bool on = true;
    private bool loading = false;

    public UILabel loadingLabel;
    public UIPanel frontPanel;
    public UICamera uiCam;

    //LoadingScreen ls;

    public void switching()
    {
        on = !on;
    }
    // Use this for initialization
    void Start()
    {
        //ls = GameObject.Find("LoadingScreen").GetComponent<LoadingScreen>();
        challengeMenu.SetActive(false);
        challengeAvatar.SetActive(false);

        //if (PlayerPrefs.GetInt("MiniGameTutorial") == 0)
        //    tutorialMode = true;
        //else
        //    tutorialMode = false;
    }

    public void OnClick()
    {
        if (on)
        {
            frontPanel.alpha = 0;
            background.mainTexture = Resources.Load("background") as Texture;
            challengeMenu.SetActive(true);
            challengeAvatar.SetActive(true);

            //ls.LoadScene(levelToLoad);
            //ls.ChangeText("Let's play...");
            //SceneManager.LoadSceneAsync("LoadingScreen", LoadSceneMode.Additive);
            //Resources.UnloadUnusedAssets();

            //StartCoroutine(GoToScene(levelToLoad));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChallengeMovements ()
    {
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
        MiniGame.isMainMenuGame = true;
        MiniGame.currentLevel = MiniGame.Level.FreePlay;

        if (!loading)
        {
            StartCoroutine(GoToScene("MiniGame"));
            loading = true;
        }
    }

    public void ChallengeBack ()
    {
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
