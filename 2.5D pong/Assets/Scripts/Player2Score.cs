using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2Score : MonoBehaviour
{
    // initial variable denfinitions
    TextMesh textMesh;
    int score = 0;
    void Start()
    {
        /*
            called before the first frame update
        */
        
        // sets the textmesh component of the gameobject its attached to the textmesh variable
        textMesh = gameObject.GetComponent<TextMesh>();
    }
    public void UpdatePlayer2Score()
    {
        /*
            is used by the ball's sript to update player 2's score
        */

        // adds 1 to the player's score
        score ++;

        // sets the text in the text mesh attached to the gameobject to the player's score as a string
        textMesh.text = score.ToString();

        // checks if the player's score is equal to 10
        if (score == 10)
        {
            // closes the current scene and loads the player 2 win screen scene
            SceneManager.LoadScene("Player2WinScreen", LoadSceneMode.Single);
        }
    }
}
