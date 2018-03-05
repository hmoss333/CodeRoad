using UnityEngine;
using System.Collections;

public class rateButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void OnClick()
    {
#if UNITY_IPHONE
        UniRate.Instance.OpenRatePage();
#endif
        UniRate.Instance.RateIfNetworkAvailable();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
