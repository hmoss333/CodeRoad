using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGame : MonoBehaviour {

    public enum Level { Tutorial, Movement1, Movement2, Movement3, Abilities1, Abilities2, Abilities3, Abilities4, Combos1, Combos2, Combos3, Loops1, Loops2, Story1, Story2, Story3, Story4, Story5, Story6, Story7 };
    public static Level currentLevel;

    public static bool isMainMenuGame;

    private void Start()
    {
        LoadScene(currentLevel);
    }

    public static void LoadScene (Level levelName)
    {
        GameObject sceneToload;
        if (!isMainMenuGame)
            sceneToload = Instantiate(Resources.Load("StoryGames/" + levelName.ToString())) as GameObject;
        else
            sceneToload = Instantiate(Resources.Load("Challenges/" + levelName.ToString())) as GameObject;

        if (sceneToload == null)
            Debug.Log("Something broke");

        currentLevel = levelName;
    }

    public static void UnloadScene (Level levelName)
    {
        Destroy(GameObject.Find(levelName.ToString() + "(Clone)"));
    }
}
