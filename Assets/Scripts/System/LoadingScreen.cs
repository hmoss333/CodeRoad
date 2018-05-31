using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {

    public GameObject[] characters;

    private static bool loading = false;
    private static string sceneToLoad;
    public static bool levelLoaded = false;

    public GameObject cameras;
    public UIPanel loadingPanel;
    //public UIPanel scenePanel;

    private void Awake()
    {
        loadingPanel = gameObject.GetComponent<UIPanel>();

        if (!cameras)
            cameras = GameObject.Find("Cameras");

        TurnOffCameras();
        TurnOffAvatars();
    }

    void Start() {
        if (!cameras)
            cameras = GameObject.Find("Cameras");

        TurnOffCameras();
        TurnOffAvatars();
    }

    // Update is called once per frame
    void Update() {
        if (loading)
        {
            levelLoaded = false;
            TurnOnCameras();
            SetAvatars();

            Coroutine co = StartCoroutine(CheckIfLoaded(sceneToLoad));
            loading = false;
        }
    }

    public static void LoadScene (string targetScene)
    {
        sceneToLoad = targetScene;
        loading = true;
    }

    private void TurnOffAvatars()
    {
        foreach (GameObject avatar in characters)
            avatar.SetActive(false);
    }
    private void SetAvatars()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
        }

        if (!MiniGame.isMainMenuGame)
        {
            switch (MiniGame.currentLevel)
            {
                case MiniGame.Level.Story1:
                    characters[0].SetActive(true);
                    break;
                case MiniGame.Level.Story2:
                    characters[1].SetActive(true);
                    break;
                case MiniGame.Level.Story3:
                    characters[2].SetActive(true);
                    break;
                case MiniGame.Level.Story4:
                    characters[3].SetActive(true);
                    break;
                case MiniGame.Level.Story5:
                    characters[4].SetActive(true);
                    break;
                case MiniGame.Level.Story6:
                    characters[5].SetActive(true);
                    break;
                case MiniGame.Level.Story7:
                    characters[0].SetActive(true);
                    break;
                default:
                    characters[0].SetActive(true);
                    break;
            }
        }
        else
        {
            int rand = Random.Range(0, characters.Length);

            characters[rand].SetActive(true); //any animations should be set to play automatically on awake, looping
        }
    }

    private void TurnOffCameras()
    {
        loadingPanel.alpha = 0f;
        if (cameras)
            cameras.SetActive(false);
    }
    private void TurnOnCameras()
    {
        loadingPanel.alpha = 1f;
        if (cameras)
            cameras.SetActive(true);
    }

    IEnumerator CheckIfLoaded(string SceneToLoad)
    {
        while (!SceneManager.GetSceneByName(SceneToLoad).isLoaded)
            yield return null;

        TurnOffAvatars();
        TurnOffCameras();
        levelLoaded = true;
        sceneToLoad = null;
    }
}
