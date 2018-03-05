using UnityEngine;
using System.Collections;

public class AboutPage : MonoBehaviour {

	public UITexture background;

	private bool on = false;

    //public UIPanel aboutPanel;
    public string link;
	public UIPanel optionsPanel;
	
	public void switching() {
		on = !on;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	public void OnClick() {

		background.mainTexture = Resources.Load ("background") as Texture;
			
			on = !on;

        //aboutPanel.alpha = 1;
        //optionsPanel.alpha = 0;
        Application.OpenURL(link);
    }
	
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
