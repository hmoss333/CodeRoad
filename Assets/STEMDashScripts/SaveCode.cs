using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCode : Singleton<SaveCode> {

    protected SaveCode() { }

    public void saveTommyCode(string codeData)
    {
        WWWForm form = new WWWForm();  //Creates the form

        //Send data as post method
        form.AddField("codeData", codeData);

        //Debug.Log("Account is Child");
        WWW www = new WWW(ServerURL.SaveCode, form);              //Sends the data to server 
        StartCoroutine(WaitForSaveCodeRequest(www));              //Listen for the response
    }

    //Coroutine to determine if the was saved successfully or not
    IEnumerator WaitForSaveCodeRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log(www.text);
            if (www.text != "error")
            {
                if (SaveAndLoad.savedCode.ContainsKey(PlayerPrefs.GetString("CurrentPlayer")))
                {
                    SaveAndLoad.savedCode[PlayerPrefs.GetString("CurrentPlayer")].Add(www.text);
                    Debug.Log("Added");
                }
                else
                {
                    SaveAndLoad.savedCode[PlayerPrefs.GetString("CurrentPlayer")] = new List<string>();
                    SaveAndLoad.savedCode[PlayerPrefs.GetString("CurrentPlayer")].Add(www.text);
                    Debug.Log("Added and created new List");
                }
                finishedSavingHandler.finishedSaving();
            } else
            {
                finishedSavingHandler.saveError();
            }
            /*
            switch (www.text)
            {
                case "success":
                    Debug.Log("Success");
                    break;
                default:
                    Debug.Log("Something went horribly wrong");
                    Debug.Log(www.text);
                    break;
            }
            */
        }
        else
        {
            Debug.Log(www.error);
            finishedSavingHandler.saveError();
        }
    }

	// Use this for initialization
	void Start () {
	    	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
