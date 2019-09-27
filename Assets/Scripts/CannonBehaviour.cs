using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviour : MonoBehaviour
{
    public float cannonTimeStamp = 0.0f;
    float reloadTime = 3.0f;
    public Transform[] waypoints;
    public int waypointIndex;
    public float speed;
    public bool cannonDmg;
    public GameObject playerObj;
    BattleBossOne boss;
    public GameObject bossTarget;
    public bool bossDmg;
    private void Awake() {
        cannonDmg = false;
        waypointIndex = 1;
        bossDmg = false;
        boss = bossTarget.GetComponent<BattleBossOne>();
    }
    public void Move(){
        if(waypointIndex == 0){
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);
        }
        else if(waypointIndex == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);
        }
        ReloadTime();
    }
    private void ReloadTime(){
        cannonTimeStamp += Time.deltaTime;
        if(cannonTimeStamp >= reloadTime && !cannonDmg){
            FirePlayer();
        }
        if(cannonDmg && cannonTimeStamp < reloadTime){
            FireBoss();
        }
    }
    private void FireBoss(){
        waypointIndex = 0;
        bossDmg = true;
    }
    private void FirePlayer(){
        waypointIndex = 0;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "PlayerRed"){
            Debug.Log("hit player");
            if(cannonTimeStamp <= reloadTime && waypointIndex == 1){
                waypointIndex = 0;
                cannonDmg = true;
            }
        }
    }
}