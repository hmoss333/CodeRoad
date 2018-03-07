using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointHandler : MonoBehaviour {
    public static Dictionary<string, float> numberOfChallenges = new Dictionary<string, float>();
    public static float completedChallenges = 0.0f;
    public static float correctPercentage = 0.0f;
    public static float incorrectPercentage = 0.0f;
    public static float incorrect = 0.0f;
    public static string currentGameChallenge = "";

    public static void init()
    {
        Debug.Log("Point handler init was called");
        numberOfChallenges["Movement1"] = 3.0f;
        numberOfChallenges["Abilities1"] = 4.0f;
        numberOfChallenges["Loops1"] = 2.0f;
        numberOfChallenges["Combos1"] = 3.0f;
        currentGameChallenge = SceneManager.GetActiveScene().name;
    }

    public static void calculatePercentages() {
        if (completedChallenges > 0)
        {
            float percentageOfCompletedChallenges = (completedChallenges / numberOfChallenges[currentGameChallenge]);
            float percentageNotCompletedChallenges = 1 - percentageOfCompletedChallenges;
            incorrectPercentage = ((incorrect * 1.5f) / 100.0f) + percentageNotCompletedChallenges;

            correctPercentage = 1 - incorrectPercentage;
            if (correctPercentage < 0.0f)
            {
                correctPercentage = 0.0f;
                incorrectPercentage = 1.0f;
            }
            correctPercentage = (float)Math.Round(correctPercentage * 100.0f);
            incorrectPercentage = (float)Math.Round(incorrectPercentage * 100.0f);
            Debug.Log("Correct Percentage: " + correctPercentage);
            Debug.Log("Incorrect Percentage: " + incorrectPercentage);
        }
        else
        {
            correctPercentage = 0.0f;
            incorrectPercentage = 0.0f;
            Debug.Log("Correct Percentage: " + correctPercentage);
            Debug.Log("Incorrect Percentage: " + incorrectPercentage);
        }
    }
    public static void resetPoints()
    {
         completedChallenges = 0.0f;
         correctPercentage = 0.0f;
         incorrectPercentage = 0.0f;
         incorrect = 0.0f;
    }
}

