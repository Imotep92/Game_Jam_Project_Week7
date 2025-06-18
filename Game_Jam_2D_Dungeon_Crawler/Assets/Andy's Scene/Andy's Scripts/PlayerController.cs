
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    // reference to rigidbody component
    public Rigidbody2D playerRigidbody;

    // player's movement speed
    public float playerMoveSpeed;

    // player's input controls
    private Vector2 movementInput;




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
        movementInput.x = Input.GetAxisRaw("Horizontal");

        // vertical movement
        movementInput.y = Input.GetAxisRaw("Vertical");
    }


    private void MovePlayer()
    {
        //transform.position += new Vector3(movementInput.x * Time.deltaTime * playerMoveSpeed, movementInput.y * Time.deltaTime * playerMoveSpeed, transform.position.z);

        playerRigidbody.linearVelocity = movementInput * playerMoveSpeed;
    }


} // end of class
