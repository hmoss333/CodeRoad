using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {

    public GameObject[] characters;

    private bool isOn = false;

    [HideInInspector] public GameObject cameras;

    private bool loading = false;
    private string sceneToLoad;
    public bool levelLoaded = false;

    UILabel loadingText;
    private string defaultText = "Loading...";

    UIPanel panel;

    public Light light;

    void Start() {
        TurnOffAvatars();
        ShowAvatar();
    }

    // Update is called once per frame
    void Update() {

    }

    public void LoadScene (string targetScene)
    {
        sceneToLoad = targetScene;
        loading = true;
    }

    private void ShowAvatar()
    {
        if (!isOn)
        {
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

            isOn = true;
        }
    }

    private void TurnOffAvatars()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
        }
    }

    private void TurnOffCameras()
    {
        panel.alpha = 0f;
        if (cameras)
            cameras.SetActive(false);
    }

    private void TurnOnCameras()
    {
        panel.alpha = 1f;
        if (cameras)
            cameras.SetActive(true);
    }

    public void TurnOnLight ()
    {
        light.gameObject.SetActive(true);
    }

    IEnumerator CheckIfLoaded(string SceneToLoad)
    {
        //yield return new WaitForSeconds(0.5f);
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == SceneToLoad)
        {
            TurnOffAvatars();
            TurnOffCameras();
            levelLoaded = true;
        }
        else if (!levelLoaded)
        {
            yield return new WaitForSeconds(0.25f);
            StartCoroutine(CheckIfLoaded(SceneToLoad));
        }
    }

    public void ChangeText (string textToBe)
    {
        loadingText.text = textToBe;
    }

    public void ResetText ()
    {
        loadingText.text = defaultText;
    }
}
