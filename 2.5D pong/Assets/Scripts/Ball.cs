﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float startWaitTime = 3f;
    [SerializeField]
    private float ballSpeed = 5f;
    public float startCount;
    [SerializeField]
    float xdir;
    [SerializeField]
    float ydir;
    public GameObject p1Score;
    public GameObject p2Score;
    // Start is called before the first frame update
    void Start()
    {
        startCount = startWaitTime;
        xdir = Random.Range(-1, 2);
        ydir = Random.Range(-1, 2);
        if (xdir == 0)
        {
            xdir = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startCount > -1)
        {
            startCount = startWaitTime - Time.timeSinceLevelLoad;
        }

        if (startCount < 0)
        {
            gameObject.transform.position = new Vector3(transform.position.x + xdir * ballSpeed * Time.deltaTime, transform.position.y + ydir * ballSpeed * Time.deltaTime, transform.position.z);
        }
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Paddle")
        {
            xdir *= -1f;
            if (transform.position.y > other.transform.position.y)
            {
                ydir = 1;
            }
            else if (transform.position.y < other.transform.position.y)
            {
                ydir = -1;
            }
            else
            {
                ydir = 0;
            }
        }
        else if (other.gameObject.tag == "Walls")
        {
            ydir *= -1f;
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player1EndZone")
        {
            p1Score.GetComponent<Player1Score>().UpdatePlayer1Score();
            xdir = 0;
            ydir = 0;
            transform.position = new Vector3(0, 0, 0);
            xdir = Random.Range(-1, 2);
            ydir = Random.Range(-1, 2);
            if (xdir == 0)
            {
                xdir = 1;
            }
        }
        else if (other.gameObject.tag == "Player2EndZone")
        {
            p2Score.GetComponent<Player2Score>().UpdatePlayer2Score();
            xdir = 0;
            ydir = 0;
            transform.position = new Vector3(0, 0, 0);
            xdir = Random.Range(-1, 2);
            ydir = Random.Range(-1, 2);
            if (xdir == 0)
            {
                xdir = 1;
            }
        }
    }
}
