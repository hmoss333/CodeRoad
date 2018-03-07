using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ResetSignupForm : MonoBehaviour {
    public InputField TxtUsername, TxtPassword, TxtFirstname, TxtLastname, TxtEmail;
    public Button BtnReset;

	// Use this for initialization
	void Start () {
        try
        {
            this.BtnReset.onClick.AddListener(new UnityEngine.Events.UnityAction(ClearFields));
        } catch(NullReferenceException ex) {}	
	}
	
    void ClearFields()
    {
        TxtFirstname.text = "";
        TxtLastname.text = "";
        TxtPassword.text = "";
        TxtUsername.text = "";
        TxtEmail.text = "";
    }

	// Update is called once per frame
	void Update () {
	
	}
}
