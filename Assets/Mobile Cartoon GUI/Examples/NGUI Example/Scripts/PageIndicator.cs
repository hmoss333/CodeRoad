using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PageIndicator : MonoBehaviour {
	public List <float> pageOffsets = new List<float> ();
	public float pageAlignError;
	public UIProgressBar pageIndicator;
	public float dotMovingSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < pageOffsets.Count; i++) {
			if (Mathf.Abs (transform.localPosition.x - pageOffsets[i]) <= pageAlignError ) {
				pageIndicator.value = Mathf.Lerp (pageIndicator.value, i, dotMovingSpeed * Time.deltaTime);
			}
		}
	}
}
