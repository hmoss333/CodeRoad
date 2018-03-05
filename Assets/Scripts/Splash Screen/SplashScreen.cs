using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashScreen : MonoBehaviour {
    void Start () {
		//if (Camera.main.aspect >= 1.7)
		//{
	        Handheld.PlayFullScreenMovie("ZyroGamesTrailer.mp4", Color.black, FullScreenMovieControlMode.Hidden, FullScreenMovieScalingMode.Fill);
		//}
		//else
		//{
		//	Handheld.PlayFullScreenMovie("ZyroGamesTrailer4_3.mp4", Color.black, FullScreenMovieControlMode.Hidden, FullScreenMovieScalingMode.Fill);
		//}
        //SceneManager.LoadScene("MenuScreen");
        SceneManager.LoadScene("MenuScreen");
    }
}
