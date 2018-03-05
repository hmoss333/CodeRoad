using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmControl : MonoBehaviour {

    [Header("Movement Controls")]
    public float vertSpeed;
    public float horizSpeed;
	private float horizMin;
	private float horizMax;
    float targetDepth = -0.25f;
    Vector3 startingPos;
    private bool dirRight = true;
    [HideInInspector]
    public bool trying; //button pressed/lowering hook
    private bool retracting = false; //lifting hook/prevent left/right movement until complete
    [HideInInspector]
    public bool comparing = false; //comparing chosen robot to target
    GameObject pickedRobot;

    [Header("Audio Elements")]
    public AudioClip armDrop;
    public AudioClip select;
    AudioSource audioSource;

    Collider col;
    GameManager gm;

    //Zumo input
    private bool key3Press = false;
    private bool key2Press = false;
    private bool key1Press = false;
    private bool keyspacePress = false;
    private bool keyenterPress = false;
    private Event e;


	/// <summary>
	/// This will be called whenever the iCade state changes i.e. it will get called for ALL events
	/// </summary>
	/// <param name="state"></param>
	/// 
	#if UNITY_IOS
	void iCadeStateCallback(int state)
	{
		print("iCade state change. Current state="+state);
	}

	/// <summary>
	/// This will be called whenever there's a button up event in iCade. It will get called for buttons and axis, since axis movement also translates into key presses
	/// </summary>
	/// <param name="button"></param>
	void iCadeButtonUpCallback(char button)
	{
		print("Button up event. Button " + button + " up");
	}

	/// <summary>
	/// This will be called whenever there's a button down event in iCade. It will get called for buttons and axis, since axis movement also translates into key presses
	/// </summary>
	/// <param name="button"></param>
	void iCadeButtonDownCallback(char button)
	{
		print("Button down event. Button " + button + " down");
		if (PlayerPrefs.GetInt("levelSelect") != 0) 
		{
			if (button == 'w') {
				key1Press = true;
			} 
			if (button == 'x') {
				key2Press = true;
			}
			if (button == 'd') {
				key3Press = true;
			}
			if (button == 'a') {
				keyspacePress = true;
			}
			if (button == 'y') {
				keyenterPress = true;
			}
			//objectApp = true;
		}
	}

	void iCadeKeyPressedCallback(int i)
	{
		//print ("Any old key pressed from Scan Mode");
		if (!trying && !comparing)
			trying = true;
	}
	#endif


    // Use this for initialization
    void Start () {
		horizMax = 0.75f;
		horizMin = -2f;

#if UNITY_IOS
		iCadeInput.Activate(true);

		//Register some callbacks
		iCadeInput.AddICadeEventCallback(iCadeStateCallback);
		iCadeInput.AddICadeButtonUpCallback(iCadeButtonUpCallback);
		iCadeInput.AddICadeButtonDownCallback(iCadeButtonDownCallback);

		horizMax = 0.65f;
		horizMin = -1.5f;
#endif
        
		col = GetComponent<Collider>();
        gm = GameObject.FindObjectOfType<GameManager>();
        startingPos = transform.position;

        audioSource = GetComponent<AudioSource>();

        e = Event.current;
    }
	
	// Update is called once per frame
	void Update () {
        if (gm.fastMode)
            horizSpeed = 0.75f;
        else
            horizSpeed = 0.5f;

        if (!gm.gameOver && (PlayerPrefs.GetInt("levelSelect") != 0))
        {
            if (!trying)
            {
                if (audioSource.isPlaying)
                    audioSource.Stop();

                if (dirRight)
                    transform.Translate(Vector2.right * horizSpeed * Time.deltaTime);
                else
                    transform.Translate(-Vector2.right * horizSpeed * Time.deltaTime);

				if (transform.position.x >= horizMax)
                    dirRight = false;
				if (transform.position.x <= horizMin)
                    dirRight = true;

                if (!comparing)
                {
                    //Zumo Input starts here
                    if (Input.GetKeyDown("1") == true)
                    {
                        key1Press = true;
                    }
                    if (Input.GetKeyDown("2") == true)
                    {
                        key2Press = true;
                    }
                    if (Input.GetKeyDown("3") == true)
                    {
                        key3Press = true;
                    }
                    if (Input.GetKeyDown("space") == true)
                    {
                        keyspacePress = true;
                    }
                    if (e != null)
                    {
                        if (e.keyCode.ToString() == "10" && e.type == EventType.keyDown)
                        {
                            keyenterPress = true;
                        }
                    }

                    if ((PlayerPrefs.GetInt("educationOn") == 1) || (PlayerPrefs.GetInt("therapyOn") == 1))
                    {
                        if ((PlayerPrefs.GetInt("key1toggle") == 0) && key1Press)
                        {
                            trying = true;
                        }
                        if ((PlayerPrefs.GetInt("key2toggle") == 0) && key2Press)
                        {
                            trying = true;
                        }
                        if ((PlayerPrefs.GetInt("key3toggle") == 0) && key3Press)
                        {
                            trying = true;
                        }
                        if ((PlayerPrefs.GetInt("keySpacetoggle") == 0) && keyspacePress)
                        {
                            trying = true;
                        }
                        if ((PlayerPrefs.GetInt("keyEntertoggle") == 0) && keyenterPress)
                        {
                            trying = true;
                        }
                        key1Press = false;
                        key2Press = false;
                        key3Press = false;
                        keyspacePress = false;
                        keyenterPress = false;
                    }
                    //Zumo Input ends here
                }
            }
            else
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = armDrop;
                    audioSource.Play();
                }
					
                if (!retracting)
                    transform.Translate(new Vector3(0, -vertSpeed * Time.deltaTime, 0));

                if (transform.position.y <= targetDepth)
                    retracting = true;

                else if (transform.position.y >= startingPos.y)
                {
                    transform.position = new Vector3(transform.position.x, startingPos.y, transform.position.z);
                    col.enabled = true;
                    audioSource.Stop();
                    trying = false;
                    retracting = false;
                    if (comparing)
                    {
                        gm.pickedRobot = pickedRobot;
                        pickedRobot = null;
                        comparing = false;
                    }
                }
            }

            if (retracting)
            {
                RetractArm();
            }
        }
    }

    void RetractArm ()
    {
        if (transform.position.y != startingPos.y)
            transform.Translate(new Vector3(0, +vertSpeed * Time.deltaTime, 0));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Robot" && trying && !gm.pickedRobot)
        {
            audioSource.clip = select;
            audioSource.Play();

            pickedRobot = other.gameObject;
            pickedRobot.GetComponent<ConveyorRobot>().picked = true;
            retracting = true;
            comparing = true;
            col.enabled = false;
            RetractArm();
        }
    }
}
