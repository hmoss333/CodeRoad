/*********************************************************************
 *      Validation
 *      This class is used to validate text data.
 *      It uses regular expressions in order to accomplish
 *      validation tasks.
 * 
 * *******************************************************************/

using System;
using System.Text.RegularExpressions;
using UnityEngine;

public class Validation {
    //Validation Block - Uses regular rexpressions for validation

    public bool isValidUsername(string username)
    {
        if (username.Length >= 5)
        {
            return true;
        }
        return false;
    }

    public bool notSameEmail(string childEmail, string adultEmail)
    {
        if (childEmail != adultEmail)
        {
            return true;
        }
        return false;
    }

    public bool isValidFirstName(string firstName)
    {
        if (firstName.Length <= 0)
        {
            return false;
        }
        return true;
    }

    public bool isValidLastName(string lastName)
    {
        if (lastName.Length <= 0)
        {
            return false;
        }
        return true;
    }

    public bool isValidEmail(string email)
    {
        string emailPattern = @"^(\w+)@(\w+)[.]([a-z]+)$";
        Match match = Regex.Match(email, emailPattern);
        if (match.Success)
        {
            return true;
        }
        return false;
    }

    public bool isValidAdultEmail(string childEmail, string adultEmail)
    {
        bool same = false;
        string emailPattern = @"^(\w+)@(\w+)[.]([a-z]+)$";
        Match match = Regex.Match(adultEmail, emailPattern);
        if(childEmail == adultEmail)
        {
            same = true;
        }

        if (match.Success && !same)
        {
            Debug.Log("Made it here");
            return true;
        } 

        return false;
    }

    //Password is being validated to make sure that it contains 1 uppercase character,
    //one number, and is at least 8 characters long
    public bool isValidPassword(string password)
    {
        string uppercasePattern = @"[A-Z]";
        string numberPattern = @"[0-9]";
        Match numberMatch = Regex.Match(password, numberPattern);
        Match uppercaseMatch = Regex.Match(password, uppercasePattern);
        if (uppercaseMatch.Success && numberMatch.Success && password.Length >= 8)
        {
            return true;
        }

        return false;
    }
}
