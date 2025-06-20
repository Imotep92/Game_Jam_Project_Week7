
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
    public float playerMoveSpeed;

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




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        //transform.position += new Vector3(movementInput.x * Time.deltaTime * playerMoveSpeed, movementInput.y * Time.deltaTime * playerMoveSpeed, transform.position.z);

        playerRigidbody.linearVelocity = playerMovementInput * playerMoveSpeed;
    }


} // end of class
