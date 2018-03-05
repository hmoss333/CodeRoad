using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonController : MonoBehaviour {

    private static SingletonController instance = null;
    public static SingletonController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SingletonController>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "SingletonController";
                    instance = go.AddComponent<SingletonController>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
