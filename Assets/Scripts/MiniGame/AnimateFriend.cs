using UnityEngine;
using System.Collections;

public class AnimateFriend : MonoBehaviour {

    Vector3 resetAfterJump;
    bool jumpReset;
    bool jumpSwitch;
    public static bool win;

    bool spin;

    // Use this for initialization
    void Start()
    {
        win = false;
        if (MiniGame.currentLevel == MiniGame.Level.Level6) { StartCoroutine(GrowShrink()); }
        if (MiniGame.currentLevel == MiniGame.Level.Level10 || MiniGame.currentLevel == MiniGame.Level.Story3 || MiniGame.currentLevel == MiniGame.Level.Story6) { Debug.Log("jumpspin"); jumpSwitch = true; StartCoroutine(Combo1()); }
    }

    	
	// Update is called once per frame
	void Update ()
    {
        if (!win)
        {

            if (MiniGame.currentLevel == MiniGame.Level.Level5 || MiniGame.currentLevel == MiniGame.Level.Story2 || MiniGame.currentLevel == MiniGame.Level.Story5)
            {
                gameObject.transform.Rotate(0, Time.deltaTime * 370, 0);
            }

            if (MiniGame.currentLevel == MiniGame.Level.Level10 || MiniGame.currentLevel == MiniGame.Level.Story3 || MiniGame.currentLevel == MiniGame.Level.Story6)
            {
                if (!spin)
                {
                    if (jumpSwitch)
                    {
                        GetComponent<Animation>().Play("Jump");
                        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2, 0), Time.deltaTime * 4);
                    }
                    else
                    {
                        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 2, 0), Time.deltaTime * 4);
                    }
                }
                else
                {
                    GetComponent<Animation>().Play("Run");
                    gameObject.transform.Rotate(0, Time.deltaTime * 370, 0);
                }
            }

        }
        else {
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
            GetComponent<Animation>().Play("Success");
        }


    }

    IEnumerator Combo1()
    {
        StartCoroutine(jump());
        yield return new WaitForSeconds(1);      
        StartCoroutine(spinAround());
        yield return new WaitForSeconds(1);
        StartCoroutine(Combo1());
    }

    IEnumerator jump()
    {
        jumpReset = true; resetAfterJump = gameObject.transform.position;
        jumpSwitch = true;
        yield return new WaitForSeconds(.5f);
        jumpSwitch = false;
        yield return new WaitForSeconds(.5f);
        jumpSwitch = true;

        if (jumpReset)
        {
            gameObject.transform.position = resetAfterJump;
            jumpReset = false;
        }
    }

    IEnumerator spinAround()
    {
        
        spin = true;
        yield return new WaitForSeconds(1);
        spin = false;
       
    }

    IEnumerator GrowShrink()
    {
        gameObject.transform.localScale = new Vector3(3f, 3f, 3f);
        yield return new WaitForSeconds(1);
        gameObject.transform.localScale = new Vector3(2, 2, 2);
        yield return new WaitForSeconds(1);
        StartCoroutine(GrowShrink());
    }

}
