
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    // reference to enemy rigidbody
    public Rigidbody2D enemyRigidbody;

    // enemy movement speed
    public float enemyMovementSpeed;

    // player sensor
    public float rangeToChasePlayer;

    // direction enemy is movement
    private Vector3 enemyMovementDirection;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // move enemy toward player
    void Update()
    {
        GetPlayerPosition();

        MoveEnemy();
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
