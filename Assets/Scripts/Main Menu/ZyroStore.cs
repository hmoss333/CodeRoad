using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
//using Parse;
using System;

public class ZyroStore : MonoBehaviour {

    public UITexture backgroundTexture;
    public UIPanel loadingLabel;
    
    //public enum MenuType { NONE = 0, MainMenu, Settings, ZyroStore, TrophyStore, ParentZone, ParentalGate, AboutUs, Subscription, Welcome, LevelSelection, Difficulty, Report }
    //public MenuType CurrentMenu;
    public enum Avatar { Lion, Croc, Elephant }
    public Avatar CurrentAvatar;
    public static Avatar SelectedAvatar;
    public Avatar selectedAvatar_;

    //public enum TrophyStoreItemType { BlueBear, PandaBear, TeddyBear, PlasticDuck, Trophy1, Trophy2, Trophy3 }
    //public TrophyStoreItemType currentStoreItem;

    //string playerName;
    bool backgroundMusic;
    bool soundEffects;
    bool background;
    bool voice;

    //ZyroStore
    public GameObject Button_ZyroStore_Walk;
    public GameObject Button_ZyroStore_Run;
    public GameObject Button_ZyroStore_Jump;
    public GameObject Button_ZyroStore_Success;
    public GameObject Button_ZyroStore_SwitchStore;
    public GameObject Button_ZyroStore_Back;
    public GameObject Button_ZyroStore_Left;
    public GameObject Button_ZyroStore_Right;
    public GameObject Button_ZyroStore_Select;
    public GameObject Button_ZyroStore_Buy_Back;
    public GameObject Button_ZyroStore_Buy_Yes;
    public GameObject Button_ZyroStore_Buy_No;

    public UILabel ZyroStore_Desc;
    public UILabel ZyroStore_MyStatus;
    public UILabel Button_ZyroStore_Select_Label;
    public UILabel ZyroStore_Message_Label;
    public GameObject ZyroStore_Message;
    public GameObject ZyroStoreItemsExceptMessage;

    //public GameObject Background_Main;
    //public GameObject Background_Store;

    public GameObject[] Avatars;
    //public GameObject[] TrophyStoreItems;


    //int itemPrice;
    //bool isPurchased;
    //int points;
    //int playerNameCount;
    //int parentalGateFirstNumber;
    //int parentalGateSecondNumber;
    //int parentalGateAnswer;

    public UIPanel zyroPanel;
    public UIPanel frontPanel;

    public string levelToLoad = "MiniGame";

    void Awake()
    {
        if (SelectedAvatar == null)
            SelectedAvatar = Avatar.Lion;
        CurrentAvatar = Avatar.Lion;
        //UpdateAvatar();
    }

    // Use this for initialization
    void Start()
    {
        //Background_Store.SetActive(false);
        //Background_Main.SetActive(false);


        // 16:9-->1.777  4:3--->1.3  3:2-->1.5 5:4

        //Resize all background with certain aspect ratioStar

        //if (Camera.main.aspect >= 1.7)
        //{
        //    Background_Main.transform.localScale = new Vector3(16f, 9f, 1f);
        //    Background_Store.transform.localScale = new Vector3(16f, 9f, 1f);
        //}

        //else if (Camera.main.aspect >= 1.6)
        //{
        //    Background_Main.transform.localScale = new Vector3(15f, 9f, 1f);
        //    Background_Store.transform.localScale = new Vector3(15f, 9f, 1f);

        //}
        //else if (Camera.main.aspect >= 1.5)
        //{
        //    Background_Main.transform.localScale = new Vector3(13.5f, 9f, 1f);
        //    Background_Store.transform.localScale = new Vector3(13.5f, 9f, 1f);

        //}
        //else if (Camera.main.aspect >= 1.3) //1.3
        //{
        //    Background_Main.transform.localScale = new Vector3(12f, 9f, 1f);
        //    Background_Store.transform.localScale = new Vector3(12f, 9f, 1f);
        //}


        //if (PlayerPrefs.GetInt("WelcomePage", 0) == 0)
        //{
        //    CurrentMenu = MenuType.Welcome;
        //}
        //else
        //{
        //    CurrentMenu = MenuType.MainMenu;
        //}


        //MenuSelection();
        //UpdateAvatar();

        Avatars[0].SetActive(false);
        Avatars[1].SetActive(false);
        Avatars[2].SetActive(false);
    }


