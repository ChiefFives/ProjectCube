using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BattleBossOne : MonoBehaviour
{
    int bossState;
    int cannonState;
    int waypointIndex = 0;
    public Transform[] waypoints;
    public float maxSpeed;
    public GameObject trigger;
    public BossChase chaseScript;
    float timeStamp = 0.0f;
    GameObject cannon;
    float shootTime = 6.821f;
    public bool bossHit;
    float fallenTimer = 0.0f;
    float fallLimit = 5.0f;
    private void Awake() {
        trigger = GameObject.Find("Trigger2");
        cannon = GameObject.Find("cannon");
        bossHit = false;
        chaseScript = trigger.GetComponent<BossChase>();
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = chaseScript.waypoints[i];
        }
    }
    private void Update() {
        timeStamp += Time.deltaTime;
        if(timeStamp <= shootTime && !bossHit){
            bossState = 1;
        }
        if(timeStamp > shootTime && !bossHit){
            bossState = 2;
        }
        if(bossHit == true && timeStamp > shootTime)
        {
            bossState = 3;
        }
        BossStates();
    }
    private void BossStates(){
        switch (bossState)
        {
            case 1:
                //Debug.Log("case 1");
                Move();
                break;
            case 2 :
                Debug.Log("case 2");
                MakeRain();
                break;
            case 3 :
                Debug.Log("case 3");
                Fallen();
                break;
            default:
                Move();
                break;
        }
    }
    private void Move(){
        //Debug.Log("Boss move");
        bossHit = false;
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, maxSpeed * Time.deltaTime);
		if (waypointIndex < waypoints.Length && transform.position == waypoints[waypointIndex].transform.position) {
			waypointIndex++;
		}
		if (waypointIndex == waypoints.Length) {
			waypointIndex = 0;
		}
    }
    private void MakeRain(){
        //activate cannon here
        //move cannon to point b, start timer
        //if < 2s and hit, move to point a and fire case 2 else >= 2s fire case 1
        //cannon goes back as it rains
        //case 1 rain without red object, case 2 rain with red object and Fallen()
        CannonBehaviour cannonBehaviour = cannon.GetComponent<CannonBehaviour>();
        cannonBehaviour.Move();
    }
    private void Fallen(){
        //boss takes damage here
        //drop boss to ground start fallen timer
        //when fallen timer is over, reset all timers, bring back to state 1
        Debug.Log("Reset");
        BossReset();
    }
    private void BossReset() {
        timeStamp = 0.0f;
        bossHit = false;
    }
}
//TODO: how many cases
//Case 1 boss summon and move while shooting
//Case 2 boss stop and attack with cannon, cannon move
//if cannon hit, attack boss switch else attack player switch
//boss hit,attack boss and fall
//player switch make rain
//Case 3 boss hit and change sprite and fall
//Back to case 1 which is default

//Cannon has two states, hit and non hit
//Boss has three states, default, make rain and hit