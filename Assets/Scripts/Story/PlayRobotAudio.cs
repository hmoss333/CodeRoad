using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRobotAudio : MonoBehaviour {

    public AudioClip robotSound;
    AudioSource specialAudiosource;


    // Use this for initialization
    void Start () {
        specialAudiosource = GameObject.Find("SpecialAudiosource").GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnClick ()
    {
        specialAudiosource.Stop();
        specialAudiosource.clip = robotSound;
        specialAudiosource.Play();
        Debug.Log("played robot audio");
    }
}
