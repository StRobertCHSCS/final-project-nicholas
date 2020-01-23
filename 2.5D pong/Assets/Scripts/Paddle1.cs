using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle1 : MonoBehaviour
{
    float direction;
    float speed = 5;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = -1;
        }
        else
        {
            direction = 0;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y + direction * speed * Time.deltaTime, transform.position.z);
    }
}
