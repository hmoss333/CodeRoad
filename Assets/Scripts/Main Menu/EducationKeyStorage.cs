using UnityEngine;
using System.Collections;

public class EducationKeyStorage : MonoBehaviour {
	
	bool key1on = false;
	bool key2on = false;
	bool key3on = false;
	bool keyEnteron = false;
	bool keySpaceon = false;

	public UIPanel panel1;
	public UIPanel panel2;
	public UIPanel panel3;
	public UIPanel panelEnter;
	public UIPanel panelSpace;

	public void switchkeys() {
		key1on = !key1on;
		key2on = !key2on;
		key3on = !key3on;
		keyEnteron = !keyEnteron;
		keySpaceon = !keySpaceon;
	}

	public void panel1Depth() {
		panel1.depth = 5;
		panel2.depth = 1;
		panel3.depth = 1;
		panelEnter.depth = 1;
		panelSpace.depth = 1;
	}

	public void panel2Depth() {
		panel1.depth = 1;
		panel2.depth = 5;
		panel3.depth = 1;
		panelEnter.depth = 1;
		panelSpace.depth = 1;
	}

	public void panel3Depth() {
		panel1.depth = 1;
		panel2.depth = 1;
		panel3.depth = 5;
		panelEnter.depth = 1;
		panelSpace.depth = 1;
	}

	public void panelEnterDepth() {
		panel1.depth = 1;
		panel2.depth = 1;
		panel3.depth = 1;
		panelEnter.depth = 5;
		panelSpace.depth = 1;
	}

	public void panelSpaceDepth() {
		panel1.depth = 1;
		panel2.depth = 1;
		panel3.depth = 1;
		panelEnter.depth = 1;
		panelSpace.depth = 5;
	}

	public void key1Decision() {
		//Debug.Log(key1.value);
		if (key1on == true) {
			if (UIPopupList.current.value == "Sound Effects") {
				key1musicFunc();
			} else if (UIPopupList.current.value == "Animation Effects") {
				key1anim1Func();
			} else if (UIPopupList.current.value == "Animate Object") {
				key1newobjFunc();
			} else if (UIPopupList.current.value == "Back Page") {
				key1backFunc();
			} else if (UIPopupList.current.value == "Next Page") {
				key1nextFunc();
			} else if (UIPopupList.current.value == "Repeat Page") {
				key1repeatFunc();
			}
		}
	}

	public void key2Decision() {
		//Debug.Log(key1.value);
		if (key2on == true) {
			if (UIPopupList.current.value == "Sound Effects") {
				key2musicFunc();
			} else if (UIPopupList.current.value == "Animation Effects") {
				key2anim1Func();
			} else if (UIPopupList.current.value == "Animate Object") {
				key2newobjFunc();
			} else if (UIPopupList.current.value == "Back Page") {
				key2backFunc();
			} else if (UIPopupList.current.value == "Next Page") {
				key2nextFunc();
			} else if (UIPopupList.current.value == "Repeat Page") {
				key2repeatFunc();
			}
		}
	}

	public void key3Decision() {
		//Debug.Log(key1.value);
		if (key3on == true) {
			if (UIPopupList.current.value == "Sound Effects") {
				key3musicFunc();
			} else if (UIPopupList.current.value == "Animation Effects") {
				key3anim1Func();
			} else if (UIPopupList.current.value == "Animate Object") {
				key3newobjFunc();
			} else if (UIPopupList.current.value == "Back Page") {
				key3backFunc();
			} else if (UIPopupList.current.value == "Next Page") {
				key3nextFunc();
			} else if (UIPopupList.current.value == "Repeat Page") {
				key3repeatFunc();
			}
		}
	}

	public void keyEnterDecision() {
		//Debug.Log(key1.value);
		if (keyEnteron == true) {
			if (UIPopupList.current.value == "Sound Effects") {
				keyEntermusicFunc();
			} else if (UIPopupList.current.value == "Animation Effects") {
				keyEnteranim1Func();
			} else if (UIPopupList.current.value == "Animate Object") {
				keyEnternewobjFunc();
			} else if (UIPopupList.current.value == "Back Page") {
				keyEnterbackFunc();
			} else if (UIPopupList.current.value == "Next Page") {
				keyEnternextFunc();
			} else if (UIPopupList.current.value == "Repeat Page") {
				keyEnterrepeatFunc();
			}
		}
	}

