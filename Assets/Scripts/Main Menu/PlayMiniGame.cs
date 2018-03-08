using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMiniGame : MonoBehaviour {

    public float timer = 0.1f;
    //public string levelToLoad = "1stScene";
    //public string altLevelToLoad = "Tutorial";
    public GameObject ChallengeMenu;
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
        ChallengeMenu.SetActive(false);

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
            ChallengeMenu.SetActive(true);

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

    IEnumerator GoToScene(string sceneName)
    {
        //Camera.main.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadSceneAsync(sceneName);

        if (SceneManager.GetActiveScene().name == "LoadingScreen")
            SceneManager.UnloadSceneAsync("LoadingScreen");
    }

    public void ChallengeMovements ()
    {
        ChallengeMenu.SetActive(false);
        SceneManager.LoadSceneAsync("LoadingScreen", LoadSceneMode.Additive);
        StartCoroutine(GoToScene("Movement1"));
    }

    public void ChallengeAbilities()
    {
        ChallengeMenu.SetActive(false);
        SceneManager.LoadSceneAsync("LoadingScreen", LoadSceneMode.Additive);
        StartCoroutine(GoToScene("Abilities1"));
    }

    public void ChallengeLoops()
    {
        ChallengeMenu.SetActive(false);
        SceneManager.LoadSceneAsync("LoadingScreen", LoadSceneMode.Additive);
        StartCoroutine(GoToScene("Loops1"));
    }

    public void ChallengeCombos()
    {
        ChallengeMenu.SetActive(false);
        SceneManager.LoadSceneAsync("LoadingScreen", LoadSceneMode.Additive);
        StartCoroutine(GoToScene("Combos1"));
    }

    public void ChallengeBack ()
    {
        ChallengeMenu.SetActive(false);
        frontPanel.alpha = 1f;
        background.mainTexture = Resources.Load("coderoad_opening") as Texture;
    }

    public void Tutorial ()
    {
        ChallengeMenu.SetActive(false);
        SceneManager.LoadSceneAsync("LoadingScreen", LoadSceneMode.Additive);
        StartCoroutine(GoToScene("Tutorial"));
    }

}
