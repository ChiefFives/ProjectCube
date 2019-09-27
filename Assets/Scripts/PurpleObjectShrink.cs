using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleObjectShrink : MonoBehaviour {

	public GameObject target;
	playerController player;

	void OnTriggerEnter2D(Collider2D collider){

		player = target.GetComponent<playerController> ();

		if(collider.gameObject.name == "PlayerPurple"){
			if (!player.isReduced) {
				Debug.Log ("Shrink");
				player.isReduced = true;
				target.transform.localScale += new Vector3 (-2F, -2F, 0);
			} else {
				Debug.Log ("Nothing happens");
			}
		}
	}
}
