using UnityEngine;
using System.Collections;
using SimpleJSON;

public class DeletePlayer : Singleton<DeletePlayer> {
    protected DeletePlayer() { }

    public bool deleteSuccess;
    public bool deleteError;

    public void init() {
        deleteSuccess = false;
    }

    void deleteLocalInstance(string player)
    {
        SaveAndLoad.listOfPlayers.Remove(player);
        string playerEmail = player + "_" + SaveAndLoad.dashEmail;

        //Remove Percent Data
        for(int i = 0; i < SaveAndLoad.gameData.Count; i++)
        {
            var playerData = JSON.Parse(SaveAndLoad.gameData[i]);
            if(playerData["email"].Value == playerEmail)
            {
                SaveAndLoad.gameData.RemoveAt(i);       
            }
        }
    }

    //Delete child from database
    public void deleteChild(string player)
    {
        WWWForm form = new WWWForm();  //Creates the form

        deleteLocalInstance(player);

        //Send data as post method
        form.AddField("email", player + "_" + SaveAndLoad.dashEmail);
        form.AddField("adultType", SaveAndLoad.dashAccountType);

        //Debug.Log("Account is Child");
        WWW www = new WWW(ServerURL.deletePlayer, form);              //Sends the data to server 
        StartCoroutine(WaitForDeleteRequest(www));              //Listen for the response
    }

    //Wait for child to be saved
    IEnumerator WaitForDeleteRequest(WWW www)
    {
        yield return www;
        if (www.error == null)
        {
            switch(www.text)
            {
                case "Deleted":
                    deleteSuccess = true;
                    Debug.Log("Deleted");
                    break;
                case "Not Deleted":
                    deleteError = true;
                    Debug.Log("Not Deleted");
                    break;
            }
        }
        else
        {
            deleteError = true;
            Debug.Log("Something went wrong");
        }
    }
}
