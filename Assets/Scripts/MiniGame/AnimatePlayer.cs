using UnityEngine;
using System.Collections;

public class AnimatePlayer : MonoBehaviour {

    public static bool run;
    public static bool jump;
    public static bool sing;
    public static bool playOnce;
    public static bool win;

    // Use this for initialization
    void Start () {
        
        run = false;
        jump = false;
        sing = false;
        playOnce = true;
        win = false;
    }
  

    void play()
    {
        if (PlayerPrefs.GetInt("voice") == 0 && playOnce)
        {
            playOnce = false;
            GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void Update () {

        if (!win)
        {
            if (run && !jump)
            {
                GetComponent<Animation>().Play("Run");
            }
            else if (!run && !jump && !sing)
            {
                GetComponent<Animation>().Play("Idle");
            }
            else if (jump)
            {
                GetComponent<Animation>().Play("Jump");
            }
            else if (sing)
            {
                GetComponent<Animation>().Play("Success");
                play();
            }
        }
        else {
            GetComponent<Animation>().Play("Success");
            play();
        }
	}
}
