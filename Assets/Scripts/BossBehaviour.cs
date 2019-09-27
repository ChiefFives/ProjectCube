using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public GameObject trigger;
    public BossChase chaseScript;
    public Transform[] chasePoints;
    public float speed;
    int waypointIndex = 0;

    bool indexLength = false;


    private void Awake() {
        trigger = GameObject.Find("Trigger1");
        chaseScript = trigger.GetComponent<BossChase>();
        for (int i = 0; i < chasePoints.Length; i++)
        {
            chasePoints[i] = chaseScript.waypoints[i];
        }
    }

    private void Update() {
        if(!indexLength){
            Move();
        }
    }

    void Move(){
		//set waypoint 0 to 1 and so forth
		transform.position = Vector2.MoveTowards(transform.position, chasePoints[waypointIndex].transform.position, speed * Time.deltaTime);

		if (waypointIndex < chasePoints.Length && transform.position == chasePoints[waypointIndex].transform.position) {
			waypointIndex++;
		}
		if (waypointIndex == chasePoints.Length) {
			waypointIndex = chasePoints.Length;
            indexLength = true;
		}
	}
}
