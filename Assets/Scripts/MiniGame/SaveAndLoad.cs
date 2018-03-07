using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using SimpleJSON;

public class SaveAndLoad : MonoBehaviour {

    public static List<string> listOfPlayers = new List<string>();
    public static List<string> gameData = new List<string>();
    public static List<string> scoreData = new List<string>();
    public static Dictionary<string, List<string>> savedCode = new Dictionary<string, List<string>>();   //Dictionary of lists -- used for detailed score page
    public static string[] currentPlayerArr = new string[5];
    public static bool loadedData = false;
    public static String dashEmail = "";    
    public static String dashPassword = "";
    public static String dashAccountType = "";
    public static String dashObjectId = "";

    public static void Clear()
    {
        listOfPlayers.Clear();
        gameData.Clear();
        scoreData.Clear();
        savedCode.Clear();
        currentPlayerArr = new string[5];
        Save();
    }

    public static void Logout()
    {
        Clear();
        SaveDash("", "", "", "");
        dashEmail = dashPassword = dashAccountType = dashObjectId = "";
        LoginToPortal.Instance.userIsLoggedIn = false;
        ClientGlobals.notConnectedToServer = false;
        PlayerPrefs.SetString("CurrentPlayer", ""); 
    }

    public static void setCurrentPlayer(string childName)
    {
        
        PlayerPrefs.SetString("CurrentPlayer", childName);
        childName = childName.ToLower();
        string playerEmail = childName + "_" + dashEmail;
        int index = 0;
        //sets the percentage score detail
        for(int i = 0; i < gameData.Count; i++)
        {
            var playerData = JSON.Parse(gameData[i]);
            string currentEmail = playerData["email"].Value;
            if(currentEmail == playerEmail)
            {
                Debug.Log("Current Player Data: " + playerData.ToString());
                currentPlayerArr[index] = playerData.ToString();
                index++;
            }
        }
    }
    public static void updateGameDataList()
    {
            string childName = PlayerPrefs.GetString("CurrentPlayer");
            childName = childName.ToLower();
            string playerEmail = childName + "_" + dashEmail;
            int index = 0;
            for(int i = 0; i < gameData.Count; i++)
            {
                var playerData = JSON.Parse(gameData[i]);
                string currentEmail = playerData["email"].Value;
                if(currentEmail == playerEmail)
                {
                    gameData[i] = currentPlayerArr[index];
                    index++;
                }
            }
            Save();
        }

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + Path.DirectorySeparatorChar+ "playerInfo.dat");

        PlayerData data = new PlayerData();

        data.listOfPlayers = listOfPlayers;
        data.gameData = gameData;
        data.scoreData = scoreData;

        bf.Serialize(file, data);
        file.Close();
    }

    public static void SaveDash(String email, String password, String AccountType, String objectId)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + Path.DirectorySeparatorChar + "playerDash.dat");

        Dash dashData = new Dash();
        dashData.dashEmail = email;
        dashData.dashPass = password;
        dashData.dashAccountType = AccountType;
        dashData.dashObjectId = objectId;

        bf.Serialize(file, dashData);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + Path.DirectorySeparatorChar + "playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            listOfPlayers = data.listOfPlayers;
            gameData = data.gameData;
            scoreData = data.scoreData;
        }
    }

    public static void LoadDash()
    {
        if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "playerDash.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + Path.DirectorySeparatorChar + "playerDash.dat", FileMode.Open);
            Dash data = (Dash)bf.Deserialize(file);
            file.Close();

            dashEmail = data.dashEmail;
            dashPassword = data.dashPass;
            dashAccountType = data.dashAccountType;
            dashObjectId = data.dashObjectId;
        }
        loadedData = true;
    }

    [Serializable]
    class PlayerData
    {
        public List<string> listOfPlayers = new List<string>();
        public List<string> gameData = new List<string>();
        public List<string> scoreData = new List<string>();
    }

    [Serializable]
    class Dash
    {
        public String dashEmail;
        public String dashPass;
        public String dashAccountType;
        public String dashObjectId;
    }
}
