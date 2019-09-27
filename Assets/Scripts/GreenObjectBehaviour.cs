using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenObjectBehaviour : MonoBehaviour {

	playerController player;
	public GameObject target;

	void OnTriggerEnter2D(Collider2D collider){

		player = target.GetComponent<playerController> ();

		if (collider.gameObject.name == "PlayerGreen") {
			if (!player.isGrav) {
				Debug.Log ("Green tile");
				//set grav to true and float
				player.isGrav = true;
				player.GravityScale ();
			} else {
				Debug.Log ("Nothing happens");
			}
		}
	}

	void OnTriggerExit2D(Collider2D collider){
		player = target.GetComponent<playerController> ();
		player.isGrav = false;
	}
}