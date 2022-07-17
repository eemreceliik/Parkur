using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public GameObject hand;

    //Look
    public LayerMask obstacleLayer;
    public Vector3 offset;

    RaycastHit hit;

    //Fire

    public GameObject bullet;
    public Transform firePoint;
    private float cooldown;

    public AudioClip gunShot;

    private void Update()
    {
        //Look

        Debug.DrawRay(firePoint.transform.position, firePoint.transform.TransformDirection(Vector3.forward) * 30, Color.green);

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, obstacleLayer))
        {
            hand.transform.LookAt(hit.point);
            hand.transform.rotation *= Quaternion.Euler(offset);

        }


        //Cooldown
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;

        }

        //Shot
        if (Input.GetMouseButtonDown(0) && cooldown <= 0)
        {
            //Create Bullet
            Instantiate(bullet, firePoint.position, firePoint.transform.rotation);
            
            //Reset Cooldown
            cooldown = 0.25f;

            //Sound
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(gunShot,0.5f);

            //Animation
            GetComponent<Animator>().SetTrigger("ShotTrigger");
        
        
        }


    }
}
