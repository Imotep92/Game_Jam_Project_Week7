
using Unity.VisualScripting;
using UnityEngine;


public class PlayerHealthController : MonoBehaviour
{
    // make player health controller script accessible from other scripts
    public static PlayerHealthController playerHealthControllerScript;


    // player health
    public int currentHealth;

    public int maximumHealth;






    private void Awake()
    {
        playerHealthControllerScript = this;
    }


    void Start()
    {
        // set player's current health
        currentHealth = maximumHealth;
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    public void DamagePlayer()
    {
        // subtract health from player
        currentHealth--;

        // if the player's health is less than or equal to zero
        if (currentHealth <= 0)
        {
            // deactivate the player
            PlayerController.playerControllerScript.gameObject.SetActive(false);
        }

        // show game over screen
        GameController.gameControllerScript.GameOver();
    }


} // end of class
