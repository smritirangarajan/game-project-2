using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Manages the lose/game over scene. Displays final score and high score.
/// Provides RestartGame and ReturnToMenu buttons.
/// </summary>
public class LoseSceneManager : MonoBehaviour
{
    [SerializeField] private TMP_Text finalScoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private string gameplaySceneName = "Gameplay";
    [SerializeField] private string mainMenuSceneName = "MainMenu";
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        if (gameManager == null)
            gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        if (gameManager != null)
        {
            if (finalScoreText != null)
                finalScoreText.text = "Final Score: " + gameManager.Score;
            if (highScoreText != null)
                highScoreText.text = "High Score: " + gameManager.HighScore;
        }
    }

    public void RestartGame()
    {
        if (gameManager != null)
        {
            gameManager.LoadGame();
        }
        else
        {
            SceneManager.LoadScene(gameplaySceneName);
        }
    }

    public void ReturnToMenu()
    {
        if (gameManager != null)
        {
            gameManager.LoadMainMenu();
        }
        else
        {
            SceneManager.LoadScene(mainMenuSceneName);
        }
    }
}
