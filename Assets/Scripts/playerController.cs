using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {

	/// <summary>
	/// Variables Section
	public float speed;
	Rigidbody2D rb2d;
	public bool isReduced;
	public bool isGrav;
	/// </summary>

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		isReduced = false;
		isGrav = false;
	}

	void Update(){
	}

	//Fixed update method
	void FixedUpdate() {

		float moveHorizontal = Input.GetAxisRaw ("Horizontal");

		PlayerMovement (moveHorizontal);

		if (Input.GetKeyDown (KeyCode.Return)) {
			Debug.Log ("Game Paused");
			PlayerPrefs.SetString ("lastLoadedScene", SceneManager.GetActiveScene ().name);
			SceneManager.LoadScene ("InGameMenu");
		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}

		//Use power up
		/*if(Input.GetKeyDown (KeyCode.X)){
			Debug.Log ("Gravity rush");
			rb2d.gravityScale *= -1;
		}*/
	}

	void PlayerMovement(float moveHorizontal) {

		rb2d.velocity = new Vector2(moveHorizontal * speed, 0);

	}

	void OnTriggerEnter2D(Collider2D collision){
		if(collision.gameObject.name == "End"){
			FindObjectOfType<HudScript> ().FinishGame ();
		}

		if (collision.gameObject.name == "NextLevel") {
			FindObjectOfType<HudScript> ().NextLevel ();
		}
	}

	public void GravityScale(){
		Debug.Log ("Gravity!");
		rb2d.gravityScale *= -1;
	}
}
