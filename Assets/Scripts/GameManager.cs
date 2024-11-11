using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float evacuationTime = 120f;
    public FadeScreen fadeScreen; // Reference to your fade script

    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded)
            return;

        evacuationTime -= Time.deltaTime;

        if (evacuationTime <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        fadeScreen.FadeToBlack(); // Trigger fade to black
        Invoke("LoadEndScene", 2f); // Wait for 2 seconds before loading end screen
    }

    void LoadEndScene()
    {
        // Logic to load the end screen, like "Thanks for playing"
        // You can load a new scene or just show a UI panel
        SceneManager.LoadScene("EndScene");
    }
}
