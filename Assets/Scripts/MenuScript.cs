using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public void PlayGame(){
		SceneManager.LoadScene ("Scene5");
	}

	public void RestartGame(){
		SceneManager.LoadScene ("Scene5");
	}

	public void Replay(){
		//get current level scene
		string sceneName = PlayerPrefs.GetString("lastLoadedScene");
		SceneManager.LoadScene (sceneName);
	}

	public void QuitGame(){
		Debug.Log ("Quit");
		Application.Quit ();
	}
}
