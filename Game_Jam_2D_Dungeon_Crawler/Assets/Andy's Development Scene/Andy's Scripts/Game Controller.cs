
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


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

    // reference to displayed 'Score Text' in the player ui panel
    public TextMeshProUGUI scoreText;

    // reference to displayed 'Lives Text' in the player ui panel
    public TextMeshProUGUI LivesText;

    // reference to 'Score integers' assigned to each enemy
    public int score;

    // reference to 'Lives integer' in the player ui panel
    public int lives;

    



    // get a reference to the audio source component
    [HideInInspector] public AudioSource audioPlayer;

    // are we playing the game
    public bool gamePawzed;

    // is the game in play
    public bool inPlay;

    // is the game over
    public bool isGameOver;

    // is the game restarting
    





    private void Start()
    {
        // set reference to the audio source component
        audioPlayer = GetComponent<AudioSource>();


        // load the main menu
        LoadMainMenu();
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

        // activate the background
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

        // deactivate the background
        backgroundPanel.SetActive(false);

        // close the pawz screen
        pawzScreen.SetActive(false);

        // and un-freeze game play
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        // activate the game over screen
        gameOverScreen.SetActive(false);

        // restart current scene
        SceneManager.LoadScene(0);

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
        //audioPlayer.Stop();

        // hide the background panel
        backgroundPanel.SetActive(false);

        // close the main menu
        titleScreen.SetActive(false);

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

    public void GameOver()
    {
        // Game over
        isGameOver = true;

        // activate the background
        backgroundPanel.SetActive(true);

        // activate the game over screen
        gameOverScreen.SetActive(true);

        // and freeze game play
        Time.timeScale = 0f;
    }


    // if the quit button is pressed
    public void QuitGame()
    {
        // quit the game
        Application.Quit();
    }


} // end of class
