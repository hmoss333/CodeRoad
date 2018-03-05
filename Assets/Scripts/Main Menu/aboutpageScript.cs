using UnityEngine;
using System.Collections;

public class aboutpageScript : MonoBehaviour {

	public void ButtonOnClick_ParentZone_About_ForestFighter(){
		#if UNITY_IOS
		Application.OpenURL ("http://itunes.apple.com/app/id883405653");
		#endif

		#if UNITY_ANDROID
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.zyrobotics.forestfighter");
		#endif
	}
	public void ButtonOnClick_ParentZone_About_ZumoPlay(){
		#if UNITY_IOS
		Application.OpenURL ("http://itunes.apple.com/app/id1104281374");
		#endif

		#if UNITY_ANDROID
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.zyrobotics.zumoplay");
		#endif
	}
	public void ButtonOnClick_ParentZone_About_OctoPlus(){
		#if UNITY_IOS
		Application.OpenURL ("http://itunes.apple.com/app/id959757516");
		#endif

		#if UNITY_ANDROID
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.zyrobotics.octoplus");
		#endif
	}
	public void ButtonOnClick_ParentZone_About_OctoMinus(){
		#if UNITY_IOS
		Application.OpenURL ("http://itunes.apple.com/app/id983332666");
		#endif

		#if UNITY_ANDROID
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.zyrobotics.octominus");
		#endif
	}

	public void ButtonOnClick_ParentZone_About_CityCount(){
		#if UNITY_IOS
		Application.OpenURL ("http://itunes.apple.com/app/id1020037455");
		#endif

		#if UNITY_ANDROID
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.zyrobotics.citycount");
		#endif
	}

	public void ButtonOnClick_ParentZone_About_Zumo(){
		Application.OpenURL("http://zumolearning.com");
	}
	public void ButtonOnClick_ParentZone_About_Tabaccess(){
		Application.OpenURL("http://zyrobotics.com/wpcproduct/tabaccess/");
	}
	public void ButtonOnClick_ParentZone_About_Website(){
		Application.OpenURL("http://zyrobotics.com/ourproducts/");
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
