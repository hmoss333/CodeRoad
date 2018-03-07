using UnityEngine;
using System.Collections;

public class pollingData : Singleton<pollingData> {
    protected pollingData () {}
    private float time;
    private bool timeStarted;
    private int count;
    private int j;
	// Use this for initialization
	public void init() {
        count = 1;
        time = 0f;
        j = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //Sets expiration when retrieving data
        if(timeStarted)
        {
            time -= Time.deltaTime;
            if(time <= 0)
            {
                controlHours.childTimes.Clear();
                timeStarted = false;
                controlHours.dataRetrieved = true;
                count++;
            }
        }
	}
     public void retrieveData(string gameName)
    {
            time = 3f;
            timeStarted = true;
            j++;
            Debug.Log("Made it to retrieve data: " + j);
            string currentPlayer = PlayerPrefs.GetString("CurrentPlayer");
            WWWForm form = new WWWForm();  //Creates the form

            //Send data as post method
            form.AddField("email", SaveAndLoad.dashEmail);
            form.AddField("gameName", gameName);

            WWW www = new WWW(ServerURL.checkTime, form);              //Sends the data to server 

            StartCoroutine(WaitForControlRequest(www));       //Listen for the response
            //Debug.Log("Returned from server: " + count);
            //count++;
            //time = 1f;
    } 
    public void updateAndRetrieve(string gameName, float time)
    {
            time = 3f;
            timeStarted = true;
            j++;
            Debug.Log("Made it to retrieve data: " + j);
                   float min = (float) System.Math.Floor(time / 60f);
            string currentPlayer = PlayerPrefs.GetString("CurrentPlayer");
            WWWForm form = new WWWForm();  //Creates the form

            //Send data as post method
            form.AddField("email", SaveAndLoad.dashEmail);
            form.AddField("gameName", gameName);
            form.AddField("timeUsed", min.ToString());

            WWW www = new WWW(ServerURL.checkTime, form);              //Sends the data to server 

            StartCoroutine(WaitForControlRequest(www));       //Listen for the response
            //Debug.Log("Returned from server: " + count);
            //count++;
            //time = 1f;
    } 

    private IEnumerator WaitForControlRequest(WWW www)
    {
        yield return www;
        if(www.error == null)
        {
            if (www.text != "bad")
            {
                string jsonData = www.text;
                var data = SimpleJSON.JSON.Parse(jsonData);
                //Debug.Log("Made it to good control request: " + j);
                //Debug.Log(www.text);
                Debug.Log(data["verified"].Value);

                controlHours.isVerified = data["verified"].AsBool;

                controlHours.childTimes.Clear();

                for (int i = 0; i < data["controlTime"].Count; i++)
                {
                    controlHours.childTimes.Add(data["controlTime"][i]["childEmail"].Value, data["controlTime"][i]["remainingTime"].AsFloat);
                }

                /*
                // Loop over pairs with foreach.
                foreach (KeyValuePair<string, float> pair in controlHours.childTimes)
                {
                    Debug.Log("Key: " + pair.Key + " Value: " + pair.Value);
                }*/
                controlHours.dataRetrieved = true;
                timeStarted = false;
                time = 0f;
            } else
            {
                controlHours.childTimes.Clear();
                controlHours.dataRetrieved = true;
                timeStarted = false;
                time = 0f;
                Debug.Log("Made it to bad control request: ");
            }

        } else
        {
            controlHours.childTimes.Clear();
            controlHours.dataRetrieved = true;
            timeStarted = false;
            time = 0f;
            Debug.Log("Error occured: " + www.error);
        }
    }
}
