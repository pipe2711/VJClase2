using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTextGameOver;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [Header("Índice de Escena")]
    private int nextSceneIndex;

    [Header("UI")]
    public GameObject gameOverUI;

    // ─── Métodos públicos (llamados desde botones u otros scripts) ────────────

    public void StartGame()
    {
        nextSceneIndex = 1;   // Escena de Intro / Diálogo
        LoadNextScene();
    }

    public void LoadGameScene()
    {
        nextSceneIndex = 2;   // Escena del juego base
        LoadNextScene();
    }

    public void GoToNextScene()
    {
        LoadNextScene();
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego");
    }

    public void PlayerDied()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;

        scoreTextGameOver.text = "Score: " + PlayerStats.score;
    }

    // 🔄 BOTÓN REINTENTAR
    public void RestartLevel()
    {
        Time.timeScale = 1f;

        PlayerStats.score = 0;
        PlayerStats.OnScoreChanged?.Invoke(PlayerStats.score); // 🔥 ESTA LÍNEA

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // 🏠 BOTÓN MENÚ
    public void GoToMenu()
    {
        Time.timeScale = 1f;

        PlayerStats.score = 0;
        PlayerStats.OnScoreChanged?.Invoke(PlayerStats.score);

        SceneManager.LoadScene(0);
    }

    // ─── Método interno ───────────────────────────────────────────────────────

    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
}