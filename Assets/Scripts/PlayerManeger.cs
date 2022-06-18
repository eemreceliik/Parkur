using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManeger : MonoBehaviour
{

    
    private bool playerAlive = true;
    public GameObject deathEffect;
    
    
    
    public void Death() 
    {
    
        if(playerAlive)
        {
            playerAlive = false;

            //Particle effect
            Instantiate(deathEffect, transform.position, Quaternion.identity);


        }    
    }
}
