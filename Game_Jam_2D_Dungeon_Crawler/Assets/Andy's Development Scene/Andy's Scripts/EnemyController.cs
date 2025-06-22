
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    // reference to enemy rigidbody
    public Rigidbody2D enemyRigidbody;

    // for checking if game object is visible on-screen
    public SpriteRenderer enemyObject;

    // reference to enemy animator
    public Animator enemyAnimator;

    // enemy movement speed
    public float enemyMovementSpeed;

    // is player in range to chase sensor
    public float rangeToChasePlayer;

    // is player in range to shoot sensor
    public float shootRange;

    // direction enemy is movement
    private Vector3 enemyMovementDirection;

    // enemy health
    public int enemyHealth = 0;

    // enemy points
    public int enemyPoints;

    // player damage
    public int playerDamage;

    // should enemy shoot at player
    public bool enemyShouldShoot;

    // what the enemy will fire
    public GameObject enemyBullet;

    // item for enemy to drop
    public GameObject keyPrefab;

    public GameObject pizzaSlicePrefab;

    // where the bullet will fire from
    public Transform firePosition;

    // how quickly the enemy can fire
    public float fireRate;

    private float fireCounter;

    // if enemy can drop key
    public bool canDropPickup;





    // move enemy toward player
    void Update()
    {
        // if we playing the game
        if (!GameController.gameControllerScript.gameOver)
        {
            // check to see if enemy is visible on-screen
            if (enemyObject.isVisible)
            {
                GetPlayerPosition();

                MoveEnemy();

                ShootAtPlayer();
            }
        }
    }


    private void ShootAtPlayer()
    {
        // if the player is in the enemies shooting range
        // and the enemy should shoot shoot at the player
        if (enemyShouldShoot && Vector3.Distance(transform.position, PlayerController.playerControllerScript.transform.position) < shootRange)
        {
            // coundown the fire counter
            fireCounter -= Time.deltaTime;

            // if the fire counter is less than or equal to zero
            if (fireCounter <= 0)
            {
                // set the fire counter to the fire rate
                fireCounter = fireRate;

                // and fire a bullet
                Instantiate(enemyBullet, firePosition.transform.position, firePosition.transform.rotation);
            }
        }
    }


    public void DamageEnemy(int damage)
    {
        // subtract damage from enemy health
        enemyHealth -= damage;

        // increase and display player score
        GameController.gameControllerScript.score += playerDamage;

        GameController.gameControllerScript.DisplayPlayerScore();

        // if the enemy has no health left
        if (enemyHealth <= 0)
        {
            // if we are in the boss room
            if (GameController.gameControllerScript.room == GameController.BOSS_ROOM)
            {
                // open the gate
                GameController.gameControllerScript.escapeToVictory[GameController.THE_EXIT].SetActive(false);

                // show the television
                GameController.gameControllerScript.escapeToVictory[GameController.THE_TELEVISION].SetActive(true);
            }

            // otherwise
            else
            {
                // subtract one from enemy count
                SpawnController.spawnControllerScript.enemyCount--;

                // if enemy can drop key
                if (canDropPickup)
                {
                    // if all the enemies in the room have been killed
                    if (SpawnController.spawnControllerScript.enemyCount == 0)
                    {
                        // drop the key
                        Instantiate(keyPrefab, transform.position, transform.rotation);
                    }

                    // otherwise
                    else
                    {
                        // choose a random number between 1 and 5
                        int randomDrop = Random.Range(0, 5);

                        // if it's the player's lucky day
                        if (randomDrop == 3)
                        {
                            // drop a pizza slice
                            Instantiate(pizzaSlicePrefab, transform.position, transform.rotation);
                        }
                    }
                }
            }


            // destroy the enemy
            Destroy(gameObject);

            // play enemy death sound
            int enemyDeathSound = 0;

            AudioController.audioControllerScript.PlaySFX(enemyDeathSound);
        }
    }


    private void GetPlayerPosition()
    {
        // if player is within the enemy sensor range
        if (Vector3.Distance(transform.position, PlayerController.playerControllerScript.transform.position) < rangeToChasePlayer)
        {
            // get the direction to move the enemy
            enemyMovementDirection = PlayerController.playerControllerScript.transform.position - transform.position;
        }

        // otherwise
        else
        {
            // stop enemy movement
            enemyMovementDirection = Vector3.zero;
        }


        // normalise the movement direction;
        enemyMovementDirection.Normalize();
    }


    private void MoveEnemy()
    {
        enemyRigidbody.linearVelocity = enemyMovementDirection * enemyMovementSpeed;
    }


} // end of class
