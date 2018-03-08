using UnityEngine;
using System.Collections;

public class animationStore : MonoBehaviour {

    public UIPanel storePanel;

    public GameObject red;
    public GameObject blue;
    public GameObject green;
    public GameObject yellow;
    public GameObject pink;
    public GameObject purple;
    public GameObject gray;
    public GameObject orange; 

    public void backToMenu()
    {      
        storePanel.alpha = 0;
        red.SetActive(false);
        blue.SetActive(false);
        green.SetActive(false);
        yellow.SetActive(false);
        pink.SetActive(false);
        purple.SetActive(false);
        gray.SetActive(false);
        orange.SetActive(false);
    }

    public void showStore()
    {      
        storePanel.alpha = 1;
        red.SetActive(true);
        blue.SetActive(true);
        green.SetActive(true);
        yellow.SetActive(true);
        pink.SetActive(true);
        purple.SetActive(true);
        gray.SetActive(true);
        orange.SetActive(true);
    }
}
