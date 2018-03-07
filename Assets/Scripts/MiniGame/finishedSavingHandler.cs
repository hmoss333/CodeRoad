using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishedSavingHandler : MonoBehaviour {
    public delegate void finishedSave();
    public delegate void errorOccured();
    public static event finishedSave finished;
    public static event errorOccured errorSaving;
    public static void finishedSaving()
    {
        finished();
    }
    public static void saveError()
    {
        errorSaving();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
