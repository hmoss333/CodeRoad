using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

    public GameObject reallyQuit;

    public UISprite playButton;
    //public UILabel play;

    public UISprite settings;
    //public UISprite a;
    //public UILabel set;

    public UISprite parent;
    //public UISprite b;
    //public UILabel parentText;

    public UISprite exitButton;
    //public UISprite c;
    //public UILabel exitText;

    public UISprite miniGame;
    //public UISprite d;
    //public UILabel miniGameText;

    public UISprite infoButton;
    //public UISprite e;
    //public UILabel infoText;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClick()
    {
        //a.alpha = 0;
        //b.alpha = 0;
        //c.alpha = 0;
        //d.alpha = 0;
        //e.alpha = 0;

        playButton.alpha = 0;
        //play.alpha = 0;

        settings.alpha = 0;
        //set.alpha = 0;

        parent.alpha = 0;
        //parentText.alpha = 0;

        exitButton.alpha = 0;
        //exitText.alpha = 0;

        miniGame.alpha = 0;
        //miniGameText.alpha = 0;

        infoButton.alpha = 0;
        //infoText.alpha = 0;

        //playButton.SetActive(false);
        //settings.SetActive(false);
        //parent.SetActive(false);
        //exitButton.SetActive(false);
        //miniGame.SetActive(false);
        //infoButton.SetActive(false);

        reallyQuit.SetActive(true);
    }

    public void yes()
    {
        //if (!Application.isEditor)
        //{
        //    System.Diagnostics.Process.GetCurrentProcess().Kill();
        //}

        Application.Quit();
    }

    public void no()
    {
        //a.alpha = 1;
        //b.alpha = 1;
        //c.alpha = 1;
        //d.alpha = 1;
        //e.alpha = 1;

        playButton.alpha = 1;
        //play.alpha = 1;

        settings.alpha = 1;
        //set.alpha = 1;

        parent.alpha = 1;
        //parentText.alpha = 1;

        exitButton.alpha = 1;
        //exitText.alpha = 1;

        miniGame.alpha = 1;
        //miniGameText.alpha = 1;

        infoButton.alpha = 1;
        //infoText.alpha = 1;

        //playButton.SetActive(true);
        //settings.SetActive(true);
        //parent.SetActive(true);
        //exitButton.SetActive(true);
        //miniGame.SetActive(true);
        //infoButton.SetActive(true);

        reallyQuit.SetActive(false);
    }
}