	public void keySpaceDecision() {
		//Debug.Log(key1.value);
		if (keySpaceon == true) {
			if (UIPopupList.current.value == "Sound Effects") {
				keySpacemusicFunc();
			} else if (UIPopupList.current.value == "Animation Effects") {
				keySpaceanim1Func();
			} else if (UIPopupList.current.value == "Animate Object") {
				keySpacenewobjFunc();
			} else if (UIPopupList.current.value == "Back Page") {
				keySpacebackFunc();
			} else if (UIPopupList.current.value == "Next Page") {
				keySpacenextFunc();
			} else if (UIPopupList.current.value == "Repeat Page") {
				keySpacerepeatFunc();
			}
		}
	}

	public void key1musicFunc() {
		if (PlayerPrefs.GetInt("key1music") == 0) {
			PlayerPrefs.SetInt("key1music",1);
			PlayerPrefs.SetInt("key1anim1",0);
			PlayerPrefs.SetInt("key1anim2",0);
			PlayerPrefs.SetInt("key1anim3",0);
			PlayerPrefs.SetInt("key1newobj",0);
			PlayerPrefs.SetInt("key1back",0);
			PlayerPrefs.SetInt("key1next",0);
			PlayerPrefs.SetInt("key1repeat",0);
		} else {
			PlayerPrefs.SetInt("key1music",0);
		}
	}

	public void key1anim1Func() {
		if (PlayerPrefs.GetInt("key1anim1") == 0) {
			PlayerPrefs.SetInt("key1music",0);
			PlayerPrefs.SetInt("key1anim1",1);
			PlayerPrefs.SetInt("key1anim2",0);
			PlayerPrefs.SetInt("key1anim3",0);
			PlayerPrefs.SetInt("key1newobj",0);
			PlayerPrefs.SetInt("key1back",0);
			PlayerPrefs.SetInt("key1next",0);
			PlayerPrefs.SetInt("key1repeat",0);
		} else {
			PlayerPrefs.SetInt("key1anim1",0);
		}
	}

	public void key1anim2Func() {
		if (PlayerPrefs.GetInt("key1anim2") == 0) {
			PlayerPrefs.SetInt("key1music",0);
			PlayerPrefs.SetInt("key1anim1",0);
			PlayerPrefs.SetInt("key1anim2",1);
			PlayerPrefs.SetInt("key1anim3",0);
			PlayerPrefs.SetInt("key1newobj",0);
			PlayerPrefs.SetInt("key1back",0);
			PlayerPrefs.SetInt("key1next",0);
			PlayerPrefs.SetInt("key1repeat",0);
		} else {
			PlayerPrefs.SetInt("key1anim2",0);
		}
	}

	public void key1anim3Func() {
		if (PlayerPrefs.GetInt("key1anim3") == 0) {
			PlayerPrefs.SetInt("key1music",0);
			PlayerPrefs.SetInt("key1anim1",0);
			PlayerPrefs.SetInt("key1anim2",0);
			PlayerPrefs.SetInt("key1anim3",1);
			PlayerPrefs.SetInt("key1newobj",0);
			PlayerPrefs.SetInt("key1back",0);
			PlayerPrefs.SetInt("key1next",0);
			PlayerPrefs.SetInt("key1repeat",0);
		} else {
			PlayerPrefs.SetInt("key1anim3",0);
		}
	}

	public void key1newobjFunc() {
		if (PlayerPrefs.GetInt("key1newobj") == 0) {
			PlayerPrefs.SetInt("key1music",0);
			PlayerPrefs.SetInt("key1anim1",0);
			PlayerPrefs.SetInt("key1anim2",0);
			PlayerPrefs.SetInt("key1anim3",0);
			PlayerPrefs.SetInt("key1newobj",1);
			PlayerPrefs.SetInt("key1back",0);
			PlayerPrefs.SetInt("key1next",0);
			PlayerPrefs.SetInt("key1repeat",0);
		} else {
			PlayerPrefs.SetInt("key1newobj",0);
		}
	}

