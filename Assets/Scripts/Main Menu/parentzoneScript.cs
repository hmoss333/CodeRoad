using UnityEngine;
using System.Collections;

public class parentzoneScript : MonoBehaviour {

	int parentalGateFirstNumber;
	int parentalGateSecondNumber;
	int parentalGateAnswer;

    bool bookClick = false;
    bool optionClick = false;

	public UITexture background;

	public UILabel Button_ParentalGate_1;
	public UILabel Button_ParentalGate_2;
	public UILabel Button_ParentalGate_3;
	public UILabel Button_ParentalGate_4;

	public UILabel PrentalGate_QuestionLabel;
	// Use this for initialization

	public UIPanel frontpanel;
	public UIPanel optionspanel;
	public UIPanel parentzonepanel;
    //public GameObject storePanel;

	public AudioSource backgroundMusic;
    public AudioClip askVoice;

    public string link;

	public void parentzoneEnter(){
        if (PlayerPrefs.GetInt("voice") == 0)
        {
            backgroundMusic.PlayOneShot(askVoice, 1.0F);
        }

        parentalGateFirstNumber = Random.Range (4,10);
		parentalGateSecondNumber = Random.Range (4,10);
		parentalGateAnswer = parentalGateFirstNumber * parentalGateSecondNumber;
		PrentalGate_QuestionLabel.text=parentalGateFirstNumber.ToString()+" X "+parentalGateSecondNumber.ToString()+" =  ?";
		
		int randomIndex = Random.Range (0, 4);
		int wrongAnswer = 0;
		if (randomIndex == 0) {
			Button_ParentalGate_1.text = parentalGateAnswer.ToString();
			wrongAnswer = parentalGateAnswer+Random.Range(1,10);
			Button_ParentalGate_2.text = wrongAnswer.ToString();
			wrongAnswer = parentalGateAnswer-Random.Range(1,10);
			Button_ParentalGate_3.text = wrongAnswer.ToString();
			wrongAnswer = parentalGateAnswer+Random.Range(1,10);
			Button_ParentalGate_4.text = wrongAnswer.ToString();
		} else if (randomIndex == 1) {
			Button_ParentalGate_2.text = parentalGateAnswer.ToString();
			wrongAnswer = parentalGateAnswer+Random.Range(1,10);
			Button_ParentalGate_1.text = wrongAnswer.ToString();
			wrongAnswer = parentalGateAnswer-Random.Range(1,10);
			Button_ParentalGate_4.text = wrongAnswer.ToString();
			wrongAnswer = parentalGateAnswer+Random.Range(1,10);
			Button_ParentalGate_3.text = wrongAnswer.ToString();
		} else if (randomIndex == 2) {
			Button_ParentalGate_3.text = parentalGateAnswer.ToString();
			wrongAnswer = parentalGateAnswer+Random.Range(1,10);
			Button_ParentalGate_2.text = wrongAnswer.ToString();
			wrongAnswer = parentalGateAnswer-Random.Range(1,10);
			Button_ParentalGate_4.text = wrongAnswer.ToString();
			wrongAnswer = parentalGateAnswer-Random.Range(1,10);
			Button_ParentalGate_1.text = wrongAnswer.ToString();
		} else if (randomIndex == 3) {
			Button_ParentalGate_4.text = parentalGateAnswer.ToString();
			wrongAnswer = parentalGateAnswer-Random.Range(1,10);
			Button_ParentalGate_1.text = wrongAnswer.ToString();
			wrongAnswer = parentalGateAnswer-Random.Range(1,10);
			Button_ParentalGate_3.text = wrongAnswer.ToString();
			wrongAnswer = parentalGateAnswer+Random.Range(1,10);
			Button_ParentalGate_2.text = wrongAnswer.ToString();
		}
		
	}
	
	public void checkbutton1(){
		parentzonepanel.alpha = 0;
		if (Button_ParentalGate_1.text == parentalGateAnswer.ToString()) {
            if (optionClick)
            {
                optionspanel.alpha = 1;
                background.mainTexture = Resources.Load("background_challenge") as Texture;
            }
            else if (bookClick)
            {
                //storePanel.SetActive(true);
                background.mainTexture = Resources.Load("background") as Texture;
            }
			
		} else {
			frontpanel.alpha = 1;
			background.mainTexture = Resources.Load ("coderoad_opening") as Texture;
			if (PlayerPrefs.GetInt("voice") == 0) 
			{
				backgroundMusic.Play();
			}
		}
	}
	
	public void checkbutton2(){
		parentzonepanel.alpha = 0;
		if (Button_ParentalGate_2.text == parentalGateAnswer.ToString()) {
            if (optionClick)
            {
                optionspanel.alpha = 1;
                background.mainTexture = Resources.Load("background_challenge") as Texture;
            }
            else if (bookClick)
            {
                //storePanel.SetActive(true);
                background.mainTexture = Resources.Load("background") as Texture;
            }
        } else {
			frontpanel.alpha = 1;
			background.mainTexture = Resources.Load ("coderoad_opening") as Texture;
			if (PlayerPrefs.GetInt("voice") == 0) 
			{
				backgroundMusic.Play();
			}
		}
	}
	
	public void checkbutton3(){
		parentzonepanel.alpha = 0;
		if (Button_ParentalGate_3.text == parentalGateAnswer.ToString()) {
            if (optionClick)
            {
                optionspanel.alpha = 1;
                background.mainTexture = Resources.Load("background_challenge") as Texture;
            }
            else if (bookClick)
            {
                //storePanel.SetActive(true);
                background.mainTexture = Resources.Load("background") as Texture;
            }
        } else {
			frontpanel.alpha = 1;
			background.mainTexture = Resources.Load ("coderoad_opening") as Texture;
			if (PlayerPrefs.GetInt("voice") == 0) 
			{
				backgroundMusic.Play();
			}
		}
	}
	
	public void checkbutton4(){
		parentzonepanel.alpha = 0;
		if (Button_ParentalGate_4.text == parentalGateAnswer.ToString()) {
            if (optionClick)
            {
                optionspanel.alpha = 1;
                background.mainTexture = Resources.Load("background_challenge") as Texture;
            }
            else if (bookClick)
            {
                //storePanel.SetActive(true);
                background.mainTexture = Resources.Load("background") as Texture;
            }
        } else {
			frontpanel.alpha = 1;
			background.mainTexture = Resources.Load ("coderoad_opening") as Texture;
			if (PlayerPrefs.GetInt("voice") == 0) 
			{
				backgroundMusic.Play();
			}
		}
	}
	
	public void cancel() {
		parentzonepanel.alpha = 0;
		frontpanel.alpha = 1;
        //storePanel.SetActive(false);
        background.mainTexture = Resources.Load ("coderoad_opening") as Texture;
		if (PlayerPrefs.GetInt("voice") == 0) 
		{
			backgroundMusic.Play();
		}
	}

    public void BookClick()
    {
        bookClick = true;
        optionClick = false;
    }

    public void OptionClick()
    {
        bookClick = false;
        optionClick = true;
    }

    public void openLink()
    {
        Application.OpenURL(link);
    }

    void Start () {

    }
    
    // Update is called once per frame
    void Update () {
    
    }
	
}
