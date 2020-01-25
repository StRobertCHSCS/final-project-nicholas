using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle1 : MonoBehaviour
{
    // initial variable definitions
    float direction;
    float speed = 7;

    // Update is called once per frame
    void Update()
    {
        /*
        called once per frame, handles the movement of the paddles
        */

        // checks is the key being held is the button for up, if so it set the direction to positive
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = 1;
        }
        // checks if the button held is the button for down, if so it sets the direction to negative
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = -1;
        }
        // if neither button is being pressed, sets direction to 0
        else
        {
            direction = 0;
        }

        // moves the paddle along the y axis
        transform.position = new Vector3(transform.position.x, transform.position.y + direction * speed * Time.deltaTime, transform.position.z);
    }
}
