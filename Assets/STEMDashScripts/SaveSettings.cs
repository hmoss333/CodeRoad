using UnityEngine;
using System.Collections;

public class SaveSettings : Singleton<SaveSettings>{

    protected SaveSettings() { }
    public bool saveWentOkay = false;
    public bool saveWentBad = false;
    
    public void saveSettings(string settingsData)
    {
        WWWForm form = new WWWForm();  //Creates the form

        //Send data as post method
        form.AddField("settingsData", settingsData);

        //Debug.Log("Account is Child");
        WWW www = new WWW(ServerURL.SaveSettings, form);              //Sends the data to server 
        StartCoroutine(WaitForSaveSettingsRequest(www));              //Listen for the response
    }

    //Coroutine to determine if the was saved successfully or not
    IEnumerator WaitForSaveSettingsRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            switch (www.text)
            {
                case "success":
                    Debug.Log("Success");
                    saveWentOkay = true;
                    break;
                default:
                    Debug.Log("Something went horribly wrong");
                    Debug.Log(www.text);
                    saveWentBad = true;
                    break;
            }
        }
        else
        {
            Debug.Log(www.error);
            saveWentBad = true;
        }
    }
}
