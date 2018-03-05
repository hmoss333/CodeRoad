using UnityEngine;
using System;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class SaveAndLoad : MonoBehaviour {

    public static List<string> listOfPlayers = new List<string>();

    public static String dashName = "";     //This value is currently storing the email and not the username
    public static String dashPassword = "";  
  
    public static void Clear()
    {
        listOfPlayers.Clear();
        Save();
    }

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + Path.DirectorySeparatorChar+ "playerInfo.dat");

        PlayerData data = new PlayerData();
        data.listOfPlayers = listOfPlayers;

        bf.Serialize(file, data);
        file.Close();
    }

    public static void SaveDash(String name, String password)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + Path.DirectorySeparatorChar + "playerDash.dat");

        Dash dashData = new Dash();
        dashData.dashName = name;
        dashData.dashPass = password; 

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

            dashName = data.dashName;
            dashPassword = data.dashPass;
        }
    }

    [Serializable]
    class PlayerData
    {
        public List<string> listOfPlayers = new List<string>();
    }

    [Serializable]
    class Dash
    {
        public String dashName;
        public String dashPass;
    }

}
