/*
    Handles when the user signs up:
        -Creates a new user
        -Adds that user to the control and progress objects
        -Sets default values for the control and progress objects
        -Sets the ACL and for the user.  

        Depends on the validation class for validation
 */

using UnityEngine;
using System.Collections;
using SimpleJSON;

public class SignupForPortal : Singleton<SignupForPortal> {
    protected SignupForPortal() { }
    private Validation validation;
    public bool validEmail, validUsername, validPassword, termsAgreed;
    public string emailMessage,  usernameMessage, passwordMessage, termsMessage;
    public string errorMessage;
    public bool error;
    public bool accountCreated;
    public bool signupSuccessful;
    public bool submittedForm;

    private string email, password, accountType;

    public void init()
    {
            validation = new Validation();
            validUsername = signupSuccessful = false;
            validEmail = validPassword = true;
            submittedForm = false;
            termsAgreed = false;
            error = false;
            emailMessage= "Email is not valid";
            usernameMessage= "Username must be 5\ncharacters or more";
            passwordMessage = "Password must be 8 characters\nor more and contain an\nuppercase letter and a number";
            termsMessage = "You must agree to our terms of service";
            errorMessage = "";
    }

    public void ClearData()
    {
            validUsername = signupSuccessful = false;
            validEmail = validPassword = true;
            submittedForm = false;
            termsAgreed = false;
            error = false;
    }

    public bool ValidateInput(string email, string password, bool agreedToTerms)
    {
        if (!validation.isValidEmail(email))
        {
            validEmail = false;
        } else
        {
            validEmail = true;
        }
        if(!validation.isValidPassword(password))
        {
            validPassword = false;
        } else
        {
            validPassword = true;
        }

        if(!agreedToTerms)
        {
            termsAgreed = false;
        } else
        {
            termsAgreed = true; 
        }

        submittedForm = true;
        if (validEmail && validPassword && termsAgreed)
        {
            return true;
        }

        return false;
    }

    public void Signup(string email, string password, string accountType)
    {
        WWWForm form = new WWWForm();  //Creates the form
        this.email = email.ToLower();
        this.password = password;
        this.accountType = accountType;

        //Send data as post method
        form.AddField("email", email);
        form.AddField("password", password);
        form.AddField("adultType", "");
        form.AddField("accountType", accountType);
#if UNITY_ANDROID
        form.AddField("platform", "Android");
#elif UNITY_IPHONE
        form.AddField("platform", "iOS");
#endif

        //Debug.Log("Account is Child");
        WWW www = new WWW(ServerURL.addUser, form);              //Sends the data to server 
        StartCoroutine(WaitForSignupRequest(www));       //Listen for the response
    }

    //Coroutine to determine if the was saved successfully or not
    IEnumerator WaitForSignupRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            switch (www.text)
            {
                case "usernameExists":
                    errorMessage = "The username already exists. Please enter another one";
                    error = true;
                    break;
                case "emailExists":
                    errorMessage = "The email is already in use. Please enter another one";
                    error = true;
                    break;
                case "emailAndusernameExists":
                    errorMessage = "The email and username are already in use. Please try again";
                    error = true;
                    break;
                case "badData":
                    errorMessage = "Email can contain only numbers and letters. Please try again.";
                    error = true;
                    break;
                case "error":
                    errorMessage = "An error occured. Please try again.";
                    error = true;
                    break;
                default:
                    error = false;
                    SaveAndLoad.SaveDash(this.email, this.password, this.accountType, "");
                    accountCreated = true;
                    break;
            }
            //Debug.Log(www.text);
        }
        else
        {
            Debug.Log(www.error);
            errorMessage = "Unable to establish a network connection. Please try again.";
            error = true;
        }
    }
}