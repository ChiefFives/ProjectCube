using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowObjectBehaviour : MonoBehaviour {

	public GameObject targetObj;

	void OnTriggerEnter2D(Collider2D collision){
		//Set it for yellow objects later
		if (collision.gameObject.name == "PlayerYellow") {
			Debug.Log ("Phase");
			Physics2D.IgnoreCollision (targetObj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		} else {
			Debug.Log ("Nothing Happened");
		}
	}
}
