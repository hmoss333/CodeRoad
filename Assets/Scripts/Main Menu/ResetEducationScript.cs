using UnityEngine;
using System.Collections;

public class ResetEducationScript : MonoBehaviour {

	public UIPopupList key1;
	public UIPopupList key2;
	public UIPopupList key3;
	public UIPopupList keyEnter;
	public UIPopupList keySpace;

	// Use this for initialization
	void Start () {
	     if (PlayerPrefs.GetInt("EducationStart") == 0) { //Here is the default setting @Jin
			key3.value = "Back Page";
			keySpace.value = "Animate Object";
			key1.value = "Next Page";
			key2.value = "Sound Effects";
			keyEnter.value = "Animation Effects";
			
			PlayerPrefs.SetInt("key1music",0);
			PlayerPrefs.SetInt("key1anim1",0);
			PlayerPrefs.SetInt("key1anim2",0);
			PlayerPrefs.SetInt("key1anim3",0);
			PlayerPrefs.SetInt("key1newobj",0);
			PlayerPrefs.SetInt("key1back",0);
			PlayerPrefs.SetInt("key1next",1);
			PlayerPrefs.SetInt("key1repeat",0);
			
			PlayerPrefs.SetInt("key2music",1);
			PlayerPrefs.SetInt("key2anim1",0);
			PlayerPrefs.SetInt("key2anim2",0);
			PlayerPrefs.SetInt("key2anim3",0);
			PlayerPrefs.SetInt("key2newobj",0);
			PlayerPrefs.SetInt("key2back",0);
			PlayerPrefs.SetInt("key2next",0);
			PlayerPrefs.SetInt("key2repeat",0);
			
			PlayerPrefs.SetInt("key3music",0);
			PlayerPrefs.SetInt("key3anim1",0);
			PlayerPrefs.SetInt("key3anim2",0);
			PlayerPrefs.SetInt("key3anim3",0);
			PlayerPrefs.SetInt("key3newobj",0);
			PlayerPrefs.SetInt("key3back",1);
			PlayerPrefs.SetInt("key3next",0);
			PlayerPrefs.SetInt("key3repeat",0);
			
			PlayerPrefs.SetInt("keyEntermusic",0);
			PlayerPrefs.SetInt("keyEnteranim1",1);
			PlayerPrefs.SetInt("keyEnteranim2",0);
			PlayerPrefs.SetInt("keyEnteranim3",0);
			PlayerPrefs.SetInt("keyEnternewobj",0);
			PlayerPrefs.SetInt("keyEnterback",0);
			PlayerPrefs.SetInt("keyEnternext",0);
			PlayerPrefs.SetInt("keyEnterrepeat",0);
			
			PlayerPrefs.SetInt("keySpacemusic",0);
			PlayerPrefs.SetInt("keySpaceanim1",0);
			PlayerPrefs.SetInt("keySpaceanim2",0);
			PlayerPrefs.SetInt("keySpaceanim3",0);
			PlayerPrefs.SetInt("keySpacenewobj",1);
			PlayerPrefs.SetInt("keySpaceback",0);
			PlayerPrefs.SetInt("keySpacenext",0);
			PlayerPrefs.SetInt("keySpacerepeat",0);

			PlayerPrefs.SetInt("EducationStart",1);
		}
	}

	public void OnClick() {
		key3.value = "Back Page";
		keySpace.value = "Animate Object";
		key1.value = "Next Page";
		key2.value = "Sound Effects";
		keyEnter.value = "Animation Effects";

		PlayerPrefs.SetInt("key1music",0);
		PlayerPrefs.SetInt("key1anim1",0);
		PlayerPrefs.SetInt("key1anim2",0);
		PlayerPrefs.SetInt("key1anim3",0);
		PlayerPrefs.SetInt("key1newobj",0);
		PlayerPrefs.SetInt("key1back",0);
		PlayerPrefs.SetInt("key1next",1);
		PlayerPrefs.SetInt("key1repeat",0);

		PlayerPrefs.SetInt("key2music",1);
		PlayerPrefs.SetInt("key2anim1",0);
		PlayerPrefs.SetInt("key2anim2",0);
		PlayerPrefs.SetInt("key2anim3",0);
		PlayerPrefs.SetInt("key2newobj",0);
		PlayerPrefs.SetInt("key2back",0);
		PlayerPrefs.SetInt("key2next",0);
		PlayerPrefs.SetInt("key2repeat",0);

		PlayerPrefs.SetInt("key3music",0);
		PlayerPrefs.SetInt("key3anim1",0);
		PlayerPrefs.SetInt("key3anim2",0);
		PlayerPrefs.SetInt("key3anim3",0);
		PlayerPrefs.SetInt("key3newobj",0);
		PlayerPrefs.SetInt("key3back",1);
		PlayerPrefs.SetInt("key3next",0);
		PlayerPrefs.SetInt("key3repeat",0);

		PlayerPrefs.SetInt("keyEntermusic",0);
		PlayerPrefs.SetInt("keyEnteranim1",1);
		PlayerPrefs.SetInt("keyEnteranim2",0);
		PlayerPrefs.SetInt("keyEnteranim3",0);
		PlayerPrefs.SetInt("keyEnternewobj",0);
		PlayerPrefs.SetInt("keyEnterback",0);
		PlayerPrefs.SetInt("keyEnternext",0);
		PlayerPrefs.SetInt("keyEnterrepeat",0);

		PlayerPrefs.SetInt("keySpacemusic",0);
		PlayerPrefs.SetInt("keySpaceanim1",0);
		PlayerPrefs.SetInt("keySpaceanim2",0);
		PlayerPrefs.SetInt("keySpaceanim3",0);
		PlayerPrefs.SetInt("keySpacenewobj",1);
		PlayerPrefs.SetInt("keySpaceback",0);
		PlayerPrefs.SetInt("keySpacenext",0);
		PlayerPrefs.SetInt("keySpacerepeat",0);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
