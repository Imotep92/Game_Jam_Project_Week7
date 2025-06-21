
using UnityEngine;


public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collidingObject)
    {
        // if the player collides with the key
        if (collidingObject.CompareTag("Player"))
        {
            // destroy the key
            Destroy(gameObject);

            // open the associated key
            GameController.gameControllerScript.OpenDoor(GameController.gameControllerScript.room - 1);
        }
    }


} // end of class
