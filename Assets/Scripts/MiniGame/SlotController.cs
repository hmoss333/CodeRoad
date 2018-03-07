using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using SimpleJSON;

public class SlotController : MonoBehaviour {

    int ROWSIZE = 1;
    const int COLSIZE = 3;
    const float XCOORD = -220.0f;
    const float YCOORD = -125.0f;
    int tempRowIndex = 0, tempColIndex = 0;
    int slotCount = 0;
    int numberOfSlots = 0;

    public GameObject slotPrefab;
    public GameObject addSlotPrefab;
    public GameObject exampleOneCode;
    public GameObject exampleTwoCode;
    public GameObject turtle;
    public GameObject gameCanvas;
    public GameObject tiles;
    public GameObject saveSlotCanvas;
    public GameObject scrollContent;
    public GameObject addSlotObject;
    public GameObject STEMDashInvitePanel;
    public GameObject errorSavingPanel;
    public ScrollRect scrollRect;
    private RectOffset Padding;
    InputField newSlotInput;
    GameObject slotObject;
    bool menuIsOpen = false;
    bool inputActive = false;
    float inputInstatiateTime = 0.0f;
    float scrollToPos = 0.0f;
    bool isScrolling = false;
    int currentRow = 0, currentCol = 0;

    public List<List<GameObject>> saveSlots = new List<List<GameObject>>();
    public List<List<GameObject>> temp = new List<List<GameObject>>();
    public static Queue<GameObject> slotObjectQueue = new Queue<GameObject>();

	// Use this for initialization
	void Start () {

        loadSlots();
        finishedSavingHandler.finished += enableSlotBtns;
        finishedSavingHandler.errorSaving += destroyOnError;
        this.gameObject.SetActive(false);
	}

    int totalCount()
    {
        int total = 0;
        for(int i = 0; i < saveSlots.Count; i++)
        {
            foreach (GameObject obj in saveSlots[i])
                total++;
        }

        return total+1;
    }
     public void scrollToSlotObject()
    {
            /*
            if(Screen.height >= 600)
                screenHeightOffset = Screen.height + heightUpOffset;
            else
                screenHeightOffset = Screen.height + (heightUpOffset - 5.0f);
                */
            float step = 1000* Time.deltaTime;
            float x = scrollContent.GetComponent<RectTransform>().anchoredPosition3D.x;
            float z = scrollContent.GetComponent<RectTransform>().anchoredPosition3D.z;
            Vector3 targetPosition = new Vector3(x, scrollToPos, z);
            scrollContent.GetComponent<RectTransform>().anchoredPosition3D = Vector3.MoveTowards(scrollContent.GetComponent<RectTransform>().anchoredPosition3D, targetPosition, step);
            if(scrollContent.GetComponent<RectTransform>().anchoredPosition3D.y == scrollToPos)
            {
                isScrolling = false;
            }
    }

