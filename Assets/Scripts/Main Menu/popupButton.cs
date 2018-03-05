using UnityEngine;
using System.Collections;

public class popupButton : MonoBehaviour {

	public UIPanel popUpWindow;

	// Use this for initialization
	void Start () {
	
	}

	public void OnClick () {
		if (popUpWindow.alpha == 0)
		{
			popUpWindow.alpha = 1;
		}
		else
		{
			popUpWindow.alpha = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
