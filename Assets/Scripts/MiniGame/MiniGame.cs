using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGame : MonoBehaviour {

    public enum Level { Tutorial, Movement1, Movement2, Movement3, Abilities1, Abilities2, Abilities3, Abilities4, Combos1, Combos2, Combos3, Loops1, Loops2, Story1, Story2, Story3, Story4, Story5, Story6, Story7, FreePlay };
    public static Level currentLevel;

    public static bool isMainMenuGame;
    public GameObject[] levelObjects;

    //public enum TutorialMode { on, off, notSet };
    public static bool tutorialMode;

    static MiniGame mg;

    private void Start()
    {
        mg = GetComponent<MiniGame>();
        LoadScene(currentLevel);
    }

    public static void LoadScene (Level levelName)
    {
        int levelNum = (int)levelName;
        GameObject sceneToload;

        try
        {
            sceneToload = Instantiate(mg.levelObjects[levelNum]);
        }
        catch
        {
            Debug.Log("Something broke");
        }

        currentLevel = levelName;
    }

    public static void UnloadScene (Level levelName)
    {
        Destroy(GameObject.Find(levelName.ToString() + "(Clone)"));
    }
}
