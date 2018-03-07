using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AccountType : MonoBehaviour {
    public Button BtnNext, BtnBack, BtnMenu;
    public Toggle IsChild, IsParent, IsTeacher;
    public string nextScene, prevScene;
    private string accountType;

	// Use this for initialization
	void Start () {
        accountType = SignUpInfo.Instance.accountType;
        this.BtnNext.onClick.AddListener(new UnityEngine.Events.UnityAction(NextScene));
        this.BtnBack.onClick.AddListener(new UnityEngine.Events.UnityAction(PrevScene));
        this.BtnMenu.onClick.AddListener(new UnityEngine.Events.UnityAction(Menu));

        switch(accountType)
        {
            case "":
                IsParent.isOn = true;
                break;
            case "Child":
                IsChild.isOn = true;
                break;
            case "Parent":
                IsParent.isOn = true;
                break;
            case "Teacher":
                IsTeacher.isOn = true;
                break;
        }
	}

    void Menu()
    {
        SignUpInfo.Instance.username = "";
        SignUpInfo.Instance.email = "";
        SignUpInfo.Instance.password = "";
        SignUpInfo.Instance.accountType = "";
        SignUpInfo.Instance.adultEmail = "";
        Application.LoadLevel("MenuScreen");
    }

    void NextScene()
    {
        if(IsChild.isOn)
        {
            SignUpInfo.Instance.accountType = "Child";
        } else if(IsParent.isOn)
        {
            SignUpInfo.Instance.accountType = "Parent";
        } else if(IsTeacher.isOn)
        {
            SignUpInfo.Instance.accountType = "Teacher";
        }

       // Debug.Log("Username: " + SignUpInfo.Instance.username);
       // Debug.Log("Email: " + SignUpInfo.Instance.email);
       // Debug.Log("Password: " + SignUpInfo.Instance.password);
       // Debug.Log("Account Type: " + SignUpInfo.Instance.accountType);
       Application.LoadLevel(nextScene);  
    }

    void PrevScene()
    {
        if(IsChild.isOn)
        {
            SignUpInfo.Instance.accountType = "Child";
        } else if(IsParent.isOn)
        {
            SignUpInfo.Instance.accountType = "Parent";
        } else if(IsTeacher.isOn)
        {
            SignUpInfo.Instance.accountType = "Teacher";
        }
        Application.LoadLevel(prevScene);  
    }
}
