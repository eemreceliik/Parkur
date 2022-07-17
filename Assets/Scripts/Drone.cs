using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private Transform player;
    public float speed = 1;
    public float followDistance = 10f;
    private float cooldown = 2f;
    public Transform firepoint;


    public GameObject bullet;

    public float healt = 100f;

    public GameObject deathEffect;
    //public AudioClip deathSound;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        FollowPlayer();
        Shot();
        Death();

    }

    private void FollowPlayer()
    {
        //Look to Player
        transform.LookAt(player.position);

        //Move to Player
        if (Vector3.Distance(transform.position, player.position) >= followDistance)
        {
            transform.position += (transform.forward * Time.deltaTime * speed/3);

        }
        else
        {
            transform.RotateAround(player.position, transform.forward, Time.deltaTime * speed);

        }

    }

    private void Shot()
    {

        if(cooldown > 0)
        {

            cooldown -= Time.deltaTime;


        }

        else
        {
            cooldown = 2f;
            //shot
            Instantiate(bullet, firepoint.position, firepoint.transform.rotation);
        }

    }

    private void Death()
    {
        
        if(healt <= 0)
        {
            //Spawn Particle
            Instantiate(deathEffect, transform.position, Quaternion.identity);

            //Play Sound Effect
           // GetComponent<AudioSource>().PlayOneShot(deathSound);

            //Destroy Gameobject
            Destroy(this.gameObject);
        }
    }

}