    //private static DateTime? AppStartedDateTime = null;
    // Update is called once per frame
    void Update () {

    }

    public void ZyroStore_()
    {
        backgroundTexture.mainTexture = Resources.Load("zyroStoreBackground") as Texture;
        ZyroStore_Message.SetActive(false);
        CurrentAvatar = SelectedAvatar;
        Avatars[0].GetComponent<Animation>().wrapMode = WrapMode.Loop;
        UpdateAvatar();
    }

    void UpdateAvatar()
    {
        switch (CurrentAvatar)
        {
            case Avatar.Lion:
                Avatars[0].SetActive(true);
                Avatars[1].SetActive(false);
                Avatars[2].SetActive(false);
                ZyroStore_Desc.text = "Name: Leo Lion"; // \n\n Skill: Double Jump \n\n Cost: 500 pts";
                //itemPrice = 500;
                break;
            case Avatar.Croc:
                Avatars[0].SetActive(false);
                Avatars[1].SetActive(true);
                Avatars[2].SetActive(false);
                ZyroStore_Desc.text = "Name: Casey Croc"; // \n\n Skill: Super Speed \n\n Cost: 500 pts";
                //itemPrice = 500;
                break;
            case Avatar.Elephant:
                Avatars[0].SetActive(false);
                Avatars[1].SetActive(false);
                Avatars[2].SetActive(true);
                ZyroStore_Desc.text = "Name: Elie Fant"; // \n\n Skill: Super Jump \n\n Cost: 500 pts";
                //itemPrice = 500;
                break;
            default:
                throw new UnityException("Unimplemented menu: " + CurrentAvatar);
        }

        //playerName = PlayerPrefs.GetString("PlayerName", "PlayerName");
        //points = PlayerPrefs.GetInt(playerName + "Points");
        //ZyroStore_MyStatus.text = "Name: " + playerName.ToString() + "\n" + "Point: " + points.ToString() + "\n" + "Avatar: " + SelectedAvatar.ToString();
        SelectedAvatar = CurrentAvatar;
        ZyroStore_MyStatus.text = "Avatar: " + SelectedAvatar.ToString();

        //if (PlayerPrefs.GetString(playerName + CurrentAvatar.ToString(), "No").Equals("Yes"))
        //{
        //    isPurchased = true;
        //    Button_ZyroStore_Select_Label.text = "Select";
        //}
        //else
        //{
        //    isPurchased = false;
        //    Button_ZyroStore_Select_Label.text = "Buy";
        //}
    }

    public void ButtonOnClick_ZyroStore_Walk()
    {
        switch (CurrentAvatar)
        {
            case Avatar.Lion:
                Avatars[0].GetComponent<Animation>().Play("Walk");
                break;
            case Avatar.Croc:
                Avatars[1].GetComponent<Animation>().Play("Walk");
                break;
            case Avatar.Elephant:
                Avatars[2].GetComponent<Animation>().Play("Walk");
                break;
            //case Avatar.Zyro:
            //    Avatars[0].GetComponent<Animation>().Play("Run");
            //    Avatars[0].GetComponent<Animation>().wrapMode = WrapMode.Loop;
            //    break;
            default:
                throw new UnityException("Unimplemented avatar: " + CurrentAvatar);
        }
    }
    public void ButtonOnClick_ZyroStore_Run()
    {
        switch (CurrentAvatar)
        {
            case Avatar.Lion:
                Avatars[0].GetComponent<Animation>().Play("Run");
                break;
            case Avatar.Croc:
                Avatars[1].GetComponent<Animation>().Play("Run");
                break;
            case Avatar.Elephant:
                Avatars[2].GetComponent<Animation>().Play("Run");
                break;
            //case Avatar.Zyro:
            //    Avatars[0].GetComponent<Animation>().Play("Run-Real");
            //    Avatars[0].GetComponent<Animation>().wrapMode = WrapMode.Loop;
            //    break;
            default:
                throw new UnityException("Unimplemented avatar: " + CurrentAvatar);
        }
    }

