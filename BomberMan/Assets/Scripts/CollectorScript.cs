using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectorScript : MonoBehaviour
{
    public Text scoreText;
    private int score;

    void IncreaseScore()
    {
        score++;

        scoreText.text = "Score: " + score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bomb")
        {
            IncreaseScore();
            collision.gameObject.SetActive(false);
        }
    }
}