	public void key1backFunc() {
		if (PlayerPrefs.GetInt("key1back") == 0) {
			PlayerPrefs.SetInt("key1music",0);
			PlayerPrefs.SetInt("key1anim1",0);
			PlayerPrefs.SetInt("key1anim2",0);
			PlayerPrefs.SetInt("key1anim3",0);
			PlayerPrefs.SetInt("key1newobj",0);
			PlayerPrefs.SetInt("key1back",1);
			PlayerPrefs.SetInt("key1next",0);
			PlayerPrefs.SetInt("key1repeat",0);
		} else {
			PlayerPrefs.SetInt("key1back",0);
		}
	}

	public void key1nextFunc() {
		if (PlayerPrefs.GetInt("key1next") == 0) {
			PlayerPrefs.SetInt("key1music",0);
			PlayerPrefs.SetInt("key1anim1",0);
			PlayerPrefs.SetInt("key1anim2",0);
			PlayerPrefs.SetInt("key1anim3",0);
			PlayerPrefs.SetInt("key1newobj",0);
			PlayerPrefs.SetInt("key1back",0);
			PlayerPrefs.SetInt("key1next",1);
			PlayerPrefs.SetInt("key1repeat",0);
		} else {
			PlayerPrefs.SetInt("key1next",0);
		}
	}

	public void key1repeatFunc() {
		if (PlayerPrefs.GetInt("key1repeat") == 0) {
			PlayerPrefs.SetInt("key1music",0);
			PlayerPrefs.SetInt("key1anim1",0);
			PlayerPrefs.SetInt("key1anim2",0);
			PlayerPrefs.SetInt("key1anim3",0);
			PlayerPrefs.SetInt("key1newobj",0);
			PlayerPrefs.SetInt("key1back",0);
			PlayerPrefs.SetInt("key1next",0);
			PlayerPrefs.SetInt("key1repeat",1);
		} else {
			PlayerPrefs.SetInt("key1repeat",0);
		}
	}

	public void key2musicFunc() {
		if (PlayerPrefs.GetInt("key2music") == 0) {
			PlayerPrefs.SetInt("key2music",1);
			PlayerPrefs.SetInt("key2anim1",0);
			PlayerPrefs.SetInt("key2anim2",0);
			PlayerPrefs.SetInt("key2anim3",0);
			PlayerPrefs.SetInt("key2newobj",0);
			PlayerPrefs.SetInt("key2back",0);
			PlayerPrefs.SetInt("key2next",0);
			PlayerPrefs.SetInt("key2repeat",0);
		} else {
			PlayerPrefs.SetInt("key2music",0);
		}
	}
	
	public void key2anim1Func() {
		if (PlayerPrefs.GetInt("key2anim1") == 0) {
			PlayerPrefs.SetInt("key2music",0);
			PlayerPrefs.SetInt("key2anim1",1);
			PlayerPrefs.SetInt("key2anim2",0);
			PlayerPrefs.SetInt("key2anim3",0);
			PlayerPrefs.SetInt("key2newobj",0);
			PlayerPrefs.SetInt("key2back",0);
			PlayerPrefs.SetInt("key2next",0);
			PlayerPrefs.SetInt("key2repeat",0);
		} else {
			PlayerPrefs.SetInt("key2anim1",0);
		}
	}
	
	public void key2anim2Func() {
		if (PlayerPrefs.GetInt("key2anim2") == 0) {
			PlayerPrefs.SetInt("key2music",0);
			PlayerPrefs.SetInt("key2anim1",0);
			PlayerPrefs.SetInt("key2anim2",1);
			PlayerPrefs.SetInt("key2anim3",0);
			PlayerPrefs.SetInt("key2newobj",0);
			PlayerPrefs.SetInt("key2back",0);
			PlayerPrefs.SetInt("key2next",0);
			PlayerPrefs.SetInt("key2repeat",0);
		} else {
			PlayerPrefs.SetInt("key2anim2",0);
		}
	}
	
