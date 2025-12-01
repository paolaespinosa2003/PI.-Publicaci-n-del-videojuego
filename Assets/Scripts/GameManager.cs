using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public int currentLevel = 1;
    public int lives = 3;

    void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else Destroy(gameObject);
    }

    public void AddScore(int v)
    {
        score += v;
        if (UIManager.Instance != null) UIManager.Instance.UpdateScore(score);
    }

    public void OnPlayerDeath()
    {
        lives--;
        if (UIManager.Instance != null) UIManager.Instance.ShowDeath();
        if (lives <= 0) {
            if (UIManager.Instance != null) UIManager.Instance.ShowGameOver();
        } else {
            if (UIManager.Instance != null) UIManager.Instance.StartCoroutine(UIManager.Instance.ResetBallCoroutine());
        }
    }

    public void LevelComplete()
    {
        if (SaveManager.Instance != null) SaveManager.Instance.SaveLevelProgress(currentLevel);
        if (UIManager.Instance != null) UIManager.Instance.ShowLevelComplete();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("MainScene"); // ensure scene name matches
    }

    public void LoadLevel(int level)
    {
        currentLevel = level;
        if (LevelManager.Instance != null) LevelManager.Instance.LoadLevel(level);
    }
}