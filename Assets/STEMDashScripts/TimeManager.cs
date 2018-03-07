using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine.SceneManagement;

/**********************************************************************
 * 
 *      This class is used as the time manager. It uses the 
 *      singleton design pattern.  At some point it may be better
 *      to use Toolbox but for now singleton works. It is supposed
 *      to initialize the AppEvent subclass, start and stop the timer
 *      and initalizse the dates.
 *      
 *      Syntax:
 *          Manager.Instance.<METHOD NAME> 
 * 
 * ********************************************************************/

public class TimeManager : Singleton<TimeManager> {
	protected TimeManager () {} // guarantee this will be always a singleton only - can't use the constructor!
 
	 #region Private Variables
    private DateTime AppStarted;    
    private DateTime AppEnded;
    private TimeSpan elapsedTime;   //Used to calculated the total minutes
    private string activeUser;
    private string playerName;
    private string playerEmail;
    private bool timeStarted = false;
    private int index;
    private int playerCounter;
    private string appName = "Default";  //Public variable that is used to store the name of the game.
    private string gameData;
    private string gameMode;
    private float min;
    #endregion

    #region Public Variables
    public float time;
    #endregion

    public void initializeAppEvent(string appName, string gameMode)
    {
        this.appName = appName;
        activeUser = SaveAndLoad.dashEmail; 
        playerName = PlayerPrefs.GetString("CurrentPlayer");

        index = SaveAndLoad.listOfPlayers.IndexOf(playerName);
        playerEmail = playerName + "_" + SaveAndLoad.dashEmail;
        playerEmail = playerEmail.ToLower();
        playerCounter = PlayerPrefs.GetInt("PlayerCounter" + index);
        gameData = "";
        this.gameMode = gameMode;
    }
    public void init()
    {
       GameStatusEventHandler.startedGame += gameWasStarted;
       GameStatusEventHandler.stoppedGame += gameWasStopped;

    }

    void gameWasStarted()
    {
        if (LoginToPortal.Instance.userIsLoggedIn)
        {
            Debug.Log("Game has started");
            if (!timeStarted)
                StartTimer();
        }
    }

    void gameWasStopped()
    {
        Debug.Log("Game has stopped");
        if(LoginToPortal.Instance.userIsLoggedIn)
            StopTimer();
    }

    void Update()
    {
        if(timeStarted)
        {
            time += Time.deltaTime;
        }
    }

    //Used to check if the user has started playing
    //If the user has started playing, then the timer has started
    public void StartTimer()
    {
        if (!timeStarted)
        {
            Debug.Log("Adult Email: " + SaveAndLoad.dashEmail);
            Debug.Log("Child current player : " + SaveAndLoad.currentPlayerArr[0]);

            timeStarted = true;
            time = 0f;
            //Checks to see if the current parse user is null
            //If its not null, it starts the app event timer and passes all the necessary
            //values to it. Has to start when the game first loads.  
            string mode;
            if (activeUser != null)
            {
                if (gameMode == "challenge")
                {
                    PointHandler.init();
                    Debug.Log("Active Scene: " + SceneManager.GetActiveScene().name);
                    mode = "Challenge";
                }
                else
                {
                    mode = "Freeplay";
                }

                DateTime date = DateTime.Now;
                string Message;
                
                 Message = playerName + " started playing " + appName + " " + mode + " at " + date.ToLocalTime().ToShortDateString() + " at " + date.ToLocalTime().ToShortTimeString();

                WWWForm form = new WWWForm();  //Creates the form
                Debug.Log("Current Player: " + playerName);
                 form.AddField("username", playerName);
                 form.AddField("email", playerEmail);
                 form.AddField("objectId", SaveAndLoad.dashObjectId);
                 form.AddField("type", 0);
                 form.AddField("appName", appName);
                 form.AddField("message", Message);
                 form.AddField("received", "false");
                 form.AddField("data", 0);
                 form.AddField("gameData", ""); 

                WWW www = new WWW(ServerURL.appEvent, form);              //Sends the data to server 
                StartCoroutine(WaitForRequest(www));       //Listen for the response

                AppStarted = DateTime.Now;
                Debug.Log("Start Time: " + AppStarted);
       //         determineDate(AppStarted, activeUser.Username);
            }
            else
            {
                Debug.Log("User does not exist");
            }
        }
    }

    public void saveScores()
    {

                int index = PlayerPrefs.GetInt(playerName); //Current index of the player
                var playerData = JSON.Parse(SaveAndLoad.currentPlayerArr[index]);
                string dateEarned = System.DateTime.Now.Month + "/" + System.DateTime.Now.Day + "/" + System.DateTime.Now.Year + " " + System.DateTime.Now.TimeOfDay.Hours + ":" + System.DateTime.Now.TimeOfDay.Minutes;
                playerData["correctPercentage"].AsFloat = PointHandler.correctPercentage;
                playerData["incorrectPercentage"].AsFloat =  PointHandler.incorrectPercentage;
                playerData["dateEarned"].Value = dateEarned;
                playerData["completionTime"].Value = min.ToString();
                SaveAndLoad.currentPlayerArr[index] = playerData.ToString();
                /*loop through the dictionary and add it to array then pass the array to join and send to the server*/
                gameData = "{";
                gameData += "\"percentData\": [" + string.Join(",", SaveAndLoad.currentPlayerArr) + "]"; //Convert to JSON Array
                gameData += "}";

                index++;
                if (index > 4)
                    index = 0;

                PlayerPrefs.SetInt(playerName, index);
                SaveAndLoad.updateGameDataList();
                Debug.Log("Saved");
    }

