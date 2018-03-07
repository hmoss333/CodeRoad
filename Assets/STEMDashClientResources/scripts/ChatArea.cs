using UnityEngine;
using System.Threading;
using System.Collections;
using System;
using System.IO;
using System.Net.Sockets;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections.Generic;

public class ChatArea : Singleton<ChatArea> {
    protected ChatArea() { }

    Thread clientRecvThread;
    Thread tryToConnect;
    Stream s;
    StreamWriter sw;
    TcpClient client;
    LiteralEscape literal;
    //Text messageArea;
    //InputField sendText;

    string sender = SaveAndLoad.dashEmail, recipient = SaveAndLoad.dashEmail;
    string data = "";
    string messages = "";
    string socket = "";
    float connectTimer = 0.0f;
    float messageTimer = 0.0f;
    string currentPlayer;

    bool disconnected = true;
    bool initialized = false;
    bool displayNotConnectedMessage = false;
    bool connectionSuccessful = false;
    bool connectionAttempted = false;
    bool ispaused = false;

	// Use this for initialization
	void Start () {
	}

    public void init()
    {
        Debug.Log("Email: " + SaveAndLoad.dashEmail);
        literal = new LiteralEscape();
        displayNotConnectedMessage = true;

        if (disconnected)
        {
            tryToConnect = new Thread(new ThreadStart(connectToServer));
            tryToConnect.IsBackground = true;
            tryToConnect.Start();
        }
    }

    void connectToServer()
    {
        try
        {
            client = new TcpClient();
            client.Connect("159.203.219.224", 32645);
            s = client.GetStream();
            disconnected = false;
            //initialize the user on the server
            connectionAttempted = true;
            connectionSuccessful = true;
            ClientGlobals.notConnectedToServer = false;
           
        } catch(SocketException sx) {
            disconnected = true;
            if (displayNotConnectedMessage)
            {
                messages += "Not Connected";
                displayNotConnectedMessage = false;
                Debug.Log("Error: " + sx.ToString());
            }
            ClientGlobals.notConnectedToServer = true;
            connectionAttempted = true;
        }
    }

    void initializeClientRoutines()
    {
            StartCoroutine(clientSend());
            clientRecvThread = new Thread(new ThreadStart(recvMsg));
            clientRecvThread.IsBackground = true;
            displayNotConnectedMessage = false;
            clientRecvThread.Start();
    }

    /*
    public void sendStreamMessage()
    {
        if (sendText.text != "")
        {
            ClientGlobals.message = sendText.text;
            sendText.text = "";
            ClientGlobals.messageSent = true;
        }
    }
    */


    //Checks to see if the socket is still connected
    bool SocketConnected(Socket s)
    {
        bool part1 = s.Poll(1000, SelectMode.SelectRead);
        bool part2 = (s.Available == 0);
        if (part1 && part2)
            return false;
        else
            return true;
    }

    void Update()
    {
        //messageArea.text = messages;
        if (LoginToPortal.Instance.userIsLoggedIn && SaveAndLoad.listOfPlayers.Count > 0)
        {
            if (connectionAttempted)
            {
                if (!disconnected)
                {
                    //Check if there is an active connection with the server
                    if (!SocketConnected(client.Client))
                    {
                        disconnected = true;
                        s.Close();
                        sw.Close();
                        initialized = false;
                        messages += "Disconnected from the server\n";
                        ClientGlobals.notConnectedToServer = true;
                        Debug.Log("Disconnected from the server");
                    }
                }

                //Initialize the message and receive routines
                if (connectionSuccessful)
                {
                    initializeClientRoutines();
                    connectionSuccessful = false;
                }

                //Try to reconnect
                if (disconnected)
                {
                    connectTimer += Time.deltaTime;
                    if (connectTimer > 5.0f)
                    {
                        connectTimer = 0.0f;
                        tryToConnect = new Thread(new ThreadStart(connectToServer));
                        tryToConnect.IsBackground = true;
                        tryToConnect.Start();
                    }
                }


                //Refresh the data by relogging in if the data has changed
                if (ClientGlobals.update)
                {
                    LoginToPortal.Instance.updateData(SaveAndLoad.dashEmail, SaveAndLoad.dashPassword, true);
                    ClientGlobals.update = false;
                }
            }
        } else if(SaveAndLoad.listOfPlayers.Count > 0)
        {
                close();
        }
        currentPlayer = PlayerPrefs.GetString("CurrentPlayer");
    }