    public void ButtonOnClick_ZyroStore_Jump()
    {
        switch (CurrentAvatar)
        {
            case Avatar.Lion:
                Avatars[0].GetComponent<Animation>().Play("Jump");
                break;
            case Avatar.Croc:
                Avatars[1].GetComponent<Animation>().Play("Jump");
                break;
            case Avatar.Elephant:
                Avatars[2].GetComponent<Animation>().Play("Jump");
                break;
            //case Avatar.Zyro:
            //    Avatars[0].GetComponent<Animation>().Play("Jump");
            //    Avatars[0].GetComponent<Animation>().wrapMode = WrapMode.Loop;
            //    break;
            default:
                throw new UnityException("Unimplemented avatar: " + CurrentAvatar);
        }
    }
    public void ButtonOnClick_ZyroStore_Success()
    {
        switch (CurrentAvatar)
        {
            case Avatar.Lion:
                Avatars[0].GetComponent<Animation>().Play("Success");
                break;
            case Avatar.Croc:
                Avatars[1].GetComponent<Animation>().Play("Success");
                break;
            case Avatar.Elephant:
                Avatars[2].GetComponent<Animation>().Play("Success");
                break;
            //case Avatar.Zyro:
            //    Avatars[0].GetComponent<Animation>().Play("Success");
            //    Avatars[0].GetComponent<Animation>().wrapMode = WrapMode.Loop;
            //    break;
            default:
                throw new UnityException("Unimplemented avatar: " + CurrentAvatar);
        }
    }
    public void ButtonOnClick_ZyroStore_Left()
    {
        if (CurrentAvatar.Equals(Avatar.Elephant))
        {
            CurrentAvatar = Avatar.Croc;
            UpdateAvatar();
        }
        else if (CurrentAvatar.Equals(Avatar.Croc))
        {
            CurrentAvatar = Avatar.Lion;
            UpdateAvatar();
        }
        else if (CurrentAvatar.Equals(Avatar.Lion))
        {
            CurrentAvatar = Avatar.Elephant;
            UpdateAvatar();
        }
    }
    public void ButtonOnClick_ZyroStore_Right()
    {
        if (CurrentAvatar.Equals(Avatar.Lion))
        {
            CurrentAvatar = Avatar.Croc;
            UpdateAvatar();
        }
        else if (CurrentAvatar.Equals(Avatar.Croc))
        {
            CurrentAvatar = Avatar.Elephant;
            UpdateAvatar();
        }
        else if (CurrentAvatar.Equals(Avatar.Elephant))
        {
            CurrentAvatar = Avatar.Lion;
            UpdateAvatar();
        }
    }

    public void ButtonOnClick_ZyroStore_Select()
    {
        Debug.Log("choosing avatar");
        SelectedAvatar = CurrentAvatar;
        selectedAvatar_ = SelectedAvatar;
        UpdateAvatar();
    }

    public void ButtonOnClick_ZyroStore_Back()
    {
        frontPanel.alpha = 1f;
        zyroPanel.alpha = 0f;

        Avatars[0].SetActive(false);
        Avatars[1].SetActive(false);
        Avatars[2].SetActive(false);

        backgroundTexture.mainTexture = Resources.Load("startScreenhis") as Texture;
    }

    public void ButtonOnClick_ZyroStore_Play()
    {
        zyroPanel.alpha = 0f;
        Avatars[0].SetActive(false);
        Avatars[1].SetActive(false);
        Avatars[2].SetActive(false);

        //loadingLabel.alpha = 1f;
        //loadingLabel.gameObject.GetComponent<LoadingScreen>().selectRand = false;
        //loadingLabel.gameObject.GetComponent<LoadingScreen>().SelectedAvatar = (LoadingScreen.Avatar)CurrentAvatar;
        //loadingLabel.gameObject.GetComponent<LoadingScreen>().loading = true;
        //loadingLabel.gameObject.GetComponent<LoadingScreen>().sceneToLoad = levelToLoad;
        //loadingLabel.gameObject.GetComponent<LoadingScreen>().ChangeText("Let's play...");

        SceneManager.LoadSceneAsync(levelToLoad);
    }

    //public void ButtonOnClick_ZyroStore_SwitchStore()
    //{
    //    CurrentMenu = MenuType.TrophyStore;
    //    UpdateTrophyStoreItems();
    //    MenuSelection();
    //}
}