	public void key2anim3Func() {
		if (PlayerPrefs.GetInt("key2anim3") == 0) {
			PlayerPrefs.SetInt("key2music",0);
			PlayerPrefs.SetInt("key2anim1",0);
			PlayerPrefs.SetInt("key2anim2",0);
			PlayerPrefs.SetInt("key2anim3",1);
			PlayerPrefs.SetInt("key2newobj",0);
			PlayerPrefs.SetInt("key2back",0);
			PlayerPrefs.SetInt("key2next",0);
			PlayerPrefs.SetInt("key2repeat",0);
		} else {
			PlayerPrefs.SetInt("key2anim3",0);
		}
	}
	
	public void key2newobjFunc() {
		if (PlayerPrefs.GetInt("key2newobj") == 0) {
			PlayerPrefs.SetInt("key2music",0);
			PlayerPrefs.SetInt("key2anim1",0);
			PlayerPrefs.SetInt("key2anim2",0);
			PlayerPrefs.SetInt("key2anim3",0);
			PlayerPrefs.SetInt("key2newobj",1);
			PlayerPrefs.SetInt("key2back",0);
			PlayerPrefs.SetInt("key2next",0);
			PlayerPrefs.SetInt("key2repeat",0);
		} else {
			PlayerPrefs.SetInt("key2newobj",0);
		}
	}

	public void key2backFunc() {
		if (PlayerPrefs.GetInt("key2back") == 0) {
			PlayerPrefs.SetInt("key2music",0);
			PlayerPrefs.SetInt("key2anim1",0);
			PlayerPrefs.SetInt("key2anim2",0);
			PlayerPrefs.SetInt("key2anim3",0);
			PlayerPrefs.SetInt("key2newobj",0);
			PlayerPrefs.SetInt("key2back",1);
			PlayerPrefs.SetInt("key2next",0);
			PlayerPrefs.SetInt("key2repeat",0);
		} else {
			PlayerPrefs.SetInt("key2back",0);
		}
	}

	public void key2nextFunc() {
		if (PlayerPrefs.GetInt("key2next") == 0) {
			PlayerPrefs.SetInt("key2music",0);
			PlayerPrefs.SetInt("key2anim1",0);
			PlayerPrefs.SetInt("key2anim2",0);
			PlayerPrefs.SetInt("key2anim3",0);
			PlayerPrefs.SetInt("key2newobj",0);
			PlayerPrefs.SetInt("key2back",0);
			PlayerPrefs.SetInt("key2next",1);
			PlayerPrefs.SetInt("key2repeat",0);
		} else {
			PlayerPrefs.SetInt("key2next",0);
		}
	}

	public void key2repeatFunc() {
		if (PlayerPrefs.GetInt("key2repeat") == 0) {
			PlayerPrefs.SetInt("key2music",0);
			PlayerPrefs.SetInt("key2anim1",0);
			PlayerPrefs.SetInt("key2anim2",0);
			PlayerPrefs.SetInt("key2anim3",0);
			PlayerPrefs.SetInt("key2newobj",0);
			PlayerPrefs.SetInt("key2back",0);
			PlayerPrefs.SetInt("key2next",0);
			PlayerPrefs.SetInt("key2repeat",1);
		} else {
			PlayerPrefs.SetInt("key2repeat",0);
		}
	}

	public void key3musicFunc() {
		if (PlayerPrefs.GetInt("key3music") == 0) {
			PlayerPrefs.SetInt("key3music",1);
			PlayerPrefs.SetInt("key3anim1",0);
			PlayerPrefs.SetInt("key3anim2",0);
			PlayerPrefs.SetInt("key3anim3",0);
			PlayerPrefs.SetInt("key3newobj",0);
			PlayerPrefs.SetInt("key3back",0);
			PlayerPrefs.SetInt("key3next",0);
			PlayerPrefs.SetInt("key3repeat",0);
		} else {
			PlayerPrefs.SetInt("key3music",0);
		}
	}
	