    public void close()
    {
        if (!disconnected)
        {
            disconnected = true;
            client.Close();
            s.Close();
            sw.Close();
            initialized = false;
            connectionAttempted = false;
            connectionSuccessful = false;
            Debug.Log("Disconnected from the server");
        }
    }

    string getJSONData(string sender, string recipient, string message, string messageId, string init, string disconnect, string sendingToChild, string receivedMessage, string socket)
    {
        string jsonData = "{";
        jsonData += "\"user\" : \"" + sender + "\",";
        jsonData += "\"recipient\": \"" + recipient + "\",";
        jsonData += "\"message\": \"" + message + "\",";
        jsonData += "\"messageId\": \"" + messageId + "\",";
        jsonData += "\"init\": \"" + init + "\",";
        jsonData += "\"disconnect\": \"" + disconnect + "\",";
        jsonData += "\"update\": \"0\",";
        jsonData += "\"sendingToChild\": \"" + sendingToChild + "\",";
        jsonData += "\"isChild\": \"1\",";
        jsonData += "\"receivedMessage\": \"" + receivedMessage  + "\",";
        jsonData += "\"gameName\": \"tommyTurtle\",";
        jsonData += "\"socket\": \"" + socket + "\"";
        jsonData += "}";
        return jsonData;
    }

    IEnumerator clientSend()
    {
         if (!disconnected)
        {
            //INITIALIZE THE CONNECTION ON THE SERVER
            string childName = PlayerPrefs.GetString("CurrentPlayer");
            childName = childName.ToLower();
            string childEmail = childName + "_" + SaveAndLoad.dashEmail;
            data = getJSONData(childEmail, "", "", "", "1", "0", "0", "", "");
            sw = new StreamWriter(s);
            sw.WriteLine(data);
            sw.AutoFlush = true;
            //END OF SERVER INITIALIZATION

            while (!disconnected)
            {
                //CHECKS IF MESSAGES ARE SENT
                sw.Flush();

                //Notifies the server that they are still connected
                if(ClientGlobals.checkConnection)
                {
                    Debug.Log("Tell server that client is still connected");
                    sw.WriteLine("stillConnected");
                    ClientGlobals.checkConnection = false;
                }


                if (ClientGlobals.messageSent)
                {
                    Debug.Log("Made it to send method");
                    string message = ClientGlobals.message;

                    if (message.Contains("\\"))
                    {
                        message = literal.escapeCharacter(message, '\\');
                    }
                    if (message.Contains("\""))
                    {
                        message = literal.escapeCharacter(message, '\"');
                    }

                    //User has disconnected
                    if (message == "exit()")
                    {
                        sender = SaveAndLoad.dashEmail;
                        data = getJSONData(sender, "", "", "", "0", "1",  "0", "",socket);
                        sw.WriteLine(data);
                        disconnected = true;
                        break;
                    }
                    //User has sent a message to a child
                    else
                    {
                        childName = PlayerPrefs.GetString("CurrentPlayer");
                        childName = childName.ToLower();
                        sender = SaveAndLoad.dashEmail;
                        recipient = SaveAndLoad.dashEmail;
                        childEmail = childName + "_" + sender;
                        data = getJSONData(sender, childEmail, message, "", "0", "0", "1", "", socket);
                        sw.WriteLine(data);
                        Debug.Log("Message: " + message);
                        messages += "<b><color=red>" + sender + ":</color></b> " + message + "\n";
                        ClientGlobals.messageSent = false;
                    }
                } else if(ClientGlobals.messageReceived)
                {
                    if (ClientGlobals.messageIds.Count > 0)
                    {
                        foreach(string messageId in ClientGlobals.messageIds)
                        {
                            yield return new WaitForSeconds(1.0f);
                            data = getJSONData("", "", "", messageId, "0", "0", "1", "1", "");
                            sw.WriteLine(data);
                        }
                    }
                    else
                    {
                        data = getJSONData("", "", "", ClientGlobals.messageId, "0", "0", "1", "1", "");
                        sw.WriteLine(data);
                    }
                    ClientGlobals.messageReceived = false;
                    ClientGlobals.messageId = "";
                    ClientGlobals.messageIds.Clear();
                    Debug.Log("Sending received message");
                }
                yield return new WaitForSeconds(0.001f);
            }
        }
    }
 

