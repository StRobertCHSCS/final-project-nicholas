using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Update()
    {
        /*
            called once per frame
        */
        
        // checks if the button pressed is the space bar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // closes the main menu scene and loads the main game scene
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
        // checks if the button pressed is the space bar
        if (Input.GetKeyDown(KeyCode.I))
        {
            // closes the current scene and loads the first instruction page scene
            SceneManager.LoadScene("InstructionsPage1", LoadSceneMode.Single);
        }
    }
}
