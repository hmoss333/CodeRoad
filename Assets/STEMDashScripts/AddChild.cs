using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class AddChild : Singleton<AddChild> {
    protected AddChild() { }
    public bool finishedAddingChild;
    public bool emailExists;
    public bool badData;
    public bool errorOccured;
    public bool serverError;
    public bool duplicateName;
    public bool notContainsLetter;
    public bool hasNewLine;
    public bool listCountExceeded;

    public string dupeNameMessage;
    public string notLetterMessage;
    public string hasNewLineMessage;
    public string listCountExeededMessage;
    public string playerExistsMessage;

    private string childName;

    public void clearData()
    {
        finishedAddingChild = false;
        emailExists = false;
        badData = false;
        errorOccured = false;
        serverError = false;
        notContainsLetter = false;
        duplicateName = false;
        hasNewLine = false;
        listCountExceeded = false;
    }

    void Start()
    {
        finishedAddingChild = false;
        emailExists = false;
        badData = false;
        errorOccured = false;
        serverError = false;
        notContainsLetter = false;
        duplicateName = false;
        hasNewLine = false;
        listCountExceeded = false;

        dupeNameMessage = "Name already exists.";
        notLetterMessage = "Name can contain only letters.";
        hasNewLineMessage = "Name cannot contain newline character.";
        listCountExeededMessage = "You have exceeded the maximum number of children allowed.";
        playerExistsMessage = "Player already exists";

        childName = "";
    }

    bool setFlag(bool flag)
    {
        if (!flag)
            return true;
        return false;
    }

    bool containsLetter(string newPlayerName)
    {
        bool answer = true;
        string pattern = @"^[a-zA-Z]{1,25}$";   //Match only upper case and lowercase

        Regex r = new Regex(pattern);

        answer = r.IsMatch(newPlayerName);

        notContainsLetter = setFlag(answer);

        return answer;
    }

    bool notDuplicateName(string newPlayerName)
    {
        bool answer = true;
        if (SaveAndLoad.listOfPlayers.Contains(newPlayerName))
        {
            answer = false;
        }

        duplicateName = setFlag(answer);

        return answer;
    }

    bool noNewLine(string newPlayerName)
    {
        bool answer = true;
        Regex r = new Regex("\n");
        answer = !r.IsMatch(newPlayerName);

        hasNewLine = setFlag(answer);

        return answer;
    }

    bool listCountNotExceeded()
    {
        bool answer = false;
        if(SaveAndLoad.listOfPlayers.Count < 10)
            answer = true;

        listCountExceeded = setFlag(answer);

        return answer;
    }

    public bool IsValid(string newPlayerName)
    {
        if (noNewLine(newPlayerName) && notDuplicateName(newPlayerName) && containsLetter(newPlayerName) && listCountNotExceeded())
                return true;
        return false;
    }

    public void AddUserChild(string childName)
    {
        clearData();
        Debug.Log("Child Name: " + childName);
        if (IsValid(childName))
        {
            this.childName = childName;
            Debug.Log("Child Name: " + childName);
            string playerName = this.childName.ToLower();
            WWWForm form = new WWWForm();
            string playerEmail = playerName + "_" + SaveAndLoad.dashEmail;
            Debug.Log("Child email: " + playerEmail);
            Debug.Log("AccountType: " + SaveAndLoad.dashAccountType);
            form.AddField("username", childName);
            form.AddField("email", childName + "_" + SaveAndLoad.dashEmail);
            form.AddField("accountType", "Child");
            form.AddField("adultType", SaveAndLoad.dashAccountType);
            form.AddField("adultEmail", SaveAndLoad.dashEmail);

            WWW www = new WWW(ServerURL.addUser, form);              //Sends the data to server 
            StartCoroutine(WaitForChildRequest(www));       //Listen for the response
        }
        else
            Debug.Log("Not Valid");
    }

    //Wait for child to be saved
    IEnumerator WaitForChildRequest(WWW www)
    {
        yield return www;
        if(www.error == null)
        {
            switch(www.text)
            {
                case "good":
                    string playerName = this.childName.ToLower();
                    string playerEmail = playerName + "_" + SaveAndLoad.dashEmail;
                    string percentData = "{";
                    percentData += "\"email\":\"" + playerEmail + "\",";
                    percentData += "\"correctPercentage\":\"0\",";
                    percentData += "\"incorrectPercentage\":\"0\",";
                    percentData += "\"dateEarned\":\"None\",";
                    percentData += "\"completionTime\": \"0\"";
                    percentData += "}"; 

                    if(!ClientGlobals.messageBuffer.ContainsKey(childName))
                        ClientGlobals.messageBuffer[childName] = new Queue<string>();

                    SaveAndLoad.listOfPlayers.Add(this.childName);

                    for (int i = 0; i < 5; i++)
                    {
                       SaveAndLoad.gameData.Add(percentData);
                    }

                    SaveAndLoad.setCurrentPlayer(this.childName);
                    SaveAndLoad.Save();
                    finishedAddingChild = true;
                    Debug.Log("Saved");
                    break;
                case "emailExists":
                    emailExists = true;
                    Debug.Log("User exists");
                    break;
                case "badData":
                    badData = true;
                    Debug.Log("Not Saved: " + www.text);
                    break;
                default:
                    errorOccured = true;
                    Debug.Log("Not Saved: " + www.text);
                    break;
            }
        } else
        {
            serverError = true;
            Debug.Log("Error: " + www.error);
        }
    }
}
