using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] private string gameplaySceneName = "MainGame";
    [SerializeField] private string mainMenuSceneName = "MainMenu";
    [SerializeField] private string loseSceneName = "LoseGame";

    private int _score;//貌似代表当前的分数
    private int _highScore;//代表最高分数
    private bool _isGameOver;

    private const string HighScoreKey = "HighScore";

    public int Score => _score;
    public int HighScore => _highScore;
    public bool IsGameOver => _isGameOver;
    

    private void Start()
    {
        _highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    public void AddScore(int amount)
    {
        if (_isGameOver) return;

        _score += amount;

        if (_score > _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt(HighScoreKey, _highScore);
            PlayerPrefs.Save();
        }
    }

    public void GameOver()
    {
        if (_isGameOver) return;

        _isGameOver = true;
        SceneManager.LoadScene(loseSceneName);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(gameplaySceneName);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}