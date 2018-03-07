using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class controlHours : MonoBehaviour {
    public static bool isVerified = true;
    public static Dictionary<string, float> childTimes = new Dictionary<string, float>();
    public static bool dataRetrieved = false;
    public static float currentTime = 0;
}
