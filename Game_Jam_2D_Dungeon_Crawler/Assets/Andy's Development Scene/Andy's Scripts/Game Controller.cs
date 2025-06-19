
using UnityEngine;


public class GameController : MonoBehaviour
{
    // reference to background panel
    public GameObject backgroundPanel;

    // reference to title screen screen
    public GameObject titleScreen;

    // reference to options screen
    public GameObject optionsScreen;

    // reference to the pawz screen
    public GameObject pawzScreen;

    // reference to the game over screen
    public GameObject gameOverScreen;

    // reference to the player ui panel
    public GameObject playerUiPanel;



    // get a reference to the audio source component
    [HideInInspector] public AudioSource audioPlayer;

    // are we playing the game
    public bool gamePawzed;

    // is the game in play
    public bool inPlay;





    private void Start()
    {
        // set reference to the audio source component
        ///audioPlayer = GetComponent<AudioSource>();


        // load the main menu
        ///LoadMainMenu();
    }



    private void Update()
    {
        // if the game is in play
        if (inPlay)
        {
            // and the game is not already pawzed
            if (!gamePawzed)
            {
                // and the player has pressed the escape key
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    PawzGame();
                }
            }
        }
    }


    private void PawzGame()
    {
        // pawz the game
        gamePawzed = true;

        // show the background
        backgroundPanel.SetActive(true);

        // load the pawz screen
        pawzScreen.SetActive(true);

        // and freeze game play
        Time.timeScale = 0f;
    }


    public void ResumeGame()
    {
        // un-pawz the game
        gamePawzed = false;

        // close the pawz screen
        pawzScreen.SetActive(false);

        // show the background
        backgroundPanel.SetActive(false);

        // and un-freeze game play
        Time.timeScale = 1f;
    }


    private void LoadMainMenu()
    {
        // activate the background
        backgroundPanel.SetActive(true);

        // load the title screen
        titleScreen.SetActive(true);
    }


    // if the play button is pressed
    public void PlayButton()
    {
        // stop the main menu music
        audioPlayer.Stop();

        // hide the background panel
        backgroundPanel.SetActive(false);

        // close the main menu
        titleScreen.SetActive(false);

        // display the player ui panel
        playerUiPanel.SetActive(true);

        // set the game in play flag
        inPlay = true;
    }


    // if the options button is pressed
    public void OptionsButton()
    {
        // if the game is pawzed
        if (gamePawzed)
        {
            // then close the pawz screen
            pawzScreen.SetActive(false);
        }

        // otherwise
        else
        {
            // close the main menu
            titleScreen.SetActive(false);
        }

        // open the options screen
        optionsScreen.SetActive(true);
    }


    // if we are closing the options screen 
    public void CloseOptions()
    {
        // and the game is pawzed
        if (gamePawzed)
        {
            // close the options screen
            optionsScreen.SetActive(false);

            // load the pawz screen
            pawzScreen.SetActive(true);
        }

        // otherwise
        else
        {
            // close the options screen
            optionsScreen.SetActive(false);

            // and open the main menu screen
            titleScreen.SetActive(true);
        }
    }


    // if the quit button is pressed
    public void QuitGame()
    {
        // quit the game
        Application.Quit();
    }


} // end of class
