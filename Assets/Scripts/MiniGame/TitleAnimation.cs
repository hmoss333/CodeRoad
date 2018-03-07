using UnityEngine;
using System.Collections;

public class TitleAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(cycle());

    }

    IEnumerator cycle()
    {
        GetComponent<Animation>().Play("Walk Turtle");
        yield return new WaitForSeconds(5);
        GetComponent<Animation>().Play("Run");
        yield return new WaitForSeconds(5);      
        GetComponent<Animation>().Play("Success");
      
        yield return new WaitForSeconds(5);
        StartCoroutine(cycle());
    }

    // Update is called once per frame
    void Update () {
	
	}
}