    void addSlot()
    {
        if (LoginToPortal.Instance.userIsLoggedIn)
        {
            int maxRow = saveSlots.Count - 1;
            int maxCol = saveSlots[maxRow].Count - 1;
            maxCol++;
            if (maxCol > 2)
            {
                maxCol = 0;
                maxRow++;
                saveSlots.Add(new List<GameObject>());
            }
            slotObject = Instantiate(slotPrefab);
            float yCoord = YCOORD - (maxRow * 240);
            float xCoord = XCOORD + (maxCol * 220);

            scrollToPos = (maxRow * 238);  //Stores the value to scroll to

            //Disables input field
            newSlotInput = slotObject.GetComponentInChildren<InputField>();
            newSlotInput.Select();
            newSlotInput.ActivateInputField();

            //Scroll up or down to the row where the slot is being made
            //scrollContent.GetComponent<RectTransform>().anchoredPosition3D = new Vector2(0, scrollToPos);
            isScrolling = true;

            int totalElements = totalCount();
            newSlotInput.text = "Slot" + totalElements;
            string code = GameManager.movesString.Replace("<b><color=#00ff00ff>", "");
            code = code.Replace("</color></b>", "");
            Text[] slotText = slotObject.GetComponentsInChildren<Text>();
            slotText[1].text = "";

            //This block is what saves the data
            newSlotInput.onEndEdit.AddListener(delegate
            {
                slotText[1].text = "<size=17>Saving...</size>";
                newSlotInput.transform.gameObject.SetActive(false);
                Transform newSlotParent = newSlotInput.GetComponentInParent<Transform>();
                newSlotParent.transform.gameObject.SetActive(false);
                Text title = slotObject.GetComponentInChildren<Text>();
                if (newSlotInput.text == "")
                {
                    title.text = "Slot" + totalElements;
                }
                else
                {
                    if (newSlotInput.text.Length > 8)
                        title.text = newSlotInput.text.Substring(0, 6) + "...";
                    else
                        title.text = newSlotInput.text;
                }
                string currentPlayerEmail = PlayerPrefs.GetString("CurrentPlayer").ToLower() + "_" + SaveAndLoad.dashEmail;
                string codeData = "{";
                codeData += "\"email\": \"" + currentPlayerEmail + "\",";
                codeData += "\"name\": \"" + PlayerPrefs.GetString("CurrentPlayer") + "\",";
                codeData += "\"title\": \"" + title.text + "\",";
                codeData += "\"code\": \"" + code + "\"";
                codeData += "}";
                SaveCode.Instance.saveTommyCode(codeData);
                
            });

            Button[] slotBtns = slotObject.GetComponentsInChildren<Button>();
            slotBtns[0].onClick.AddListener(loadSavedCode);
            slotBtns[1].onClick.AddListener(deleteSlot);
            slotBtns[0].gameObject.SetActive(false);
            slotBtns[1].gameObject.SetActive(false);
            Text[] indices = slotBtns[0].GetComponentsInChildren<Text>();
            indices[0].text = maxRow.ToString();
            indices[1].text = maxCol.ToString();
            indices = slotBtns[1].GetComponentsInChildren<Text>();
            indices[0].text = maxRow.ToString();
            indices[1].text = maxCol.ToString();

            slotObject.transform.SetParent(scrollContent.transform);
            slotObject.GetComponent<RectTransform>().anchoredPosition3D = new Vector2(xCoord, yCoord);
            saveSlots[maxRow].Add(slotObject);
            slotObjectQueue.Enqueue(slotObject);

            maxCol++;
            if (maxCol > 2)
            {
                maxCol = 0;
                maxRow++;
            }

            yCoord = YCOORD - (maxRow * 240);
            xCoord = XCOORD + (maxCol * 220);
            addSlotObject.GetComponent<RectTransform>().anchoredPosition3D = new Vector2(xCoord, yCoord);
            float scrollViewHeight = scrollContent.GetComponent<RectTransform>().rect.height;
            float addSlotObjectYPos = addSlotObject.GetComponent<RectTransform>().anchoredPosition3D.y;
            float position = Math.Abs(addSlotObjectYPos) + 98;
            if (position >= scrollViewHeight/2)
                scrollContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, scrollViewHeight * 2.0f);

        } else
        {
            STEMDashInvitePanel.SetActive(true);
        }
    }

    void enableSlotBtns()
    {
        if (slotObjectQueue.Count > 0)
        {
            GameObject thisObject = slotObjectQueue.Dequeue();
            Button[] slotBtns = thisObject.GetComponentsInChildren<Button>(true);
            slotBtns[0].gameObject.SetActive(true);
            slotBtns[1].gameObject.SetActive(true);
            Text[] slotText = thisObject.GetComponentsInChildren<Text>();
            slotText[1].text = "";

            //Sets the preview code
            for (int i = 0; i < GameManager.movement.Count; i++)
            {
                string previewCode = GameManager.movement[i].Replace("<b><color=#00ff00ff>", "");
                previewCode = previewCode.Replace("</color></b>", "");
                if (i == 5)
                    break;
                slotText[1].text += previewCode + "...\n";
            }
        }
    }

    void destroyOnError()
    {

        if (slotObjectQueue.Count > 0)
        {
            GameObject thisObject = slotObjectQueue.Dequeue();
            Button[] slotBtns = thisObject.GetComponentsInChildren<Button>(true);
            Text[] indices = slotBtns[1].GetComponentsInChildren<Text>(true);
            int rowIndex = int.Parse(indices[0].text); 
            int colIndex = int.Parse(indices[1].text); 
            if (saveSlots[rowIndex][colIndex] != null)
            {
                float lastX, lastY;
                int maxRow = saveSlots.Count - 1;
                int maxCol = saveSlots[maxRow].Count - 1;
                if (maxCol == -1)
                    maxCol = 2;
                try
                {
                    lastX = saveSlots[maxRow][maxCol].GetComponent<RectTransform>().anchoredPosition3D.x;
                    lastY = saveSlots[maxRow][maxCol].GetComponent<RectTransform>().anchoredPosition3D.y;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    maxRow--;
                    lastX = saveSlots[maxRow][maxCol].GetComponent<RectTransform>().anchoredPosition3D.x;
                    lastY = saveSlots[maxRow][maxCol].GetComponent<RectTransform>().anchoredPosition3D.y;
                }
                Text title = saveSlots[rowIndex][colIndex].GetComponentInChildren<Text>();
                addSlotObject.GetComponent<RectTransform>().anchoredPosition3D = new Vector2(lastX, lastY);
                Destroy(saveSlots[rowIndex][colIndex]);
                saveSlots[rowIndex][colIndex] = null;
                shiftContainer();
                errorSavingPanel.SetActive(true);
            }
        }
    }
    
    public void exitSTEMDashInvitePanel()
    {
        STEMDashInvitePanel.SetActive(false);
    }

    public void exitErrorPanel()
    {
        errorSavingPanel.SetActive(false);
    }

    void deleteSlot()
    {
        Button deleteBtn = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        Text[] indices = deleteBtn.GetComponentsInChildren<Text>();
        int rowIndex = int.Parse(indices[0].text); 
        int colIndex = int.Parse(indices[1].text); 
        if (saveSlots[rowIndex][colIndex] != null)
        {
            float lastX, lastY;
            int maxRow = saveSlots.Count - 1;
            int maxCol = saveSlots[maxRow].Count - 1;
            if (maxCol == -1)
                maxCol = 2;
            try
            {
                lastX = saveSlots[maxRow][maxCol].GetComponent<RectTransform>().anchoredPosition3D.x;
                lastY = saveSlots[maxRow][maxCol].GetComponent<RectTransform>().anchoredPosition3D.y;
            } catch(ArgumentOutOfRangeException ex)
            {
                maxRow--;
                lastX = saveSlots[maxRow][maxCol].GetComponent<RectTransform>().anchoredPosition3D.x;
                lastY = saveSlots[maxRow][maxCol].GetComponent<RectTransform>().anchoredPosition3D.y;
            }
            Text title = saveSlots[rowIndex][colIndex].GetComponentInChildren<Text>();
            string email = PlayerPrefs.GetString("CurrentPlayer").ToLower() + "_" + SaveAndLoad.dashEmail;
            addSlotObject.GetComponent<RectTransform>().anchoredPosition3D = new Vector2(lastX, lastY);
            Destroy(saveSlots[rowIndex][colIndex]);
            int index = colIndex + (rowIndex * COLSIZE) - 2;  //This is needed to calculate the position of the locally stored data
            var data = JSON.Parse(SaveAndLoad.savedCode[PlayerPrefs.GetString("CurrentPlayer")][index]); 
            saveSlots[rowIndex][colIndex] = null;
            shiftContainer();
            deleteCode.Instance.deleteTommyCode(data["objectId"].Value); //delete from cloud
            SaveAndLoad.savedCode[PlayerPrefs.GetString("CurrentPlayer")].RemoveAt(index);
        }
    }

    void loadSavedCode()
    {
        Button loadBtn = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        Text[] indices = loadBtn.GetComponentsInChildren<Text>();
        int rowIndex = int.Parse(indices[0].text);
        int colIndex = int.Parse(indices[1].text);
        GameObject slotObj = saveSlots[rowIndex][colIndex];
        Text[] slotText = slotObj.GetComponentsInChildren<Text>();
        if (rowIndex == 0 && colIndex == 0 || rowIndex == 0 && colIndex == 1)
        {
            string[] slotTxtArr = slotText[1].text.Replace("...", "").Split('\n');
            GameManager.movement.Clear();
            GameManager.movement.AddRange(slotTxtArr);
        }
        else
        {
            int index = colIndex + (rowIndex * COLSIZE)-2;
            var data = JSON.Parse(SaveAndLoad.savedCode[PlayerPrefs.GetString("CurrentPlayer")][index]);
            string[] slotTxtArr = data["code"].Value.Replace("...", "\n").Split('\n');
            GameManager.movement.Clear();
            GameManager.movement.AddRange(slotTxtArr);
            GameManager.movement.RemoveAt(GameManager.movement.Count - 1); //Remove blank space
        }
        GameManager.loadedCode = true;
        toggleSaveMenu(); 
    }

    //Use to load all slots saved
    void loadSlots()
    {
        if(SaveAndLoad.savedCode.ContainsKey(PlayerPrefs.GetString("CurrentPlayer")))
        {
            if (SaveAndLoad.savedCode[PlayerPrefs.GetString("CurrentPlayer")].Count > 0)
            {
                numberOfSlots = SaveAndLoad.savedCode[PlayerPrefs.GetString("CurrentPlayer")].Count;
                ROWSIZE = (int)Math.Ceiling((double) (numberOfSlots + 2) / COLSIZE);
            }
        }
        for(int i = 0; i < ROWSIZE; i++)
        {
            float column = YCOORD - (i * 240);
            saveSlots.Add(new List<GameObject>());
            for(int j = 0; j < COLSIZE; j++)
            {
                float row = XCOORD + (j * 220);
                if (i == 0 && j == 0) //Load first example
                {
                    exampleOneCode.GetComponent<RectTransform>().anchoredPosition3D = new Vector2(row, column);

                    Button[] slotBtns = exampleOneCode.GetComponentsInChildren<Button>();
                    Text[] indices = slotBtns[0].GetComponentsInChildren<Text>();
                    indices[0].text = i.ToString();
                    indices[1].text = j.ToString();
                    slotBtns[0].onClick.AddListener(loadSavedCode);
                    saveSlots[i].Add(exampleOneCode);
                }
                else if (i == 0 && j == 1) //Load second example
                {
                    exampleTwoCode.GetComponent<RectTransform>().anchoredPosition3D = new Vector2(row, column);
                    Button[] slotBtns = exampleTwoCode.GetComponentsInChildren<Button>();
                    Text[] indices = slotBtns[0].GetComponentsInChildren<Text>();
                    indices[0].text = i.ToString();
                    indices[1].text = j.ToString();
                    slotBtns[0].onClick.AddListener(loadSavedCode);
                    saveSlots[i].Add(exampleTwoCode);
                }
                else if(numberOfSlots > 0)
                {
                    try
                    {
                        slotObject = Instantiate(slotPrefab);

                        //Disables input field
                        InputField newSlotInput = slotObject.GetComponentInChildren<InputField>();
                        newSlotInput.transform.gameObject.SetActive(false);
                        Transform newSlotParent = newSlotInput.GetComponentInParent<Transform>();
                        newSlotParent.transform.gameObject.SetActive(false);
                        Text title = slotObject.GetComponentInChildren<Text>();
                        int index = j + (i * COLSIZE) - 2;  //This is needed to calculate the position of the locally stored data
                        var data = JSON.Parse(SaveAndLoad.savedCode[PlayerPrefs.GetString("CurrentPlayer")][index]);

                        //Sets the title
                        title.text = data["title"].Value;

                        Button[] slotBtns = slotObject.GetComponentsInChildren<Button>();
                        slotBtns[0].onClick.AddListener(loadSavedCode);
                        slotBtns[1].onClick.AddListener(deleteSlot);
                        Text[] indices = slotBtns[0].GetComponentsInChildren<Text>();
                        indices[0].text = i.ToString();
                        indices[1].text = j.ToString();
                        indices = slotBtns[1].GetComponentsInChildren<Text>();
                        indices[0].text = i.ToString();
                        indices[1].text = j.ToString();

                        //Sets the code preview
                        Text[] slotText = slotObject.GetComponentsInChildren<Text>();
                        string[] slotTxtArr = data["code"].Value.Replace("...", "...\n").Split('\n');
                        slotText[1].text = "";
                        for (int k = 0; k < slotTxtArr.Length; k++)
                        {
                            if (k == 5)
                                break;
                            slotText[1].text += slotTxtArr[k] + "\n";
                        }

                        //Sets parent and positioning
                        slotObject.transform.SetParent(scrollContent.transform);
                        slotObject.GetComponent<RectTransform>().anchoredPosition3D = new Vector2(row, column);
                        saveSlots[i].Add(slotObject);
                    }
                    catch (ArgumentOutOfRangeException ex) { }
                }
            }
        } 

        //Reposition the add slot button
        int maxRow = saveSlots.Count - 1;
        int maxCol = saveSlots[maxRow].Count - 1;
        maxCol++;
        if (maxCol > 2)
        {
            maxCol = 0;
            maxRow++;
        }
        float yCoord = YCOORD - (maxRow * 240);
        float xCoord = XCOORD + (maxCol * 220);
        addSlotObject = Instantiate(addSlotPrefab);
        addSlotObject.transform.SetParent(scrollContent.transform);
        Button addSlotBtn = addSlotObject.GetComponentInChildren<Button>();
        addSlotBtn.onClick.AddListener(addSlot);
        addSlotObject.GetComponent<RectTransform>().anchoredPosition3D = new Vector2(xCoord, yCoord);
        float scrollViewHeight = scrollContent.GetComponent<RectTransform>().rect.height;
        float addSlotObjectYPos = addSlotObject.GetComponent<RectTransform>().anchoredPosition3D.y;
        float position = Math.Abs(addSlotObjectYPos) + 98;

        //Increases the size of the scrollContent when the add button hits the bottom
        if (position >= scrollViewHeight)
            scrollContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, scrollViewHeight * 2.0f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isScrolling)
            scrollToSlotObject();
	}

    public void toggleSaveMenu()
    {
        if(!menuIsOpen)
        {
            saveSlotCanvas.SetActive(true);
            if (PlayerPrefs.GetInt("Voice") == 1)
            {
                saveSlotCanvas.GetComponent<AudioSource>().Play();
            }
            menuIsOpen = true; 
            disableGameCanvas();
        }
        else
        {
            enableGameCanvas();
            if (STEMDashInvitePanel.activeInHierarchy)
                STEMDashInvitePanel.SetActive(false);
            if(errorSavingPanel.activeInHierarchy)
                errorSavingPanel.SetActive(false);
            saveSlotCanvas.SetActive(false);
            menuIsOpen = false; 
        }
    }

    void disableGameCanvas()
    {
        turtle.SetActive(false);
        gameCanvas.SetActive(false);
    }

    void enableGameCanvas()
    {
        turtle.SetActive(true);
        gameCanvas.SetActive(true);
    }

    //Used to shift all slots to the left when a slot is deleted
     void shiftContainer()
        {
            tempRowIndex = 0;
            tempColIndex = 0;
            for(int i = 0; i < saveSlots.Count; i++)
            {
                for(int j = 0; j < saveSlots[i].Count; j++)
                {
                    if(saveSlots[i][j] != null)
                        addToTemp(saveSlots[i][j]);
                }
            }
            copyToOriginal();
        }
        void copyToOriginal()
        {
            saveSlots.Clear();
            for(int i = 0; i < temp.Count; i++)
            {
                saveSlots.Add(new List<GameObject>());
                for(int j = 0; j < temp[i].Count; j++)
                {
                    saveSlots[i].Add(temp[i][j]);
                }
            }
            temp.Clear();
        }

      void addToTemp(GameObject element)
        {
            float yCoord = YCOORD - (tempRowIndex * 240);
            float xCoord = XCOORD + (tempColIndex * 220);
            if (temp.Count == 0)
                temp.Add(new List<GameObject>());
            if (tempRowIndex == 0 && tempColIndex == 0) //Load first example
            {
                exampleOneCode.transform.localPosition = new Vector2(xCoord, yCoord);
                Button[] slotBtns = exampleOneCode.GetComponentsInChildren<Button>();
                Text[] indices = slotBtns[0].GetComponentsInChildren<Text>();
                indices[0].text = tempRowIndex.ToString();
                indices[1].text = tempColIndex.ToString();
                exampleOneCode.GetComponent<RectTransform>().anchoredPosition3D = new Vector2(xCoord, yCoord);
                temp[tempRowIndex].Add(exampleOneCode);
            }
            else if (tempRowIndex == 0 && tempColIndex == 1) //Load second example
            {
                exampleTwoCode.transform.localPosition = new Vector2(xCoord, yCoord);
                Button[] slotBtns = exampleTwoCode.GetComponentsInChildren<Button>();
                Text[] indices = slotBtns[0].GetComponentsInChildren<Text>();
                indices[0].text = tempRowIndex.ToString();
                indices[1].text = tempColIndex.ToString();
                exampleTwoCode.GetComponent<RectTransform>().anchoredPosition3D = new Vector2(xCoord, yCoord);
                temp[tempRowIndex].Add(exampleTwoCode);
            }
            else if(tempColIndex < 3)
            {
                Button[] slotBtns = element.GetComponentsInChildren<Button>();
                Text[] indices = slotBtns[0].GetComponentsInChildren<Text>();
                indices[0].text = tempRowIndex.ToString();
                indices[1].text = tempColIndex.ToString();
                indices = slotBtns[1].GetComponentsInChildren<Text>();
                indices[0].text = tempRowIndex.ToString();
                indices[1].text = tempColIndex.ToString();
                element.GetComponent<RectTransform>().anchoredPosition3D = new Vector2(xCoord, yCoord);
                temp[tempRowIndex].Add(element);
            }

            tempColIndex++;
            if(tempColIndex == COLSIZE)
            {
                temp.Add(new List<GameObject>());
                tempRowIndex++;
                tempColIndex = 0;
            }
        }

    public void OnDeselect(BaseEventData eventData)
    {
        throw new NotImplementedException();
    }
}
