using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Test : MonoBehaviour
{
	[Header("Variables")]
	private bool enabled = true;
	//public bool isOn = false; // Clicking will toggle the button on and off. Starts off
	public int count = -1;
	string message;
	private bool completetext = true;
	//bool animateBook = false;
	//bool animateChest = false;
	//private bool didSeeKeyPress = false;
	private bool objectApp = false;
	private bool key3Press = false;
	private bool key2Press = false;
	private bool key1Press = false;
	private bool keyspacePress = false;
	private bool keyenterPress = false;
	private bool repeat = false;
	private bool back = false;
	private bool backPage = false;
	private bool repeatPage = false;
	private bool nextPage = false;
	private bool load = false;
	float startAlpha;
	int sequence;
	//bool isAnimationEffect = true;
	int randMusic;
	Event e;

	[Header("Menu Objects")]
	public GameObject storyParent;
	public UIPanel storyView;
	public Camera mainCamera;
	public UITexture sprite;
	public UISprite otherBackground;
	public UILabel label;
	public UISprite next;
	public UILabel play;
	public UISprite cover;

	public UISprite exitBack;
	public UISprite playBack2;
	public UILabel exitLabel;
	public UISprite repeatBack;
	public UISprite repeatBack2;
	public UILabel repeatLabel;
	public UISprite backBack;
	public UISprite backBack2;
	public UILabel backLabel;

    [Header("Characters")]
    public GameObject[] page1;
    public GameObject[] page2;
    public GameObject[] page3;
    public GameObject[] page4;
    public GameObject[] page5;
    public GameObject[] page6;
    public GameObject[] page7;
    public GameObject[] page8;
    public GameObject[] page9;
    public GameObject[] page10;
    public GameObject[] page11;
    public GameObject[] page12;
    public GameObject[] page13;
    public GameObject[] page14;
    public GameObject[] page15;
    public GameObject[] page16;
    public GameObject[] page17;
    public GameObject[] page18;
    public GameObject[] page19;
    public GameObject[] page20;
    public GameObject[] page21;
    public GameObject[] page22;
    public GameObject[] page23;
    public GameObject[] page24;

    [Header("Effects")]
	public UISprite testobj;
	public GameObject specialAnimationEffect1;
	public GameObject specialAnimationEffect2;
	public GameObject specialAnimationEffect3;
	public GameObject specialAnimationEffect4;
	public GameObject specialAnimationEffect5;
	public GameObject specialAnimationEffect6;
	public GameObject specialAnimationEffect7;
	public GameObject specialAnimationEffect8;
	public GameObject specialAnimationEffect9;
	public GameObject specialAnimationEffect10;
	public GameObject specialAnimationEffect11;
	public GameObject specialAnimationEffect12;
	public GameObject specialAnimationEffect13;
	public GameObject specialAnimationEffect14;
	public GameObject specialAnimationEffect15;
	public GameObject specialAnimationEffect16;
	public GameObject specialAnimationEffect17;
	public GameObject specialAnimationEffect18;
    public GameObject specialAnimationEffect19;
    public GameObject specialAnimationEffect20;
    public GameObject specialAnimationEffect21;
    public GameObject specialAnimationEffect22;
    public GameObject specialAnimationEffect23;
    public GameObject specialAnimationEffect24;

    [Header("Story Audio")]
	public AudioClip part1;
	public AudioClip part2;
	public AudioClip part3;
	public AudioClip part4;
	public AudioClip part5;
	public AudioClip part6;
	public AudioClip part7;
	public AudioClip part8;
	public AudioClip part9;
	public AudioClip part10;
	public AudioClip part11;
	public AudioClip part12;
	public AudioClip part13;
	public AudioClip part14;
	public AudioClip part15;
	public AudioClip part16;
	public AudioClip part17;
	public AudioClip part18;
    public AudioClip part19;
    public AudioClip part20;
    public AudioClip part21;
    public AudioClip part22;
    public AudioClip part23;
    public AudioClip part24;
    public AudioClip part25;
    public AudioClip part26;
    public AudioClip part27;
    public AudioClip part28;
    public AudioClip part29;
    public AudioClip part30;
    public AudioClip part31;
    public AudioClip part32;
    public AudioClip part33;
    public AudioClip part34;
    public AudioClip part35;
    public AudioClip part36;
    public AudioClip part37;
    public AudioClip part38;
    public AudioClip part39;
    public AudioClip part40;
    public AudioClip part41;
    public AudioClip part42;
    public AudioClip part43;
    public AudioClip part44;
    public AudioClip part45;
    public AudioClip part46;
    public AudioClip part47;
    public AudioClip part48;

    [Header("Audio")]
	public AudioClip robotSound1;
	public AudioClip robotSound2;
	public AudioClip robotSound3;
	public AudioClip robotSound4;
	public AudioClip soundSpecial1;
	public AudioClip soundSpecial2;
	public AudioClip soundSpecial3;
	public AudioClip soundSpecial4;
	public AudioClip soundSpecial5;
	public AudioClip soundSpecial6;
	public AudioClip soundSpecial7;
	public AudioClip soundSpecial8;
	public AudioClip soundSpecial9;
	public AudioClip soundSpecial10;
	public AudioClip soundSpecial11;
	public AudioClip soundSpecial12;
	public AudioClip soundSpecial13;
	public AudioClip soundSpecial14;
	public AudioClip soundSpecial15;
	public AudioClip soundSpecial16;
	public AudioClip soundSpecial17;
	public AudioClip soundSpecial18;
	public AudioSource audiosource;
	public AudioSource specialAudiosource;

	[Header("MiniGame Stuff")]
	private bool inMiniGameMode;
	private bool playedGame1;
	private bool playedGame2;
	private bool playedGame3;
	private bool playedGame4;

	[Header("Tutorial")]
	public GameObject Tutorial_1;
	public GameObject Tutorial_2;
	public GameObject Tutorial_3;
	public bool inTutorialMode;

	[Header("GUI")]
	public UIFont font;
	public UIAtlas atlas;

	//[Header("Loading Screen")]
	//LoadingScreen ls;

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
	objectApp = true;
	setTap ();
	}

	void iCadeKeyPressedCallback(int i)
	{

	}
	#endif

	public void setTap()
	{
		if (inTutorialMode)
		{
			if (Tutorial_1.activeInHierarchy)
				Turotiral1OnClick();
			else if (Tutorial_2.activeInHierarchy)
				Turotiral2OnClick();
			else if (Tutorial_3.activeInHierarchy)
				Turotiral3OnClick();
		}

		completetext = true;
		audiosource.Stop();
	}

	public void exitClick()
	{
        StartCoroutine(DisplayScene());
	}

	public void repeatClick()
	{
		count--;
		OnClick();
	}

	public void backClick()
	{
		back = true;
		if (count == -1)
		{
			back = false;
		}
		else
		{
			count -= 1;
			OnClick();
		}
	}

	public void tapStory()
	{
		if (!inMiniGameMode)
		{
			if (inTutorialMode)
			{
				if (Tutorial_1.activeInHierarchy)
					Turotiral1OnClick();
				else if (Tutorial_2.activeInHierarchy)
					Turotiral2OnClick();
				else if (Tutorial_3.activeInHierarchy)
					Turotiral3OnClick();
			}

			//if (isAnimationEffect)
			else
			{
				playSpecialAnimationEffect();
				playSpecialAudioEffect();
			}
			//isAnimationEffect = !isAnimationEffect;//Toggle effects;
		}
	}

	void Start()
	{
		e = Event.current;

		//ls = GameObject.Find("LoadingScreen").GetComponent<LoadingScreen>();
		inMiniGameMode = false;
		playedGame1 = false;
		playedGame2 = false;
		playedGame3 = false;

		startAlpha = sprite.alpha;
		sequence = 0;

		//DisableRobots();

		//float start = sprite.alpha;
		//sprite.alpha = 0f;
		//sprite.spriteName = "scene1";

		//StartCoroutine(FadeIn(sprite, 0.5f, start));
		//label.text = "Shapes are here to show us the way.";
		//StartCoroutine(TypeText(next.alpha,play.alpha));

		//This is needed to activate the iCade plugin. Deactivate it by using iCadeInput.Activate(false)
		#if UNITY_IOS
		iCadeInput.Activate(true);

		//Register some callbacks
		iCadeInput.AddICadeEventCallback(iCadeStateCallback);
		iCadeInput.AddICadeButtonUpCallback(iCadeButtonUpCallback);
		iCadeInput.AddICadeButtonDownCallback(iCadeButtonDownCallback);
		#endif

		//label.fontSize = (int)(34*PlayerPrefs.GetFloat("printSize")) + 34;
		label.fontSize = (int)(27 * PlayerPrefs.GetFloat("printSize")) + 23; //+ 27;

        //if (repeat == false)
        //{
        //	CFX_SpawnSystem.PreloadObject (specialAnimationEffect1,1);
        //	CFX_SpawnSystem.PreloadObject (specialAnimationEffect2,1);
        //	CFX_SpawnSystem.PreloadObject (specialAnimationEffect3,1);
        //	CFX_SpawnSystem.PreloadObject (specialAnimationEffect4,1);
        //	CFX_SpawnSystem.PreloadObject (specialAnimationEffect5,1);
        //	CFX_SpawnSystem.PreloadObject (specialAnimationEffect6,1);
        //	CFX_SpawnSystem.PreloadObject (specialAnimationEffect7,1);
        //	CFX_SpawnSystem.PreloadObject (specialAnimationEffect8,1);
        //	CFX_SpawnSystem.PreloadObject (specialAnimationEffect9,1);
        //	CFX_SpawnSystem.PreloadObject (specialAnimationEffect10,1);
        //	CFX_SpawnSystem.PreloadObject (specialAnimationEffect11,1);
        //	CFX_SpawnSystem.PreloadObject (specialAnimationEffect12,1);
        //	CFX_SpawnSystem.PreloadObject (specialAnimationEffect13,1);
        //	CFX_SpawnSystem.PreloadObject (specialAnimationEffect14,1);
        //	CFX_SpawnSystem.PreloadObject (specialAnimationEffect15,1);
        //	CFX_SpawnSystem.PreloadObject (specialAnimationEffect16,1);
        //	CFX_SpawnSystem.PreloadObject (specialAnimationEffect17,1);
        //	CFX_SpawnSystem.PreloadObject (specialAnimationEffect18,1);

        //	repeat = true;
        //}


        //================================================//
        ////Undo this later when audio has been provided////
        //================================================//
        //if (PlayerPrefs.GetInt("voice") == 1)
        //{
        part1 = null;
        part2 = null;
        part3 = null;
        part4 = null;
        part5 = null;
        part6 = null;
        part7 = null;
        part8 = null;
        part9 = null;
        part10 = null;
        part11 = null;
        part12 = null;
        part13 = null;
        part14 = null;
        part15 = null;
        part16 = null;
        part17 = null;
        part18 = null;
        //}

        OnClick();

		//If tutorial is finished, don't start; otherwise start normally
		if (PlayerPrefs.GetInt("tutorial") != 0) { inTutorialMode = false; } else { inTutorialMode = true; }

		if (PlayerPrefs.GetInt("tutorial") == 0)
			Tutorial_1.SetActive(true);
		else
			Tutorial_1.SetActive(false);

		Tutorial_2.SetActive(false);
		Tutorial_3.SetActive(false);

	}

	void OnGUI()
	{
		//GUI.Box (new Rect (10,10,100,50), "scene: "+(count).ToString());// For debug. Delete this function for release build
	}

	void Update()
	{
		//if (Input.anyKey)
		//{
		//    if (Tutorial_1.activeInHierarchy)
		//        Turotiral1OnClick();
		//    else if (Tutorial_2.activeInHierarchy)
		//        Turotiral2OnClick();
		//    else if (Tutorial_3.activeInHierarchy)
		//        Turotiral3OnClick();
		//}

		if (!inMiniGameMode) //should prevent any input from being read if in minigame mode
		{
			if (Input.GetKeyDown("1") == true)
			{
				key1Press = true;
				objectApp = true;
				setTap ();
                //OnClick(); //trying this out
			}
			if (Input.GetKeyDown("2") == true)
			{
				key2Press = true;
				objectApp = true;
				setTap ();
                //OnClick(); //trying this out
            }
			if (Input.GetKeyDown("3") == true)
			{
				key3Press = true;
				objectApp = true;
				setTap ();
                //OnClick(); //trying this out
            }
			if (Input.GetKeyDown("space") == true)
			{
				keyspacePress = true;
				objectApp = true;
				setTap ();
                //OnClick(); //trying this out
            }
			if (e != null)
			{
				if (e.keyCode.ToString() == "10" && e.type == EventType.keyDown)
				{
					//if (Input.GetKeyDown(KeyCode.Return)) {
					keyenterPress = true;
					objectApp = true;
					setTap ();
                    //OnClick(); //trying this out
                }
			}

			if ((PlayerPrefs.GetInt("educationOn") == 1) && (PlayerPrefs.GetInt("therapyOn") == 0))
			{
                if ((PlayerPrefs.GetInt("key1newobj") == 1) && key1Press)
				{
					//AnimateAllActiveObject();
					if (PlayerPrefs.GetFloat("printSize") < 0.6f)
					{

					}
					else
					{

					}
				}
				if ((PlayerPrefs.GetInt("key1anim1") == 1) && key1Press)
				{
					playSpecialAnimationEffect();
				}
				if ((PlayerPrefs.GetInt("key1anim2") == 1) && key1Press)
				{

				}
				if ((PlayerPrefs.GetInt("key1anim3") == 1) && key1Press)
				{

				}
				if ((PlayerPrefs.GetInt("key1music") == 1) && key1Press)
				{
					playSpecialAudioEffect();
				}
				if ((PlayerPrefs.GetInt("key1back") == 1) && key1Press)
				{
					if (load)
					{
						if (completetext == false)
						{
							backPage = true;
							setTap();
						}
						else
						{
							backClick();
						}
					}
				}
				if ((PlayerPrefs.GetInt("key1next") == 1) && key1Press)
				{
					if (load)
					{
						if (completetext == false)
						{
							nextPage = true;
							setTap();
						}
						else
						{
							OnClick();
						}
					}
				}
				if ((PlayerPrefs.GetInt("key1repeat") == 1) && key1Press)
				{
					if (load)
					{
						if (completetext == false)
						{
							repeatPage = true;
							setTap();
						}
						else
						{
							repeatClick();
						}
					}
				}
				if ((PlayerPrefs.GetInt("key2newobj") == 1) && key2Press)
				{
					//AnimateAllActiveObject();
					if (PlayerPrefs.GetFloat("printSize") < 0.6f)
					{

					}
					else
					{

					}
				}
				if ((PlayerPrefs.GetInt("key2anim1") == 1) && key2Press)
				{
					playSpecialAnimationEffect();
				}
				if ((PlayerPrefs.GetInt("key2anim2") == 1) && key2Press)
				{

				}
				if ((PlayerPrefs.GetInt("key2anim3") == 1) && key2Press)
				{

				}
				if ((PlayerPrefs.GetInt("key2music") == 1) && key2Press)
				{
					playSpecialAudioEffect();
				}
				if ((PlayerPrefs.GetInt("key2back") == 1) && key2Press)
				{
					if (load)
					{
						if (completetext == false)
						{
							backPage = true;
							setTap();
						}
						else
						{
							backClick();
						}
					}
				}
				if ((PlayerPrefs.GetInt("key2next") == 1) && key2Press)
				{
					if (load)
					{
						if (completetext == false)
						{
							nextPage = true;
							setTap();
						}
						else
						{
							OnClick();
						}
					}
				}
				if ((PlayerPrefs.GetInt("key2repeat") == 1) && key2Press)
				{
					if (load)
					{
						if (completetext == false)
						{
							repeatPage = true;
							setTap();
						}
						else
						{
							repeatClick();
						}
					}
				}
				if ((PlayerPrefs.GetInt("key3newobj") == 1) && key3Press)
				{
					//AnimateAllActiveObject();
					if (PlayerPrefs.GetFloat("printSize") < 0.6f)
					{

					}
					else
					{

					}
				}
				if ((PlayerPrefs.GetInt("key3anim1") == 1) && key3Press)
				{
					playSpecialAnimationEffect();
				}
				if ((PlayerPrefs.GetInt("key3anim2") == 1) && key3Press)
				{
				}
				if ((PlayerPrefs.GetInt("key3anim3") == 1) && key3Press)
				{
				}
				if ((PlayerPrefs.GetInt("key3music") == 1) && key3Press)
				{
					playSpecialAudioEffect();
				}
				if ((PlayerPrefs.GetInt("key3back") == 1) && key3Press)
				{
					if (load)
					{
						if (completetext == false)
						{
							backPage = true;
							setTap();
						}
						else
						{
							backClick();
						}
					}
				}
				if ((PlayerPrefs.GetInt("key3next") == 1) && key3Press)
				{
					if (load)
					{
						if (completetext == false)
						{
							nextPage = true;
							setTap();
						}
						else
						{
							OnClick();
						}
					}
				}
				if ((PlayerPrefs.GetInt("key3repeat") == 1) && key3Press)
				{
					if (load)
					{
						if (completetext == false)
						{
							repeatPage = true;
							setTap();
						}
						else
						{
							repeatClick();
						}
					}
				}
				if ((PlayerPrefs.GetInt("keySpacenewobj") == 1) && keyspacePress)
				{
					//AnimateAllActiveObject();
					if (PlayerPrefs.GetFloat("printSize") < 0.6f)
					{

					}
					else
					{

					}
				}
				if ((PlayerPrefs.GetInt("keySpaceanim1") == 1) && keyspacePress)
				{
					playSpecialAnimationEffect();
				}
				if ((PlayerPrefs.GetInt("keySpaceanim2") == 1) && keyspacePress)
				{
				}
				if ((PlayerPrefs.GetInt("keySpaceanim3") == 1) && keyspacePress)
				{
				}
				if ((PlayerPrefs.GetInt("keySpacemusic") == 1) && keyspacePress)
				{
					playSpecialAudioEffect();
				}
				if ((PlayerPrefs.GetInt("keySpaceback") == 1) && keyspacePress)
				{
					if (load)
					{
						if (completetext == false)
						{
							backPage = true;
							setTap();
						}
						else
						{
							backClick();
						}
					}
				}
				if ((PlayerPrefs.GetInt("keySpacenext") == 1) && keyspacePress)
				{
					if (load)
					{
						if (completetext == false)
						{
							nextPage = true;
							setTap();
						}
						else
						{
							OnClick();
						}
					}
				}
				if ((PlayerPrefs.GetInt("keySpacerepeat") == 1) && keyspacePress)
				{
					if (load)
					{
						if (completetext == false)
						{
							repeatPage = true;
							setTap();
						}
						else
						{
							repeatClick();
						}
					}
				}
				if ((PlayerPrefs.GetInt("keyEnternewobj") == 1) && keyenterPress)
				{
					//AnimateAllActiveObject();
					if (PlayerPrefs.GetFloat("printSize") < 0.6f)
					{

					}
					else
					{

					}
				}
				if ((PlayerPrefs.GetInt("keyEnteranim1") == 1) && keyenterPress)
				{
					playSpecialAnimationEffect();
				}
				if ((PlayerPrefs.GetInt("keyEnteranim2") == 1) && keyenterPress)
				{
				}
				if ((PlayerPrefs.GetInt("keyEnteranim3") == 1) && keyenterPress)
				{
				}
				if ((PlayerPrefs.GetInt("keyEntermusic") == 1) && keyenterPress)
				{
					playSpecialAudioEffect();
				}
				if ((PlayerPrefs.GetInt("keyEnterback") == 1) && keyenterPress)
				{
					if (load)
					{
						if (completetext == false)
						{
							backPage = true;
							setTap();
						}
						else
						{
							backClick();
						}
					}
				}
				if ((PlayerPrefs.GetInt("keyEnternext") == 1) && keyenterPress)
				{
					if (load)
					{
						if (completetext == false)
						{
							nextPage = true;
							setTap();
						}
						else
						{
							OnClick();
						}
					}
				}
				if ((PlayerPrefs.GetInt("keyEnterrepeat") == 1) && keyenterPress)
				{
					if (load)
					{
						if (completetext == false)
						{
							repeatPage = true;
							setTap();
						}
						else
						{
							repeatClick();
						}
					}
				}
				key1Press = false;
				key2Press = false;
				key3Press = false;
				keyspacePress = false;
				keyenterPress = false;
			}


			if (sequence == 0)
			{

			}
			else if (sequence == 1)
			{

			}

//			if ((PlayerPrefs.GetInt("educationOn") == 0) && (PlayerPrefs.GetInt("therapyOn") == 1))
//			{
//				if ((PlayerPrefs.GetInt("key1toggle") == 0) && key1Press)
//				{
//					setTap();
//					OnClick();
//				}
//				if ((PlayerPrefs.GetInt("key2toggle") == 0) && key2Press)
//				{
//					setTap();
//					OnClick();
//				}
//				if ((PlayerPrefs.GetInt("key3toggle") == 0) && key3Press)
//				{
//					setTap();
//					OnClick();
//				}
//				if ((PlayerPrefs.GetInt("keySpacetoggle") == 0) && keyspacePress)
//				{
//					setTap();
//					OnClick();
//				}
//				if ((PlayerPrefs.GetInt("keyEntertoggle") == 0) && keyenterPress)
//				{
//					setTap();
//					OnClick();
//				}
//				key1Press = false;
//				key2Press = false;
//				key3Press = false;
//				keyspacePress = false;
//				keyenterPress = false;
//			}
			if (objectApp && (((PlayerPrefs.GetInt("educationOn") == 1) && (PlayerPrefs.GetInt("therapyOn") == 1))
				|| ((PlayerPrefs.GetInt("educationOn") == 0) && (PlayerPrefs.GetInt("therapyOn") == 0))))
			{
				setTap();
				OnClick();
				objectApp = false;
			}
			else
			{
				objectApp = false;
			}
		}
	}

	//void AnimateAllActiveObject()
	//{
	//    //if (blueChar.activeSelf)
	//    //    tapBlue();
	//    //if (blueShipNoAlien.activeSelf)
	//    //    tapBlueShipNoAlien();
	//    //if (blueShipWithAlien.activeSelf)
	//    //    tapBlueShipWithAlien();     
	//}

	void playSpecialAudioEffect()
	{
		specialAudiosource.Stop();
		randMusic = Random.Range(1, 25);
		if (randMusic == 1)
		{
			specialAudiosource.clip = soundSpecial1;
		}
		else if (randMusic == 2)
		{
			specialAudiosource.clip = soundSpecial2;
		}
		else if (randMusic == 3)
		{
			specialAudiosource.clip = soundSpecial3;
		}
		else if (randMusic == 4)
		{
			specialAudiosource.clip = soundSpecial4;
		}
		else if (randMusic == 5)
		{
			specialAudiosource.clip = soundSpecial5;
		}
		else if (randMusic == 6)
		{
			specialAudiosource.clip = soundSpecial6;
		}
		else if (randMusic == 7)
		{
			specialAudiosource.clip = soundSpecial7;
		}
		else if (randMusic == 8)
		{
			specialAudiosource.clip = soundSpecial8;
		}
		else if (randMusic == 9)
		{
			specialAudiosource.clip = soundSpecial9;
		}
		else if (randMusic == 10)
		{
			specialAudiosource.clip = soundSpecial10;
		}
		else if (randMusic == 11)
		{
			specialAudiosource.clip = soundSpecial11;
		}
		else if (randMusic == 12)
		{
			specialAudiosource.clip = soundSpecial12;
		}
		else if (randMusic == 13)
		{
			specialAudiosource.clip = soundSpecial13;
		}
		else if (randMusic == 14)
		{
			specialAudiosource.clip = soundSpecial14;
		}
		else if (randMusic == 15)
		{
			specialAudiosource.clip = soundSpecial15;
		}
		else if (randMusic == 16)
		{
			specialAudiosource.clip = soundSpecial16;
		}
		else if (randMusic == 17)
		{
			specialAudiosource.clip = soundSpecial17;
		}
		else if (randMusic == 18)
		{
			specialAudiosource.clip = soundSpecial18;
		}
		if (PlayerPrefs.GetFloat("printSize") < 0.6f)
		{
			switch (count - 1)
			{
			case -1:
				specialAudiosource.clip = soundSpecial1;
				break;
			case 0:
				specialAudiosource.clip = soundSpecial2;
				break;
			case 1:
				specialAudiosource.clip = soundSpecial3;
				break;
			case 2:
				specialAudiosource.clip = soundSpecial4;
				break;
			case 3:
				specialAudiosource.clip = soundSpecial5;
				break;
			case 4:
				specialAudiosource.clip = soundSpecial6;
				break;
			case 5:
				specialAudiosource.clip = soundSpecial7;
				break;
			case 6:
				specialAudiosource.clip = soundSpecial8;
				break;
			case 7:
				specialAudiosource.clip = soundSpecial9;
				break;
			case 8:
				specialAudiosource.clip = soundSpecial10;
				break;
			case 9:
				specialAudiosource.clip = soundSpecial11;
				break;
			case 10:
				specialAudiosource.clip = soundSpecial12;
				break;
			case 11:
				specialAudiosource.clip = soundSpecial13;
				break;
			case 12:
				specialAudiosource.clip = soundSpecial14;
				break;
			case 13:
				specialAudiosource.clip = soundSpecial15;
				break;
			case 14:
				specialAudiosource.clip = soundSpecial16;
				break;
			case 15:
				specialAudiosource.clip = soundSpecial17;
				break;
			case 16:
				specialAudiosource.clip = soundSpecial18;
				break;
			default:
				Debug.Log("This sound is not implemented");
				break;
			}
		}
		else
		{
			switch (count - 1)
			{
			case -1:
			case 0:
				specialAudiosource.clip = soundSpecial1;
				break;
			case 1:
			case 2:
				specialAudiosource.clip = soundSpecial2;
				break;
			case 3:
			case 4:
				specialAudiosource.clip = soundSpecial3;
				break;
			case 5:
			case 6:
				specialAudiosource.clip = soundSpecial4;
				break;
			case 7:
			case 8:
				specialAudiosource.clip = soundSpecial5;
				break;
			case 9:
			case 10:
				specialAudiosource.clip = soundSpecial6;
				break;
			case 11:
			case 12:
				specialAudiosource.clip = soundSpecial7;
				break;
			case 13:
			case 14:
				specialAudiosource.clip = soundSpecial8;
				break;
			case 15:
			case 16:
				specialAudiosource.clip = soundSpecial9;
				break;
			case 17:
			case 18:
				specialAudiosource.clip = soundSpecial10;
				break;
			case 19:
			case 20:
				specialAudiosource.clip = soundSpecial11;
				break;
			case 21:
			case 22:
				specialAudiosource.clip = soundSpecial12;
				break;
			case 23:
			case 24:
				specialAudiosource.clip = soundSpecial13;
				break;
			case 25:
			case 26:
				specialAudiosource.clip = soundSpecial14;
				break;
			case 27:
			case 28:
				specialAudiosource.clip = soundSpecial15;
				break;
			case 29:
			case 30:
				specialAudiosource.clip = soundSpecial16;
				break;
			case 31:
			case 32:
				specialAudiosource.clip = soundSpecial17;
				break;
			case 33:
			case 34:
				specialAudiosource.clip = soundSpecial18;
				break;
			default:
				Debug.Log("This sound is not implemented");
				break;
			}
		}
		specialAudiosource.Play();
	}

	void playSpecialAnimationEffect()
	{

  //      if (PlayerPrefs.GetFloat("printSize") < 0.6f)
  //      {
		//	switch (count - 1)
		//	{
		//	case -1:
		//		CFX_SpawnSystem.GetNextObject(specialAnimationEffect1, true);
		//		specialAnimationEffect1.GetComponent<ParticleSystem>().Play();
		//		break;
		//	case 0:
		//		CFX_SpawnSystem.GetNextObject(specialAnimationEffect2, true);
		//		specialAnimationEffect2.GetComponent<ParticleSystem>().Play();
		//		break;
		//	case 1:
		//		CFX_SpawnSystem.GetNextObject(specialAnimationEffect3, true);
		//		specialAnimationEffect3.GetComponent<ParticleSystem>().Play();
		//		break;
		//	case 2:
		//		CFX_SpawnSystem.GetNextObject(specialAnimationEffect4, true);
		//		specialAnimationEffect4.GetComponent<ParticleSystem>().Play();
		//		break;
		//	case 3:
		//		CFX_SpawnSystem.GetNextObject(specialAnimationEffect5, true);
		//		specialAnimationEffect5.GetComponent<ParticleSystem>().Play();
		//		break;
		//	case 4:
		//		CFX_SpawnSystem.GetNextObject(specialAnimationEffect6, true);
		//		specialAnimationEffect6.GetComponent<ParticleSystem>().Play();
		//		break;
		//	case 5:
		//		CFX_SpawnSystem.GetNextObject(specialAnimationEffect7, true);
		//		specialAnimationEffect7.GetComponent<ParticleSystem>().Play();
		//		break;
		//	case 6:
		//		CFX_SpawnSystem.GetNextObject(specialAnimationEffect8, true);
		//		specialAnimationEffect8.GetComponent<ParticleSystem>().Play();
		//		break;
		//	case 7:
		//		CFX_SpawnSystem.GetNextObject(specialAnimationEffect9, true);
		//		specialAnimationEffect9.GetComponent<ParticleSystem>().Play();
		//		break;
		//	case 8:
		//		CFX_SpawnSystem.GetNextObject(specialAnimationEffect10, true);
		//		specialAnimationEffect10.GetComponent<ParticleSystem>().Play();
		//		break;
		//	case 9:
		//		CFX_SpawnSystem.GetNextObject(specialAnimationEffect11, true);
		//		specialAnimationEffect11.GetComponent<ParticleSystem>().Play();
		//		break;
		//	case 10:
		//		CFX_SpawnSystem.GetNextObject(specialAnimationEffect12, true);
		//		specialAnimationEffect12.GetComponent<ParticleSystem>().Play();
		//		break;
		//	case 11:
		//		CFX_SpawnSystem.GetNextObject(specialAnimationEffect13, true);
		//		specialAnimationEffect13.GetComponent<ParticleSystem>().Play();
		//		break;
		//	case 12:
		//		CFX_SpawnSystem.GetNextObject(specialAnimationEffect14, true);
		//		specialAnimationEffect14.GetComponent<ParticleSystem>().Play();
		//		break;
		//	case 13:
		//		CFX_SpawnSystem.GetNextObject(specialAnimationEffect15, true);
		//		specialAnimationEffect15.GetComponent<ParticleSystem>().Play();
		//		break;
		//	case 14:
		//		CFX_SpawnSystem.GetNextObject(specialAnimationEffect16, true);
		//		specialAnimationEffect16.GetComponent<ParticleSystem>().Play();
		//		break;
		//	case 15:
		//		CFX_SpawnSystem.GetNextObject(specialAnimationEffect17, true);
		//		specialAnimationEffect17.GetComponent<ParticleSystem>().Play();
		//		break;
		//	case 16:
		//		CFX_SpawnSystem.GetNextObject(specialAnimationEffect18, true);
		//		specialAnimationEffect18.GetComponent<ParticleSystem>().Play();
		//		break;
		//	default:
		//		Debug.Log("This animation effect is not implemented");
		//		break;
		//	}
		//}
		//else
		//{
			switch (count - 1)
			{
			case -1:
			case 0:
				CFX_SpawnSystem.GetNextObject(specialAnimationEffect1, true);
				specialAnimationEffect1.GetComponent<ParticleSystem>().Play();
				break;
			case 1:
			case 2:
				CFX_SpawnSystem.GetNextObject(specialAnimationEffect2, true);
				specialAnimationEffect2.GetComponent<ParticleSystem>().Play();
				break;
			case 3:
			case 4:
				CFX_SpawnSystem.GetNextObject(specialAnimationEffect3, true);
				specialAnimationEffect3.GetComponent<ParticleSystem>().Play();
				break;
			case 5:
			case 6:
				CFX_SpawnSystem.GetNextObject(specialAnimationEffect4, true);
				specialAnimationEffect4.GetComponent<ParticleSystem>().Play();
				break;
			case 7:
			case 8:
				CFX_SpawnSystem.GetNextObject(specialAnimationEffect5, true);
				specialAnimationEffect5.GetComponent<ParticleSystem>().Play();
				break;
			case 9:
			case 10:
				CFX_SpawnSystem.GetNextObject(specialAnimationEffect6, true);
				specialAnimationEffect6.GetComponent<ParticleSystem>().Play();
				break;
			case 11:
			case 12:
				CFX_SpawnSystem.GetNextObject(specialAnimationEffect7, true);
				specialAnimationEffect7.GetComponent<ParticleSystem>().Play();
				break;
			case 13:
			case 14:
				CFX_SpawnSystem.GetNextObject(specialAnimationEffect8, true);
				specialAnimationEffect8.GetComponent<ParticleSystem>().Play();
				break;
			case 15:
			case 16:
				CFX_SpawnSystem.GetNextObject(specialAnimationEffect9, true);
				specialAnimationEffect9.GetComponent<ParticleSystem>().Play();
				break;
			case 17:
			case 18:
				CFX_SpawnSystem.GetNextObject(specialAnimationEffect10, true);
				specialAnimationEffect10.GetComponent<ParticleSystem>().Play();
				break;
			case 19:
			case 20:
				CFX_SpawnSystem.GetNextObject(specialAnimationEffect11, true);
				specialAnimationEffect11.GetComponent<ParticleSystem>().Play();
				break;
			case 21:
			case 22:
				CFX_SpawnSystem.GetNextObject(specialAnimationEffect12, true);
				specialAnimationEffect12.GetComponent<ParticleSystem>().Play();
				break;
			case 23:
			case 24:
				CFX_SpawnSystem.GetNextObject(specialAnimationEffect13, true);
				specialAnimationEffect13.GetComponent<ParticleSystem>().Play();
				break;
			case 25:
			case 26:
				CFX_SpawnSystem.GetNextObject(specialAnimationEffect14, true);
				specialAnimationEffect14.GetComponent<ParticleSystem>().Play();
				break;
			case 27:
			case 28:
				CFX_SpawnSystem.GetNextObject(specialAnimationEffect15, true);
				specialAnimationEffect15.GetComponent<ParticleSystem>().Play();
				break;
			case 29:
			case 30:
				CFX_SpawnSystem.GetNextObject(specialAnimationEffect16, true);
				specialAnimationEffect16.GetComponent<ParticleSystem>().Play();
				break;
			case 31:
			case 32:
				CFX_SpawnSystem.GetNextObject(specialAnimationEffect17, true);
				specialAnimationEffect17.GetComponent<ParticleSystem>().Play();
				break;
			case 33:
			case 34:
				CFX_SpawnSystem.GetNextObject(specialAnimationEffect18, true);
				specialAnimationEffect18.GetComponent<ParticleSystem>().Play();
				break;

            //===Untested===//
            case 35:
            case 36:
                CFX_SpawnSystem.GetNextObject(specialAnimationEffect19, true);
                specialAnimationEffect19.GetComponent<ParticleSystem>().Play();
                break;
            case 37:
            case 38:
                CFX_SpawnSystem.GetNextObject(specialAnimationEffect20, true);
                specialAnimationEffect20.GetComponent<ParticleSystem>().Play();
                break;
            case 39:
            case 40:
                CFX_SpawnSystem.GetNextObject(specialAnimationEffect21, true);
                specialAnimationEffect21.GetComponent<ParticleSystem>().Play();
                break;
            case 41:
            case 42:
                CFX_SpawnSystem.GetNextObject(specialAnimationEffect22, true);
                specialAnimationEffect22.GetComponent<ParticleSystem>().Play();
                break;
            case 43:
            case 44:
                CFX_SpawnSystem.GetNextObject(specialAnimationEffect23, true);
                specialAnimationEffect23.GetComponent<ParticleSystem>().Play();
                break;
            case 45:
            case 46:
                CFX_SpawnSystem.GetNextObject(specialAnimationEffect24, true);
                specialAnimationEffect24.GetComponent<ParticleSystem>().Play();
                break;

            //===Default===//
            default:
				Debug.Log("This animation effect is not implemented");
				break;
			}
		//}
	}

	public void OnClick()
	{
		if (inTutorialMode && Tutorial_3.activeSelf)
			Turotiral3OnClick();

		if (enabled == true && (!inTutorialMode))
		{
			load = false;
			enabled = false;
			float nextAlpha = next.alpha;
			float coverAlpha = cover.alpha;
			play.text = "";
			//cover.alpha = 0;
			next.alpha = 0;
			exitBack.GetComponent<Collider>().enabled = false;
			exitBack.alpha = 0;
			playBack2.alpha = 0;
			exitLabel.alpha = 0;
			repeatBack.GetComponent<Collider>().enabled = false;
			repeatBack.alpha = 0;
			repeatBack2.alpha = 0;
			repeatLabel.alpha = 0;
			backBack.GetComponent<Collider>().enabled = false;
			backBack.alpha = 0;
			backBack2.alpha = 0;
			backLabel.alpha = 0;

			specialAnimationEffect1.GetComponent<ParticleSystem>().Stop();
			specialAnimationEffect2.GetComponent<ParticleSystem>().Stop();
			specialAnimationEffect3.GetComponent<ParticleSystem>().Stop();
			specialAnimationEffect4.GetComponent<ParticleSystem>().Stop();
			specialAnimationEffect5.GetComponent<ParticleSystem>().Stop();
			specialAnimationEffect6.GetComponent<ParticleSystem>().Stop();
			specialAnimationEffect7.GetComponent<ParticleSystem>().Stop();
			specialAnimationEffect8.GetComponent<ParticleSystem>().Stop();
			specialAnimationEffect9.GetComponent<ParticleSystem>().Stop();
			specialAnimationEffect10.GetComponent<ParticleSystem>().Stop();
			specialAnimationEffect11.GetComponent<ParticleSystem>().Stop();
			specialAnimationEffect12.GetComponent<ParticleSystem>().Stop();
			specialAnimationEffect13.GetComponent<ParticleSystem>().Stop();
			specialAnimationEffect14.GetComponent<ParticleSystem>().Stop();
			specialAnimationEffect15.GetComponent<ParticleSystem>().Stop();
			specialAnimationEffect16.GetComponent<ParticleSystem>().Stop();
			specialAnimationEffect17.GetComponent<ParticleSystem>().Stop();
			specialAnimationEffect18.GetComponent<ParticleSystem>().Stop();
            specialAnimationEffect19.GetComponent<ParticleSystem>().Stop();
            specialAnimationEffect20.GetComponent<ParticleSystem>().Stop();
            specialAnimationEffect21.GetComponent<ParticleSystem>().Stop();
            specialAnimationEffect22.GetComponent<ParticleSystem>().Stop();
            specialAnimationEffect23.GetComponent<ParticleSystem>().Stop();
            specialAnimationEffect24.GetComponent<ParticleSystem>().Stop();



            //if (PlayerPrefs.GetFloat("printSize") < 0.6f)
            //{
            //    if (count == 3 || count == 1)
            //    {
            //        sprite.alpha = 1;
            //        otherBackground.alpha = 0;
            //    }
            //}
            //else
            //{
            //    if (count == 7 || count == 4)
            //    {
            //        sprite.alpha = 1;
            //        otherBackground.alpha = 0;
            //    }
            //}

            //every 5 levels, if minigame option is active, display minigame instead of going to next page
            if (count == 9 || count == 15 || count == 27 || count == 39)
			{
				if (PlayerPrefs.GetInt("minigames") == 1)
				{
					if (!inMiniGameMode && CanPlay())
					{
						label.text = "";
                        StartCoroutine(SetMiniGame());

                        //==For Testing; Replace when minigame is ready==//
                        //Debug.Log("Minigame plays here");
                        //StartCoroutine(FadeOuter(sprite, 0.5f, nextAlpha, coverAlpha));
                    }
					else
					{
						//inMiniGameMode = false;
						StartCoroutine(FadeOuter(sprite, 0.5f, nextAlpha, coverAlpha));
					}
				}
				else
					StartCoroutine(FadeOuter(sprite, 0.5f, nextAlpha, coverAlpha));
			}
			else
			{
				StartCoroutine(FadeOuter(sprite, 0.5f, nextAlpha, coverAlpha));
			}
		}
	}

	//check which minigames have already been played
	bool CanPlay ()
	{
		if (count >= 9 && !playedGame1)
			return true;
		else if (count >= 15 && !playedGame2)
			return true;
		else if (count >= 27 && !playedGame3)
			return true;
        else if (count >= 39 && !playedGame4)
            return true;
        else
			return false;
	}

    void EnableCharacters(GameObject[] pageNum)
    {
        for (int i = 0; i < pageNum.Length; i++)
        {
            pageNum[i].SetActive(true);
        }
    }

    void DisableCharacters(GameObject[] pageNum)
    {
        for (int i = 0; i < pageNum.Length; i++)
        {
            pageNum[i].SetActive(false);
        }
    }

    void DisableRobots()
	{
        DisableCharacters(page1);
        DisableCharacters(page2);
        DisableCharacters(page3);
        DisableCharacters(page4);
        DisableCharacters(page5);
        DisableCharacters(page6);
        DisableCharacters(page7);
        DisableCharacters(page8);
        DisableCharacters(page9);
        DisableCharacters(page10);
        DisableCharacters(page11);
        DisableCharacters(page12);
        DisableCharacters(page13);
        DisableCharacters(page14);
        DisableCharacters(page15);
        DisableCharacters(page16);
        DisableCharacters(page17);
        DisableCharacters(page18);
        DisableCharacters(page19);
        DisableCharacters(page20);
        DisableCharacters(page21);
        DisableCharacters(page22);
        DisableCharacters(page23);
        DisableCharacters(page24);
    }

    void AnimatePage(GameObject[] pageNum)
    {
        for (int i = 0; i < pageNum.Length; i++)
        {
            if (pageNum[i].GetComponent<UI2DSpriteAnimation>() != null)
                pageNum[i].GetComponent<UI2DSpriteAnimation>().Play();
        }
    }

    //minigame logic here
    IEnumerator SetMiniGame()
	{
		inMiniGameMode = true;

        //DisableRobots();

        //if (!SceneManager.GetSceneByName("LoadingScreen").isLoaded)
            SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Additive);
        yield return new WaitForSeconds(1f);
        audiosource.Stop();
		mainCamera.gameObject.SetActive(false);
		storyView.alpha = 0f;

        if (count >= 9 && !playedGame1)
        {
            playedGame1 = true;
            StartCoroutine(GoToScene("StoryMovement"));
        }
        if (count >= 15 && !playedGame2)
        {
            playedGame2 = true;
            StartCoroutine(GoToScene("StoryAbilities"));
        }
        if (count >= 27 && !playedGame3)
        {
            playedGame3 = true;
            StartCoroutine(GoToScene("StoryCombos"));
        }
        if (count >= 39 && !playedGame4)
        {
            playedGame4 = true;
            StartCoroutine(GoToScene("StoryLoops"));
        }
        //StartCoroutine(GoToScene("MiniGame_Story"));
		//enabled = false;
	}

	IEnumerator GoToScene (string sceneName)
	{
		yield return new WaitForSeconds(1f);
		SceneManager.LoadSceneAsync(sceneName);
	}

	public void EndMiniGame()
	{
	    StartCoroutine(GoToScene("Empty"));

        StartCoroutine(TurnOnCamera());
	}

	IEnumerator TurnOnCamera()
	{
        if (!SceneManager.GetSceneByName("LoadingScreen").isLoaded && SceneManager.GetSceneByName("Empty").isLoaded) {
            //yield return new WaitForSeconds(0.25f);
            //storyView.alpha = 1f;
			//mainCamera.gameObject.SetActive(true);
			enabled = true;
			next.alpha = 1f;
			cover.alpha = 1f;
			OnClick();
            storyView.alpha = 1f;
            mainCamera.gameObject.SetActive(true);
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(TurnOnCamera());
        }
    }

	IEnumerator FadeOther(UIWidget w, float durationInSeconds)
	{
		float startA = w.alpha;
		float currentTime = 0f;
		while (currentTime < durationInSeconds)
		{
			w.alpha = Mathf.Lerp(startA, 0f, currentTime / durationInSeconds);
			currentTime += Time.deltaTime;
			yield return null;
		}
		sprite.mainTexture = Resources.Load("image1") as Texture;
		StartCoroutine(FadeIn(sprite, 0.5f, startA));
	}

    IEnumerator FadeOuter(UIWidget w, float durationInSeconds, float nextAlpha, float coverAlpha)
    {
        inMiniGameMode = false; //ensures the scene has changed before OnClick checks if minigame is active; update OnClick so this isn't necissary

        float startA = w.alpha;
        label.text = "";
        //float currentTime = 0f;
        //if (PlayerPrefs.GetFloat("printSize") < 0.6f)
        //{
        //	if (count == 18)
        //	{
        //		label.text = "The planets are grand and my Wootzy friends too.\n Learning colors with friends was a fun thing to do. ";
        //	}
        //	else
        //	{
        //		label.text = "";
        //	}
        //}
        //else
        //{
        //	if (count == 37)
        //	{
        //		label.text = "Learning colors with friends was a fun thing to do. ";
        //	}
        //	else
        //	{
        //		label.text = "";
        //	}
        //}
        yield return null;

        /*
		if (PlayerPrefs.GetFloat("printSize") < 0.6f) {
			if (((back == false) && ((count == 0) || (count == 1) || (count == 2) || (count == 3) || (count == 4))) || ((back == true) 
			                                                                                                            && ((count == -1) || (count == 0) || (count == 1) || (count == 2) || (count == 3)))) {
				while(currentTime < durationInSeconds)
				{
					w.alpha = Mathf.Lerp(startA,0f, currentTime / durationInSeconds);
					currentTime += Time.deltaTime;
					yield return null;
				}
			}
		} else {
			if (((back == false) && ((count == 1) || (count == 3) || (count == 5) || (count == 7) || (count == 9))) || ((back == true) 
			                                                                                                            && ((count == 0) || (count == 2) || (count == 4) || (count == 6) || (count == 8)))) {
				while(currentTime < durationInSeconds)
				{
					w.alpha = Mathf.Lerp(startA,0f, currentTime / durationInSeconds);
					currentTime += Time.deltaTime;
					yield return null;
				}
			}
		}
		*/
        //cover.alpha = coverAlpha;

        //if (PlayerPrefs.GetFloat("printSize") < 0.6f)
        //{
        if (count == -1)
        {
            EnableCharacters(page1);

            audiosource.Stop();
            audiosource.clip = part1;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image1") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "What is coding? \n Is this something for me? ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 0)
        {
            DisableCharacters(page2);
            EnableCharacters(page1);

            if (back)
                AnimatePage(page1);

            audiosource.Stop();
            audiosource.clip = part2;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image1") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "Coding helps to make computers \n think more quickly. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 1)
        {
            DisableCharacters(page1);
            EnableCharacters(page2);

            if (!back)
                AnimatePage(page2);

            audiosource.Stop();
            audiosource.clip = part3;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image2") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "Meet Tommy the Turtle who will \n help you learn to code. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 2)
        {
            DisableCharacters(page3);
            EnableCharacters(page2);

            if (back)
                AnimatePage(page2);

            audiosource.Stop();
            audiosource.clip = part4;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image2") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "He and his friends will lead you \n down the Code Road. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 3)
        {
            DisableCharacters(page2);
            EnableCharacters(page3);

            if (!back)
                AnimatePage(page3);

            audiosource.Stop();
            audiosource.clip = part5;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image3") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "We will first get help \n from Ollie Owl and Cathy Cat. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 4)
        {
            DisableCharacters(page4);
            EnableCharacters(page3);

            if (back)
                AnimatePage(page3);

            audiosource.Stop();
            audiosource.clip = part6;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image3") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "We will all work together \n as we code and chat. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 5)
        {
            DisableCharacters(page3);
            EnableCharacters(page4);

            if (!back)
                AnimatePage(page4);

            audiosource.Stop();
            audiosource.clip = part7;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image4") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "We will also meet other friends \n along the way ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 6)
        {
            DisableCharacters(page5);
            EnableCharacters(page4);

            if (back)
                AnimatePage(page4);

            audiosource.Stop();
            audiosource.clip = part8;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image4") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "To teach computers what to do \n and what to say. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 7)
        {
            DisableCharacters(page4);
            EnableCharacters(page5);

            if (!back)
                AnimatePage(page5);

            audiosource.Stop();
            audiosource.clip = part9;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image5") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "You might think- I can't talk to computers. \n I don't know how! ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 8)
        {
            EnableCharacters(page5);
            DisableCharacters(page6);

            if (back)
                AnimatePage(page5);

            audiosource.Stop();
            audiosource.clip = part10;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image5") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "Time for an adventure with Tommy \n who will show you now. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 9)
        {
            DisableCharacters(page5);
            EnableCharacters(page6);

            if (!back)
                AnimatePage(page6);

            audiosource.Stop();
            audiosource.clip = part11;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image6") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "First on the road, \n we meet Ollie Owl sitting in a tree. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 10)
        {
            EnableCharacters(page6);
            DisableCharacters(page7);

            if (back)
                AnimatePage(page6);

            audiosource.Stop();
            audiosource.clip = part12;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image6") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "Ollie is laughing \n and singing with glee. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 11)
        {
            DisableCharacters(page6);
            EnableCharacters(page7);

            if (!back)
                AnimatePage(page7);

            audiosource.Stop();
            audiosource.clip = part13;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image7") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "Ollie says 'I sit here and sing \n because it's what I was told.' ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 12)
        {
            EnableCharacters(page7);
            DisableCharacters(page8);

            if (back)
                AnimatePage(page7);

            audiosource.Stop();
            audiosource.clip = part14;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image7") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "'Please give me another command \n before I grow old.' ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 13)
        {
            DisableCharacters(page7);
            EnableCharacters(page8);

            if (!back)
                AnimatePage(page8);

            audiosource.Stop();
            audiosource.clip = part15;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image8") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "Our computers use commands \n in just the same way, ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 14)
        {
            EnableCharacters(page8);
            DisableCharacters(page9);

            if (back)
                AnimatePage(page8);

            audiosource.Stop();
            audiosource.clip = part16;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image8") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "When a simple command runs \n it makes the computer play. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 15)
        {
            DisableCharacters(page8);
            EnableCharacters(page9);

            if (!back)
                AnimatePage(page9);

            audiosource.Stop();
            audiosource.clip = part17;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image9") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "As we travel down the road, \n we see Leo Lion slinking along. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 16)
        {
            DisableCharacters(page10);
            EnableCharacters(page9);

            if (back)
                AnimatePage(page9);

            audiosource.Stop();
            audiosource.clip = part18;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image9") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "All of a sudden he takes a big, high jump \n right off of the ground. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 17)
        {
            DisableCharacters(page9);
            EnableCharacters(page10);

            if (!back)
                AnimatePage(page10);

            audiosource.Stop();
            audiosource.clip = part19;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image10") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "Leo says, 'I take little steps \n until I get in place.' ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 18)
        {
            DisableCharacters(page11);
            EnableCharacters(page10);

            if (back)
                AnimatePage(page10);

            audiosource.Stop();
            audiosource.clip = part20;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image10") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "'Then I make a big jump \n and get ahead of the race.' ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 19)
        {
            DisableCharacters(page10);
            EnableCharacters(page11);

            if (!back)
                AnimatePage(page11);

            audiosource.Stop();
            audiosource.clip = part21;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image11") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "See-our computer can do that- \n make a jump too, ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 20)
        {
            DisableCharacters(page12);
            EnableCharacters(page11);

            if (back)
                AnimatePage(page11);

            audiosource.Stop();
            audiosource.clip = part22;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image11") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "Over the steps called coding \n that tells it what to do. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 21)
        {
            DisableCharacters(page11);
            EnableCharacters(page12);

            if (!back)
                AnimatePage(page12);

            audiosource.Stop();
            audiosource.clip = part23;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image12") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "Next, we run into Elenor Elephant \n who walks slow as can be. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 22)
        {
            DisableCharacters(page13);
            EnableCharacters(page12);

            if (back)
                AnimatePage(page12);

            audiosource.Stop();
            audiosource.clip = part24;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image12") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "She says 'I don't run. \n I walk quite deliberately.' ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 23)
        {
            DisableCharacters(page12);
            EnableCharacters(page13);

            if (!back)
                AnimatePage(page13);

            audiosource.Stop();
            audiosource.clip = part25;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image13") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "'Two steps left, \n then four steps right.' ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 24)
        {
            DisableCharacters(page14);
            EnableCharacters(page13);

            if (back)
                AnimatePage(page13);

            audiosource.Stop();
            audiosource.clip = part26;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image13") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "'I count to make sure \n I don't lose sight.' ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 25)
        {
            DisableCharacters(page13);
            EnableCharacters(page14);

            if (!back)
                AnimatePage(page14);

            audiosource.Stop();
            audiosource.clip = part27;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image14") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "Our computers also count \n each step along their way, ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 26)
        {
            DisableCharacters(page15);
            EnableCharacters(page14);

            if (back)
                AnimatePage(page14);

            audiosource.Stop();
            audiosource.clip = part28;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image14") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "To make sure it does \n exactly what we say. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 27)
        {
            DisableCharacters(page14);
            EnableCharacters(page15);

            if (!back)
                AnimatePage(page15);

            audiosource.Stop();
            audiosource.clip = part29;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image15") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "Next on the road, we come to Cathy Cat \n who is twirling, twirling around. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 28)
        {
            DisableCharacters(page16);
            EnableCharacters(page15);

            if (back)
                AnimatePage(page15);

            audiosource.Stop();
            audiosource.clip = part30;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image15") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "'What in the world are you doing Cathy?' \n says Tommy with a frown. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 29)
        {
            DisableCharacters(page15);
            EnableCharacters(page16);

            if (!back)
                AnimatePage(page16);

            audiosource.Stop();
            audiosource.clip = part31;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image16") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "Cathy says 'I'm looping, \n looping don't you see?' ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 30)
        {
            DisableCharacters(page17);
            EnableCharacters(page16);

            if (back)
                AnimatePage(page16);

            audiosource.Stop();
            audiosource.clip = part32;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image16") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "'I loop and I loop. \n Its really fun for me.' ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 31)
        {
            DisableCharacters(page16);
            EnableCharacters(page17);

            if (!back)
                AnimatePage(page17);

            audiosource.Stop();
            audiosource.clip = part33;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image17") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "Our computers use looping \n in just the same way ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 32)
        {
            DisableCharacters(page18);
            EnableCharacters(page17);

            if (back)
                AnimatePage(page17);

            audiosource.Stop();
            audiosource.clip = part34;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image17") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "By doing the same thing \n a million times a day. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 33)
        {
            DisableCharacters(page17);
            EnableCharacters(page18);

            if (!back)
                AnimatePage(page18);

            audiosource.Stop();
            audiosource.clip = part35;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image18") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "With Cat in tow, we meet Dudly Dog \n who is sad you see, ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 34)
        {
            EnableCharacters(page18);
            DisableCharacters(page19);

            if (back)
                AnimatePage(page18);

            audiosource.Stop();
            audiosource.clip = part36;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image18") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "Because he wants to do things \n faster and more easily. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 35)
        {
            DisableCharacters(page18);
            EnableCharacters(page19);

            if (!back)
                AnimatePage(page19);

            audiosource.Stop();
            audiosource.clip = part37;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image19") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "Dudly says 'I need help my friends \n and I have a plan too!' ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 36)
        {
            EnableCharacters(page19);
            DisableCharacters(page20);

            if (back)
                AnimatePage(page19);

            audiosource.Stop();
            audiosource.clip = part38;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image19") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "'I'll put down each step \n called instructions for you.' ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 37)
        {
            DisableCharacters(page19);
            EnableCharacters(page20);

            if (!back)
                AnimatePage(page20);

            audiosource.Stop();
            audiosource.clip = part39;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image20") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "Did you know everyone's computer \n can follow the same plan? ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 38)
        {
            EnableCharacters(page20);
            DisableCharacters(page21);

            if (back)
                AnimatePage(page20);

            audiosource.Stop();
            audiosource.clip = part40;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image20") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "Instructions make a program \n that can be used over and over again. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 39)
        {
            DisableCharacters(page20);
            EnableCharacters(page21);

            if (!back)
                AnimatePage(page21);

            audiosource.Stop();
            audiosource.clip = part41;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image21") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "With all of our friends, \n we have come to the end of the road ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 40)
        {
            EnableCharacters(page21);
            DisableCharacters(page22);

            if (back)
                AnimatePage(page21);

            audiosource.Stop();
            audiosource.clip = part42;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image21") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "And we've learned about words \n that are used when we code. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 41)
        {
            DisableCharacters(page21);
            EnableCharacters(page22);

            if (!back)
                AnimatePage(page22);

            audiosource.Stop();
            audiosource.clip = part43;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image22") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "See, with Tommy, \n you can use the same words too! ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 42)
        {
            EnableCharacters(page22);
            DisableCharacters(page23);

            if (back)
                AnimatePage(page22);

            audiosource.Stop();
            audiosource.clip = part44;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image22") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "Jump, loop, count, and run \n lets you tell the computer what to do. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 43)
        {
            DisableCharacters(page22);
            EnableCharacters(page23);

            if (!back)
                AnimatePage(page23);

            audiosource.Stop();
            audiosource.clip = part45;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image23") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "Tommy the Turtle has helped you \n learn to code. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 44)
        {
            EnableCharacters(page23);
            DisableCharacters(page24);

            if (back)
                AnimatePage(page23);

            audiosource.Stop();
            audiosource.clip = part46;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image23") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "Thank you for taking this trip \n with friends down the Code Road. ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        else if (count == 45)
        {
            DisableCharacters(page23);
            EnableCharacters(page24);

            if (!back)
                AnimatePage(page24);

            audiosource.Stop();
            audiosource.clip = part47;
            audiosource.Play();
            count++;
            sprite.mainTexture = Resources.Load("image24") as Texture;
            StartCoroutine(FadeIn(sprite, 0.5f, startA));
            message = "Congratulations on completeing \n the Code Road! ";
            StartCoroutine(TypeText(nextAlpha, coverAlpha));
        }
        //else if (count == 42)
        //{
        //    EnableCharacters(page24);

        //    if (back)
        //        AnimatePage(page24);

        //    audiosource.Stop();
        //    audiosource.clip = part48;
        //    audiosource.Play();
        //    count++;
        //    sprite.mainTexture = Resources.Load("image24") as Texture;
        //    StartCoroutine(FadeIn(sprite, 0.5f, startA));
        //    message = "Because he wants to do things \n faster and more easily. ";
        //    StartCoroutine(TypeText(nextAlpha, coverAlpha));
        //}


        else if (count == 46)
        {
            DisableCharacters(page24);
            //ls.GetComponent<UIPanel>().alpha = 1f;
            storyView.alpha = 0f;

            //SceneManager.LoadSceneAsync("LoadingScreen", LoadSceneMode.Additive);
            StartCoroutine(DisplayScene());
        }
        //}

        back = false;
    }

    IEnumerator FadeIn(UIWidget w, float durationInSeconds, float a)
	{
		float startA = w.alpha;
		float currentTime = 0f;
		while (currentTime < durationInSeconds)
		{
			w.alpha = Mathf.Lerp(startA, a, currentTime / durationInSeconds);
			currentTime += Time.deltaTime;
			yield return null;
		}
		w.alpha = startAlpha;
		//w.alpha = 0f;

		if (PlayerPrefs.GetFloat("printSize") < 0.6f)
		{
			//			if (count == 3) {
			//				w.alpha = 0;
			//				otherBackground.alpha = 1;
			//			} else {
			//				otherBackground.alpha = 0;
			//			}
			//otherBackground.alpha = 0;
		}
		else
		{
			//if (count == 6)
			//{
			//	w.alpha = 0;
			//	otherBackground.alpha = 1;
			//}
			//else if (count == 7)
			//{
			//	w.alpha = 0;
			//	otherBackground.alpha = 1;
			//}
			//else
			//{
			//	otherBackground.alpha = 0;
			//}
		}
	}

	IEnumerator TypeText(float nextAlpha, float coverAlpha)
	{
		load = true;
		completetext = false;
		/*
		strings = new string[message.Length];
		int track = 0;
		int prev = 0;
		for (int i = 0;i < message.Length;i++)
		{
			Debug.Log(message.Length);
			if (message[i] == ' ') {
				Debug.Log("a");
				strings[track] = message.Substring(prev,i-prev+1);
			}
			prev = i+1;
			track = track+1;
		}
		for (int i = 0;i < strings.Length;i++)
		{
			Debug.Log(strings.Length);
			if (strings[i] != null) {
				label.text += strings[i];
			}
			yield return 0;
			yield return new WaitForSeconds(0.05f);
		}
		*/
		//if (PlayerPrefs.GetFloat ("printSize") == 1f)
		//	message = message.Replace ("Wootzy","WOOTZY");
		int spaces = 0;
		if ((PlayerPrefs.GetInt("typing") == 1) && (PlayerPrefs.GetInt("highlight") == 0))
		{
            label.text += "[FFFF00]";
			foreach (char letter in message.ToCharArray())
			{
				if (completetext == true)
				{
					label.text = message;
					break;
				}
				label.text += letter;
				//if (sound)
				//{
				//    //AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
				//}
				if (letter == ' ')
				{
					spaces++;
				}
				yield return 0;
				yield return new WaitForSeconds(0.038f);
			}
		}
		else
		{
			if (PlayerPrefs.GetInt("typing") == 1)
			{
				foreach (char letter in message.ToCharArray())
				{
					if (completetext == true)
					{
						label.text = message;
						break;
					}
					label.text += letter;
					//if (sound)
					//{
					//    //AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
					//}
					yield return 0;
					yield return new WaitForSeconds(0.038f);
				}
			}
			else if (PlayerPrefs.GetInt("highlight") == 0)
			{
				label.text = "[FFFF00]" + message;
				string[] parts = new string[2];
				parts[0] = "[FFFF00]";
				parts[1] = "";
				bool twosentence = false;
				foreach (char letter in message.ToCharArray())
				{
					parts[0] += letter;
					parts[1] += letter;
					if (letter == '\n')
					{
						parts[0] += "[-]";
						parts[1] += "[FFFF00]";
						twosentence = true;
					}
				}
				label.text = parts[0];
				if (twosentence)
				{
					yield return 0;
					for (int i = 0; i < 22; i++)
					{
						//if (PlayerPrefs.GetFloat("printSize") > 0.6f)
						//{
						//    yield return new WaitForSeconds(0.15f);
						//}
						//else
						//{//if too long
						if (count == 0 || count == 1 || count == 8 || count == 14 || count == 16)
						{
							yield return new WaitForSeconds(0.1f);
						}
						else if (count == 3 || count == 5 || count == 9 || count == 11 || count == 13 || count == 15)
						{// if short 
							yield return new WaitForSeconds(0.24f);
						}
						else
						{
							yield return new WaitForSeconds(0.17f);
						}
						//}
						if (completetext == true)
						{
							break;
						}
					}
					label.text = parts[1];
				}
				yield return 0;
				if (completetext == false)
				{
					for (int i = 0; i < 22; i++)
					{
						//if (PlayerPrefs.GetFloat("printSize") > 0.6f)
						//{
						if (count == 6 || count == 8 || count == 9 || count == 10 || count == 11 || count == 18 || count == 22 || count == 23 || count == 24 || count == 26 || count == 27 || count == 28 || count == 30 || count == 31 || count == 34 || count == 36 || count == 37)
						{
							yield return new WaitForSeconds(0.20f);
						}
						else if (count == 11)
						{
							yield return new WaitForSeconds(0.24f);
						}
						else if (count == 0)
						{
							yield return new WaitForSeconds(0.1f);
						}
						else
						{
							yield return new WaitForSeconds(0.15f);
						}
						//Debug.Log(count);
						//}
						//else
						//{
						//    if (count == 8 || count == 14 || count == 16 || count == 18)
						//    {
						//        yield return new WaitForSeconds(0.26f);//
						//    }
						//    else
						//    {
						//        yield return new WaitForSeconds(0.15f);
						//    }
						//}
						if (completetext == true)
						{
							break;
						}
					}
				}
				label.text = message;
			}
			else
			{
				label.text = message;
			}
		}

		/*
		foreach (char letter in message.ToCharArray()) 
		{
			if (completetext == true) 
			{
				label.text = message;
				break;
			}
			label.text += letter;
			if (sound)
			{
				//AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
			}
			yield return 0;
            if (PlayerPrefs.GetFloat("printSize") < 0.6f) {
				if (count == 3) {
					yield return new WaitForSeconds (0.05f);
				} else if (count == 6) {
					yield return new WaitForSeconds (0.025f);
				} else if (count == 7) {
					yield return new WaitForSeconds (0.035f);
				} else {
					yield return new WaitForSeconds (0.045f);
				}
			} else {
				if (count == 6) {
					yield return new WaitForSeconds (0.08f);
				} else if ((count == 10) || (count == 13)) {
					yield return new WaitForSeconds (0.03f);
				} else {
					yield return new WaitForSeconds (0.045f);
				}
			}

		}  
		*/

		/*
		int numSpaces = 0;
		foreach (char letter in message.ToCharArray()) 
		{
			if (letter == ' ') 
			{
				numSpaces++;
			}
		}
		int times = 0;
		int equals = 0;

		label.text += "[FFFF00]";
		foreach (char letter in message.ToCharArray()) 
		{
			if (completetext == true) 
			{
				label.text = message;
				break;
			}
			label.text += letter;
			if (letter == ' ') {
				label.text += "[-]";
			}
		}
		yield return 0;
		if (PlayerPrefs.GetFloat("printSize") < 0.6f) {
			if (count != 7) {
				yield return new WaitForSeconds (0.25f);
			} else {
				yield return new WaitForSeconds (0.22f);
			}
			if (count == 2) {
				yield return new WaitForSeconds (0.06f);
			} else if (count == 3) {
				yield return new WaitForSeconds (0.08f);
			} else if (count == 4) {
				yield return new WaitForSeconds (0.12f);
			} else if (count == 5) {
				yield return new WaitForSeconds (0.04f);
			} 
		} else {
			yield return new WaitForSeconds (0.25f);
			if (count == 6) {
				yield return new WaitForSeconds (0.15f);
			} else if (count == 7 || count == 8) {
				yield return new WaitForSeconds (0.11f);
			} else if (count == 10) {
				yield return new WaitForSeconds (0.03f);
			} else {
				yield return new WaitForSeconds (0.04f);
			}
		}

		while (equals != numSpaces)
		{
			times = 0;
			label.text = "";
			foreach (char letter in message.ToCharArray()) 
			{
				label.text += letter;
				if (letter == ' ' && times == equals) {
					label.text += "[FFFF00]";
					times++;
				} else if (letter == ' ' && times == equals+1) {
					label.text += "[-]";
					times++;
				} else if (letter == ' ') {
					times++;
				}
			}  
			if (completetext == true) 
			{
				label.text = message;
				break;
			}
			equals++;
			yield return 0;
			if (PlayerPrefs.GetFloat("printSize") < 0.6f) {
				if (count != 7) {
					yield return new WaitForSeconds (0.25f);
				} else {
					yield return new WaitForSeconds (0.22f);
				}
				if (count == 2) {
					yield return new WaitForSeconds (0.06f);
				} else if (count == 3) {
					yield return new WaitForSeconds (0.08f);
				} else if (count == 4) {
					yield return new WaitForSeconds (0.12f);
				} else if (count == 5) {
					yield return new WaitForSeconds (0.04f);
				} 
			} else {
				yield return new WaitForSeconds (0.25f);
				if (count == 6) {
					yield return new WaitForSeconds (0.15f);
				} else if (count == 7 || count == 8) {
					yield return new WaitForSeconds (0.11f);
				} else if (count == 10) {
					yield return new WaitForSeconds (0.03f);
				} else if ((count == 12) || (count == 13)) { 

				} else {
					yield return new WaitForSeconds (0.04f);
				}
			}
		}
		*/
		completetext = true;
		next.alpha = nextAlpha;
		//cover.alpha = coverAlpha;
		//play.text = "Next";

		exitBack.GetComponent<Collider>().enabled = true;
		exitBack.alpha = 255;
		playBack2.alpha = 255;
		exitLabel.alpha = 255;
		repeatBack.GetComponent<Collider>().enabled = true;
		repeatBack.alpha = 255;
		repeatBack2.alpha = 255;
		repeatLabel.alpha = 255;
		backBack.GetComponent<Collider>().enabled = true;
		backBack.alpha = 255;
		backBack2.alpha = 255;
		backLabel.alpha = 255;

		if (count == 0)
		{
			//play.text = "Play";
		}
		enabled = true;

		if (backPage)
		{
			backPage = false;
			backClick();
		}
		if (nextPage)
		{
			nextPage = false;
			OnClick();
		}
		if (repeatPage)
		{
			repeatPage = false;
			repeatClick();
		}
	}

	IEnumerator DisplayScene()
	{
        if (!SceneManager.GetSceneByName("LoadingScreen").isLoaded)
            SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Additive);

        //mainCamera.gameObject.SetActive(false);

        yield return new WaitForSeconds(1);
		SceneManager.LoadSceneAsync(1);
		Destroy(storyParent);

        if (SceneManager.GetActiveScene().name == "LoadingScreen")
            SceneManager.UnloadSceneAsync("LoadingScreen");
    }

	IEnumerable RepeatScene()
	{
		yield return new WaitForSeconds(0);
		SceneManager.LoadScene("1stScene");

		//LoadingScreen loadingTemp = Instantiate(ls);

		Destroy(storyParent);

        if (SceneManager.GetActiveScene().name == "LoadingScreen")
            SceneManager.UnloadSceneAsync("LoadingScreen");
    }

	public void Turotiral1OnClick()
	{
		Tutorial_1.SetActive(false);
		Tutorial_2.SetActive(true);
		PlayerPrefs.SetInt("tutorial", 1);
	}
	public void Turotiral2OnClick()
	{
		Tutorial_2.SetActive(false);
		Tutorial_3.SetActive(true);
		PlayerPrefs.SetInt("tutorial", 2);
	}
	public void Turotiral3OnClick()
	{
		Tutorial_3.SetActive(false);
		inTutorialMode = false;
		//Set finish tutorial
		PlayerPrefs.SetInt("tutorial", 3);
	}
}

