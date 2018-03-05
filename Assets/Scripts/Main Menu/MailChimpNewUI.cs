using UnityEngine;
using System.Collections;

public class MailChimpNewUI : MonoBehaviour {
	public string apiKey;
	public string listId;
	public string dataCenter;
	public string groupingsName;
	public string groupValue;
	public string loadLevelOnSuccess = "";
	public string formTitle = "Register to Receive Updates";
	public delegate void Callback ();

	public bool isDrawn = false;
	public bool isShowingAlert = false;
	private Hashtable options = new Hashtable();
	private string alertMessage = "";

	UIInput UI_FirstName;
	UIInput UI_LastName;
	UIInput UI_Email;
	GameObject UI_Button_SignUp;
	GameObject Step1;
	UILabel UI_Alert;

	void Start(){
		UI_FirstName=GameObject.Find ("Input_FirstName").GetComponent<UIInput>();
		UI_LastName=GameObject.Find ("Input_LastName").GetComponent<UIInput>();
		UI_Email=GameObject.Find ("Input_Email").GetComponent<UIInput>();
		UI_Button_SignUp=GameObject.Find ("Button_SignUp");
		UIEventListener.Get (UI_Button_SignUp).onClick = Connect;
		Step1=GameObject.Find("Step1");
		UI_Alert=GameObject.Find ("Alert").GetComponent<UILabel>();
	}
	
	void OnGUI () 
	{
		if (options == null) {
			options = new Hashtable();
		}
		//Read data from Input
	
		Enter();
//		if (isDrawn) {
//			
//			// Show Signup Box
//
//			GUILayout.BeginArea(
//				new Rect(
//				Screen.width * 0.25f,
//				Screen.height * 0.25f,
//				Screen.width * 0.5f,
//				Screen.height * 0.25f
//				)
//				);
//			
//			GUILayout.BeginVertical("box");
//			
//			GUILayout.Box(formTitle);
//			
//			Field("First Name", "FNAME");
//			GUILayout.FlexibleSpace();
//			Field("Last Name", "LNAME");
//			GUILayout.FlexibleSpace();
//			Field("Email", "email_address");
//			GUILayout.FlexibleSpace();
//			
//			GUILayout.BeginHorizontal();
//			GUILayout.FlexibleSpace();
//
//			GUILayout.FlexibleSpace();
//			GUILayout.EndHorizontal();
//			
//			GUILayout.EndVertical();
//			
//			GUILayout.EndArea();
//		}
		
//		if (this.isShowingAlert) {
//			GUILayout.BeginArea(
//				new Rect(
//				Screen.width * 0.3f,
//				Screen.height * 0.2f,
//				Screen.width * 0.4f,
//				Screen.height * 0.2f
//				)
//				);
//			
//			GUILayout.BeginVertical("box");
//			
//			GUILayout.FlexibleSpace();
//			GUILayout.BeginHorizontal();
//			
//			GUILayout.FlexibleSpace();
//			GUILayout.Label(this.alertMessage);
//			GUILayout.FlexibleSpace();
//			
//			GUILayout.EndHorizontal();
//			GUILayout.FlexibleSpace();
//			
//			GUILayout.EndVertical();
//			
//			GUILayout.EndArea();
//		}
	}
	
	bool Validate ()
	{
		bool result = false;
		if (options.Contains("email_address") &&
		    options.Contains("FNAME") &&
		    options.Contains("LNAME")) {
			if (options["email_address"].ToString().IndexOf("@") > 0 &&
			    options["FNAME"].ToString() != "" &&
			    options["LNAME"].ToString() != "") {
				result = true;
			}
		}
		return result;
	}
	/*
	void Field (string label, string name) {
		GUILayout.BeginHorizontal();
		GUILayout.Label(label, GUILayout.Width(Screen.width * 0.2f));
		if (!options.Contains(name)) {
			options[name] = "";
		}
		options[name] = GUILayout.TextField(options[name].ToString());
		GUILayout.EndHorizontal();
	}
  */
	void Enter () {
		if (!options.Contains("FNAME")) {
			options["FNAME"] = "";
		}
		options["FNAME"] = UI_FirstName.value;

		if (!options.Contains("LNAME")) {
			options["LNAME"] = "";
		}
		options["LNAME"] = UI_LastName.value;

		if (!options.Contains("email_address")) {
			options["email_address"] = "";
		}
		options["email_address"] = UI_Email.value;

	}
	/*
	private IEnumerator Alert (string message, Callback cb)
	{
		this.alertMessage = message;
		this.isShowingAlert = true;
		this.isDrawn = false;
		yield return new WaitForSeconds(3f);
		this.isShowingAlert = false;
		this.isDrawn = true;
		this.alertMessage = "";
		if (cb != null) {
			cb();
		}
	}
	*/

	void Connect(GameObject SignUp){
		//if (GUILayout.Button("Sign Up!")) {
			// do the thing
			if (Validate()) {
				//StartCoroutine(Alert("Sit Tight", null));
				UI_Alert.text="Connecting";	
				MailChimpCore mc = MailChimpCore.Instance(); 
				mc.apiKey = this.apiKey;
				mc.listId = this.listId;
				mc.dataCenter = this.dataCenter;
				mc.groupValue = this.groupValue;
				mc.groupingsName = this.groupingsName;
				
				mc.Subscribe(
					options["FNAME"].ToString(),
					options["LNAME"].ToString(),
					options["email_address"].ToString(),
					delegate (System.Xml.XmlDocument doc) {
					if (mc.isErrored) {
						// Display alert box.
						System.Xml.XmlNodeList codes = doc.GetElementsByTagName("code");
						int errCode = 0;
						if (codes.Count > 0) {
							errCode = int.Parse(codes[0].InnerText);
						}
						
						switch (errCode) {
						case 214:
							//StartCoroutine(Alert("According to our records, you're already registered. Also, You Rock!", null));
						UI_Alert.text="According to our records, you're already registered. \n Also, You Rock!";
							break;
						default:
							//StartCoroutine(Alert("There was a problem with your submission, try again later.", null));
							UI_Alert.text="There was a problem with your submission, try again later.";
							break;
						}
					} else {
						// Test out
						// Show thanks
					    UI_Alert.text="Thank you for signing up! \n Check your inbox to confirm your subscription.";
//						this.isDrawn = false;
//						StartCoroutine(Alert("You are awesome (and good looking.) We'll be in touch.", delegate () {
//							if (this.loadLevelOnSuccess != "") {
//								Application.LoadLevel(this.loadLevelOnSuccess);
//							} else {
//								this.isDrawn = false;
//							}
//						}));
					}
				}
				);
			} else {
				// Display alert that fields need values.
				//StartCoroutine(Alert("There seems to be a problem with some of the values you entered, did you fill out the whole form?", null));
			UI_Alert.text="There seems to be a problem with some of the values you entered,\n did you fill out the whole form?";
			}
		//}
	}

}
