using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManeger : MonoBehaviour
{

    
    private bool playerAlive = true;
    public GameObject deathEffect;
    public GameObject hand;
    public GameObject crosshair;
    public GameObject gameOverMenu;
    
    public void Death() 
    {
    
        if(playerAlive)
        {
            //Set Boolean
            playerAlive = false;

            //Particle effect
            Instantiate(deathEffect, transform.position, Quaternion.identity);

            //Disable Player
            GetComponent<PlayerMovement>().enabled = false;
            hand.SetActive(false);
            crosshair.SetActive(false);
            
            //Cursor Active
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            //Enable Game Over Menu
            gameOverMenu.SetActive(true);


        }    
    }
}
