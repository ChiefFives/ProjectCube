using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleObjectGrow : MonoBehaviour {

	public GameObject target;
	playerController player;

	void OnTriggerEnter2D(Collider2D collider){

		player = target.GetComponent<playerController> ();

		if(collider.gameObject.name == "PlayerPurple"){
			if (player.isReduced) {
				Debug.Log ("Grow");
				player.isReduced = false;
				target.transform.localScale += new Vector3 (2F, 2F, 0);
			} else {
				Debug.Log ("Nothing happens");
			}
		}
	}
}