    //Logs the total minutes the player has played the game
    //It tracks the dates and calculates the total minutes played.
    public void StopTimer()
    {
        if (activeUser != null)
        {
            if (timeStarted)
            {
                Debug.Log("Stop called");
                PlayerPrefs.SetInt("timeStarted", 0);
                string ender = "";
                timeStarted = false;
                float timePlayed = 0f;
                AppEnded = DateTime.Now;
                Debug.Log("End Time: " + AppEnded);
                elapsedTime = AppEnded - AppStarted;
                timePlayed = (float)elapsedTime.TotalMinutes;
                double minutes = Math.Round((double)timePlayed);
                string mode = "";

                Debug.Log("End time from delta" + time);
                min = (float) Math.Round(time / 60f); //minutes stored using Time.Delta
                ender = minutes > 1 ? "minutes" : "minute";

                if (gameMode == "challenge")
                {
                    PointHandler.calculatePercentages();
                    saveScores();
                    Debug.Log("Game Data: " + gameData);
                    mode = "Challenge";
                }
                else
                {
                    gameData = "";
                    mode = "Freeplay";
                }

                 Debug.Log("Total minutes: " + min);
                 string Message = playerName + " stopped playing " + appName + " " + mode +  " after " + min + " " + ender;

                 WWWForm form = new WWWForm();  //Creates the form

                 form.AddField("username", playerName);
                 form.AddField("email", playerEmail);
                 form.AddField("objectId", SaveAndLoad.dashObjectId);
                 form.AddField("type", 0);
                 form.AddField("appName", appName);
                 form.AddField("message", Message);
                 form.AddField("received", "true");
                 form.AddField("data", min.ToString());
                 form.AddField("gameData", gameData);

                //Debug.Log(gameData);
                PointHandler.resetPoints();
                WWW www = new WWW(ServerURL.appEvent, form);              //Sends the data to server 
                StartCoroutine(WaitForRequest(www));                     //Listen for the response
                Debug.Log("Stop Time: " + AppEnded);
            }
        } else
        {
            Debug.Log("User does not exist");
        }
    }
    //Logs the total minutes the player has played the game
    //It tracks the dates and calculates the total minutes played.
    public void sendData(int correct, int incorrect)
    {
        if (activeUser != null)
        {
            if (timeStarted)
            {
                PlayerPrefs.SetInt("timeStarted", 0);
                string ender = "";
                timeStarted = false;
                float timePlayed = 0f;
                AppEnded = DateTime.Now;
                Debug.Log("End Time: " + AppEnded);
                elapsedTime = AppEnded - AppStarted;
                timePlayed = (float)elapsedTime.TotalMinutes;
                double minutes = Math.Round((double)timePlayed);
                string mode = "";

                float min = (float) Math.Floor((controlHours.childTimes[playerEmail] * 60.0f)); //minutes stored using Time.Delta
                //float min = (float) Math.Floor(time / 60f); //minutes stored using Time.Delta
                Debug.Log("Minutes in time manager: " + min);

                ender = minutes > 1 ? "minutes" : "minute";

                if (gameMode == "challenge")
                {
                    saveScores();
                    mode = "Challenge";
                }
                else
                {
                    gameData = "";
                    mode = "Drill";
                }

                 Debug.Log("Total minutes: " + min);
                 string Message;
                 Message = playerName + " stopped playing " + appName + " " + mode +  " after " + min + " " + ender;

                 WWWForm form = new WWWForm();  //Creates the form

                 form.AddField("username", playerName);
                 form.AddField("email", playerEmail);
                 form.AddField("objectId", SaveAndLoad.dashObjectId);
                 form.AddField("type", 0);
                 form.AddField("appName", appName);
                 form.AddField("message", Message);
                 form.AddField("received", "true");
                 form.AddField("data", min.ToString());
                 form.AddField("gameData", gameData);

                 //Debug.Log(gameData);

                WWW www = new WWW(ServerURL.appEvent, form);              //Sends the data to server 
                StartCoroutine(WaitForRequest(www));                     //Listen for the response
            }
        } else
        {
            Debug.Log("User does not exist");
        }
    }

    
    //Coroutine to determine if the was saved successfully or not
     IEnumerator WaitForRequest(WWW www)
     {
        yield return www;
 
         // check for errors
         if (www.error == null)
         {
             Debug.Log(www.text);
         } else {
             Debug.Log(www.error);
         }    
    } 
}