	public void key3anim1Func() {
		if (PlayerPrefs.GetInt("key3anim1") == 0) {
			PlayerPrefs.SetInt("key3music",0);
			PlayerPrefs.SetInt("key3anim1",1);
			PlayerPrefs.SetInt("key3anim2",0);
			PlayerPrefs.SetInt("key3anim3",0);
			PlayerPrefs.SetInt("key3newobj",0);
			PlayerPrefs.SetInt("key3back",0);
			PlayerPrefs.SetInt("key3next",0);
			PlayerPrefs.SetInt("key3repeat",0);
		} else {
			PlayerPrefs.SetInt("key3anim1",1);
		}
	}
	
	public void key3anim2Func() {
		if (PlayerPrefs.GetInt("key3anim2") == 0) {
			PlayerPrefs.SetInt("key3music",0);
			PlayerPrefs.SetInt("key3anim1",0);
			PlayerPrefs.SetInt("key3anim2",1);
			PlayerPrefs.SetInt("key3anim3",0);
			PlayerPrefs.SetInt("key3newobj",0);
			PlayerPrefs.SetInt("key3back",0);
			PlayerPrefs.SetInt("key3next",0);
			PlayerPrefs.SetInt("key3repeat",0);
		} else {
			PlayerPrefs.SetInt("key3anim2",0);
		}
	}
	
	public void key3anim3Func() {
		if (PlayerPrefs.GetInt("key3anim3") == 0) {
			PlayerPrefs.SetInt("key3music",0);
			PlayerPrefs.SetInt("key3anim1",0);
			PlayerPrefs.SetInt("key3anim2",0);
			PlayerPrefs.SetInt("key3anim3",1);
			PlayerPrefs.SetInt("key3newobj",0);
			PlayerPrefs.SetInt("key3back",0);
			PlayerPrefs.SetInt("key3next",0);
			PlayerPrefs.SetInt("key3repeat",0);
		} else {
			PlayerPrefs.SetInt("key3anim3",0);
		}
	}
	
	public void key3newobjFunc() {
		if (PlayerPrefs.GetInt("key3newobj") == 0) {
			PlayerPrefs.SetInt("key3music",0);
			PlayerPrefs.SetInt("key3anim1",0);
			PlayerPrefs.SetInt("key3anim2",0);
			PlayerPrefs.SetInt("key3anim3",0);
			PlayerPrefs.SetInt("key3newobj",1);
			PlayerPrefs.SetInt("key3back",0);
			PlayerPrefs.SetInt("key3next",0);
			PlayerPrefs.SetInt("key3repeat",0);
		} else {
			PlayerPrefs.SetInt("key3newobj",0);
		}
	}

	public void key3backFunc() {
		if (PlayerPrefs.GetInt("key3back") == 0) {
			PlayerPrefs.SetInt("key3music",0);
			PlayerPrefs.SetInt("key3anim1",0);
			PlayerPrefs.SetInt("key3anim2",0);
			PlayerPrefs.SetInt("key3anim3",0);
			PlayerPrefs.SetInt("key3newobj",0);
			PlayerPrefs.SetInt("key3back",1);
			PlayerPrefs.SetInt("key3next",0);
			PlayerPrefs.SetInt("key3repeat",0);
		} else {
			PlayerPrefs.SetInt("key3back",0);
		}
	}

	public void key3nextFunc() {
		if (PlayerPrefs.GetInt("key3next") == 0) {
			PlayerPrefs.SetInt("key3music",0);
			PlayerPrefs.SetInt("key3anim1",0);
			PlayerPrefs.SetInt("key3anim2",0);
			PlayerPrefs.SetInt("key3anim3",0);
			PlayerPrefs.SetInt("key3newobj",0);
			PlayerPrefs.SetInt("key3back",0);
			PlayerPrefs.SetInt("key3next",1);
			PlayerPrefs.SetInt("key3repeat",0);
		} else {
			PlayerPrefs.SetInt("key3next",0);
		}
	}

