using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudio : MonoBehaviour {

    public AudioClip characterSound;
    AudioSource specialAudiosource;


    // Use this for initialization
    void Start()
    {
        specialAudiosource = GameObject.Find("SpecialAudiosource").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClick()
    {
        specialAudiosource.Stop();
        specialAudiosource.clip = characterSound; //SelectRandomAudio(characterSounds);
        specialAudiosource.Play();
    }

    AudioClip SelectRandomAudio(AudioClip[] audioList)
    {
        int randNum = (int)Random.Range(0.0f, (float)audioList.Length);

        AudioClip ac = audioList[randNum];

        return ac;
    }
}
