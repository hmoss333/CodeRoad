/*********************************************************************
 *      Session 
 *      This class is used as a session handler.  It keeps track
 *      if a user is currently logged in or not.  The class 
 *      is dependent on serialization of the serializedUser class
 *      in order to save data and load it into the user singleton.
 * 
 * *******************************************************************/

using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Session {
    string path;

    public Session()
    {
        path = Application.persistentDataPath + "/loginData.dat";
    }

    //Save log in info
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);

        serializedUser user = new serializedUser();
        user.username = User.Instance.username;
        user.email = User.Instance.email;
        user.objectID = User.Instance.objectId;
        user.accountType = User.Instance.accountType;

        bf.Serialize(file, user);

        file.Close();
    }

    //Load in log in data
    public void Load()
    {
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            serializedUser user = (serializedUser)bf.Deserialize(file);
            file.Close();
            User.Instance.username = user.username;
            User.Instance.email = user.email;
            User.Instance.objectId = user.objectID;
            User.Instance.accountType = user.accountType;
        }
    }

    //Deletes login info
    public void Delete()
    {
        if (File.Exists(path))
        {
            File.Delete(path);
            User.Instance.username = null;
            User.Instance.email = null;
            User.Instance.objectId = null;
            User.Instance.accountType = null;
        }
    }
}
