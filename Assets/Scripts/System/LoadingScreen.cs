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

    // Use this for initialization
    //private void Awake()
    //{
    //    panel = gameObject.GetComponent<UIPanel>();
    //    loadingText = gameObject.GetComponentInChildren<UILabel>();

    //    if (!cameras)
    //        cameras = GameObject.Find("Cameras");        

    //    TurnOffAvatars();
    //    TurnOffCameras();
    //}

    void Start() {
        //if (!cameras)
        //    cameras = GameObject.Find("Cameras");

        //string currentScene = SceneManager.GetActiveScene().name;
        //if (currentScene != "LoadingSceen")
        //    SceneManager.UnloadSceneAsync(currentScene);

        //selectRand = true;
        TurnOffAvatars();
        ShowAvatar();
        //TurnOffCameras();
    }

    // Update is called once per frame
    void Update() {
        //if (loading)
        //{
        //    Debug.Log(defaultText);
        //    levelLoaded = false;
        //    isOn = false;
        //    TurnOnCameras();
        //    ShowAvatar();
        //    StartCoroutine(CheckIfLoaded(sceneToLoad));
        //    loading = false;
        //}
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
            int rand = Random.Range(0, characters.Length);

            characters[rand].SetActive(true); //any animations should be set to play automatically on awake, looping

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
