using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GusanoHealthController : HealthControllerParent
{
    public static GusanoHealthController instance;    

    private void Awake()
    {
        instance = this;
    }
    public GusanoHealthController(int _currentHealth, float _invincibleLength)
       : base(_currentHealth, _invincibleLength)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
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
        //Si el contador para poder volver a hacernos daño no ha llegado a 0
        if (invincibleCounter <= zero)
        {
            if (currentHealth > zero) // Que no lo maten 5 veces antes de que toque el suelo
            {
                currentHealth--;
                //Llamamos al método que cambia el estado de los corazones
                // UIController.instance.UpdateHealthDisplay();
                // UIController.instance.UpdateIndexDisplay();

                if (currentHealth <= zero)
                {
                    PlayerDie();
                }
                //Estamos aún vivos pero sufriendo daños
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
        currentHealth = zero; //Por si acaso no crashee

        // gameObject.SetActive(false); //Script exclusivo del personaje, por lo que gameObject = personaje
        UnityEngine.SceneManagement.SceneManager.LoadScene("ezio");
        // Efecto de muerte
        //          Instantiate(PlayerController.instance.deathEffect, transform.position, transform.rotation);


        // pausar el juego y activar menú de muerte
    }
    public void HealGusano()
    {
        // Sumamos uno a la vida actual del jugador
        currentHealth++;
        // Si al curarnos la vida sobrepasase la vida máxima (mejor ponerlo así para evitar casos extraños, como dos colldiers que
        // curan que los cogemos justo a la vez
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        //      UIController.instance.UpdateHealthDisplay();
    }

}