	public void key3repeatFunc() {
		if (PlayerPrefs.GetInt("key3repeat") == 0) {
			PlayerPrefs.SetInt("key3music",0);
			PlayerPrefs.SetInt("key3anim1",0);
			PlayerPrefs.SetInt("key3anim2",0);
			PlayerPrefs.SetInt("key3anim3",0);
			PlayerPrefs.SetInt("key3newobj",0);
			PlayerPrefs.SetInt("key3back",0);
			PlayerPrefs.SetInt("key3next",0);
			PlayerPrefs.SetInt("key3repeat",1);
		} else {
			PlayerPrefs.SetInt("key3repeat",0);
		}
	}

	public void keyEntermusicFunc() {
		if (PlayerPrefs.GetInt("keyEntermusic") == 0) {
			PlayerPrefs.SetInt("keyEntermusic",1);
			PlayerPrefs.SetInt("keyEnteranim1",0);
			PlayerPrefs.SetInt("keyEnteranim2",0);
			PlayerPrefs.SetInt("keyEnteranim3",0);
			PlayerPrefs.SetInt("keyEnternewobj",0);
			PlayerPrefs.SetInt("keyEnterback",0);
			PlayerPrefs.SetInt("keyEnternext",0);
			PlayerPrefs.SetInt("keyEnterrepeat",0);
		} else {
			PlayerPrefs.SetInt("keyEntermusic",0);
		}
	}
	
	public void keyEnteranim1Func() {
		if (PlayerPrefs.GetInt("keyEnteranim1") == 0) {
			PlayerPrefs.SetInt("keyEntermusic",0);
			PlayerPrefs.SetInt("keyEnteranim1",1);
			PlayerPrefs.SetInt("keyEnteranim2",0);
			PlayerPrefs.SetInt("keyEnteranim3",0);
			PlayerPrefs.SetInt("keyEnternewobj",0);
			PlayerPrefs.SetInt("keyEnterback",0);
			PlayerPrefs.SetInt("keyEnternext",0);
			PlayerPrefs.SetInt("keyEnterrepeat",0);
		} else {
			PlayerPrefs.SetInt("keyEnteranim1",0);
		}
	}
	
	public void keyEnteranim2Func() {
		if (PlayerPrefs.GetInt("keyEnteranim2") == 0) {
			PlayerPrefs.SetInt("keyEntermusic",0);
			PlayerPrefs.SetInt("keyEnteranim1",0);
			PlayerPrefs.SetInt("keyEnteranim2",1);
			PlayerPrefs.SetInt("keyEnteranim3",0);
			PlayerPrefs.SetInt("keyEnternewobj",0);
			PlayerPrefs.SetInt("keyEnterback",0);
			PlayerPrefs.SetInt("keyEnternext",0);
			PlayerPrefs.SetInt("keyEnterrepeat",0);
		} else {
			PlayerPrefs.SetInt("keyEnteranim2",0);
		}
	}
	
	public void keyEnteranim3Func() {
		if (PlayerPrefs.GetInt("keyEnteranim3") == 0) {
			PlayerPrefs.SetInt("keyEntermusic",0);
			PlayerPrefs.SetInt("keyEnteranim1",0);
			PlayerPrefs.SetInt("keyEnteranim2",0);
			PlayerPrefs.SetInt("keyEnteranim3",1);
			PlayerPrefs.SetInt("keyEnternewobj",0);
			PlayerPrefs.SetInt("keyEnterback",0);
			PlayerPrefs.SetInt("keyEnternext",0);
			PlayerPrefs.SetInt("keyEnterrepeat",0);
		} else {
			PlayerPrefs.SetInt("keyEnteranim3",0);
		}
	}
	
	public void keyEnternewobjFunc() {
		if (PlayerPrefs.GetInt("keyEnternewobj") == 0) {
			PlayerPrefs.SetInt("keyEntermusic",0);
			PlayerPrefs.SetInt("keyEnteranim1",0);
			PlayerPrefs.SetInt("keyEnteranim2",0);
			PlayerPrefs.SetInt("keyEnteranim3",0);
			PlayerPrefs.SetInt("keyEnternewobj",1);
			PlayerPrefs.SetInt("keyEnterback",0);
			PlayerPrefs.SetInt("keyEnternext",0);
			PlayerPrefs.SetInt("keyEnterrepeat",0);
		} else {
			PlayerPrefs.SetInt("keyEnternewobj",0);
		}
	}

