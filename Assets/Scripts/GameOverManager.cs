using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; 
    public TextMeshProUGUI gameOverText; 
    public GameObject tryAgainButton;
    public float fadeDuration = 1f; 

    private bool isGameOver = false;

    private void Start()
    {
        gameOverPanel.SetActive(false); 
        tryAgainButton.SetActive(false); 
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !isGameOver) 
        {
            StartCoroutine(HandleGameOver());
        }
    }

    private IEnumerator HandleGameOver()
    {
        isGameOver = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        gameOverPanel.SetActive(true);

        CanvasGroup canvasGroup = gameOverPanel.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameOverPanel.AddComponent<CanvasGroup>();
        }

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 1f;

        tryAgainButton.SetActive(true);
    }

    public void RestartLevel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
