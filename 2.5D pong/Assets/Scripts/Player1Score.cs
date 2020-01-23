using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1Score : MonoBehaviour
{
    TextMesh textMesh;
    int score = 0;
    void Start()
    {
        textMesh = gameObject.GetComponent<TextMesh>();
    }
    public void UpdatePlayer1Score()
    {
        score ++;
        textMesh.text = score.ToString();
        if (score >= 1)
        {
            SceneManager.LoadScene("Player1WinScreen", LoadSceneMode.Single);
        }
    }
}