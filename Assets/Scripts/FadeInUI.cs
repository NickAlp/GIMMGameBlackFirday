using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInUI : MonoBehaviour
{
    public TMP_Text fadeText; 
    public Button fadeButton; 
    public TMP_Text buttonLabel;
    public float fadeInDuration = 2f; 
    public float fadeOutDuration = 1f; 
    public string mainMenuSceneName = "MainMenu"; 

    private Image buttonImage; 

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        buttonImage = fadeButton.GetComponent<Image>();

        SetAlpha(fadeText, 0);
        SetAlpha(buttonLabel, 0);
        SetAlpha(buttonImage, 0);

        fadeButton.interactable = false;

        StartCoroutine(FadeInTextAndButton());
    }

    private IEnumerator FadeInTextAndButton()
    {
        float timer = 0f;

        while (timer < fadeInDuration)
        {
            timer += Time.deltaTime;
            SetAlpha(fadeText, Mathf.Lerp(0, 1, timer / fadeInDuration));
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        timer = 0f;

        while (timer < fadeInDuration)
        {
            timer += Time.deltaTime;
            SetAlpha(buttonImage, Mathf.Lerp(0, 1, timer / fadeInDuration));
            SetAlpha(buttonLabel, Mathf.Lerp(0, 1, timer / fadeInDuration));
            yield return null;
        }

        fadeButton.interactable = true;
    }

    public void OnButtonClick()
    {
        fadeButton.interactable = false;

        StartCoroutine(FadeOutTextAndButton());
    }

    private IEnumerator FadeOutTextAndButton()
    {
        float timer = 0f;

        while (timer < fadeOutDuration)
        {
            timer += Time.deltaTime;
            SetAlpha(fadeText, Mathf.Lerp(1, 0, timer / fadeOutDuration));
            SetAlpha(buttonImage, Mathf.Lerp(1, 0, timer / fadeOutDuration));
            SetAlpha(buttonLabel, Mathf.Lerp(1, 0, timer / fadeOutDuration));
            yield return null;
        }

        SceneManager.LoadScene(mainMenuSceneName);
    }

    private void SetAlpha(Graphic graphic, float alpha)
    {
        if (graphic != null)
        {
            Color color = graphic.color;
            color.a = alpha;
            graphic.color = color;
        }
    }
}