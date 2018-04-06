using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMiniGame : MonoBehaviour {

    public float timer = 0.1f;
    //public string levelToLoad = "1stScene";
    //public string altLevelToLoad = "Tutorial";
    public GameObject challengeMenu;
    public GameObject challengeAvatar;
    public UITexture background;
    private bool on = true;

    public UILabel loadingLabel;
    public UIPanel frontPanel;

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
        challengeMenu.SetActive(false);
        challengeAvatar.SetActive(false);
        MiniGame.isMainMenuGame = true;
        MiniGame.currentLevel = MiniGame.Level.Movement1;
        StartCoroutine(GoToScene("MiniGame"));
        //StartCoroutine(GoToScene("Movement1"));
    }

    public void ChallengeAbilities()
    {
        challengeMenu.SetActive(false);
        challengeAvatar.SetActive(false);
        MiniGame.isMainMenuGame = true;
        MiniGame.currentLevel = MiniGame.Level.Abilities1;
        StartCoroutine(GoToScene("MiniGame"));
        //StartCoroutine(GoToScene("Abilities1"));
    }

    public void ChallengeLoops()
    {
        challengeMenu.SetActive(false);
        challengeAvatar.SetActive(false);
        MiniGame.isMainMenuGame = true;
        MiniGame.currentLevel = MiniGame.Level.Loops1;
        StartCoroutine(GoToScene("MiniGame"));
        //StartCoroutine(GoToScene("Loops1"));
    }

    public void ChallengeCombos()
    {
        challengeMenu.SetActive(false);
        challengeAvatar.SetActive(false);
        MiniGame.isMainMenuGame = true;
        MiniGame.currentLevel = MiniGame.Level.Combos1;
        StartCoroutine(GoToScene("MiniGame"));
        //StartCoroutine(GoToScene("Combos1"));
    }

    public void ChallengeBack ()
    {
        challengeMenu.SetActive(false);
        challengeAvatar.SetActive(false);
        frontPanel.alpha = 1f;
        background.mainTexture = Resources.Load("coderoad_opening") as Texture;
    }

    public void Tutorial ()
    {
        challengeMenu.SetActive(false);
        challengeAvatar.SetActive(false);
        MiniGame.isMainMenuGame = true;
        MiniGame.currentLevel = MiniGame.Level.Tutorial;
        StartCoroutine(GoToScene("MiniGame"));
        //StartCoroutine(GoToScene("Tutorial"));
    }

    IEnumerator GoToScene(string sceneName)
    {
        if (!SceneManager.GetSceneByName("LoadingScreen").isLoaded)
            SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Additive);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync(sceneName);

        if (SceneManager.GetActiveScene().name == "LoadingScreen")
            SceneManager.UnloadSceneAsync("LoadingScreen");
    }

}
