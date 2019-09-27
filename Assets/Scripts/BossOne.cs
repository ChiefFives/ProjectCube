using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BossOne : MonoBehaviour
{
    GameObject trigger;
    GameObject cannon;
    BossChase chaseScript;
    public Transform[] waypoints;
    int bossStates;
    public float bossTimer;
    float fallBossTimer;
    float shootingTime;
    float fallenTime;
    bool bossHit;
    int waypointIndex;
    public float maxSpeed;
    private void Awake() {
        trigger = GameObject.Find("Trigger2");
        cannon = GameObject.Find("cannon");
        bossTimer = 0.0f;
        fallBossTimer = 0.0f;
        shootingTime = 6.821f;
        fallenTime = 5.0f;
        bossHit = false;
        waypointIndex = 0;
        chaseScript = trigger.GetComponent<BossChase>();
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = chaseScript.waypoints[i];
        }
    }
    private void Update() {
        if(!bossHit){
            bossTimer += Time.deltaTime;
            fallBossTimer = 0.0f;
            if(bossTimer <= shootingTime){
                bossStates = 1;
            }else
            {
                bossStates = 2;
            }
        }else
        {
            bossTimer = 0.0f;
            bossStates = 3;
            fallBossTimer += Time.deltaTime;
        }
        BossStates();
    }
    private void BossStates(){
        switch (bossStates)
        {
            case 1:
            //Debug.Log("Move Boss");
            Move();
            break;
            case 2:
            //Debug.Log("Call Cannon");
            CallCannon();
            break;
            case 3:
            Debug.Log("Boss Fall");
            Fallen();
            break;
            default:
            break;
        }
    }
    private void Move(){
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, maxSpeed * Time.deltaTime);
		if (waypointIndex < waypoints.Length && transform.position == waypoints[waypointIndex].transform.position) {
			waypointIndex++;
		}
		if (waypointIndex == waypoints.Length) {
			waypointIndex = 0;
		}
    }
    private void CallCannon(){
        CannonBehaviour cannonScript = cannon.GetComponent<CannonBehaviour>();
        cannonScript.Move();
        if(cannonScript.bossDmg && bossTimer > 15.0f){
            bossHit = true;
        }
        else
        {
            if(bossTimer > 15.0f){
                ResetBoss();
            }
        }
    }
    private void Fallen(){
        if(fallBossTimer >= fallenTime){
            ResetBoss();
        }
    }
    private void ResetBoss(){
        bossHit = false;
        fallBossTimer = 0.0f;
        bossTimer = 0.0f;
        waypointIndex = 0;
    }
}

//Needs to reset cannon when boss is reset as well, reset everything after a cycle and not before