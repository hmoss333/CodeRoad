using UnityEngine;
using System.Collections;

public class NGUIThemeSwitch : MonoBehaviour {
	public int currentTheme = 0;

	public UIButton[] themeButtons;

	public UIAtlas[] atlases;

	public Color32[] colorTheme01;
	public Color32[] colorTheme02;
	public Color32[] colorTheme03;
	
	public StoreWindow storeWindow;

	public void SwitchTheme01 () {
		SwitchTheme (0);
	}

	public void SwitchTheme02 () {
		SwitchTheme (1);
	}

	public void SwitchTheme03 () {
		SwitchTheme (2);
	}

	public void SwitchTheme (int themeID) {
		GameObject[] UISprites;
		UISprites = GameObject.FindGameObjectsWithTag ("NGUI");
		Color32[] targetColors = colorTheme01;
		storeWindow.fontHighlightColor = targetColors[0];
		switch (themeID) {
		case 0:
			targetColors = colorTheme01;
			break;
		case 1:
			targetColors = colorTheme02;
			break;
		case 2:
			targetColors = colorTheme03;
			break;
		default:
			targetColors = colorTheme01;
			break;
		}

		foreach (GameObject go in UISprites) {
			if (go.GetComponent <UISprite> () != null) {
				go.GetComponent <UISprite> ().atlas = atlases[themeID];
			}

			if (go.GetComponent <UISprite> () != null) {
				if (go.GetComponent <UISprite> ().name == "ScrollDot") {
					go.GetComponent <UISprite> ().color = targetColors[1];
				}
			}

			if (go.GetComponent <UILabel> () != null) {
				if (go.GetComponent <UILabel> ().name == "Label") {
					go.GetComponent <UILabel> ().color = targetColors[1];
				}
				
				if (go.GetComponent <UILabel> ().name == "ButtonLabel01") {
					if (themeID == 1 || themeID == 2) {
						go.GetComponent <UILabel> ().color = targetColors[1];
					}
					else go.GetComponent <UILabel> ().color = targetColors[0];
				}

				if (go.GetComponent <UILabel> ().name == "ButtonLabel02") {
					go.GetComponent <UILabel> ().color = targetColors[1];
				}
				
				if (go.GetComponent <UILabel> ().name == "TextLabel") {
					go.GetComponent <UILabel> ().color = targetColors[2];
				}
				
				if (go.GetComponent <UILabel> ().name == "FieldLabel") {
					if (themeID == 1 || themeID == 2) {
						go.GetComponent <UILabel> ().color = targetColors[1];
					}
					else go.GetComponent <UILabel> ().color = targetColors[0];
				}
				
				if (go.GetComponent <UILabel> ().name == "ResultLabel") {
					go.GetComponent <UILabel> ().color = targetColors[2];
				}
				
				if (go.GetComponent <UILabel> ().name == "AchievementLabel") {
					go.GetComponent <UILabel> ().color = targetColors[1];
				}
				
				if (go.GetComponent <UILabel> ().name == "AchievementPopup") {
					go.GetComponent <UILabel> ().color = targetColors[0];
				}
				
				if (go.GetComponent <UILabel> ().name == "LevelLabel") {
					go.GetComponent <UILabel> ().color = targetColors[1];
				}
				
				if (go.GetComponent <UILabel> ().name == "TitleLabel") {
					go.GetComponent <UILabel> ().color = targetColors[0];
				}

				if (go.GetComponent <UILabel> ().name == "LevelUpLabel") {
					if (themeID == 1 || themeID == 2) {
						go.GetComponent <UILabel> ().color = targetColors[0];
					}
					else go.GetComponent <UILabel> ().color = targetColors[1];
				}

			}
		}

		currentTheme = themeID;
		UpdateThemeButtons (currentTheme);
	}

	void UpdateThemeButtons (int focusButton) {
		foreach (UIButton b in themeButtons) {
			b.isEnabled = true;
		}
		themeButtons[focusButton].isEnabled = false;
	}
}
