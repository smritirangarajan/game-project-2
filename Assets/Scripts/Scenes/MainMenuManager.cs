using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles main menu buttons. StartGame and QuitGame.
/// </summary>
public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string gameplaySceneName = "Gameplay";
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        if (gameManager == null)
            gameManager = FindObjectOfType<GameManager>();
    }

    public void StartGame()
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

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
