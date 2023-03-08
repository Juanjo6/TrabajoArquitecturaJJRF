using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{   
    // public GameObject mainMenu, settingsMenu, creditsMenu, exitGameMenu;

    // public GameObject blackPanel;

    //bool inCredits, inExitMenu;

    private void Update()
    {

    }

    //TO ENTER PLAY MENU
    public void PlayGame()
    {
        Invoke("fadeToBlack", 0);
    }

    //TO ENTER SETTINGS MENU
    public void toSettings()
    {
      //  mainMenu.SetActive(false);
       // settingsMenu.SetActive(true);
       // EventSystem.current.SetSelectedGameObject(null);
        //EventSystem.current.SetSelectedGameObject(settingsButton);
        //Settings.instance.inSettings = true;

    }

    //TO ENTER CREDITS MENU
    public void toCredits()
    {
        //mainMenu.SetActive(false);
        //creditsMenu.SetActive(true);
        //EventSystem.current.SetSelectedGameObject(null);
        //EventSystem.current.SetSelectedGameObject(creditsButton);
    }

    //TO GO BACK TO MAIN MENU
    public void toMainMenu()
    {
        // settingsMenu.SetActive(false);
        // creditsMenu.SetActive(false);
        // exitGameMenu.SetActive(false);
        // mainMenu.SetActive(true);
        // EventSystem.current.SetSelectedGameObject(null);
        // EventSystem.current.SetSelectedGameObject(mainMenuButton);
    }

    //TO EXIT THE GAME
    public void exitGame() //OPEN MENU
    {
        // exitGameMenu.SetActive(true);
        // mainMenu.SetActive(false);
        // EventSystem.current.SetSelectedGameObject(null);
        // EventSystem.current.SetSelectedGameObject(exitGameButton);
        // inExitMenu = true;
    }

    public void ExitGame() //QUIT APP
    {
        Application.Quit(); // Vale también para móvil
    }

    public void GoToScene1()
    {
        // blackPanel.GetComponent<Animator>().Play(0);
        // yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
    public void GoToMainScene()
    {
        SceneManager.LoadScene(0); //preludio
    }
}
