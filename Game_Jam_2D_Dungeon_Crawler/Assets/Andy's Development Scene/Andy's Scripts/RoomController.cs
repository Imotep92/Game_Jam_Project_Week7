
using UnityEngine;



public class RoomController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collidingObject)
    {
        // if the player enters a new room
        if (collidingObject.CompareTag("Player"))
        {
            // move the camera to the new room
            CameraController.cameraControllerScript.EnterNewRoom(transform);
        }
    }


} // end of class
