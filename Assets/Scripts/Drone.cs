using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public Transform player;
    public float speed = 1;
    public float followDistance = 10f;


    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        //Look to Player
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

        //Move to Player
        if(Vector3.Distance(transform.position, player.position) >= followDistance)
        {
            transform.Translate(transform.forward * Time.deltaTime * speed);

        }
        else
        {
            transform.RotateAround(player.position, transform.forward, Time.deltaTime * speed);

        }

    }

}
