using UnityEngine;
using UnityEngine.UI;

public class LoginLogout : MonoBehaviour {
    public Button logoutBtn, signupBtn , menuBtn, webportalBtn;
    private bool userSaved = false;
    private Session session;

	// Use this for initialization
	void Start () {
        this.logoutBtn.onClick.AddListener(new UnityEngine.Events.UnityAction(Logout));	
        this.signupBtn.onClick.AddListener(new UnityEngine.Events.UnityAction(Signup));
        this.menuBtn.onClick.AddListener(new UnityEngine.Events.UnityAction(GoToMenu));
        this.webportalBtn.onClick.AddListener(new UnityEngine.Events.UnityAction(GoToStemdash));

        session = new Session();

        //Loads the log in info
        session.Load();        
	}

    void GoToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScreen");
    }

    void Login()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Login_Scene");
    }

    void Signup()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Login_Scene");
    }

    void GoToStemdash()
    {
        Application.OpenURL("http://www.stemdash.com");
    }

    void Logout()
    {
        SaveAndLoad.SaveDash("", "", "", "");
        SaveAndLoad.Clear();
        controlHours.isVerified = true;
        controlHours.childTimes.Clear();
        session.Delete();
    }
	
	// Update is called once per frame
	void Update () {
        string user = SaveAndLoad.dashEmail;
        if(user != null)
        {
            signupBtn.gameObject.SetActive(false);
            logoutBtn.gameObject.SetActive(true);
                
            //Save user
            if(!userSaved)
            {
                session.Save();
                userSaved = true;
            }
        } else
        {

            //userNameTxt.text = "";
            logoutBtn.gameObject.SetActive(false);
            signupBtn.gameObject.SetActive(true);
            userSaved = false;
        }
	}
}

