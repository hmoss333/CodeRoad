using UnityEngine;
using System.Collections;

public class SignUpInfo : Singleton<SignUpInfo> {
    protected SignUpInfo() { }
    public string username = "";
    public string email = "";
    public string firstname = "";
    public string lastname = "";
    public string password = "";
    public string accountType = "";
    public string adultEmail = "";
}
