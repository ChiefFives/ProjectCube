using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChase : MonoBehaviour
{
    public GameObject bossChase;
    public Transform spawnPoint;
    public Transform[] waypoints;

    bool isCreate = false;

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player"){
            //spawn boss character
            //boss then runs enemy script
            if(!isCreate){
                GameObject a = Instantiate(bossChase);
                isCreate = true;
            }
        }
    }
}
