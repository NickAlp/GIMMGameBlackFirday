using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject menuContainer; // Empty GameObject holding the buttons
    public Image fadePanel; // Panel used for fading to black
    public float fadeDuration = 1.0f; // Duration of the fade effect
    public string nextSceneName; // Name of the next scene to load

    public void Playgame()
    {
        // Start the fade and menu disabling sequence
        StartCoroutine(FadeToNextScene());
    }

    public void Quitgame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    private IEnumerator FadeToNextScene()
    {
        // Disable the MainMenu (menuContainer)
        if (menuContainer != null)
        {
            menuContainer.SetActive(false); // This will turn it off in the Inspector
        }

        // Activate and fade in the fadePanel
        if (fadePanel != null)
        {
            fadePanel.gameObject.SetActive(true); // Ensure the fade panel is active
            Color panelColor = fadePanel.color;
            float elapsedTime = 0f;

            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                panelColor.a = Mathf.Clamp01(elapsedTime / fadeDuration); // Gradually increase alpha
                fadePanel.color = panelColor;
                yield return null;
            }
        }

        // Wait briefly (optional delay) and then load the next scene
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(nextSceneName);
    }
}
