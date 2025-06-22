
using UnityEngine;


public class SpawnController : MonoBehaviour
{
    // get a reference to the spawn controller script
    public static SpawnController spawnControllerScript;


    // reference for enemy prefab
    public GameObject[] enemyPrefabs;

    // stores a random vector3 position to spawn enemy
    private Vector3 randomEnemyPosition;

    // keeps track of the number of enemies in play
    // made public so it can be accessed for the enemy controller script
    public int enemyCount;




    void Start()
    {
        spawnControllerScript = this;


        InitialiseEnemySpawner();
    }


    public void InitialiseEnemySpawner()
    {
        enemyCount = 0;
    }


    // generates random spawn positions for the enemy
    public Vector3 GenerateRandomSpawnPosition()
    {
        float playerX = PlayerController.playerControllerScript.transform.position.x;

        float playerY = PlayerController.playerControllerScript.transform.position.y;

        float spawnPosX = 0f;

        float spawnPosY = 0f;


        // spawn boundaries
        // room 0
        if (playerX > 48f && playerX < 59f)
        {
            spawnPosX = 49f;
        }

        // room 1
        if (playerX > 36f && playerX < 47f)
        {
            spawnPosX = 37f;
        }

        // room 2
        if (playerX > 24f && playerX < 35f)
        {
            spawnPosX = 25f;
        }


        // rooms 3 - 6
        if (playerY > 6f && playerY < 14f)
        {
            spawnPosY = Random.Range(7f, 13f);
        }

        else if (playerY > -3.5f && playerY < 3.5f)
        {
            spawnPosY = -3f;
        }



        // create the new position
        randomEnemyPosition = new Vector3(spawnPosX, spawnPosY, 0f);

        // and return it
        return randomEnemyPosition;
    }


    public void SpawnRandomEnemyWave(int enemiesToSpawn)
    {
        // loop through number of enemies to spawn
        for (int numberOfEnemies = 0; numberOfEnemies < enemiesToSpawn; numberOfEnemies++)
        {
            // enemy to select
            int randomEnemy;

            // if we are in the boss room
            if (GameController.gameControllerScript.room == GameController.BOSS_ROOM)
            {
                //randomEnemy = GameController.BOSS_SPRITE;
                GameController.gameControllerScript.escapeToVictory[GameController.THE_BOSS].SetActive(true);

                // play boss musid
                AudioController.audioControllerScript.PlayBossMusic();
            }

            // otherwise
            else
            {
                // select a random enemy minus the boss sprite
                randomEnemy = Random.Range(0, enemyPrefabs.Length - 1);

                // instantiate the enemy at random spawn location
                Instantiate(enemyPrefabs[randomEnemy], GenerateRandomSpawnPosition(), enemyPrefabs[randomEnemy].transform.rotation);
            }
        }

        // keep track of the number of enemies in play
        enemyCount = enemiesToSpawn;
    }


} // end of class
