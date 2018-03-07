using UnityEngine;

public class GameStatusEventHandler : MonoBehaviour {

    public delegate void gameStarted();
    public static event gameStarted startedGame;
    public delegate void gameStopped();
    public static event gameStopped stoppedGame;
    public static void gameWasStarted(string gameMode)
    {
        if (LoginToPortal.Instance.userIsLoggedIn)
        {
            TimeManager.Instance.initializeAppEvent("Tommy the Turtle", gameMode);
            startedGame();
        }
    }
    public static void gameWasStopped()
    {
        if (LoginToPortal.Instance.userIsLoggedIn)
        {
            stoppedGame();
        }
    }
}
