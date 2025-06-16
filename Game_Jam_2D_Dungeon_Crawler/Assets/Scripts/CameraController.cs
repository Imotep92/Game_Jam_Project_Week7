
using UnityEngine;


public class CameraController : MonoBehaviour
{
    // get a reference to the camera controller script
    public static CameraController cameraControllerScript;



    // speed at which the camera moves between rooms
    public float cameraMovementSpeed;

    // the room where the camera will move to
    public Transform targetRoom;



    private void Awake()
    {
        // set the reference to the camera controller script
        cameraControllerScript = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }


    // move camera to new room when player enters it
    private void MoveCamera()
    {
        // if we have moved into a new room
        if (targetRoom != null)
        {
            // then move camera to new room
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetRoom.position.x, targetRoom.position.y, transform.position.z), cameraMovementSpeed * Time.deltaTime);
        }
    }


    public void EnterNewRoom(Transform newRoomTarget)
    {
        // get the transform position of the new room entered by the player
        targetRoom = newRoomTarget;
    }


} // end of class
