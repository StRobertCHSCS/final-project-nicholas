using System.Collections;
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
            startCount = startWaitTime - Time.time;
            Debug.Log(startCount);
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
            // one point to player 1
            // reset ball
            // on keypress space, restart it
        }
        else if (other.gameObject.tag == "Player2EndZone")
        {
            // one point to player 2
            // reset ball
            // on keypress space, restart it
        }
    }
}
