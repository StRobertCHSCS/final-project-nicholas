using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    // initial variale definitions
    TextMesh textMesh;
    public GameObject ball;
    Ball ballScript;
    int text;

    void Start()
    {
        /*
            called before the first frame update
        */

        // sets the textmesh variale to the texmesh component attached to the gameobject
        textMesh = gameObject.GetComponent<TextMesh>();

        // sets the ball variable to the ball gameObject
        ball = GameObject.Find("Ball");

        // sets the ballscript component to the script called ball attached to the bll gameObject
        ballScript = ball.GetComponent<Ball>();
    }

    void Update()
    {
        /*
            called once every frame
        */

        // check is the startcount variable in the ballscript is greater than 0
        if (ballScript.startCount > 0)
        {
            // sets the text variable to the ciel of the startcount variable
            text = (int) Mathf.Ceil(ballScript.startCount);

            // sets the text in the textmesh component to the text vraiable as a string
            textMesh.text = text.ToString();
        }
        // checks if the startcount variable is between 0 and -1
        else if (ballScript.startCount < 0 && ballScript.startCount > -1)
        {
            // sets the text in the textmesh component to START
            textMesh.text = "START";
        }

        // checks if the startcount variable is less than -1
        if (ballScript.startCount < -1)
        {
            // destroys the gameobject
            Destroy(gameObject);
        }
    }
}