    void recvMsg()
    {
	    string serverMessage = "";
        
        //Debug.Log("Client Recv Called");
        while (!disconnected)
        {
            byte[] bb = new byte[100000];
            int k = s.Read(bb, 0, 100000);     //Reads in a stream of bytes

            //Check if there is an active connection with the server
            if (!SocketConnected(client.Client))
            {
                disconnected = true;
                s.Close();
                sw.Close();
                initialized = false;
                messages += "Disconnected from the server\n";
                ClientGlobals.notConnectedToServer = true;
                Debug.Log("Disconnected from the server. Inside thread");
                break;
            }

            for (int i = 0; i < k; i++)
            {
                serverMessage += Convert.ToChar(bb[i]).ToString();
            }

            Debug.Log(serverMessage);
            if (serverMessage != "" && serverMessage != "checkConnection")
            {
                //Console.WriteLine(serverMessage);
                if (!initialized)
                {
                    var data = JSON.Parse(serverMessage);
                    socket = data["socket"].Value;
                    Debug.Log("Message: " + data["message"].Value);
                    initialized = true;

                    if(data["hasBulk"].AsInt == 1)
                    {
                        Debug.Log("The child has bulk messages");
                        for(int i = 0; i < data["bulkMessages"].Count; i++)
                        {
                            ClientGlobals.messageQueue.Enqueue("<color=#00ffffff>@</color><color=yellow>" + currentPlayer + ":</color> " + data["bulkMessages"][i]["message"].Value);
                            ClientGlobals.messageIds.Add(data["bulkMessages"][i]["messageId"].Value);
                            Debug.Log(data["bulkMessages"][i]["message"].Value);
                        }
                        ClientGlobals.messageReceived = true;
                    } else {
                        Debug.Log("The child has no bulk messages");
                    }
                }
                else
                {
                    var data = JSON.Parse(serverMessage);
                    //Check if the data needs to be updated
                    if(data["update"].AsInt == 1)
                    {
                        ClientGlobals.update = true; 
                    }

                    ClientGlobals.messageQueue.Enqueue("<color=#00ffffff>@</color><color=yellow>" + currentPlayer + ":</color> " + data["message"].Value);
                    ClientGlobals.messageId = data["messageId"].Value;
                    ClientGlobals.messageReceived = true;
                }

                serverMessage = "";
            } else if(serverMessage == "checkConnection")
            {
                ClientGlobals.checkConnection = true;
                serverMessage = "";
            }
        }
    }

    private void OnApplicationPause(bool pause)
    {
        Debug.Log("Application is paused");
        ispaused = true;
    }

    //Might Need this to disconnect
    /*
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Debug.Log("The application was paused");
            if (LoginToPortal.Instance.userIsLoggedIn)
            {
                if (!disconnected)
                {
                    disconnected = true;
                    client.Close();
                    s.Close();
                    sw.Close();
                    initialized = false;
                    connectionAttempted = false;
                    connectionSuccessful = false;
                    Debug.Log("Disconnected from the server");
                }
            }
        }
        else
        {
            if (LoginToPortal.Instance.userIsLoggedIn)
            {
                if (disconnected)
                {
                    Debug.Log("The application was unpaused");
                    tryToConnect = new Thread(new ThreadStart(connectToServer));
                    tryToConnect.IsBackground = true;
                    tryToConnect.Start();
                }
            }
        }
    }
        */

    private void OnApplicationQuit()
    {
        if (!disconnected)
        {
            disconnected = true;
            client.Close();
            s.Close();
            sw.Close();
        }
    }
}
