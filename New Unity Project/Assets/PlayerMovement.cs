using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float upThrust;      // upward force when jumping
    public float xThrust = 0f; // number between ´0, 3 max
    public float rotMove;       // rotation movement when doing tricks
    public Rigidbody rb;
    bool canJump = false;
   
    int score = 0;
    public int incScore = 1;        // increase the score by this amount    Change to float??
    public int thrustDiv = 1000;  // divide score by this number. 1000 is too big, 500 is too small

    private float XRotBJ; // x rotation before jumping
    private float YRotBJ; // y rotation before jumping





    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        XRotBJ = transform.eulerAngles.x;
        YRotBJ = transform.eulerAngles.y;
    }

    void FixedUpdate()
    {
        jumpOnKey();
       
    }

    // Update is called once per frame
    
void Update () {

        XRotBJ = transform.eulerAngles.x;
        YRotBJ = transform.eulerAngles.y;
        checkForTricks();
        getBoosted();
       
        Debug.Log("score" + score);

      




    }
    // get boosted with a downward force (for a 20 deg slope) with an amount proportional to the score. 
    void getBoosted()
    {
        xThrust = score / thrustDiv;
     
        rb.AddForce(-.9396f*xThrust, -.342020f*xThrust, 0, ForceMode.Impulse);
    }

    // check if the the tricks are available (key and collision)
    void checkForTricks()
    {
        // rotate along the x axis in an "up" way
        if (!canJump && Input.GetKey("w"))
        {
            transform.Rotate(rotMove * Time.deltaTime, 0, 0);
            score += incScore;
        }
        // rotate along the x axis in an "down" way (opposite of up)
        if (!canJump && Input.GetKey("s"))
        {
            transform.Rotate(-rotMove * Time.deltaTime, 0, 0);
            score += incScore;
        }
        // rotate along the y axis in an "up" way
        if (!canJump && Input.GetKey("d"))
        {
            transform.Rotate(0, rotMove * Time.deltaTime, 0);
            score += incScore;
        }
        // rotate along the y axis in an "down" way (opposite of up)
        if (!canJump && Input.GetKey("a"))
        {
            transform.Rotate(0, -rotMove * Time.deltaTime, 0);
            score += incScore;
        }
    }


   

    // Jump only if you are touching anything (not limited to the ramp)
    void jumpOnKey()
    {
        if (canJump && Input.GetKeyDown("space"))
        {
            rb.AddForce(-upThrust*.2f, upThrust, 0, ForceMode.Impulse);
           
        }
    }

    // If not on collission with anything, disable the possibility of jumping
    void OnCollisionExit(Collision collisionInfo)
    {
        canJump = false;
    }

    // If on constant collission with anything, allow you to jump
    void OnCollisionStay(Collision collisionInfo)
    {
      
        canJump = true;
    }
    void OnCollisionEnter(Collision collisionInfo)
    {

        canJump = true;
    }


}
