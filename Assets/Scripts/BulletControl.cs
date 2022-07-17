using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{

    public float speed = 10f;
    public float lifetime = 5f;
    public bool enemyBullet= false;
    public float bulletRadius = 0.5f;
    public LayerMask playerLayer;

    public GameObject hitEffect;

    private void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        
        //transform.position += transform.forward * Time.deltaTime * speed;

        lifetime -= Time.deltaTime;

        if(lifetime <= 0)

        {

            Destroy(this.gameObject);
        }

        

    }

    private void OnTriggerEnter(Collider other)
    {
        //Hit to enemy
        if (other.CompareTag("Enemy"))
        {
            GameObject drone = other.transform.gameObject;
            if(drone!=null&&drone.GetComponent<Drone>()!=null)drone.GetComponent<Drone>().healt -= 50f;

        }


        //Enemy Bullet
        if (enemyBullet && other.CompareTag("Player"))
        {
         other.GetComponent<PlayerManeger>().Death();
        }
        //Hit
        Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(gameObject);



    }


}
