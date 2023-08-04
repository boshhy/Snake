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
        AudioManager.instance.StopBGM();
    }



    public void CoopSelected()
    {
        AudioManager.instance.PlaySFX(0);
        EventSystem.current.SetSelectedGameObject(null);
        theMainMenu.SetActive(false);
        theCoopMenu.SetActive(true);

        firstCoopButton.Select();
    }



    public void BackToMainMenuFromCoop()
    {
        AudioManager.instance.PlaySFX(0);
        EventSystem.current.SetSelectedGameObject(null);
        theCoopMenu.SetActive(false);
        theMainMenu.SetActive(true);
        
        coopButton.Select();
    }
    
    public void VersusSelected()
    {
        AudioManager.instance.PlaySFX(0);
        EventSystem.current.SetSelectedGameObject(null);
        theMainMenu.SetActive(false);
        theVersusMenu.SetActive(true);

        firstVersusButton.Select();
    }    
    
    public void BackToMainMenuFromVersus()
    {
        AudioManager.instance.PlaySFX(0);
        EventSystem.current.SetSelectedGameObject(null);
        theVersusMenu.SetActive(false);
        theMainMenu.SetActive(true);
        
        versusButton.Select();
    }



    public void PlayGame()
    {
        AudioManager.instance.PlaySFX(0);
        AudioManager.instance.NormalSpeed();
        AudioManager.instance.PlayBGM();
        SceneManager.LoadScene("Snake One Player");
    }

    public void Quit()
    {
        AudioManager.instance.PlaySFX(0);
        Application.Quit();
    }

    public void TwoPlayerEasy()
    {
        AudioManager.instance.PlaySFX(0);
        AudioManager.instance.NormalSpeed();
        AudioManager.instance.PlayBGM();
        SceneManager.LoadScene("Snake Two Player Easy");
    }

    public void TwoPlayerMedium()
    {
        AudioManager.instance.PlaySFX(0);
        AudioManager.instance.NormalSpeed();
        AudioManager.instance.PlayBGM();
        SceneManager.LoadScene("Snake Two Player Medium");
    }

    public void TwoPlayerHard()
    {
        AudioManager.instance.PlaySFX(0);
        AudioManager.instance.NormalSpeed();
        AudioManager.instance.PlayBGM();
        SceneManager.LoadScene("Snake Two Player Hard");
    }
    public void VersusEasy()
    {
        AudioManager.instance.PlaySFX(0);
        AudioManager.instance.NormalSpeed();
        AudioManager.instance.PlayBGM();
        SceneManager.LoadScene("Snake Versus Easy");
    }

    public void VersusMedium()
    {
        AudioManager.instance.PlaySFX(0);
        AudioManager.instance.NormalSpeed();
        AudioManager.instance.PlayBGM();
        SceneManager.LoadScene("Snake Versus Medium");
    }
    public void VersusHard()
    {
        AudioManager.instance.PlaySFX(0);
        AudioManager.instance.NormalSpeed();
        AudioManager.instance.PlayBGM();
        SceneManager.LoadScene("Snake Versus Hard");
    }

}
