using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsPage2 : MonoBehaviour
{
    void Update()
    {
        /*
            called once per frame
        */

        // checks if the space bar was pressd
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // closes the current scene and loads the main menu scene
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
}
