using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float startWaitTime = 3f;
    private float ballSpeed = 10f;
    public float startCount;
    // Start is called before the first frame update
    void Start()
    {
        startCount = startWaitTime;
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
            gameObject.transform.position = new Vector3(transform.position.x + (ballSpeed * Time.deltaTime), transform.position.y, transform.position.z);

        
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        ballSpeed *= -1f;
    }
}
