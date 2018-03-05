using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyBookButton : MonoBehaviour {

    public UITexture background;

    private bool on = false;

    public GameObject buyBookPanel;
    public UIPanel optionsPanel;

    public void switching()
    {
        on = !on;
    }
    // Use this for initialization
    void Start()
    {

    }

    public void OnClick()
    {

        background.mainTexture = Resources.Load("background") as Texture;

        on = !on;

        //buyBookPanel.alpha = 1;
        optionsPanel.alpha = 0;

        buyBookPanel.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
