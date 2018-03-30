using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRobotAudio : MonoBehaviour {

    public AudioClip[] characterSounds;
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
        specialAudiosource.clip = SelectRandomAudio(characterSounds);//robotSound;
        specialAudiosource.Play();
    }

    AudioClip SelectRandomAudio (AudioClip[] audioList)
    {
        int randNum = (int)Random.Range(0.0f, (float)audioList.Length);

        AudioClip ac = audioList[randNum];

        return ac;
    }
}
