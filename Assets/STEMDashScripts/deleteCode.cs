using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteCode : Singleton<deleteCode> {
    protected deleteCode() { }

    public void deleteTommyCode(string objectId)
    {
        WWWForm form = new WWWForm();  //Creates the form

        //Send data as post method
        form.AddField("objectId", objectId);
        //Debug.Log("Account is Child");
        WWW www = new WWW(ServerURL.deleteCode, form);              //Sends the data to server 
        StartCoroutine(WaitForDeleteCodeRequest(www));              //Listen for the response
    }

    //Coroutine to determine if the was saved successfully or not
    IEnumerator WaitForDeleteCodeRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
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
        }
        else
        {
            Debug.Log(www.error);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