	public void keyEnterbackFunc() {
		if (PlayerPrefs.GetInt("keyEnterback") == 0) {
			PlayerPrefs.SetInt("keyEntermusic",0);
			PlayerPrefs.SetInt("keyEnteranim1",0);
			PlayerPrefs.SetInt("keyEnteranim2",0);
			PlayerPrefs.SetInt("keyEnteranim3",0);
			PlayerPrefs.SetInt("keyEnternewobj",0);
			PlayerPrefs.SetInt("keyEnterback",1);
			PlayerPrefs.SetInt("keyEnternext",0);
			PlayerPrefs.SetInt("keyEnterrepeat",0);
		} else {
			PlayerPrefs.SetInt("keyEnterback",0);
		}
	}

	public void keyEnternextFunc() {
		if (PlayerPrefs.GetInt("keyEnternext") == 0) {
			PlayerPrefs.SetInt("keyEntermusic",0);
			PlayerPrefs.SetInt("keyEnteranim1",0);
			PlayerPrefs.SetInt("keyEnteranim2",0);
			PlayerPrefs.SetInt("keyEnteranim3",0);
			PlayerPrefs.SetInt("keyEnternewobj",0);
			PlayerPrefs.SetInt("keyEnterback",0);
			PlayerPrefs.SetInt("keyEnternext",1);
			PlayerPrefs.SetInt("keyEnterrepeat",0);
		} else {
			PlayerPrefs.SetInt("keyEnternext",0);
		}
	}

	public void keyEnterrepeatFunc() {
		if (PlayerPrefs.GetInt("keyEnterrepeat") == 0) {
			PlayerPrefs.SetInt("keyEntermusic",0);
			PlayerPrefs.SetInt("keyEnteranim1",0);
			PlayerPrefs.SetInt("keyEnteranim2",0);
			PlayerPrefs.SetInt("keyEnteranim3",0);
			PlayerPrefs.SetInt("keyEnternewobj",0);
			PlayerPrefs.SetInt("keyEnterback",0);
			PlayerPrefs.SetInt("keyEnternext",0);
			PlayerPrefs.SetInt("keyEnterrepeat",1);
		} else {
			PlayerPrefs.SetInt("keyEnterrepeat",0);
		}
	}

	public void keySpacemusicFunc() {
		if (PlayerPrefs.GetInt("keySpacemusic") == 0) {
			PlayerPrefs.SetInt("keySpacemusic",1);
			PlayerPrefs.SetInt("keySpaceanim1",0);
			PlayerPrefs.SetInt("keySpaceanim2",0);
			PlayerPrefs.SetInt("keySpaceanim3",0);
			PlayerPrefs.SetInt("keySpacenewobj",0);
			PlayerPrefs.SetInt("keySpaceback",0);
			PlayerPrefs.SetInt("keySpacenext",0);
			PlayerPrefs.SetInt("keySpacerepeat",0);
		} else {
			PlayerPrefs.SetInt("keySpacemusic",0);
		}
	}
	
	public void keySpaceanim1Func() {
		if (PlayerPrefs.GetInt("keySpaceanim1") == 0) {
			PlayerPrefs.SetInt("keySpacemusic",0);
			PlayerPrefs.SetInt("keySpaceanim1",1);
			PlayerPrefs.SetInt("keySpaceanim2",0);
			PlayerPrefs.SetInt("keySpaceanim3",0);
			PlayerPrefs.SetInt("keySpacenewobj",0);
			PlayerPrefs.SetInt("keySpaceback",0);
			PlayerPrefs.SetInt("keySpacenext",0);
			PlayerPrefs.SetInt("keySpacerepeat",0);
		} else {
			PlayerPrefs.SetInt("keySpaceanim1",0);
		}
	}
	
