using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneTransition : MonoBehaviour
{
    public GameObject menuContainer; // UI container to disable, e.g., MainMenu
    public Image fadePanel; // Drag your FadePanel's Image component here
    public TextMeshProUGUI backstoryText; // Drag the Text component for the backstory here
    public float fadeDuration = 1.0f; // Duration of fade-in and fade-out
    public float backstoryDuration = 30.0f; // Duration to display the backstory text

    public void StartGameTransition(string sceneName)
    {
        StartCoroutine(FadeOutAndShowBackstory(sceneName));
    }

    private IEnumerator FadeOutAndShowBackstory(string sceneName)
    {
        // Disable the menu container
        if (menuContainer != null)
        {
            menuContainer.SetActive(false); // Deactivate menu UI
        }

        // Fade to black
        float elapsedTime = 0f;
        Color panelColor = fadePanel.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            panelColor.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadePanel.color = panelColor;
            yield return null;
        }

        // Display the backstory text
        if (backstoryText != null)
        {
            backstoryText.gameObject.SetActive(true); // Show the text
            yield return new WaitForSeconds(backstoryDuration); // Wait for the backstory duration
        }

        // Fade out the backstory (optional)
        elapsedTime = 0f;
        if (backstoryText != null)
        {
            Color textColor = backstoryText.color;

            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                textColor.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeDuration);
                backstoryText.color = textColor;
                yield return null;
            }
        }

        // Load the next scene
        SceneManager.LoadScene(sceneName);
    }
}
