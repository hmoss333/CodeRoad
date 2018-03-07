using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadManager : MonoBehaviour {

    // Use this for initialization
    GameObject loadingBar;
    Text percentTxt;
    Text loadingText;
    public static string level;
    float loadTime = 0.0f;
	void Start () {
        loadingBar = GameObject.Find("loadingBar");
        percentTxt = GameObject.Find("PercentText").GetComponent<Text>();
        loadingText = GameObject.Find("NowLoadingText").GetComponent<Text>();
        if(level != "" || level != null)
            StartCoroutine(AsyncLoad(level));		
	}

    void Update()
    {
        loadTime += Time.deltaTime;
        if(loadTime >= 0.3f)
        {
            switch(loadingText.text)
            {
                case "Now Loading":
                    loadingText.text = "Now Loading.";
                    loadTime = 0.0f;
                    break; 
                case "Now Loading.":
                    loadingText.text = "Now Loading..";
                    loadTime = 0.0f;
                    break; 
                case "Now Loading..":
                    loadingText.text = "Now Loading...";
                    loadTime = 0.0f;
                    break; 
                case "Now Loading...":
                    loadingText.text = "Now Loading";
                    loadTime = 0.0f;
                    break; 
            }
        }
    }

    IEnumerator AsyncLoad(string level)
    {
        yield return null;
        AsyncOperation ao = SceneManager.LoadSceneAsync(level);
        ao.allowSceneActivation = false;

        while(!ao.isDone)
        {
            float progress = Mathf.Clamp01(ao.progress / 0.9f);
            Debug.Log("Loading Progress: " + (progress * 100) + "%");
            loadingBar.GetComponent<RectTransform>().sizeDelta = new Vector2(progress * 500.0f, 30f);
            percentTxt.text = Mathf.Round((progress * 100)).ToString() + "%";

            //load completed
            if(ao.progress == 0.9f)
            {
                yield return new WaitForSeconds(0.5f);
                ao.allowSceneActivation = true;
            }
            yield return null;
        }
    }
	
}
