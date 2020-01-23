using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2Score : MonoBehaviour
{
    TextMesh textMesh;
    int score = 0;
    void Start()
    {
        textMesh = gameObject.GetComponent<TextMesh>();
    }
    public void UpdatePlayer2Score()
    {
        score ++;
        textMesh.text = score.ToString();
        if (score >= 10)
        {
            SceneManager.LoadScene("Player2WinScreen", LoadSceneMode.Single);
        }
    }
}
