
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    // make player controller script accessible from other scripts
    public static PlayerController playerControllerScript;

    // reference to rigidbody component
    public Rigidbody2D playerRigidbody;

    // player's movement speed
    public float playerMoveSpeed;

    // player's input controls
    private Vector2 playerMovementInput;



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
        // horizontal movement
        playerMovementInput.x = Input.GetAxisRaw("Horizontal");

        // vertical movement
        playerMovementInput.y = Input.GetAxisRaw("Vertical");

        // normalise the player's input
        playerMovementInput.Normalize();
    }


    private void MovePlayer()
    {
        //transform.position += new Vector3(movementInput.x * Time.deltaTime * playerMoveSpeed, movementInput.y * Time.deltaTime * playerMoveSpeed, transform.position.z);

        playerRigidbody.linearVelocity = playerMovementInput * playerMoveSpeed;
    }


} // end of class
