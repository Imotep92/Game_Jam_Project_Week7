
using UnityEngine;


public class Key : MonoBehaviour
{
    // index of key
    public int keyIndex;



    private void OnTriggerEnter2D(Collider2D collidingObject)
    {
        // if the player collides with the key
        if (collidingObject.CompareTag("Player"))
        {
            // destroy the key
            Destroy(gameObject);

            // open the associated key
            GameController.gameControllerScript.OpenDoor(keyIndex);
        }
    }


} // end of class
