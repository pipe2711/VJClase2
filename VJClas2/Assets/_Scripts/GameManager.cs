using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI - Game Over")]
    public GameObject gameOverUI;
    public TextMeshProUGUI scoreTextGameOver;

    [Header("UI - Win")]
    public GameObject winUI;
    public TextMeshProUGUI winText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        Time.timeScale = 1f;
    }

    // ─────────────────────────────
    // 🎮 MAIN MENU → INTRO
    // ─────────────────────────────

    public void StartGame()
    {
        Time.timeScale = 1f;

        // 🔥 RESET SCORE + UI FIX
        PlayerStats.score = 0;
        PlayerStats.OnScoreChanged?.Invoke(PlayerStats.score);

        SceneManager.LoadScene(1); // Intro
    }

    // ─────────────────────────────
    // 🧩 DIALOGUE → GAMEPLAY
    // ─────────────────────────────

    public void LoadGameScene()
    {
        Time.timeScale = 1f;

        // 🔥 RESET SCORE + UI FIX (IMPORTANTE TAMBIÉN AQUÍ)
        PlayerStats.score = 0;
        PlayerStats.OnScoreChanged?.Invoke(PlayerStats.score);

        SceneManager.LoadScene(2); // Gameplay
    }

    // ─────────────────────────────
    // 💀 GAME OVER
    // ─────────────────────────────

    public void PlayerDied()
    {
        Time.timeScale = 0f;

        if (gameOverUI != null)
            gameOverUI.SetActive(true);

        if (scoreTextGameOver != null)
            scoreTextGameOver.text = "Score: " + PlayerStats.score;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;

        // 🔥 RESET SCORE + UI FIX
        PlayerStats.score = 0;
        PlayerStats.OnScoreChanged?.Invoke(PlayerStats.score);

        SceneManager.LoadScene(2);
    }

    public void GoToMenuFromGameOver()
    {
        Time.timeScale = 1f;

        // 🔥 RESET SCORE + UI FIX
        PlayerStats.score = 0;
        PlayerStats.OnScoreChanged?.Invoke(PlayerStats.score);

        SceneManager.LoadScene(0);
    }

    // ─────────────────────────────
    // 🏆 BOSS WIN
    // ─────────────────────────────

    public void BossDefeated()
    {
        Time.timeScale = 0f;

        if (winUI != null)
            winUI.SetActive(true);

        if (winText != null)
        {
            winText.text =
                "🎉 Congratulations!\n\n" +
                "You completed the demo\n" +
                "(Returning to menu...)";
        }

        StartCoroutine(ReturnToMenuAfterWin());
    }

    private IEnumerator ReturnToMenuAfterWin()
    {
        yield return new WaitForSecondsRealtime(4f);

        Time.timeScale = 1f;

        // 🔥 RESET SCORE + UI FIX
        PlayerStats.score = 0;
        PlayerStats.OnScoreChanged?.Invoke(PlayerStats.score);

        SceneManager.LoadScene(0);
    }

    // ─────────────────────────────
    // 🔄 MENU DIRECTO
    // ─────────────────────────────

    public void GoToMenu()
    {
        Time.timeScale = 1f;

        // 🔥 RESET SCORE + UI FIX
        PlayerStats.score = 0;
        PlayerStats.OnScoreChanged?.Invoke(PlayerStats.score);

        SceneManager.LoadScene(0);
    }
}