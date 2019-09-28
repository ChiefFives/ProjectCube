using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    //Variables that will be used to move the player
    public float speed;
    Rigidbody2D rb2d; //This is a unity library call, it is always called for objects
    // Start is called before the first frame update
    void Start()
    {
        //Initialize player and other objects
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       float moveHorizontal = Input.GetAxisRaw ("Horizontal"); //Input is a unity call
       PlayerMovement (moveHorizontal);
    }

    void PlayerMovement(float moveHorizontal){
        //Player movement to be coded here
        rb2d.velocity = new Vector2(moveHorizontal * speed, 0); //this line is always used for movement
    }
}
