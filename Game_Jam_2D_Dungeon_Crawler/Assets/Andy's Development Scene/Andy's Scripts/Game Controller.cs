
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading;
using System.Collections;
using Unity.VisualScripting;


public class GameController : MonoBehaviour
{
    // make game controller script accessible from other scripts
    public static GameController gameControllerScript;

    // array for doors
    public GameObject[] doors;

    // array for lives
    public GameObject[] playerLives;

    // array for health
    public GameObject[] playerPizzaHealth;

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
    public TMP_Text scoreText;

    // game time text
    public TMP_Text gameTimeText;

    // reference to displayed 'Lives Text' in the player ui panel
    ///public TextMeshProUGUI LivesText;

    // reference to 'Score integers' assigned to each enemy
    public int score;

    // reference to 'Lives integer' in the player ui panel
    public int lives;

    // player health
    public int playerHealth;

    // game time left
    // 6 minutes or 360 seconds
    [HideInInspector] public float gameTime;



    // current room the player is in
    public int room;

    public const int BOSS_ROOM = 6;

    // boss sprite
    public const int BOSS_SPRITE = 3;





    // get a reference to the audio source component
    [HideInInspector] public AudioSource audioPlayer;

    // are we playing the game
    public bool gamePawzed;

    // is the game in play
    public bool inPlay;

    // is the game over
    public bool gameOver;

    // if we are starting the level
    public bool levelStart;

    // if we are entering a room
    public bool hasEnterdRoom;

    public float coolDownTimer = 3f;

    public float enteredRoomTimer;




    private void Awake()
    {
        gameControllerScript = this;
    }


    private void Start()
    {
        // set reference to the audio source component
        audioPlayer = GetComponent<AudioSource>();


        InitialiseLevelStart();

        // load the title screen
        TitleScreen();
    }


    private void InitialiseLevelStart()
    {
        // set starting room
        room = 0;

      
        gameOver = true;

        inPlay = false;

        // we are starting the level
        levelStart = true;
    }



    private void Update()
    {
        // if player has entered a room
        if (!gameOver && hasEnterdRoom)
        {
            PlayerEnteredRoom();
        }


        if (!gameOver && !gamePawzed)
        {
            DisplayGameTime();
        }


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


    private void PlayerEnteredRoom()
    {
        enteredRoomTimer -= Time.deltaTime;

        if (enteredRoomTimer <= 0)
        {
            enteredRoomTimer = 0;

            hasEnterdRoom = false;

            CameraController.cameraControllerScript.SpawnEnemy();
        }
    }


    public void OpenDoor(int doorToOpen)
    {
        // open door to next room
        doors[doorToOpen].SetActive(false);
    }


    public void CloseDoor(int doorToClose)
    {
        // close the door from the previous room
        doors[doorToClose].SetActive(true);

        // player has entered room
        enteredRoomTimer = coolDownTimer;

        hasEnterdRoom = true;
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
        // close the game over screen
        gameOverScreen.SetActive(false);

        // and un-freeze game play
        Time.timeScale = 1f;

        // restart the game
        SceneManager.LoadScene(0);
    }


    private void TitleScreen()
    {
        // start playing menu music
        ///audioPlayer.Play();

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

        // close the game over screen
        gameOverScreen.SetActive(false);

        // display the player ui panel
        playerUiPanel.SetActive(true);

        Initialise();
    }


    private void Initialise()
    {
        // player core
        score = 0;

        // player lives
        lives = 3;

        // player health
        playerHealth = 100;

        // game time left
        // 6 minutes or 360 seconds
        gameTime = 360f;

        // set the game in play flag
        inPlay = true;

        gameOver = false;

        levelStart = false;

        enteredRoomTimer = coolDownTimer;

        hasEnterdRoom = true;
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
            // close the title screen
            titleScreen.SetActive(false);
        }

        // if the game is over, close the game over screen
        gameOverScreen.SetActive(false);

        // open the options screen
        optionsScreen.SetActive(true);
    }


    // if we are closing the options screen 
    public void CloseOptions()
    {
        // if we are starting the level
        if (levelStart)
        {
            // close the options screen
            optionsScreen.SetActive(false);

            // and open the title screen
            titleScreen.SetActive(true);
        }


        // if the game is pawzed
        if (gamePawzed)
        {
            // close the options screen
            optionsScreen.SetActive(false);

            // load the pawz screen
            pawzScreen.SetActive(true);
        }


        // if the game is over and we are not starting the level
        if (gameOver && !levelStart)
        {
            // close the options screen
            optionsScreen.SetActive(false);

            // and open the game over screen
            gameOverScreen.SetActive(true);
        }
    }


    public void GameOver()
    {
        // game over
        gameOver = true;

        // start playing menu music
        audioPlayer.Play();

        // activate the background
        backgroundPanel.SetActive(true);

        // open the game over screen
        gameOverScreen.SetActive(true);

        // and freeze game play
        Time.timeScale = 0f;
    }


    public void DisplayPlayerScore()
    {
        scoreText.text = score.ToString("000000");
    }


    public void DisplayGameTime()
    {
        gameTime -= Time.deltaTime;

        gameTimeText.text = gameTime.ToString("00:00");

        if (gameTime < 0)
        {
            gameTime = 0f;

            GameOver();
        }
    }


    // if the quit button is pressed
    public void QuitGame()
    {
        // quit the game
        Application.Quit();
    }


} // end of class
