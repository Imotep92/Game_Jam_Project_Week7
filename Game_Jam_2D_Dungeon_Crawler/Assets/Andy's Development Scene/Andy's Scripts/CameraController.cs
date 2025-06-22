
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

        // close the door from the previous room 
        CloseDoor(GameController.gameControllerScript.room - 1);

        // increment room number
        GameController.gameControllerScript.room++;

        // play enter room sound
        int enterRoomSound = 18;

        AudioController.audioControllerScript.PlaySFX(enterRoomSound);
    }


    public void SpawnEnemy()
    {
        // if we are playing the game
        if (!GameController.gameControllerScript.gameOver)
        {
            // get room number entered
            int roomEntered = GameController.gameControllerScript.room;

            // number of enemies to spawn
            int enemiesToSpawn;

            // if we are in the starting room (room 0)
            // or we have entered the boss room (room 6)
            if (roomEntered - 1 == 0 || roomEntered == GameController.BOSS_ROOM)
            {
                // we should only spawn one enemy
                enemiesToSpawn = 1;
            }

            // otherwise
            else
            {
                // set enemies to spawn based on room number
                enemiesToSpawn = roomEntered;
            }

            // spawn enemy
            SpawnController.spawnControllerScript.SpawnRandomEnemyWave(enemiesToSpawn);
        }
    }


    private void CloseDoor(int doorToClose)
    {
        // if the door to close does not exist
        if (doorToClose < 0)
        {
            // simply return
            return;
        }

        // otherwise
        else
        {
            // close the door to the previous room
            GameController.gameControllerScript.CloseDoor(doorToClose);
        }
    }


} // end of class
