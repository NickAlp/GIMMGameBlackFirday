using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneTransition : MonoBehaviour
{
    public GameObject menuContainer; 
    public Image fadePanel; 
    public TextMeshProUGUI backstoryText;
    public Button skipButton; 
    public float fadeDuration = 1.0f; 
    public float backstoryDuration = 30.0f;

    private bool skipPressed = false;

    public void StartGameTransition(string sceneName)
    {
        if (menuContainer != null)
        {
            menuContainer.SetActive(false); 
        }

        if (skipButton != null)
        {
            skipButton.gameObject.SetActive(true); 
            skipButton.onClick.AddListener(() => SkipBackstory(sceneName)); 
        }

        if (backstoryText != null)
        {
            backstoryText.gameObject.SetActive(true); 
        }
        StartCoroutine(FadeOutAndShowBackstory(sceneName));
    }

    private IEnumerator FadeOutAndShowBackstory(string sceneName)
    {
        float elapsedTime = 0f;
        Color panelColor = fadePanel.color;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            panelColor.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadePanel.color = panelColor;
            yield return null;
        }
        if (backstoryText != null && !skipPressed)
        {
            float remainingTime = backstoryDuration;

            while (remainingTime > 0f && !skipPressed)
            {
                remainingTime -= Time.deltaTime;
                yield return null;
            }
        }

        if (backstoryText != null)
        {
            StartCoroutine(FadeOutUIElement(backstoryText));
        }

        if (skipButton != null)
        {
            StartCoroutine(FadeOutUIElement(skipButton.GetComponent<Image>()));
            TextMeshProUGUI buttonText = skipButton.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                StartCoroutine(FadeOutUIElement(buttonText));
            }
        }

        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene(sceneName);
    }

    private void SkipBackstory(string sceneName)
    {
        skipPressed = true; 
        StartCoroutine(SkipSequence(sceneName)); 
    }

    private IEnumerator SkipSequence(string sceneName)
    {
        if (backstoryText != null)
        {
            StartCoroutine(FadeOutUIElement(backstoryText));
        }

        if (skipButton != null)
        {
            StartCoroutine(FadeOutUIElement(skipButton.GetComponent<Image>()));
            TextMeshProUGUI buttonText = skipButton.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                StartCoroutine(FadeOutUIElement(buttonText));
            }
        }

        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator FadeOutUIElement(Graphic uiElement)
    {
        float elapsedTime = 0f;
        Color elementColor = uiElement.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            elementColor.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeDuration);
            uiElement.color = elementColor;
            yield return null;
        }

        uiElement.gameObject.SetActive(false); // Deactivate the UI element after fading
    }
}