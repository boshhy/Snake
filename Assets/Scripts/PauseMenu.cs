using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// Used to control the pause menu
public class PauseMenu : MonoBehaviour
{
    // Get a reference to the pause menu object    
    public GameObject pauseMenu;
    public PlayerControls playerUIControls;

    // Public Static bool so other scripts can reference and make sure game is not paused
    public static bool isPaused = false;
    public Button primaryButton;



    void Awake()
    {
        playerUIControls = new PlayerControls();
    }
    
    void OnEnable()
    { 
        playerUIControls.PauseUI.Enable();
        playerUIControls.PauseUI.Pause.performed += PressStart;
    }

    void OnDisable()
    {
        playerUIControls.PauseUI.Disable();
        playerUIControls.PauseUI.Pause.performed -= PressStart; 
    }
    // Start is called before the first frame update
    void Start()
    {
        // Pause menu shoul not be active when loading a scene
        pauseMenu.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        // // Check to see if player has pressed the 'escape' key
        // if (Input.GetKeyDown(KeyCode.Escape))
        // {
        //     // If game is paused, then resume the game
        //     if (isPaused)
        //     {
        //         ResumeGame();
        //     }
        //     // Else game is playing so pause the game
        //     else
        //     {
        //         PauseGame();
        //     }
        // }
    }
    
    public void PressStart(InputAction.CallbackContext cntx)
    {
        // If game is paused, then resume the game
        if (isPaused)
        {
            ResumeGame();
        }
        // Else game is playing so pause the game
        else
        {
            PauseGame();
        }
    }

    // Used to pause the game
    public void PauseGame()
    {
        // Play pause SFX
        AudioManager.instance.PlaySFX(1);

        // Activate the pause menu
        pauseMenu.SetActive(true);
        primaryButton.Select();

        // Set timescale to zero so nothing gets updated
        Time.timeScale = 0f;

        // Game is now paused
        isPaused = true;
    }

    // Used to resume the game
    public void ResumeGame()
    {
        // Play resume SFX
        AudioManager.instance.PlaySFX(1);

        // Deactivate the pause menu
        pauseMenu.SetActive(false);

        // Set timescale back to 1 so we update normally
        Time.timeScale = 1f;

        // Game is now unpaused 
        isPaused = false;
    }


    // Used to quit the game
    public void Quit()
    {
        Application.Quit();
    }
}
