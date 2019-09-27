using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueIObjectBehaviour : MonoBehaviour {

	public GameObject warpPoint;
	public GameObject target;

	void OnTriggerEnter2D(Collider2D collision){
		Debug.Log ("Collision occurs by platform");

		if (collision.gameObject.name == "PlayerBlue") {
			Debug.Log ("teleport");
			target.transform.position = warpPoint.transform.position;

		}
	}
}
