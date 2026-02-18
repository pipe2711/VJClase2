using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void NewGame()
    {
        Debug.Log("Inicio el Juego");
    }

    public void Continue()
    {
        Debug.Log("Continua el juego");
    }

    public void LoadGame()
    {
        Debug.Log("Cargando Juego");
    }

    public void Options()
    {
        Debug.Log("Abriendo Opciones");
    }

    public void Challenge()
    {
        Debug.Log("Abriendo Challenge");
    }

}
