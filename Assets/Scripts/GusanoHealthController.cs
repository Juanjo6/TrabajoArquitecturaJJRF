using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GusanoHealthController : MonoBehaviour
{
    public static GusanoHealthController instance;

    private int zero = 0;

    public int gusanoCurrentHealth, gusanoMaxHealth;

    //Variable de invencibilidad.
    public float invincibleLength;
    public float invincibleCounter; //Contador del tiempo en activa de la invencibilidad

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gusanoCurrentHealth = gusanoMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleCounter > zero)
        {
            // Le resto 1 a ese contador
            invincibleCounter -= Time.deltaTime; //Si son 60 frames, va quitando de 1/60 en 1/60 aprox.
        }
    }
    public void DealWithDamage()
    {
        //Si el contador para poder volver a hacernos da�o no ha llegado a 0
        if (invincibleCounter <= zero)
        {
            if (gusanoCurrentHealth > zero) // Que no lo maten 5 veces antes de que toque el suelo
            {
                gusanoCurrentHealth--;
                //Llamamos al m�todo que cambia el estado de los corazones
                // UIController.instance.UpdateHealthDisplay();
                // UIController.instance.UpdateIndexDisplay();

                if (gusanoCurrentHealth <= zero)
                {
                    PlayerDie();
                }
                //Estamos a�n vivos pero sufriendo da�os
                else
                {
                    // PlayerController.instance.anim.SetTrigger("isHurt");
                    // PlayerController.instance.KnockBack();

                    invincibleCounter = invincibleLength;

                }
            }
        }
    }
    public void PlayerDie()
    {
        // AudioManager.instance.PlaySFXPlayer(5);
        //AudioManager.instance.StopSFXBackground(4);
        //AudioManager.instance.StopSFXBackground(5);
        //AudioManager.instance.StopSFXBackground(6);
        //PlayerController.instance.slideCounter = zero; // Reseteamos deslizamiento y vaciamos la barra de power up
        gusanoCurrentHealth = zero; //Por si acaso no crashee

        // gameObject.SetActive(false); //Script exclusivo del personaje, por lo que gameObject = personaje
        UnityEngine.SceneManagement.SceneManager.LoadScene("ezio");
        // Efecto de muerte
        //          Instantiate(PlayerController.instance.deathEffect, transform.position, transform.rotation);

    }
    public void HealGusano()
    {
        // Sumamos uno a la vida actual del jugador
        gusanoCurrentHealth++;
        // Si al curarnos la vida sobrepasase la vida m�xima (mejor ponerlo as� para evitar casos extra�os, como dos colldiers que
        // curan que los cogemos justo a la vez
        if (gusanoCurrentHealth > gusanoMaxHealth)
        {
            gusanoCurrentHealth = gusanoMaxHealth;
        }
        //      UIController.instance.UpdateHealthDisplay();
    }

    public void GoBackToMenu()
    {
        Time.timeScale = 1f; // Si no el juego seguir�a pausado en el men�
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuInicial");
    }
}
