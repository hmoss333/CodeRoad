using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class STEMDashController : MonoBehaviour {
    //Canvas
    GameObject loginCanvas; 
    GameObject loggingInCanvas; 
    GameObject signupCanvas; 
    GameObject signingUpCanvas;
    GameObject termsPopup;

    //Input Fields
    InputField txtLoginPassword;
    InputField txtLoginEmail;
    InputField txtsignupEmail;
    InputField txtsignupPassword;
    InputField txtsignupConfirmPassword;

    //Labels
    Text lblLoginStatus;
    Text emailValidationTxt;
    Text passwordValidationTxt;
    Text passConfirmValidationTxt;
    Text lblsignupStatus;
    Text LoggingInLabel;
    Text creatingAccountLabel;

    Toggle parentRadio;
    Toggle teacherRadio;
    Toggle termsCheck;

    bool validationPassed;

    //Needed to swap menus on initial load
    public enum STEMDashMenu { Login, Signup };
    public static STEMDashMenu CurrentMenu; 

    Validation validation;

	// Use this for initialization
	void Start () {
        validationPassed = false;
        validation = new Validation();
        //Initialize canvas'
        loginCanvas = GameObject.Find("LoginCanvas");
        loggingInCanvas = GameObject.Find("LoggingInCanvas");
        signupCanvas = GameObject.Find("SignupCanvas");
        signingUpCanvas = GameObject.Find("SigningUpCanvas");
        termsPopup = GameObject.Find("TermsPopup");

        //Initialize Input Fields
        txtLoginEmail = GameObject.Find("txtLoginEmail").GetComponent<InputField>();
        txtLoginPassword = GameObject.Find("txtLoginPassword").GetComponent<InputField>();
        txtsignupEmail = GameObject.Find("txtsignupEmail").GetComponent<InputField>();
        txtsignupPassword = GameObject.Find("txtsignupPassword").GetComponent<InputField>();
        txtsignupConfirmPassword = GameObject.Find("txtsignupConfirmPassword").GetComponent<InputField>();

        //Labels
        lblLoginStatus = GameObject.Find("lblloginStatus").GetComponent<Text>();
        emailValidationTxt = GameObject.Find("emailValidationTxt").GetComponent<Text>();
        passwordValidationTxt = GameObject.Find("passwordValidationTxt").GetComponent<Text>();
        passConfirmValidationTxt = GameObject.Find("passConfirmValidationTxt").GetComponent<Text>();
        lblsignupStatus = GameObject.Find("lblsignupStatus").GetComponent<Text>();
        LoggingInLabel = GameObject.Find("LoggingInLabel").GetComponent<Text>();
        creatingAccountLabel = GameObject.Find("creatingAccountLabel").GetComponent<Text>();

        parentRadio = GameObject.Find("parentCheck").GetComponent<Toggle>();
        teacherRadio = GameObject.Find("teacherCheck").GetComponent<Toggle>();
        termsCheck = GameObject.Find("TermsCheck").GetComponent<Toggle>();

        LoginToPortal.Instance.init();
        SignupForPortal.Instance.init();

        clearLoginValidationText();
        clearsignupValidationText();
        disableTermsPopup();
        showStartupMenu();
	}

    void showStartupMenu()
    {
        switch(CurrentMenu)
        {
            case STEMDashMenu.Login:
                showLoginCanvas();
                break;
            case STEMDashMenu.Signup:
                showSignUpCanvas();
                break;
        }
    }

    public void showTermsPop()
    {
        termsPopup.SetActive(true);
    }

    public void disableTermsPopup()
    {
        termsPopup.SetActive(false);
    }

    public void showSignUpCanvas()
    {
        loginCanvas.SetActive(false);
        loggingInCanvas.SetActive(false);
        signupCanvas.SetActive(true);
        signingUpCanvas.SetActive(false);
    }

    public void showLoginCanvas()
    {
        loginCanvas.SetActive(true);
        loggingInCanvas.SetActive(false);
        signupCanvas.SetActive(false);
        signingUpCanvas.SetActive(false);
    }

    public void showLoggingInCanvas()
    {
        loginCanvas.SetActive(false);
        loggingInCanvas.SetActive(true);
        signupCanvas.SetActive(false);
        signingUpCanvas.SetActive(false);
    }

    public void showSigningInCanvas()
    {
        loginCanvas.SetActive(false);
        loggingInCanvas.SetActive(false);
        signupCanvas.SetActive(false);
        signingUpCanvas.SetActive(true);
    }

    public void signupForSTEMDash()
    {
        if (txtsignupPassword.text.Equals(txtsignupConfirmPassword.text))
        {
            passConfirmValidationTxt.text = "";
            if (SignupForPortal.Instance.ValidateInput(txtsignupEmail.text, txtsignupPassword.text, termsCheck.isOn))
            {
                SignupForPortal.Instance.ClearData();
                if(parentRadio.isOn)
                    SignupForPortal.Instance.Signup(txtsignupEmail.text, txtsignupPassword.text, "Parent");
                else
                    SignupForPortal.Instance.Signup(txtsignupEmail.text, txtsignupPassword.text, "Teacher");
                validationPassed = true;
                showSigningInCanvas();
            } else
            {

                validationPassed = false;
            }
        } else
        {
            if (validation.isValidEmail(txtsignupEmail.text))
            {
                SignupForPortal.Instance.validEmail = true;
                emailValidationTxt.text = "";
                Debug.Log("Valid email");
            }
            if (validation.isValidPassword(txtsignupPassword.text))
            {
                SignupForPortal.Instance.validPassword= true;
                passwordValidationTxt.text = "";
                Debug.Log("Valid Password");
            }
            if(termsCheck.isOn)
            {
                SignupForPortal.Instance.termsAgreed = true;
                lblsignupStatus.text = "";
            }
            passConfirmValidationTxt.text = "Passwords do not match";
        }
    }

    public void loginIntoSTEMDash()
    {
        clearLoginValidationText();
        if (txtLoginEmail.text == "" && txtLoginPassword.text != "")
        {
            lblLoginStatus.text = "Email field cannot be empty";
        }
        else if (txtLoginEmail.text != "" && txtLoginPassword.text == "")
        {
            lblLoginStatus.text  = "Password field cannot be empty";
        }
        else if (txtLoginEmail.text == "" && txtLoginPassword.text == "")
        {
            lblLoginStatus.text = "Password and email fields cannot be empty";
        }
        else
        {
            showLoggingInCanvas(); 
            LoginToPortal.Instance.Login(txtLoginEmail.text, txtLoginPassword.text);
        }
    }
    public void showMenu()
    {
        StartCoroutine(showMainMenu());
    }

    IEnumerator showMainMenu()
    {
        yield return new WaitForSeconds(0.1f);
        LoadManager.level = "Title";
        SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Additive);
        Application.LoadLevel("MenuScreen");
    }

    void clearsignupValidationText()
    {
        emailValidationTxt.text = "";
        passwordValidationTxt.text = "";
        passConfirmValidationTxt.text = "";
        lblsignupStatus.text = "";
    }

    void clearLoginValidationText()
    {
        lblLoginStatus.text = "";
    }

    void loginRoutine()
    {
        if(LoginToPortal.Instance.userIsLoggedIn)
        {
            LoggingInLabel.text = "Success!";
            StartCoroutine(showMainMenu());  
        }
        if(LoginToPortal.Instance.errorLoggingIn)
        {
            LoginToPortal.Instance.errorLoggingIn = false;
            lblLoginStatus.text = LoginToPortal.Instance.errorMessage;
            showLoginCanvas();
        }
    }

    void signupRoutine()
    {
        if (!SignupForPortal.Instance.validEmail)
        {
            emailValidationTxt.text = SignupForPortal.Instance.emailMessage;
        }
        else
        {
            emailValidationTxt.text = "";
        }

        if (!SignupForPortal.Instance.validPassword)
        {
            passwordValidationTxt.text = SignupForPortal.Instance.passwordMessage;
        }
        else
        {
            passwordValidationTxt.text = "";
        }

        if(SignupForPortal.Instance.submittedForm)
        {
            SignupForPortal.Instance.submittedForm = false;
            if(!SignupForPortal.Instance.termsAgreed)
            {
                lblsignupStatus.text = SignupForPortal.Instance.termsMessage;
            } else
            {
                lblsignupStatus.text = "";
            }
        }

        if (SignupForPortal.Instance.error && validationPassed)
        {
            showSignUpCanvas(); 
            lblsignupStatus.text = SignupForPortal.Instance.errorMessage;
        }

        if(SignupForPortal.Instance.accountCreated)
        {
            SignupForPortal.Instance.accountCreated = false;
            creatingAccountLabel.text = "Success";
            StartCoroutine(showMainMenu());  
        }
    }

	// Update is called once per frame
	void Update () {
        loginRoutine();
        signupRoutine();
	}
}
