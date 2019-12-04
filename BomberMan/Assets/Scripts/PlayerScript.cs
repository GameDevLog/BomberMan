using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10f;
    private float minX = -2.55f;
    private float maxX = 2.55f;

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        if (Input.GetKeyDown("space"))
        {
            // Get current scene name
            string scene = SceneManager.GetActiveScene().name;
            // Load it
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
            // Resume it
            Resume();
        }
    }

    void MovePlayer()
    {
        float h = Input.GetAxis("Horizontal");
        Vector2 currentPosition = transform.position;

        if (h > 0)
        {
            // going to the right side
            currentPosition.x += speed * Time.deltaTime;
        }
        else if (h < 0)
        {
            // going to the left side
            currentPosition.x -= speed * Time.deltaTime;
        }

        if (currentPosition.x < minX)
        {
            currentPosition.x = minX;
        }
        else if (currentPosition.x > maxX)
        {
            currentPosition.x = maxX;
        }

        transform.position = currentPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bomb")
        {
            Parse();
        }
    }

    void Parse()
    {
        Time.timeScale = 0.0f;
    }

    void Resume()
    {
        Time.timeScale = 1.0f;
    }
}
