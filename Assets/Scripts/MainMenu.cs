using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public Button primaryButton;
    public GameObject theMainMenu;
    public GameObject theCoopMenu;
    public GameObject theVersusMenu;
    public Button coopButton;
    public Button versusButton;
    public Button firstCoopButton;
    public Button firstVersusButton;

    void Start() 
    {
        theCoopMenu.SetActive(false);
        theVersusMenu.SetActive(false);
        primaryButton.Select();
    }



    public void CoopSelected()
    {
        EventSystem.current.SetSelectedGameObject(null);
        theMainMenu.SetActive(false);
        theCoopMenu.SetActive(true);

        firstCoopButton.Select();
    }



    public void BackToMainMenuFromCoop()
    {
        EventSystem.current.SetSelectedGameObject(null);
        theCoopMenu.SetActive(false);
        theMainMenu.SetActive(true);
        
        coopButton.Select();
    }
    
    public void VersusSelected()
    {
        EventSystem.current.SetSelectedGameObject(null);
        theMainMenu.SetActive(false);
        theVersusMenu.SetActive(true);

        firstVersusButton.Select();
    }    
    
    public void BackToMainMenuFromVersus()
    {
        EventSystem.current.SetSelectedGameObject(null);
        theVersusMenu.SetActive(false);
        theMainMenu.SetActive(true);
        
        versusButton.Select();
    }



    public void PlayGame()
    {
        SceneManager.LoadScene("Snake One Player");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void TwoPlayerEasy()
    {
        SceneManager.LoadScene("Snake Two Player Easy");
    }

    public void TwoPlayerMedium()
    {
        SceneManager.LoadScene("Snake Two Player Medium");
    }

    public void TwoPlayerHard()
    {
        SceneManager.LoadScene("Snake Two Player Hard");
    }
    public void VersusEasy()
    {
        SceneManager.LoadScene("Snake Versus Easy");
    }

    public void VersusMedium()
    {
        SceneManager.LoadScene("Snake Versus Medium");
    }
    public void VersusHard()
    {
        SceneManager.LoadScene("Snake Versus Hard");
    }

}
