using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CannonOne : MonoBehaviour
{
    BossOne bossScript;
    public GameObject bossTarget;
    float timer;
    int waypointIndex;
    public float speed;
    public Transform[] waypoints;
    float reloadTime;
    bool cannonHit;
    int cannonState;
    public bool bossDmg;
    public GameObject playerObj;
    private void Awake() {
        bossScript = bossTarget.GetComponent<BossOne>();
        timer = 0.0f;
        waypointIndex = 1;
        reloadTime = 3.0f;
        cannonHit = false;
        bossDmg = false;
        CannonStates();
    }
    public void CannonStates(){
        timer += Time.deltaTime;
        if(cannonHit){
            if(waypointIndex == 0){
                cannonState = 0;
            }
            else
            {
                cannonState = 0;
            }
        }else{
            if(waypointIndex == 0){
                cannonState = 1;
            }
            else{
                cannonState = 1;
            }
        }
        switch (cannonState)
        {
            case 0:
            BossSwitch();
            break;
            case 1:
            PlayerSwitch();
            break;
            default:
            break;
        }
    }
    private void PlayerSwitch(){
        waypointIndex = 1;
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);
        if(timer > reloadTime){
            FireCannon();
        }
    }
    private void BossSwitch(){
        waypointIndex = 0;
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);
        if(timer > reloadTime){
            bossDmg = true;
            FireCannon();
        }
    }
    private void FireCannon(){
        Debug.Log("Fire Cannon");
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "PlayerRed"){
            if(timer <= reloadTime && waypointIndex == 1){
                cannonHit = true;
            }
        }
    }
    private void ResetCannon(){
        waypointIndex =0;
        cannonHit = false;
    }
}