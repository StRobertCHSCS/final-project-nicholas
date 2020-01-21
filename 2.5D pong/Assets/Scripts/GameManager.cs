using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject paddle1;
    public GameObject paddle2;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(paddle1);
        Instantiate(paddle2);
        Instantiate(ball);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
