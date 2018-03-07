using UnityEngine;
using System;
using System.Collections;
using SimpleJSON;
using System.Collections.Generic;
using System.Linq;

public class LoginToPortal : Singleton<LoginToPortal> {
    protected LoginToPortal() { }
    public bool userIsLoggedIn;
    public bool badData;
    public bool emptyFields;
    public bool errorLoggingIn;
    public bool justLoggedIn;
    public bool nosavedSettings;
    public string errorMessage;
    private bool update;

    private string email, password;

    public void init()
    {
        userIsLoggedIn = false;
        badData = false;
        emptyFields = false;
        errorLoggingIn = false;
        nosavedSettings = false;
        errorMessage = "";
    }

    public void ClearData()
    {
        badData = false;
        emptyFields = false;
        errorLoggingIn = false;
        nosavedSettings = false;
        errorMessage = "";
    }
    	
    public void Login(string email, string password)
    {
         errorMessage = "";
         this.email = email;
         this.password = password;
        if (this.email == "" || this.password == "")
        {
            errorMessage = "You cannot leave any fields empty";
        }
        else
        {
            WWWForm form = new WWWForm();  //Creates the form
            //Send data as post method
            form.AddField("email", email);
            form.AddField("password", password);
            form.AddField("gameName", "tommyTurtle");

            WWW www = new WWW(ServerURL.login, form);              //Sends the data to server 

            StartCoroutine(WaitForLoginRequest(www));       //Listen for the response
        }
    }


     public void updateData(string email, string password, bool update)
    {
         errorMessage = "";
         this.email = email;
         this.password = password;
        if (this.email == "" || this.password == "")
        {
            errorMessage = "You cannot leave any fields empty";
        }
        else
        {
            Debug.Log("Made it to updateData.");
            WWWForm form = new WWWForm();  //Creates the form
            //Send data as post method
            form.AddField("email", email);
            form.AddField("password", password);
            form.AddField("gameName", "stemDashApp");

            WWW www = new WWW(ServerURL.login, form);              //Sends the data to server 
            this.update = update;

            StartCoroutine(WaitForLoginRequest(www));               //Listen for the response
        }
    }

     //Coroutine to determine if the was saved successfully or not
     IEnumerator WaitForLoginRequest(WWW www)
     {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            switch (www.text) {
                case "bad":
                    errorLoggingIn = true;
                    errorMessage = "The email or password entered was invalid.\n Please try again.";
                    Debug.Log(errorMessage);
                    break;
                case "empty":
                    errorLoggingIn = true;
                    errorMessage = "You can not leave any fields empty.";
                    Debug.Log(errorMessage);
                    break;
                default:
                    errorLoggingIn = false;
                    userIsLoggedIn = true;
                    justLoggedIn = true;
                    string jsonData = www.text;
                    var data = JSON.Parse(jsonData);
                    string name = data["username"].Value;
                    string email = data["email"].Value;
                    string settings = data["settings"].Value;
                    string accountType = data["accountType"].Value;
                    string objectId = data["objectId"].Value;
                    string children = data["children"].Value;
                    string gameData = data["gameData"].Value;
                    string codeData = data["codeData"].Value;

                    //string emailEnd, correctEnd, incorrectEnd, playsEnd, levelEnd;
                    //emailEnd = correctEnd = incorrectEnd = playsEnd = levelEnd = ""; 

                    SaveAndLoad.Clear();
                    SaveAndLoad.SaveDash(email, password, accountType, objectId);
                    SaveAndLoad.LoadDash();
                    if (settings != "None")
                    {
                        Debug.Log("User has settings");
                        PlayerPrefs.SetInt("Voice", data["settings"]["Voice"].AsInt);
                        PlayerPrefs.SetInt("Music", data["settings"]["Music"].AsInt);
                        PlayerPrefs.SetInt("Scan", data["settings"]["Scan"].AsInt);
                        PlayerPrefs.SetInt("fontSizeIndex", data["settings"]["fontSizeIndex"].AsInt);
                        PlayerPrefs.SetFloat("scanSpeed", data["settings"]["scanSpeed"].AsFloat);
                      Debug.Log("Voice: " + data["settings"]["Voice"].AsInt);
                      Debug.Log("Music: " + data["settings"]["Music"].AsInt);
                      Debug.Log("Scan: " + data["settings"]["Scan"].AsInt);

                    }
                    else
                    {
                        Debug.Log("User has no settings");
                    }
                    if (children != "None")
                    {
                        for (int i = 0; i < data["children"].Count; i++)
                        {
                                string playerName = data["children"][i]["username"].Value;
                                SaveAndLoad.listOfPlayers.Add(playerName);
                                Debug.Log("Adding " + playerName + " to messageBuffer");
                                if(!ClientGlobals.messageBuffer.ContainsKey(playerName))
                                    ClientGlobals.messageBuffer[playerName] = new Queue<string>();
                                int index = PlayerPrefs.GetInt(playerName);
                                if(index == 0)
                                    PlayerPrefs.SetInt(playerName, 0);
                        }
                        SaveAndLoad.Save();
                        SaveAndLoad.Load();
                    }
                    if(gameData != "None")
                    {
                        for (int i = 0; i < data["gameData"].Count; i++)
                        {
                            SaveAndLoad.gameData.Add(data["gameData"][i].ToString());
                            Debug.Log(data["gameData"][i].ToString());
                            /*
                            Debug.Log("Email: " + data["gameData"][i]["email"].Value);
                            Debug.Log("Correct: " + data["gameData"][i]["correctPercentage"].Value);
                            Debug.Log("Incorrect: " + data["gameData"][i]["incorrectPercentage"].Value);
                            Debug.Log("Date Earned: " + data["gameData"][i]["dateEarned"].Value);
                            Debug.Log("Completion Time: " + data["gameData"][i]["completionTime"].Value);
                            */
                        }
                    }
                    if (codeData != "None")
                    {
                        for (int i = 0; i < data["codeData"].Count; i++)
                        {
                            //SaveCode.Instance.saveTommyCode(data["codeData"].ToString());
                            if (SaveAndLoad.savedCode.ContainsKey(data["codeData"][i]["name"].Value))
                            {
                                SaveAndLoad.savedCode[data["codeData"][i]["name"].Value].Add(data["codeData"][i].ToString());
                                Debug.Log("Added");
                            }
                            else
                            {
                                SaveAndLoad.savedCode[data["codeData"][i]["name"].Value] = new List<string>();
                                SaveAndLoad.savedCode[data["codeData"][i]["name"].Value].Add(data["codeData"][i].ToString());
                                Debug.Log("Added and created new List");
                            }
                        }
                    }

                    SaveAndLoad.setCurrentPlayer(SaveAndLoad.listOfPlayers[0]);
                    break;
            }
         } else {
            errorLoggingIn = true;
            errorMessage = "Unable to establish a network connection. Please try again.";
            Debug.Log(errorMessage);
        }    
    } 
}