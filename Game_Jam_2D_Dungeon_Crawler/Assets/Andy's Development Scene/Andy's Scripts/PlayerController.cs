
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class PlayerController : MonoBehaviour
{
    // make player controller script accessible from other scripts
    public static PlayerController playerControllerScript;

    // reference to rigidbody component
    public Rigidbody2D playerRigidbody;

    // reference to player animator
    public Animator playerAnimator;

    // player's movement speed
    public float playerMoveSpeed = 5;

    // player's movement controls
    private Vector2 playerMovementInput;

    // reference to player bullet
    public GameObject playerBullet;

    // position to fire bullet from
    public Transform firePosition;

    // if player has remote control
    public bool playerHasRemote;




    private void Awake()
    {
        // set reference to player controller script
        playerControllerScript = this;
    }





    void Update()
    {
        // get player input
        GetPlayerInput();

        // move player
        MovePlayer();
    }


    private void GetPlayerInput()
    {
        // player movement
        // horizontal movement
        // if player presses the left arrow key
        // store the value in player movement x
        playerMovementInput.x = Input.GetAxisRaw("Horizontal");

        // vertical movement
        // if player presses the left arrow key
        // store the value in player movement y
        playerMovementInput.y = Input.GetAxisRaw("Vertical");

        // normalise the player's input
        playerMovementInput.Normalize();

        SetPlayerSpriteDirection();

        // player firing
        // if the player is holding the remote control
        if (playerHasRemote)
        {
            // if the player presses the space bar
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // fire a bullet
                Instantiate(playerBullet, firePosition.position, firePosition.rotation);
            }
        }
    }


    private void SetPlayerSpriteDirection()
    {
        // if player is moving left
        if (playerMovementInput.x < 0)
        {
            // flip sprite to face left
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        // if player is moving right
        if (playerMovementInput.x > 0)
        {
            // flip player to face right
            transform.localScale = Vector3.one;
        }
    }


    private void MovePlayer()
    {
        playerRigidbody.linearVelocity = playerMovementInput * playerMoveSpeed;
    }


    public void DamagePlayer(int enemyDamage)
    {
        // subtract health from player
        GameController.gameControllerScript.playerHealth -= enemyDamage;

        // display player's pizza health based on player health
        if (GameController.gameControllerScript.playerHealth < 100 && GameController.gameControllerScript.playerHealth > 60 )
        {
            GameController.gameControllerScript.playerPizzaHealth[0].SetActive(false);

            GameController.gameControllerScript.playerPizzaHealth[1].SetActive(true);
        }

        if (GameController.gameControllerScript.playerHealth < 60 && GameController.gameControllerScript.playerHealth > 30)
        {
            GameController.gameControllerScript.playerPizzaHealth[1].SetActive(false);

            GameController.gameControllerScript.playerPizzaHealth[2].SetActive(true);
        }
        
        if (GameController.gameControllerScript.playerHealth < 30 && GameController.gameControllerScript.playerHealth > 0)
        {
            GameController.gameControllerScript.playerPizzaHealth[2].SetActive(false);

            GameController.gameControllerScript.playerPizzaHealth[3].SetActive(true);
        }

        // if the player's health is less than or equal to zero
        if (GameController.gameControllerScript.playerHealth <= 0)
        {
            GameController.gameControllerScript.lives--;

            if (GameController.gameControllerScript.lives >= 0)
            {
                GameController.gameControllerScript.playerLives[GameController.gameControllerScript.lives].SetActive(false);

                GameController.gameControllerScript.playerHealth = 100;

                GameController.gameControllerScript.playerPizzaHealth[3].SetActive(false);

                GameController.gameControllerScript.playerPizzaHealth[0].SetActive(true);
            }
        }


        if (GameController.gameControllerScript.lives < 0)
        { 
            // deactivate the player
            gameObject.SetActive(false);

            // show game over screen
            //GameController.gameControllerScript.GameOver();
        }
    }



    private void OnTriggerEnter2D(Collider2D collidingObject)
    {
        // if player collides with the remote
        if (collidingObject.CompareTag("Remote Control"))
        {
            // set player has remote flag
            playerHasRemote = true;

            // and destroy the remote
            Destroy(collidingObject.gameObject);
        }
    }


} // end of class
