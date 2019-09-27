using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedObjectBehaviour : MonoBehaviour {

	public GameObject targetObj;

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.name == "PlayerRed") {
			Debug.Log ("Wall destroyed");
			Destroy (this.gameObject);
		} else {
			Debug.Log ("Nothing Happened");
		}
	}
}
