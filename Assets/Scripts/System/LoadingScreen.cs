using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {

    public GameObject[] characters;

    private bool loading = false;
    private string sceneToLoad;
    public static bool levelLoaded = false;

    void Start() {
        SetAvatars();
    }

    // Update is called once per frame
    void Update() {

    }

    public void LoadScene (string targetScene)
    {
        sceneToLoad = targetScene;
        loading = true;
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

    public static void WaitForSceneToLoad (string sceneName)
    {

    }
}