	public void keySpaceanim2Func() {
		if (PlayerPrefs.GetInt("keySpaceanim2") == 0) {
			PlayerPrefs.SetInt("keySpacemusic",0);
			PlayerPrefs.SetInt("keySpaceanim1",0);
			PlayerPrefs.SetInt("keySpaceanim2",1);
			PlayerPrefs.SetInt("keySpaceanim3",0);
			PlayerPrefs.SetInt("keySpacenewobj",0);
			PlayerPrefs.SetInt("keySpaceback",0);
			PlayerPrefs.SetInt("keySpacenext",0);
			PlayerPrefs.SetInt("keySpacerepeat",0);
		} else {
			PlayerPrefs.SetInt("keySpaceanim2",0);
		}
	}
	
	public void keySpaceanim3Func() {
		if (PlayerPrefs.GetInt("keySpaceanim3") == 0) {
			PlayerPrefs.SetInt("keySpacemusic",0);
			PlayerPrefs.SetInt("keySpaceanim1",0);
			PlayerPrefs.SetInt("keySpaceanim2",0);
			PlayerPrefs.SetInt("keySpaceanim3",1);
			PlayerPrefs.SetInt("keySpacenewobj",0);
			PlayerPrefs.SetInt("keySpaceback",0);
			PlayerPrefs.SetInt("keySpacenext",0);
			PlayerPrefs.SetInt("keySpacerepeat",0);
		} else {
			PlayerPrefs.SetInt("keySpaceanim3",0);
		}
	}
	
	public void keySpacenewobjFunc() {
		if (PlayerPrefs.GetInt("keySpacenewobj") == 0) {
			PlayerPrefs.SetInt("keySpacemusic",0);
			PlayerPrefs.SetInt("keySpaceanim1",0);
			PlayerPrefs.SetInt("keySpaceanim2",0);
			PlayerPrefs.SetInt("keySpaceanim3",0);
			PlayerPrefs.SetInt("keySpacenewobj",1);
			PlayerPrefs.SetInt("keySpaceback",0);
			PlayerPrefs.SetInt("keySpacenext",0);
			PlayerPrefs.SetInt("keySpacerepeat",0);
		} else {
			PlayerPrefs.SetInt("keySpacenewobj",0);
		}
	}

	public void keySpacebackFunc() {
		if (PlayerPrefs.GetInt("keySpaceback") == 0) {
			PlayerPrefs.SetInt("keySpacemusic",0);
			PlayerPrefs.SetInt("keySpaceanim1",0);
			PlayerPrefs.SetInt("keySpaceanim2",0);
			PlayerPrefs.SetInt("keySpaceanim3",0);
			PlayerPrefs.SetInt("keySpacenewobj",0);
			PlayerPrefs.SetInt("keySpaceback",1);
			PlayerPrefs.SetInt("keySpacenext",0);
			PlayerPrefs.SetInt("keySpacerepeat",0);
		} else {
			PlayerPrefs.SetInt("keySpaceback",0);
		}
	}

	public void keySpacenextFunc() {
		if (PlayerPrefs.GetInt("keySpacenext") == 0) {
			PlayerPrefs.SetInt("keySpacemusic",0);
			PlayerPrefs.SetInt("keySpaceanim1",0);
			PlayerPrefs.SetInt("keySpaceanim2",0);
			PlayerPrefs.SetInt("keySpaceanim3",0);
			PlayerPrefs.SetInt("keySpacenewobj",0);
			PlayerPrefs.SetInt("keySpaceback",0);
			PlayerPrefs.SetInt("keySpacenext",1);
			PlayerPrefs.SetInt("keySpacerepeat",0);
		} else {
			PlayerPrefs.SetInt("keySpacenext",0);
		}
	}

	public void keySpacerepeatFunc() {
		if (PlayerPrefs.GetInt("keySpacerepeat") == 0) {
			PlayerPrefs.SetInt("keySpacemusic",0);
			PlayerPrefs.SetInt("keySpaceanim1",0);
			PlayerPrefs.SetInt("keySpaceanim2",0);
			PlayerPrefs.SetInt("keySpaceanim3",0);
			PlayerPrefs.SetInt("keySpacenewobj",0);
			PlayerPrefs.SetInt("keySpaceback",0);
			PlayerPrefs.SetInt("keySpacenext",0);
			PlayerPrefs.SetInt("keySpacerepeat",1);
		} else {
			PlayerPrefs.SetInt("keySpacerepeat",0);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
}
