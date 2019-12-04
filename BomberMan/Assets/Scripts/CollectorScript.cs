using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectorScript : MonoBehaviour
{
    public Text scoreText;
    private int score;
    private static int highScore;

    private void Start()
    {
        DisplayScore();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bomb")
        {
            IncreaseScore();
            collision.gameObject.SetActive(false);
        }
    }

    void DisplayScore()
    {
        scoreText.text = "High Score: " + highScore + "\nScore: " + score;
    }

    void IncreaseScore()
    {
        score++;

        if (score > highScore)
        {
            highScore = score;
        }

        DisplayScore();
    }
}
