using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;

    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    private void Awake()
    {
        instance = this;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        AudioManager.instance.PlayMusic(2);
        //Acciones.instancia.activarPausa();
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Activamos el canvas del libro
        AudioManager.instance.PlayMusic(1);
        //Acciones.instancia.activarPausa();
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1f; // Si no el juego seguiría pausado en el menú
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    public void RestartGame()
    {
        pauseMenuUI.SetActive(false); // Quitamos el lienzo (canvas)
        Time.timeScale = 1f;
        GameIsPaused = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Ezio");
    }
}
