using System;
using System.Collections;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

/*  
 *  Anything related to user data is thrown here. 
 * 
 * */

public class User : Singleton<User> {
    protected User() { }
    //User specfic data that is saved when a user logs in
    public string username;
    public bool canPlay;
    public string email;
    public int score;
    public int starCount;
    public int streak;
    public string objectId;
    public string accountType;
    public List<string> listOfPlayersData = new List<string>();
    public string serverRes;
    public bool exitGame = false;


    //Global variables that are needed across scripts
    public bool loggedIn = false;
    public int playCount;
    public bool accountJustCreated = false;
    public bool parentZoneExit = false;
    public bool parentZoneEnter = false;
    public bool parentZoneExit2 = false;
    public bool stemDashLoaded = false;
    public bool justLoggedIn = false;

    //Parallel Lists that represents the data associated with a player
    //Saved in PlayerPrefs once the user is logged in
    public List<string> playerEmails = new List<string>();
    public List<int> correctPercentages = new List<int>();
    public List<int> incorrectPercentages = new List<int>();
    public List<string> datesCreated = new List<string>();

    public void Clear()
    {
        playerEmails.Clear();
        correctPercentages.Clear();
        incorrectPercentages.Clear();
        datesCreated.Clear();
    }
}

[Serializable]
class serializedUser 
{
    public string username;
    public string email;
    public string objectID;
    public bool accountJustCreated = false;
    public string accountType;
    public List<string> listOfPlayersData = new List<string>();

    //Parallel Lists that represents the data associated with a player
    public List<string> playerEmails = new List<string>();
    public List<float> correctPercentages = new List<float>();
    public List<float> incorrectPercentages = new List<float>();
    public List<string> datesCreated = new List<string>();
}
