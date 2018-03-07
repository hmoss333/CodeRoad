using UnityEngine;
using System.Collections;

public class ResetProgress : Singleton<ResetProgress>{
    protected ResetProgress() { }

     public void resetProgress(string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("email", email);

        WWW www = new WWW(ServerURL.ResetProgress, form);              //Sends the data to server 
        StartCoroutine(WaitForChildRequest(www));       //Listen for the response
    }

    //Wait for child to be saved
    IEnumerator WaitForChildRequest(WWW www)
    {
        yield return www;
        if(www.error == null)
        {
            Debug.Log(www.text);
        } else
        {
            Debug.Log("Error: " + www.error);
        }
    }

}
