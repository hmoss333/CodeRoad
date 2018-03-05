using UnityEngine;
using System.Xml;
using System.Collections;

public class MailChimpCore : MonoBehaviour {
	public string apiKey;
	public string listId;
	public string dataCenter;
	public string groupingsName;
	public string groupValue;
	public bool isErrored;
	public bool showLists;

	public static string uri = "http://<dc>.api.mailchimp.com/1.3/?output=xml&method=";
	public delegate void Callback (System.Xml.XmlDocument response);

	private Hashtable options;
	private string method;
	private Callback cb;

	public static MailChimpCore Instance ()
	{
		MailChimpCore _instance = null;
		GameObject anchor = GameObject.Find("MailChimpBlob");
		if (anchor == null) {
			anchor = new GameObject("MailChimpBlob");
			_instance = anchor.AddComponent<MailChimpCore>();
		} else if (anchor.GetComponent<MailChimpCore>() == null) {
			_instance = anchor.AddComponent<MailChimpCore>();
		} else {
			_instance = anchor.GetComponent<MailChimpCore>();
		}

		return _instance;
	}

	public void Start ()
	{
		if (apiKey.IndexOf("-") > 0) {
			string[] workingKey = apiKey.Split('-');
			this.apiKey = workingKey[0];
			this.dataCenter = workingKey[1];
		}

		if (this.showLists) {
			this.Lists();
		}
	}
	
	// Subscribes a user to your mail list.
	public void Subscribe (string firstname, string lastname, string email, Callback cb)
	{
		this.options					= new Hashtable();
		this.options["email_address"] 	= email;
		this.options["merge_vars[FNAME]"] = firstname;
		this.options["merge_vars[LNAME]"] = lastname;

		if (this.groupValue != "" && this.groupingsName != "") {
			this.options["merge_vars[GROUPINGS][0][name]"] = this.groupingsName;
			this.options["merge_vars[GROUPINGS][0][groups]"] = this.groupValue;
		}

		this.method 					= "listSubscribe";
		this.cb 						= cb;

		try {

			StartCoroutine("Finish");

		} catch (System.Exception e) {
			Debug.LogWarning(e);
		}
	}

	// Returns a list of all your lists so you can establish a list id to assign new subscriptions to.
	public void Lists ()
	{
		this.options 				= new Hashtable();
		this.options["start"]		= 0;
		this.options["limit"]		= 25;
		this.options["sortField"]	= "created";
		this.options["sortDir"]		= "DESC";

		try {
			this.method = "lists";
			this.cb = delegate (System.Xml.XmlDocument response) {
				System.Xml.XmlNodeList lists = response.GetElementsByTagName("struct");
				foreach (System.Xml.XmlNode node in lists) {
					Debug.Log(node.SelectNodes("id")[0].InnerText + " // " + node.SelectNodes("name")[0].InnerText);
				}
			};
			StartCoroutine("Finish");
		} catch (System.Exception e) {
			Debug.LogWarning(e);
		}
	}

	// This method invokes the actual request to MailChimp and passes the result back to the callback specified.
	private IEnumerator Finish ()
		//string method, Hashtable options, Callback cb)
	{
		if (apiKey == null) {
			Debug.Log("Exception");
			throw new System.Exception("Cannot call MailChimp without an API Key. Sorry.");
		}

		if (dataCenter == null) {
			Debug.Log("Exception");
			throw new System.Exception("Cannot call MailChimp without an API Key. Sorry.");
		}

		// build url
		//
		string requestUrl = uri.Replace("<dc>", dataCenter) + this.method;
		Debug.Log("To Request URL " + requestUrl);

		// assemble post body
		//
		WWWForm post = new WWWForm();
		foreach(DictionaryEntry dt in this.options) {
			post.AddField(dt.Key.ToString(), dt.Value.ToString());
		}

		post.AddField("apikey", this.apiKey);

		if (this.listId != null) {
			post.AddField("id", this.listId);
		}

		// create connection socket
		//
		WWW connection = new WWW(requestUrl, post);

		// deliver payload
		//
		yield return connection;
		// handle response and invoke callback

		System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
		doc.LoadXml(connection.text);
		System.Xml.XmlNodeList errors = doc.GetElementsByTagName("error");

		if (errors.Count > 0) {
			this.isErrored = true;
		} else {
			this.isErrored = false;
        }

		Debug.Log(connection.text);

		cb(doc);
	}

}

