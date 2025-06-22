
using UnityEngine;


public class PlayerBullet : MonoBehaviour
{
    // reference to player bullet rigidbody
    public Rigidbody2D playerBulletRigidbody;

    // speed of player bullet
    public float playerBulletSpeed = 7.5f;

    // player bullet damage
    public int playerBulletDamage = 50;





    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }


    private void MoveBullet()
    {
        // move the bullet to the right relative to the transform of the bullet object
        playerBulletRigidbody.linearVelocity = transform.up * playerBulletSpeed;
    }


    // when the bullet collides with another object
    private void OnTriggerEnter2D(Collider2D collidingObject)
    {
        // destroy the bullet
        Destroy(gameObject);

        // if the player bullet collides with an enemy
        if (collidingObject.CompareTag("Enemy"))
        {
            // get a reference to the enemy controller script
            // and call the damage enemy function with the player bullet damage value
            collidingObject.GetComponent<EnemyController>().DamageEnemy(playerBulletDamage);

            // play enemy hurt sound
            int enemyHurtSound = 1;

            AudioController.audioControllerScript.PlaySFX(enemyHurtSound);
        }
    }


    // if the bullet moves out of camera view
    private void OnBecameInvisible()
    {
        // destroy the bullet
        Destroy(gameObject);
    }


} // end of class
