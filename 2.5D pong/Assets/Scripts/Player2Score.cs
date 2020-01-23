using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Score : MonoBehaviour
{
    TextMesh textMesh;
    int score = 0;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        textMesh = gameObject.GetComponent<TextMesh>();
    }
    public void UpdatePlayer2Score()
    {
        score ++;
        textMesh.text = score.ToString();
    }
}
