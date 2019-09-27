using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

	public Transform[] waypoints;

	public float maxSpeed;

	int waypointIndex = 0;

	void Start(){

		transform.position = waypoints [waypointIndex].transform.position;
	}

	void Update(){
		Move ();
	}

	void Move(){
		//set waypoint 0 to 1 and so forth
		transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, maxSpeed * Time.deltaTime);

		if (waypointIndex < waypoints.Length && transform.position == waypoints[waypointIndex].transform.position) {
			waypointIndex++;
		}
		if (waypointIndex == waypoints.Length) {
			waypointIndex = 0;
		}
	}
}
