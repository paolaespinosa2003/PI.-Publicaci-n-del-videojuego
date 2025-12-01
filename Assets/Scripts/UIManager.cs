using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Text scoreText;
    public GameObject mainMenuPanel;
    public GameObject hudPanel;
    public GameObject pausePanel;
    public GameObject levelCompletePanel;
    public GameObject gameOverPanel;
    public GameObject deathPanel;
    public Transform ballSpawn;

    void Awake()
    {
        Instance = this;
    }

    public void UpdateScore(int s)
    {
        if (scoreText) scoreText.text = $"Score: {s}";
    }

    public void ShowMainMenu()
    {
        if (mainMenuPanel) mainMenuPanel.SetActive(true);
        if (hudPanel) hudPanel.SetActive(false);
    }

    public void StartGame()
    {
        if (mainMenuPanel) mainMenuPanel.SetActive(false);
        if (hudPanel) hudPanel.SetActive(true);
        if (GameManager.Instance != null) { GameManager.Instance.score = 0; GameManager.Instance.lives = 3; GameManager.Instance.currentLevel = 1; }
        if (LevelManager.Instance != null) LevelManager.Instance.LoadLevel(1);
    }

    public void ShowLevelComplete()
    {
        if (levelCompletePanel) levelCompletePanel.SetActive(true);
    }

    public void ShowGameOver()
    {
        if (gameOverPanel) gameOverPanel.SetActive(true);
    }

    public void ShowDeath()
    {
        if (deathPanel) deathPanel.SetActive(true);
    }

    public IEnumerator ResetBallCoroutine()
    {
        yield return new WaitForSeconds(1f);
        if (deathPanel) deathPanel.SetActive(false);
        if (LevelManager.Instance != null) LevelManager.Instance.ResetBallPosition();
    }
}