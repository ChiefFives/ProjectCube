using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HudScript : MonoBehaviour {

	bool gameHasEnded = false;

	public void EndGame(){

		if(gameHasEnded == false){
			gameHasEnded = true;
			Debug.Log ("Game Over");
			Restart ();
		}
	}

	void Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		gameHasEnded = false;
	}

	public void NextLevel(){
		gameHasEnded = false;
		Debug.Log ("Next Level");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void FinishGame(){
		if(gameHasEnded == false){
			gameHasEnded = true;
			Debug.Log ("Game Over");
			SceneManager.LoadScene ("GameOver");
		}
	}
}
