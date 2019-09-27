using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controlling player sprites

public class PlayerColor : MonoBehaviour {

	public Sprite[] mySprites;
	SpriteRenderer spRender;
	//public GameObject redwall;

	bool playerColor;
	bool isGrounded;

	// Use this for initialization
	void Start () {
		spRender = GetComponent<SpriteRenderer>();
		playerColor = false;
		if(spRender.sprite == null)
		{
			NoColor();
		}
	}

	//Set initial state
	void NoColor(){
		//switch back to colorless state here
		spRender.sprite = mySprites[0];
		gameObject.name = "PlayerColorless";
		playerColor = false;
	}

	void OnTriggerEnter2D(Collider2D collision){
		if(collision.tag == "powerups"){
			Debug.Log ("Contact With sphere");

			//Check color and submit
			if(collision.name == "sphereRed"){
				spRender.sprite = mySprites[1];
				gameObject.name = "PlayerRed";
				playerColor = true;
			}

			if (collision.name == "sphereBlue") {
				spRender.sprite = mySprites [2];
				gameObject.name = "PlayerBlue";
				playerColor = true;
			}

			if (collision.name == "sphereYellow") {
				spRender.sprite = mySprites [3];
				gameObject.name = "PlayerYellow";
				playerColor = true;
			}

			if (collision.name == "sphereGreen") {
				spRender.sprite = mySprites [4];
				gameObject.name = "PlayerGreen";
				playerColor = true;
			}

			if (collision.name == "spherePurple") {
				spRender.sprite = mySprites [5];
				gameObject.name = "PlayerPurple";
				playerColor = true;
			}
		}
		//check for enemy
		if(collision.tag == "enemy"){
			Debug.Log ("Enemy contact");
			//TODO create conditon for color and no color damage
			OnDamage();
		}

		if(collision.tag == "Ground"){
			isGrounded = true;
		}

		/*if (collision.tag == "redobstacles" && spRender.sprite == mySprites[1]) {
			Debug.Log ("Red power used");
			Destroy (collision.gameObject);
		}*/
			
	}

	void OnTriggerExit2D(Collider2D collision){
		if(collision.tag == "Ground"){
			isGrounded = false;
		}
	}
		
	//Player damage
	void OnDamage(){
		if (playerColor) {
			NoColor ();
		} else {
			Destroy (this.gameObject);
			FindObjectOfType<HudScript> ().EndGame ();
		}
	}
}
