using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    void Awake()
    {
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            GameObject[] gameObjs = GameObject.FindGameObjectsWithTag("MusicController");
            if (gameObjs.Length > 1)
                Destroy(this.gameObject);
            DontDestroyOnLoad(this.gameObject);
        } else
        {
            GameObject gameObj = GameObject.FindGameObjectWithTag("MusicController");
            gameObj.GetComponent<AudioSource>().Stop();
        }
    }
}
