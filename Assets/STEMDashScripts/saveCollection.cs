using UnityEngine;
using System.Collections;

public class saveCollection : Singleton<saveCollection> {
    protected saveCollection() { }

    public void saveOctoStore(string collectionData)
    {
        WWWForm form = new WWWForm();
        form.AddField("collectionData", collectionData);

        WWW www = new WWW(ServerURL.SaveCollection, form);              //Sends the data to server 
        StartCoroutine(WaitForCollectionRequest(www));       //Listen for the response 
    }

    IEnumerator WaitForCollectionRequest(WWW www)
    {
        yield return www;
        if(www.error == null)
        {
            Debug.Log(www.text);
        } else
        {
            Debug.Log("Error Occured: " + www.error); 
        }

    }
}
