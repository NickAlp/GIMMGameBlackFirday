using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    public Image fadeImage;

    private void Start()
    {
        fadeImage.canvasRenderer.SetAlpha(1.0f);
        FadeIn();
    }

    public void FadeIn()
    {
        fadeImage.CrossFadeAlpha(0.0f, 2f, false);
    }

    public void FadeToBlack()
    {
        fadeImage.CrossFadeAlpha(1.0f, 2f, false);
    }
}
