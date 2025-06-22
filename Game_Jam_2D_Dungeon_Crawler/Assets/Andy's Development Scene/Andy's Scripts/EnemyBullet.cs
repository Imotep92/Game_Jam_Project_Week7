
using UnityEngine;


public class EnemyBullet : MonoBehaviour
{
    // speed of enemy bullet
    public float bulletSpeed;

    // bullet damage
    public int enemyBulletDamage;

    // direction to player
    private Vector3 directionToPlayer;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // get direction to player
        directionToPlayer = PlayerController.playerControllerScript.transform.position - transform.position;

        // normalise bullet direction
        directionToPlayer.Normalize();
    }


    void Update()
    {
        // move enemy bullet
        transform.position += directionToPlayer * bulletSpeed * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collidingObject)
    {
        // destroy enemy bullet
        Destroy(gameObject);

        // if the enemy bullet collides with the player
        if (collidingObject.CompareTag("Player"))
        {
            // damage player
            PlayerController.playerControllerScript.DamagePlayer(enemyBulletDamage);

            // play player hurt sound
            int playerHurtSound = 10;

            AudioController.audioControllerScript.PlaySFX(playerHurtSound);

        }
    }


    // if the enemy bullet goes out of camera view
    private void OnBecameInvisible()
    {
        // destroy the bullet
        Destroy(gameObject);
    }


} // end of class
