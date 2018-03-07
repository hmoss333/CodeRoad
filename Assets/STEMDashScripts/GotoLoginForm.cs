using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GotoLoginForm : MonoBehaviour {
    public Button loginBtn;
	// Use this for initialization
	void Start () {
        this.loginBtn.onClick.AddListener(new UnityEngine.Events.UnityAction(Login));	
	}

    void Login()
    {
        Application.LoadLevel("Login_Scene");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
