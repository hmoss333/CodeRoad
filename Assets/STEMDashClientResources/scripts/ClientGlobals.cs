using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClientGlobals : MonoBehaviour {
    public static bool messageSent = false;
    public static bool checkConnection = false;
    public static string message = "";
    public static bool update = false;
    public static bool updateGraphData = false;
    public static bool updateTimeData = false;
    public static bool updateImageData = false;
    public static bool gameActive = false;
    public static bool messageReceived = false;
    public static string messageId = "";
    public static List<string> messageIds = new List<string>();
    public static Queue<string> messageQueue = new Queue<string>();
    public static Dictionary<string, Queue<string>> messageBuffer = new Dictionary<string, Queue<string>>();   //Dictionary of lists -- used for detailed score page
    public static bool notConnectedToServer = false;
    public static float chatTimer = 0.0f;
}
