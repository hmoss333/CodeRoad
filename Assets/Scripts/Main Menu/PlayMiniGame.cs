using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayMiniGame : MonoBehaviour {

    //public float timer = 0.1f;
    //public string levelToLoad = "1stScene";
    //public string altLevelToLoad = "Tutorial";

    public CanvasGroup challengeMenu; //can change this to Canvas and use alpha if need be (check which is better for performance)
    public GameObject challengeAvatar;
    //public GameObject characterSelectMenu;
    //public GameObject[] avatars;
    //public GameObject currentAvatar;
    //int currentAvatarNum;
    //public Text avatarName;

    public UITexture background;
    private bool on = true;
    private bool loading = false;

    public UILabel loadingLabel;
    public UIPanel frontPanel;
    public UICamera uiCam;

    //public static bool returnFromChallenge = false;

    //LoadingScreen ls;

    public void switching()
    {
        on = !on;
    }
    // Use this for initialization
    void Start()
    {
        //TurnOffAvatars(avatars);
        //characterSelectMenu.SetActive(false);
        //challengeMenu.SetActive(false);
        //challengeAvatar.SetActive(false);
        //currentAvatarNum = 0;
        //currentAvatar = SetAvatar(avatars, currentAvatarNum);
        //SetAvatarName(currentAvatarNum);

        //if (returnFromChallenge)
        //{
        //    SetChallengeScreen();
        //    returnFromChallenge = false;
        //}
    }

    public void OnClick()
    {
        if (on)
        {
            frontPanel.alpha = 0f;
            background.mainTexture = Resources.Load("background_challenge") as Texture;
            challengeMenu.alpha = 1f;
            challengeAvatar.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //IEnumerator GoToScene(string sceneName)
    //{
    //    uiCam.enabled = false;
    //    //SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Additive);
    //    LoadingScreen.LoadScene("MiniGame");
    //    challengeMenu.SetActive(false);
    //    challengeAvatar.SetActive(false);
    //    yield return new WaitForSeconds(1.5f);
    //    SceneManager.LoadSceneAsync(sceneName);
    //}
}
