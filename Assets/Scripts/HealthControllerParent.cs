using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControllerParent : MonoBehaviour
{
    protected int zero = 0;

    public int currentHealth, maxHealth;

    //Variable de invencibilidad.
    public float invincibleLength;
    public float invincibleCounter; //Contador del tiempo en activa de la invencibilidad

    public HealthControllerParent(int _currentHealth, float _invincibleLength)
    {
        currentHealth = _currentHealth;
        invincibleLength = _invincibleLength;
    }

    public void GoBackToMenu()
    {
        Time.timeScale = 1f; // Si no el juego seguiría pausado en el menú
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuInicial");
    }
}
