using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsPage1 : MonoBehaviour
{
    void Update()
    {
        /*
            called once per frame
        */

        // checks if the space bar was pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // closes the current scene and loads the second instruction page scene
            SceneManager.LoadScene("InstructionsPage2", LoadSceneMode.Single);
        }
    }
}
