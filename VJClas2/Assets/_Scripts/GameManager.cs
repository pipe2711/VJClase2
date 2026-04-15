using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Índice de Escena")]
    private int nextSceneIndex;  
                  
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

    // Método genérico: cualquier script puede ajustar nextSceneIndex y llamar esto
    public void GoToNextScene()
    {
        LoadNextScene();
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego");
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
}
