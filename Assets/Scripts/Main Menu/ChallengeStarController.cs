using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeStarController : MonoBehaviour {

    public string PlayerPrefString;
    public GameObject star;
    

    private void OnEnable()
    {
        star.SetActive(false);

        if (CheckPlayerPrefs(PlayerPrefString))
            star.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
		
	}

    bool CheckPlayerPrefs(string pPString)
    {
        if (PlayerPrefs.GetInt(pPString, 0) == 1)
            return true;
        else
            return false;
    }
}
