using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorRobot : MonoBehaviour {

    public int ID;
    float speed;
    float recycleTime = 2.25f;
    bool recycling = false;

    ArmControl ac;
    public bool picked;

    GameManager gm;

    // Use this for initialization
    void Start () {
        ac = GameObject.FindObjectOfType<ArmControl>();
        gm = GameObject.FindObjectOfType<GameManager>();

        speed = gm.speed;
    }
	
	// Update is called once per frame
	void Update () {
        if (!picked)
            transform.Translate(speed * Time.deltaTime, 0, 0);
        else if (ac.comparing)
            transform.position = ac.transform.position;

        if (speed != gm.speed)
            speed = gm.speed;
    }

    IEnumerator Recycle()
    {
        recycling = true;
        yield return new WaitForSeconds(recycleTime);
        Destroy(this.gameObject);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Cycler" && !recycling)
        {
            StartCoroutine(Recycle());
        }
    }
}
