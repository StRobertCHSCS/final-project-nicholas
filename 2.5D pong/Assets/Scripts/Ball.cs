using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // initial variable declarations
    private float startWaitTime = 3;
    [SerializeField]
    private float ballSpeed = 5;
    public float startCount;
    [SerializeField]
    float xdir;
    [SerializeField]
    float ydir;
    public GameObject p1Score;
    public GameObject p2Score;

    void Start()
    {
        /*
            called before the first frame update
        */

        // sets the startcount variable to the start wait time variable
        startCount = startWaitTime;
        // speeds up the ball ever 2.5 seconds
        InvokeRepeating("SpeedUp", 2.5f, 2.5f);
        // sets the x direction to a random number from 1 to -1 inclusive
        xdir = Random.Range(-1, 2);
        // sets the y direction to a random number from 1 to -1 inclusive
        ydir = Random.Range(-1, 2);
        // if the x direction is 0, set it to 1
        if (xdir == 0)
        {
            xdir = 1;
        }
    }

    void Update()
    {
        /*
            called once per frame
        */ 

        // checks if the startcount is greater than -1
        if (startCount > -1)
        {
            // sets startcount to startwaittime minus the time in seconds since the level has loaded
            startCount = startWaitTime - Time.timeSinceLevelLoad;
        }

        // checks if the startcount is less than 0
        if (startCount < 0)
        {
            // moves the ball
            gameObject.transform.position = new Vector3(transform.position.x + xdir * ballSpeed * Time.deltaTime, transform.position.y + ydir * ballSpeed * Time.deltaTime, transform.position.z);
        }
    }


    void OnCollisionEnter(Collision other)
    {
        /*
            called when the ball collides with another object

            Parameters:
                other {Collision} -- the gameobject that the ball collided with
        */

        // checks if the collided object has the tag "Paddle"
        if (other.gameObject.tag == "Paddle")
        {
            // changes the x direction
            xdir *= -1;
            // checks if the ball's y coordinate is above the paddle's
            if (transform.position.y > other.transform.position.y)
            {
                // makes the y direction positive
                ydir = 1;
            }
            // checks if the ball's y coodinate is below the paddle's
            else if (transform.position.y < other.transform.position.y)
            {
                // makes the y direction negative
                ydir = -1;
            }
            else
            {
                // sets the y direction to 0 so that the ball goes straight
                ydir = 0;
            }
        }
        // checks if the gameobject has the tag "Walls"
        else if (other.gameObject.tag == "Walls")
        {
            // changes the y direction
            ydir *= -1;
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        /*
            called when the ball enters a collider set as a trigger

            Parameters:
                other {Collider} - the gameobject that the colider is attached to
        */

        // checks if the gameobject has the tag "Player1EndZone"
        if (other.gameObject.tag == "Player1EndZone")
        {
            // updates player 1's score using the method from the Player1Score.cs file
            p1Score.GetComponent<Player1Score>().UpdatePlayer1Score();
            ResetBall();
        }
        // checks if the gameobject has the tag "Player2EndZone"
        else if (other.gameObject.tag == "Player2EndZone")
        {
            // updates player 2's score using the method from the Player2Score.cs file
            p2Score.GetComponent<Player2Score>().UpdatePlayer2Score();
            ResetBall();
        }
    }

    private void SpeedUp()
    {
        /*
            method that is called whenever the ball should speed up
        */
        ballSpeed += 0.5f;
    }

    private void ResetBall()
    {
        /*
            resets the ball back to 0,0 and randomizes the direction
        */

        // sets the position to 0 on all axes
        transform.position = new Vector3(0, 0, 0);
        // randomizes the x direction
        xdir = Random.Range(-1, 2);
        // randomizes the y direction
        ydir = Random.Range(-1, 2);
        // if the x direction is 0, sets it to 1
        if (xdir == 0)
        {
            xdir = 1;
        }
        // resets the ball speed back to 5
        ballSpeed = 5;
    }
}
