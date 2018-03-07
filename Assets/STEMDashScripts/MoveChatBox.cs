using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveChatBox : MonoBehaviour {

	 public bool MoveDown = false;    ///gives you control in inspector to trigger it or not
	 public bool MoveUp = false;    ///gives you control in inspector to trigger it or not
     public Vector3 MoveVector = Vector3.up; //unity already supplies us with a readonly vector representing up and we are just chaching that into MoveVector
     public float MoveSpeed = 1000.0f; //change this to make it faster or slower
     Button exitBtn;
     float heightUpOffset = 0.0f; 
     float heightDownOffset = 0.0f; 
 
     private MoveChatBox chatBox; //for caching this transform
     
     Vector3 startPosition; //used to cache the start position of the transform
     void Start()
     { 
        chatBox = this;
        Debug.Log("Screen Height: " + Screen.height);
        exitBtn = chatBox.GetComponentInChildren<Button>(); 
        exitBtn.onClick.AddListener(exitPopup);
        switch(PlayerPrefs.GetString("boxSize"))
        {
            case "small":
                chatBox.transform.localScale = new Vector2(1.0f, 1.0f);
                heightDownOffset = 63.0f;
                heightUpOffset = 68.0f; 
                break;
            case "medium":
                chatBox.transform.localScale = new Vector2(1.3f, 1.3f);
                heightDownOffset = 83.0f;
                heightUpOffset = 88.0f; 
                break;
            case "large":
                chatBox.transform.localScale = new Vector2(1.6f, 1.6f);
                heightDownOffset = 100.0f;
                heightUpOffset = 105.0f; 
                break;
        }
     }
    void exitPopup()
    {
        if(chatBox.gameObject != null)
        {
            ClientGlobals.chatTimer = 0.0f;
            MoveDown = false;
            MoveUp = false;
            Destroy(chatBox.gameObject);
            Debug.Log("Clicked");
        } 
    }

     void Update()
     {
        //See if you can work out whats going on here, for your own enjoyment
        //chatBox.transform.position = startPosition + MoveVector * (MoveRange * Mathf.Sin(Time.timeSinceLevelLoad * MoveSpeed));
        if(MoveDown)
             moveDown();
        if (MoveUp)
            moveUp();
     }

    public void moveDown()
    {
        float screenHeightOffset = 0.0f;
        screenHeightOffset = Screen.height - heightDownOffset;
        /*
        if(Screen.height >= 600)
            screenHeightOffset = Screen.height - heightDownOffset;
        else
            screenHeightOffset = Screen.height - (heightDownOffset - 5.0f);
            */

        float step = MoveSpeed * Time.deltaTime;
        Vector3 targetPosition = new Vector3(chatBox.transform.position.x, screenHeightOffset, chatBox.transform.position.z);
        chatBox.transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (chatBox.transform.position.y == screenHeightOffset)
        {
            MoveDown = false;
            Debug.Log("Ending Chat Box Postion: " + chatBox.transform.position.y);
            Debug.Log("Screen height Offset: " + screenHeightOffset);
        }
    }

    public void moveUp()
    {
            float screenHeightOffset = 0.0f;
            screenHeightOffset = Screen.height + heightUpOffset;
            /*
            if(Screen.height >= 600)
                screenHeightOffset = Screen.height + heightUpOffset;
            else
                screenHeightOffset = Screen.height + (heightUpOffset - 5.0f);
                */
            float step = MoveSpeed * Time.deltaTime;
            Vector3 targetPosition = new Vector3(chatBox.transform.position.x, screenHeightOffset, chatBox.transform.position.z);
            chatBox.transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            if(chatBox.transform.position.y == screenHeightOffset)
            {
                MoveUp = false;
                Debug.Log("Ending Chat Box Postion: " + chatBox.transform.position.y);
                Debug.Log("Screen height Offset: " + screenHeightOffset);
            }
    }
}
