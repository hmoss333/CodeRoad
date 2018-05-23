using UnityEngine;
using System.Collections;

public class settingsPanelScript : MonoBehaviour {

	public GameObject education;
	public GameObject therapy;
	public UIToggle highlightCheck;
	public UIToggle typingCheck;
	public UIToggle voiceCheck;
    public UIToggle miniGameCheck;
    public UIToggle scanCheck;
    public UISlider scanSlider;
    public UIToggle educationCheck;
	public UIToggle therapyCheck;
	private bool on = false;

    //public UISlider speedOfLabel;
    //public UILabel speedLabel;

    public UISprite educationBack;
	public UISprite therapyBack;

	public UISprite playBackground; 

	private Color orig;
	private Color half;

    public void Awake ()
    {
        //speedOfLabel = GameObject.Find("speedOfLabel").GetComponent<UISlider>();
        //speedOfLabel.value = 1 - PlayerPrefs.GetFloat("speedOfLabel");
        PlayerPrefs.SetInt("levelSelect", 0);
    }

    public void switching() {
		on = !on;
	}

	public void highlightButton () {
		if (on) {
			if (PlayerPrefs.GetInt("highlight") == 1) {
				PlayerPrefs.SetInt("highlight",0);
			} else {
				PlayerPrefs.SetInt("highlight",1);
			}
		}
	}

	public void typingButton () {
		if (on) {
			if (PlayerPrefs.GetInt("typing") == 0) {
				PlayerPrefs.SetInt("typing",1);
			} else {
				PlayerPrefs.SetInt("typing",0);
			}
		}
	}

	public void voiceButton () {
		if (on) {
			if (PlayerPrefs.GetInt("voice") == 1) {
				PlayerPrefs.SetInt("voice",0);
			} else {
				PlayerPrefs.SetInt("voice",1);
			}
		}
    }

    public void miniGameButton()
    {
        if (on) {
            if (PlayerPrefs.GetInt("minigames") == 1) {
                PlayerPrefs.SetInt("minigames", 0);
            } else {
                PlayerPrefs.SetInt("minigames", 1);
            }
        }
    }

    public void scanButton()
    {
        if (on)
        {
            if (PlayerPrefs.GetInt("Scan") == 1)
            {
                PlayerPrefs.SetInt("Scan", 0);
            }
            else
            {
                PlayerPrefs.SetInt("Scan", 1);
            }
        }

        Debug.Log(PlayerPrefs.GetInt("Scan"));
    }

    public void scanSpeed()
    {
        PlayerPrefs.SetFloat("scanSpeed", scanSlider.value);
    }

    public void educationButton () {
		if (on) {
			if ((PlayerPrefs.GetInt("educationOn") == 1) && (PlayerPrefs.GetInt("therapyOn") == 1)) {
				educationBack.color = half;
				education.GetComponent<Collider>().enabled = false;
				therapyBack.color = orig;
				therapy.GetComponent<Collider>().enabled = true;
				PlayerPrefs.SetInt("educationOn",0);
			} else {
				if (PlayerPrefs.GetInt("therapyOn") == 1) {
					educationBack.color = half;
					education.GetComponent<Collider>().enabled = false;
					therapyBack.color = half;
					therapy.GetComponent<Collider>().enabled = false;
					PlayerPrefs.SetInt("educationOn",1);
				} else {
					if (PlayerPrefs.GetInt("educationOn") == 1) {
						PlayerPrefs.SetInt("educationOn",0);
						educationBack.color = half;
						education.GetComponent<Collider>().enabled = false;
					} else {
						PlayerPrefs.SetInt("educationOn",1);
						educationBack.color = orig;
						education.GetComponent<Collider>().enabled = true;
					}
				}
			}
		}
	}

	public void therapyButton () {
		if (on) {
			if ((PlayerPrefs.GetInt("educationOn") == 1) && (PlayerPrefs.GetInt("therapyOn") == 1)) {
				educationBack.color = orig;
				education.GetComponent<Collider>().enabled = true;
				therapyBack.color = half;
				therapy.GetComponent<Collider>().enabled = false;
				PlayerPrefs.SetInt("therapyOn",0);
			} else {
				if (PlayerPrefs.GetInt("educationOn") == 1) {
					educationBack.color = half;
					education.GetComponent<Collider>().enabled = false;
					therapyBack.color = half;
					therapy.GetComponent<Collider>().enabled = false;
					PlayerPrefs.SetInt("therapyOn",1);
				} else {
					if (PlayerPrefs.GetInt("therapyOn") == 1) {
						PlayerPrefs.SetInt("therapyOn",0);
						therapyBack.color = half;
						therapy.GetComponent<Collider>().enabled = false;
					} else {
						PlayerPrefs.SetInt("therapyOn",1);
						therapyBack.color = orig;
						therapy.GetComponent<Collider>().enabled = true;
					}
				}
			}
		}
	}

	void Start () {

		orig = playBackground.color;
		half = new Color(playBackground.color.r/2, playBackground.color.g/2, playBackground.color.b/2);

		if (PlayerPrefs.GetInt("highlight") == 1) {
			highlightCheck.value = false;
		} else {
			highlightCheck.value = true;
		}
		if (PlayerPrefs.GetInt("typing") == 0) {
			typingCheck.value = false;
		} else {
			typingCheck.value = true;
		}
		if (PlayerPrefs.GetInt("voice") == 1) {
			voiceCheck.value = false;
		} else {
			voiceCheck.value = true;
		}
        if (PlayerPrefs.GetInt("minigames") == 1) {
            miniGameCheck.value = true;
        } else {
            miniGameCheck.value = false;
        }
        if (PlayerPrefs.GetInt("Scan") == 1) {
            scanCheck.value = true;
        } else {
            scanCheck.value = false;
        }
        scanSlider.value = PlayerPrefs.GetFloat("scanSpeed");


        if (PlayerPrefs.GetInt("eduStart") == 0) {
			PlayerPrefs.SetInt("eduStart",1);
			PlayerPrefs.SetInt("educationOn",1);
		}


		if ((PlayerPrefs.GetInt("educationOn") == 1) && (PlayerPrefs.GetInt("therapyOn") == 1)) {
			educationCheck.value = true;
			educationBack.color = half;
			education.GetComponent<Collider>().enabled = false;
			therapyCheck.value = true;
			therapyBack.color = half;
			therapy.GetComponent<Collider>().enabled = false;
		} else {
			if (PlayerPrefs.GetInt("educationOn") == 0) {
				educationCheck.value = false;
				educationBack.color = half;
				education.GetComponent<Collider>().enabled = false;
			} else {
				educationCheck.value = true;
				educationBack.color = orig;
				education.GetComponent<Collider>().enabled = true;
			}
			if (PlayerPrefs.GetInt("therapyOn") == 0) {
				therapyCheck.value = false;
				therapyBack.color = half;
				therapy.GetComponent<Collider>().enabled = false;
			} else {
				therapyCheck.value = true;
				therapyBack.color = orig;
				therapy.GetComponent<Collider>().enabled = true;
			}
		}

        //PlayerPrefs.SetFloat("speedOfLabel", 0.50f);
    }

}
