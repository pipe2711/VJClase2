using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void StartGame()
    {
        // Carga la escena de Intro / Diálogo (Índice 1)
        SceneManager.LoadScene(1);
    }

    public void LoadGameScene()
    {
        // Carga la escena del juego base (Índice 2)
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego");
    }
}

