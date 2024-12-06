using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeScreen : MonoBehaviour
{
    public Image fadeImage; // Assign your fade image in the Inspector
    public float fadeDuration = 1.0f; // Duration of the fade effect
    public float delayBeforeTransition = 1.0f; // Additional delay before transitioning
    public string sceneToLoad; // The name of the scene to transition to

    private bool isFading = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isFading) // Replace "Player" with the player's tag
        {
            StartCoroutine(FadeAndLoadScene());
        }
    }

    private IEnumerator FadeAndLoadScene()
    {
        isFading = true;

        // Fade to black
        float elapsedTime = 0;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        // Wait for an additional delay
        yield return new WaitForSeconds(delayBeforeTransition);

        // Load the new scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
