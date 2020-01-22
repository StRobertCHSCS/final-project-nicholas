using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    TextMesh textMesh;
    public GameObject ball;
    Ball ballScript;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = gameObject.GetComponent<TextMesh>();
        ball = GameObject.Find("Ball");
        ballScript = ball.GetComponent<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ballScript.startCount > 0)
        {
            int text = (int) Mathf.Ceil(ballScript.startCount);
            textMesh.text = text.ToString();
        }
        else if (ballScript.startCount < 0 && ballScript.startCount > -1)
        {
            textMesh.text = "START";
        }

        if (ballScript.startCount < -1)
        {
            Destroy(gameObject);
        }
    }
}
